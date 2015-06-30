using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using OnlineCookbook.Model;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Service;
using WebApplication.Controllers;
using System.Collections.Generic;
using System.Web;
using System.Web.Http.Hosting;
using System.Net;
using System.Web.Http;
using System.Net.Http;


namespace Controller.Test
{
    [TestClass]
    public class AlergenControllerTest
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
                    Id = "992a69de-f418-4f7d-a0d6-ee533736d6f8"
                },

                new AlergenPOCO()
                {
                    AlergenName = "laktoza",
                    Abrv = "lak",
                    Id = Guid.NewGuid().ToString()
                },

                new AlergenPOCO()
                {
                    AlergenName = "orah",
                    Abrv = "or",
                    Id = Guid.NewGuid().ToString()
                }
            };
        }


        [TestMethod]
        public void GetControllerById()
        {
            //Arrange
            var mock = new Mock<IAlergenService>();
            mock.Setup(x => x.GetAsync("992a69de-f418-4f7d-a0d6-ee533736d6f8"))
                .ReturnsAsync(Alergens[0]);

            var service = mock.Object;
            var controller = new AlergenController(service);
            controller.Request = new HttpRequestMessage()
            {
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            };

            //Act
            var response = controller.Get("992a69de-f418-4f7d-a0d6-ee533736d6f8");

            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode); //status kod od taska kada je bilo bez Result
            //na ovaj nacin prvo mi daj rezultati i onda sam od rezultata zatrazila status kod
            Assert.IsNotNull(response.Result);
            
        } 
        
    }
}
