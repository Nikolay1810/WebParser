using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parsing.Models.Url
{
    [Table("UrlShop")]
    public class UrlShop
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        public int ProductTagsId { get; set; }
    }
}