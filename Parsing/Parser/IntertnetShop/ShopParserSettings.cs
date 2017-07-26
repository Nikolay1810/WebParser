using Parser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.IntertnetShop
{
    class ShopParserSettings : IParserSettings
    {
        public int EndPoint { get; set; }

        public string Prefix { get; set; }

        public int StartPoint { get; set; }

        public string Url { get; set; }
    }
}
