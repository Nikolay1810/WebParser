using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreParser.InternetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreParser.Structure;

namespace CoreParser.InternetShop.Tests
{
    [TestClass()]
    public class ParserWorkerTests
    {
        [TestMethod()]
        public void StartTest()
        {
            IParser<Product> prodParser = new ProductParser();
            IParserWorker<Product> parser = new ParserWorker<Product>(prodParser);
            parser.Settings = new ProductParserSetting("http://allo.ua/ru/products/mobile/proizvoditel-xiaomi", "li.item",
                "a.product-name", "a.product-image", "span.price-sym-6", "div.attr-content");

            var requestProduct = parser.Start();

            if(requestProduct.Result.Count == 0)
            {
                Assert.IsNull(requestProduct);
            }
        }
    }
}