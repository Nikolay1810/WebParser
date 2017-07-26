using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parsing.Models.TagsProduct
{
    public class ProductTags
    {
        [Key]
        public int Id { get; set; }

        public string TagCatalog { get; set; }

        public string TagName { get; set; }

        public string TagParentImage { get; set; }

        public string TagPrice { get; set; }

        public string TagDescription { get; set; }
    }
}