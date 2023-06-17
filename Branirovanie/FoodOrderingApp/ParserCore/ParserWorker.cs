using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Parser;

namespace FoodOrderingApp.ParserCore
{
    public class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        bool isActive;
        HtmlLoader loader;

        #region Properties

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object, List<CBSection>> OnSectionsLoaded;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            isActive = true;
            ParseToGetSections();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void ParseToGetSections()
        {
            var context = BrowsingContext.New(Configuration.Default);

            string source = await loader.GetSourceSections();
            var document = await context.OpenAsync(req => req.Content(source));
            var sections = parser.ParseSections(document);
            parserSettings.SectionLinks = sections.Keys.ToList();
            var list = new List<CBSection>();

            foreach (var section in sections)
            {
                list.Add(new CBSection(section.Key, section.Value) { GroupName = "rbSection" });
            }

            OnSectionsLoaded?.Invoke(this, list);

            isActive = false;
        }

        public async void ParseSection(string section)
        {
            var source = await loader.GetSourceBySection(section);
            var context = BrowsingContext.New(Configuration.Default);

            var document = await context.OpenAsync(req => req.Content(source));

            var result = parser.ParseFood(document);

            OnNewData?.Invoke(this, result);
        }
    }
}
