using CoreParser.InternetShop;
using Parsing.Models.History;
using Parsing.Models.TagsProduct;
using Parsing.Models.Url;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Parsing.Infrastructure
{
    public class ShopContext:DbContext
    {
        public ShopContext() : base("name=ShopContext") { }

        DbSet<Product> Product { get; set; }
        DbSet<ProductTags> ProductTags { get; set; }
        DbSet<UrlShop> UrlShop { get; set; }
        DbSet<HistoryRefreshPrice> HistoryRefreshPrice { get; set; }

    }
}