using CoreParser.InternetShop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Parsing.Infrastructure;
using Parsing.Infrastructure.Repository;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing.Infrastructure.Tests
{
    [TestClass()]
    public class WorkWithContextTests
    {
        private readonly IRepository<Product> _repository;

        public WorkWithContextTests()
        {
            var fixture = new Fixture();
            var list = fixture.CreateMany<Product>(300).ToList();
            var repo = new Mock<IRepository<Product>>();
            repo.Setup(r => r.Get()).Returns(list);
            repo.Setup(r => r.FindById(43)).Returns(() => new Product()
            {
                Id = 43,
                Name = "Test",
                ImageUrl = "Test",
                Price = "Test",
                Descriptions = "Test"
            });


            _repository = repo.Object;
        }

        

        [TestMethod()]
        public void GetTest()
        {
            Assert.AreEqual(_repository.Get().Count(), 300);
        }

        [TestMethod()]
        public void FindByIdTest()
        {
            var prod = _repository.FindById(43);
            Assert.IsNotNull(prod);
        }

        
    }
}