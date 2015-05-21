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
        public async Task<HttpResponseMessage> Get(HttpRequestMessage request, string sortOrder = "", string sortDirection = "", int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                  var result = await Service.GetAsync(new AlergenFilter(sortOrder, sortDirection, pageNumber, pageSize));
                  if (result != null)
                  {
                      return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<AlergenModel>>(result));                 
                  }
                  else
                  {
                      return request.CreateResponse(HttpStatusCode.NotFound);
                  }
              }
             catch (Exception e)
             {
                  throw e;
             }
          }

 
       /* public async Task<HttpResponseMessage> Get(HttpRequestMessage request, AlergenController filter)
        {
            try
            {
                var alergens = await Service.GetAsync(filter);
                var alergensResult = Mapper.Map<List<AlergenModel>>(alergens);
                return request.CreateResponse(HttpStatusCode.OK, alergensResult); 
            }
            catch (Exception e)
            {
                throw e;
            }
        }*/


        // GET: api/Alergen
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<HttpResponseMessage> Get(HttpRequestMessage request, Guid id)
        {
            var result = await Service.GetAsync(id);
            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<AlergenModel>>(result));
            }
            else 
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }


        // POST: api/Alergen
        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request, AlergenModel alergenModel)
        {
            alergenModel.Id = Guid.NewGuid();
            try
            {
                var result = await Service.InsertAsync(Mapper.Map<AlergenPOCO>(alergenModel)); 
                if (result == 1)
                {
                    return request.CreateResponse(HttpStatusCode.OK, alergenModel);
                }
                else 
                {
                    return request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                 throw e;
            }
        }


        // PUT: api/Alergen
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<HttpResponseMessage> Put(HttpRequestMessage request, Guid id, AlergenModel alergenModel)
        {
            try
            {

                if (id == alergenModel.Id)
                {
                    var result = await Service.UpdateAsync(Mapper.Map<AlergenPOCO>(alergenModel));
                    if (result == 1)
                    {
                        return request.CreateResponse(HttpStatusCode.OK, alergenModel);
                    }
                    else
                    { 
                        return request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
                return request.CreateResponse(HttpStatusCode.BadRequest, "ID's don't match!");
            }
            catch (Exception e)
            {
                throw e;
            } 
        }


        // DELETE: api/Alergen
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
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
                throw e;
            }
        }

        public class AlergenModel
        {
            public System.Guid Id { get; set; }
            public string AlergenName { get; set; }
            public System.Guid Abrv { get; set; }
        }

    }
}
