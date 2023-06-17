using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.ParserCore.Presto
{
    class PrestoSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://arh.chibbis.ru/presto/menu";

        public string Prefix { get; set; } = "{Section}";

        public List<string> SectionLinks { get; set; } = new List<string>();
    }
}
