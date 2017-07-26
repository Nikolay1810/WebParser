using Parsing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Prod = CoreParser.InternetShop;

namespace Parsing.Controllers.Product
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public string GetProductById(string args)
        {
            var jsSerializer = new JavaScriptSerializer();
            try
            {
                var argsAsObject = jsSerializer.Deserialize<Prod.Product>(args);
                if(argsAsObject != null)
                {
                    WorkWithContext<Prod.Product> workProd = new WorkWithContext<Prod.Product>();
                    var product = workProd.FindById(argsAsObject.Id);
                    if(product != null)
                    {
                        return jsSerializer.Serialize(product);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return "null";
        }
    }
}