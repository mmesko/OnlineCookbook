using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Service;

namespace OnlineCookbook.WebApi.Controllers
{
    [RoutePrefix("api/Alergen")]

    public class AlergenController : ApiController
    {
        

        private IAlergenService Service { get; set; }

        public AlergenController(IAlergenService service)
        {
            Service = service;
        }


        // GET: api/Alergen
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get(string sortOrder = "alergenId", int pageNumber = 1, int pageSize = 30)
        {
            try
            {
                var alergens = await Service.GetAsync(sortOrder, pageNumber, pageSize);
                var alergensResult = Mapper.Map<List<AlergenModel>>(alergens);
                return Ok(alergensResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        // GET: api/TestingArea/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var ialergen = await Service.GetAsync(id);
            if (ialergen != null)
            {
                var alergen= Mapper.Map<AlergenModel>(ialergen);//poslati korisniku stvari koje mu trebaju,ne želim mu slati sve
                return Ok(alergen);
            }
            else return NotFound();
        }



        // POST: api/TestingArea
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(AlergenModel alergenModel)
        {
           
            try
            {
                var result = await Service.InsertAsync(Mapper.Map<AlergenPOCO>(alergenModel)); //
                if (result == 1) return Ok(alergenModel);
                else return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }



        // PUT: api/Alergen/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int id, AlergenModel alergenModel)
        {
            try
            {
                if (id == alergenModel.Id)
                {
                    var result = await Service.UpdateAsync(Mapper.Map<AlergenPOCO>(alergenModel));
                    if (result == 1) return Ok(alergenModel);
                    else return NotFound();
                }
                return BadRequest("IDs do not match.");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }



        // DELETE: api/Alergen/
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var result = await Service.DeleteAsync(id);
                if (result == 1) return Ok("Deleted");
                else return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        public class AlergenModel
        {
            public int Id { get; set; }
            public string AlergenName { get; set; }  
        }




    }
}
