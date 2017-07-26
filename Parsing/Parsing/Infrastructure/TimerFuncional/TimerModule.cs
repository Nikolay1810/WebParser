using CoreParser.InternetShop;
using CoreParser.Structure;
using Parsing.Models.History;
using Parsing.Models.TagsProduct;
using Parsing.Models.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Parsing.Infrastructure.TimerFuncional
{
    public class TimerModule : IHttpModule
    {
        static Timer timer;
        long interval = 30000;
        static object synclock = new object();
        public void Init(HttpApplication context)
        {
            timer = new Timer(new TimerCallback(RefreshProduct), null, 0, interval);
        }
        public void Dispose()
        {
        }

        private async void RefreshProduct(object obj)
        {
            try
            {
                WorkWithContext<Product> workProd = new WorkWithContext<Product>();
                var prodList = workProd.Get();

                var prodParsList = new List<Product>();
                var historyPrice = new WorkWithContext<HistoryRefreshPrice>();

                WorkWithContext<UrlShop> workUrlShop = new WorkWithContext<UrlShop>();
                var urlShopList = workUrlShop.Get();

                WorkWithContext<ProductTags> workProdTags = new WorkWithContext<ProductTags>();
                var tagsList = workProdTags.Get();

                foreach (var item in urlShopList)
                {
                    IParser<Product> prodParser = new ProductParser();
                    IParserWorker<Product> parser = new ParserWorker<Product>(prodParser);

                    var tag = tagsList.FirstOrDefault(u => u.Id == item.ProductTagsId);
                    parser.Settings = new ProductParserSetting(item.Url, tag.TagCatalog,
                        tag.TagName, tag.TagParentImage, tag.TagPrice, tag.TagDescription);

                    var requestProduct = await parser.Start();

                    if (requestProduct.Count != 0)
                    {
                        prodParsList.AddRange(requestProduct);
                    }
                }

                foreach (var prodPars in prodParsList)
                {
                    var product = prodList.FirstOrDefault(u => u.ImageUrl.Contains(prodPars.ImageUrl));
                    if (product != null)
                    {
                        if (product.Price != prodPars.Price)
                        {
                            product.Price = prodPars.Price;
                            workProd.UpdateEntity(product);
                        }
                        if (prodPars.Price != "Не удалось распарсить")
                        {
                            historyPrice.AddEntity(new HistoryRefreshPrice()
                            {
                                RefreshDate = DateTime.Now,
                                Price = prodPars.Price,
                                ProductId = product.Id
                            });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}