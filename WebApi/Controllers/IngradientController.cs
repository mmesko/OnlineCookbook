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
using OnlineCookbook.Filters.ModelFilter;

namespace OnlineCookbook.WebApi.Controllers
{
    [RoutePrefix("api/Ingradient")]

    public class IngradientController : ApiController
    {
        private IIngradientService Service { get; set; }

        public IngradientController(IIngradientService service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get(IngradientFilter filter)
        {
            try
            {
                var ingradients = await Service.GetAsync(filter);
                var ingradientsResult = Mapper.Map<List<IngradientModel>>(ingradients);
                return Ok(ingradientsResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var iIngradient = await Service.GetAsync(id);
            if (iIngradient != null)
            {
                var ingradient = Mapper.Map<IngradientModel>(iIngradient);//poslati korisniku stvari koje mu trebaju,ne želim mu slati sve
                return Ok(ingradient);
            }
            else return NotFound();
        }


        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(IngradientModel ingradientModel)
        {
            ingradientModel.Id = Guid.NewGuid();
            try
            {
                var result = await Service.InsertAsync(Mapper.Map<IngradientPOCO>(ingradientModel)); //
                if (result == 1) return Ok(ingradientModel);
                else return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> Put(Guid id, IngradientModel ingradientModel)
        {
            try
            {    
                if (id == ingradientModel.Id)
                {    
                    var result = await Service.UpdateAsync(Mapper.Map<IngradientPOCO>(ingradientModel));
                    if (result == 1) return Ok(ingradientModel);
                    else return NotFound();
                }
                return BadRequest("IDs do not match.");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
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


        public class IngradientModel
        {
            public System.Guid Id { get; set; }
            public string IngradientName { get; set; }
            public System.Guid Abrv { get; set; }
        }

    }
}
