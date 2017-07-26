using CoreParser.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreParser.InternetShop
{
    public class ProductParserSetting : IParserSettings
    {
        public ProductParserSetting(string url, string tagCatalog, string tagName, string tagParentImage, string tagPrice, string tagDescription)
        {
            this.Url = url;
            this.TagCatalog = tagCatalog;
            this.TagName = tagName;
            this.TagParentImage = tagParentImage;
            this.TagPrice = tagPrice;
            this.TagDescription = tagDescription;
            Prefix = "page=CurrentId";
            StartPoint = 1;
            EndPoint = 3;
        }

        public string Url { get; set; }

        public string TagCatalog { get; set; }

        public string TagName { get; set; }

        public string TagParentImage { get; set; }

        public string TagPrice { get; set; }

        public string TagDescription { get; set; }

        public string Prefix { get; set; }

        public int StartPoint { get; set; }

        public int EndPoint { get; set; }

    }
}
