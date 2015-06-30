using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OnlineCookbook.Model;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;

namespace WebApplication.Controllers
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
        public async Task<HttpResponseMessage> Get(string sortOrder = "", string sortDirection = "", int pageNumber = 0, int pageSize = 0) //kalsa uestionRequest s ovim praznim parametrima?
        {
            try
            {
                var result = await Service.GetAsync(new IngradientFilter(sortOrder, sortDirection, pageNumber, pageSize));
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<IngradientModel>>(result));
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

        // GET: api/Ingradient/5
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Get(string id)
        {
            var result = await Service.GetAsync(id);
            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<IngradientModel>>(result));
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
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<IngradientModel>>(result));
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


        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Post(IngradientModel ingradientModel)
        {
            ingradientModel.Id = Guid.NewGuid().ToString();

            try
            {
                var result = await Service.InsertAsync(Mapper.Map<IngradientPOCO>(ingradientModel));
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ingradientModel);
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


        // PUT: api/Ingradient/5
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Put(string id, IngradientModel ingradientModel)
        {
            try
            {

                if (id == ingradientModel.Id)
                {
                    var result = await Service.UpdateAsync(Mapper.Map<IngradientPOCO>(ingradientModel));
                    if (result == 1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, ingradientModel);
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

        // DELETE: api/Ingradient/5
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

        public class IngradientModel
        {
            public string Id { get; set; }
            public string IngradientName { get; set; }
            public string Abrv { get; set; }
        }

    }
}
