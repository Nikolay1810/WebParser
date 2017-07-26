using CoreParser.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace CoreParser.InternetShop
{
    public class ProductParser : IParser<Product>
    {
        public List<Product> Parse(IHtmlDocument document, IParserSettings settings)
        {
            Encoding utf8 = Encoding.UTF8;
            Encoding window = Encoding.GetEncoding(1251);
            byte[] utf8Bytes;
            byte[] endConvertBytes;

            string tag = settings.TagCatalog.Split('.').FirstOrDefault();
            string classTag = settings.TagCatalog.Split('.').LastOrDefault();

            var productList = new List<Product>();
            try
            {
                
                var products = document.QuerySelectorAll(tag).Where(u => u.ClassName != null && u.ClassName.Contains(classTag));
                foreach (var itemProd in products)
                {
                    var product = new Product();

                    var nameTag = itemProd.QuerySelector(settings.TagName);
                    string name = nameTag?.TextContent;
                    if (name != null)
                    {
                        utf8Bytes = utf8.GetBytes(name);
                        endConvertBytes = Encoding.Convert(utf8, window, utf8Bytes);
                        product.Name = utf8.GetString(endConvertBytes).Trim();
                    }

                    var imageUrlParent = itemProd.QuerySelector(settings.TagParentImage);
                    string imageUrl = imageUrlParent?.Children.FirstOrDefault(u => u.TagName.Contains("IMG"))?.Attributes.FirstOrDefault(u => u.LocalName == "data_src" )?.Value;
                    if (imageUrl == null)
                    {
                        imageUrl = imageUrlParent?.Children.FirstOrDefault(u => u.TagName.Contains("IMG"))?.Attributes.FirstOrDefault(u => u.LocalName == "data-original")?.Value;
                    }
                    if (imageUrl != null)
                    {
                        utf8Bytes = utf8.GetBytes(imageUrl);
                        endConvertBytes = Encoding.Convert(utf8, window, utf8Bytes);
                        product.ImageUrl = utf8.GetString(endConvertBytes).Trim();
                    }
                    var priceParent = itemProd.QuerySelector(settings.TagPrice);
                    string price = priceParent?.TextContent;
                    if (price != null)
                    {
                        utf8Bytes = utf8.GetBytes(price);
                        endConvertBytes = Encoding.Convert(utf8, window, utf8Bytes);
                        product.Price = utf8.GetString(endConvertBytes).Trim(new char[] {'?'});
                    }

                    var desctiptionTag = itemProd.QuerySelector(settings.TagDescription);
                    string description = desctiptionTag?.TextContent;
                    if (description != null)
                    {
                        utf8Bytes = utf8.GetBytes(description);
                        endConvertBytes = Encoding.Convert(utf8, window, utf8Bytes);
                        product.Descriptions = utf8.GetString(endConvertBytes).Trim();
                    }
                    productList.Add(product);
                }
            }
            catch(Exception ex)
            {

            }
            return productList;
        }
    }
}
