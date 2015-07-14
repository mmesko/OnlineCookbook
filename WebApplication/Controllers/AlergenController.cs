using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Service;
using System.Data.Entity.Validation;
using OnlineCookbook.Common.Filters;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/Alergen")] 
    public class AlergenController : ApiController
    {
        private IAlergenService Service { get; set; }

        public AlergenController(IAlergenService service)
        {
            Service = service;
        }

        [Route("{pageNumber}/{pageSize}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                var result = await Service.GetAsync(new AlergenFilter(pageNumber, pageSize));
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<AlergenModel>>(result));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        // GET: api/Alergen/5
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Get(string id)
        {
            var result = await Service.GetAsync(id);
            
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<AlergenModel>>(result));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }


        // GET: api/Alergen/getByName/
        [HttpGet()]
        [Route("getByName/{name}")]
        public async Task<HttpResponseMessage> GetByName(string name)
        {
            try
            {
                var result = await Service.GetNameAsync(name);

                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<AlergenModel>>(result));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        // POST: api/Alergen
        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Post(AlergenModel alergenModel)
        {
            alergenModel.Id = Guid.NewGuid().ToString();

            try
            {
                var result = await Service.InsertAsync(Mapper.Map<AlergenPOCO>(alergenModel));
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, alergenModel);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }
        // PUT: api/Alergen/5
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Put(string id, AlergenModel alergenModel)
        {
            try
            {

                if (id == alergenModel.Id)
                {
                    var result = await Service.UpdateAsync(Mapper.Map<AlergenPOCO>(alergenModel));
                    if (result == 1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, alergenModel);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID's don't match!");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        // DELETE: api/Alergen/5
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Delete(string id)
        {
            try
            {
                var result = await Service.DeleteAsync(id);
                if (result == 1)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }


        public class AlergenModel
        {
            public string Id { get; set; }
            public string AlergenName { get; set; }
            public string Abrv { get; set; }
        }
    }
}
