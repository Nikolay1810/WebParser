using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parsing.Models.TagsProduct
{
    public class TagProductRequest
    {
        public string Url { get; set; }
        public string TagCatalog { get; set; }

        public string TagName { get; set; }

        public string TagParentImage { get; set; }

        public string TagPrice { get; set; }

        public string TagDescription { get; set; }
    }
}