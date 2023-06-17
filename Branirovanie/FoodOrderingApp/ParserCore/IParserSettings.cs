using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.ParserCore
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }

        string Prefix { get; set; }

        List<string> SectionLinks { get; set; }
    }
}
