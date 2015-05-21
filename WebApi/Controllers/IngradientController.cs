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

        // GET: api/Ingradient
        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get(HttpRequestMessage request, string sortOrder = "", string sortDirection = "", int pageNumber = 0, int pageSize = 0) //kalsa uestionRequest s ovim praznim parametrima?
        {
            try
            {
                var result = await Service.GetAsync(new IngradientFilter(sortOrder, sortDirection, pageNumber, pageSize));
                if (result != null)
                {
                    return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<IngradientModel>>(result));
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

        // GET: api/Ingradient
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<HttpResponseMessage> Get(HttpRequestMessage request, Guid id)
        {
            var result = await Service.GetAsync(id);
            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<IngradientModel>>(result));
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }


        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request, IngradientModel ingradientModel)
        {
            ingradientModel.Id = Guid.NewGuid();
            try
            {
                var result = await Service.InsertAsync(Mapper.Map<IngradientPOCO>(ingradientModel));
                if (result == 1)
                {
                    return request.CreateResponse(HttpStatusCode.OK, ingradientModel);
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
        public async Task<HttpResponseMessage> Put(HttpRequestMessage request, Guid id, IngradientModel ingradientModel)
        {
            try
            {

                if (id == ingradientModel.Id)
                {
                    var result = await Service.UpdateAsync(Mapper.Map<IngradientPOCO>(ingradientModel));
                    if (result == 1)
                    {
                        return request.CreateResponse(HttpStatusCode.OK, ingradientModel);
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

        // DELETE: api/Ingradient
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



        public class IngradientModel
        {
            public System.Guid Id { get; set; }
            public string IngradientName { get; set; }
            public System.Guid Abrv { get; set; }
        }

    }
}
