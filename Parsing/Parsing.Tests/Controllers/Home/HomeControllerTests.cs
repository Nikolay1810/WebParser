using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parsing.Controllers.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing.Controllers.Home.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void GetDataTest()
        {
            var controller = new HomeController();
            var result = controller.GetData();
            Assert.IsNotNull(result);
        }
    }
}