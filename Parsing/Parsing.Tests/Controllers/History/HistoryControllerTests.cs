using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Parsing.Controllers.History;
using Parsing.Infrastructure.Repository;
using Parsing.Models.History;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Parsing.Controllers.History.Tests
{
    [TestClass()]
    public class HistoryControllerTests
    {

        private readonly IRepository<HistoryRefreshPrice> _repository;

        public HistoryControllerTests()
        {
            var fixture = new Fixture();
            var list = fixture.CreateMany<HistoryRefreshPrice>(300).ToList();
            var repo = new Mock<IRepository<HistoryRefreshPrice>>();
            repo.Setup(r => r.Get()).Returns(list);
            
            _repository = repo.Object;
        }


        [TestMethod()]
        public void HistoryTest()
        {
            var historyController = new HistoryController();
            var result = historyController.HistoryTest(_repository);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(((ViewResult)result).Model, typeof(List<HistoryRefreshPrice>));

            var count = ((List<HistoryRefreshPrice>)((ViewResult)result).Model).ToList().Count();

            Assert.AreEqual(300, count);
        }
    }
}