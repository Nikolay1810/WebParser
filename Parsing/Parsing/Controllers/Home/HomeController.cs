using Prod = CoreParser.InternetShop;
using CoreParser.Structure;
using HtmlAgilityPack;
using Parsing.Infrastructure;
using Parsing.Models.TagsProduct;
using Parsing.Models.Url;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Parsing.Models.History;

namespace Parsing.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
        [HttpPost]
        public string GetData()
        {
            try
            {
                var jsSerializer = new JavaScriptSerializer();
                WorkWithContext<Prod.Product> workProd = new WorkWithContext<CoreParser.InternetShop.Product>();
                var prodList = workProd.Get();
                return jsSerializer.Serialize(prodList);
            }
            catch(Exception ex)
            {

            }
            return "false";
        }

        [HttpPost]
        public string GetParseData(string args)
        {
            var jsSerializer = new JavaScriptSerializer();
            try
            {
                var argsAsObject = jsSerializer.Deserialize<TagProductRequest>(args);
                if (argsAsObject != null)
                {
                    WorkWithContext<UrlShop> workUrlShop = new WorkWithContext<UrlShop>();
                    Func<UrlShop, bool> predicate = (u => u.Url.Contains(argsAsObject.Url));
                    var urlShop = workUrlShop.Get(predicate);
                    if(urlShop != null)
                    {
                        return "Вы уже вводили такую ссылку";
                    }

                    IParser<Prod.Product> prodParser = new Prod.ProductParser();
                    IParserWorker<Prod.Product> parser = new Prod.ParserWorker<Prod.Product>(prodParser);
                    parser.Settings = new Prod.ProductParserSetting(argsAsObject.Url, argsAsObject.TagCatalog,
                        argsAsObject.TagName, argsAsObject.TagParentImage, argsAsObject.TagPrice, argsAsObject.TagDescription);

                    var requestProduct = parser.Start();
                    var productList = new List<Prod.Product>();
                    
                    if (requestProduct.Result.Count != 0)
                    {
                        ProductTags prodTags = new ProductTags()
                        {
                            TagCatalog = argsAsObject.TagCatalog,
                            TagName = argsAsObject.TagName,
                            TagParentImage = argsAsObject.TagParentImage,
                            TagPrice = argsAsObject.TagPrice,
                            TagDescription = argsAsObject.TagDescription
                        };

                        WorkWithContext<ProductTags> workTags = new WorkWithContext<ProductTags>();
                        var addedTags = workTags.AddEntity(prodTags);

                        int productTagsId = 0;

                        if (addedTags != null) 
                        {
                            productTagsId = addedTags.Id;
                        }

                        urlShop = new UrlShop()
                        {
                            ProductTagsId = productTagsId,
                            Url = argsAsObject.Url
                        };

                        workUrlShop.AddEntity(urlShop);

                        productList.AddRange(requestProduct.Result.Select(u => new Prod.Product()
                        {
                            Name = u.Name != null ? u.Name : "Не удалось распарсить",
                            ImageUrl = u.ImageUrl != null ? u.ImageUrl : "Не удалось распарсить",
                            Price = u.Price != null ? u.Price : "Не удалось распарсить",
                            Descriptions = u.Descriptions!=null? u.Descriptions:"Не удалось распарсить",
                        }));

                        var workProduct = new WorkWithContext<Prod.Product>();

                        if (workProduct.AddEntities(productList))
                        {
                            return "true";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            return "false";
        }

    }
}