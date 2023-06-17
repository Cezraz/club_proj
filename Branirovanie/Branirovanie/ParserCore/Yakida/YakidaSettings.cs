﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branirovanie.ParserCore.Presto
{
    class YakidaSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://arh.chibbis.ru/yakida-figaro/menu";

        public string Prefix { get; set; } = "{Section}";

        public List<string> SectionLinks { get; set; } = new List<string>();
    }
}
