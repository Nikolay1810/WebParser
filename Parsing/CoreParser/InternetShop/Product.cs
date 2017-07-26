using CoreParser.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreParser.InternetShop
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Price { get; set; }

        public string Descriptions { get; set; }
    }
}
