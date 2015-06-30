using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using OnlineCookbook.Common.Filters;
using OnlineCookbook.Model;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service;
using OnlineCookbook.Service.Common;
using System.Threading.Tasks;


namespace Service.Test
{
    [TestClass]
    public class AlergenServiceTest
    {
        private List<IAlergen> Alergens;


        [TestInitialize]
        public void Setup()
        {
            Alergens = new List<IAlergen>()
            {
                new AlergenPOCO()
                {
                    AlergenName = "gluten",
                    Abrv = "glu",
                    Id = "maja123"
                },

                new AlergenPOCO()
                {
                    AlergenName = "laktoza",
                    Abrv = "lak",
                    Id = "maja010203"
                },

                new AlergenPOCO()
                {
                    AlergenName = "orah",
                    Abrv = "or",
                    Id = "0903mm"
                }
            };
        }
       


        [TestMethod]
        public void GetAllTest()
        {
            var filter = new AlergenFilter("Abrv", 1, 3);

            var mock = new Mock<IAlergenRepository>();
            mock.Setup(x => x.GetAsync(filter))
                .ReturnsAsync(Alergens);

            var repository = mock.Object;
            var service = new AlergenService(repository);
            var result = service.GetAsync(filter);

            Assert.IsNotNull(result.Result);
            Assert.AreEqual((result.Result)[0].Abrv, "glu");
        }


        [TestMethod]
        public void GetByIdTest()
        {
            var mock = new Mock<IAlergenRepository>();
            mock.Setup(x => x.GetAsync("maja123"))
                .ReturnsAsync(Alergens[0]);

            var repository = mock.Object;
            var service = new AlergenService(repository);
            var result = service.GetAsync("maja123");
            

            Assert.IsNotNull(result.Result);
            Assert.AreEqual((result.Result).Abrv, "glu");
        }

    }


    

}