using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Service.Common;
using System.Threading.Tasks;
using OnlineCookbook.Model;
using AutoMapper;
using OnlineCookbook.Common.Filters;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/Favourite")] 
    public class FavouriteController : ApiController
    {

        private IFavouriteService Service { get; set; }

        public FavouriteController(IFavouriteService service)
        {
            Service = service;
        }
        // GET: api/Favourite
        [HttpGet]
        [Route("{recipeId}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(string id, int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                var result = await Service.GetAsync(id, new FavouriteFilter(pageNumber, pageSize));
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<FavouriteModel>>(result));
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

        // GET: api/Favourite/5
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Get(string id)
        {
            var result = await Service.GetAsync(id);

            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<FavouriteModel>>(result));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // GET: api/Favourite/GetByName/5
        [HttpGet()]
        [Route("getByName/{name}")]
        public async Task<HttpResponseMessage> GetByName(string name)
        {
            try
            {
                var result = await Service.GetNameAsync(name);

                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<FavouriteModel>(result));
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

        // POST: api/Favourite
        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Post(FavouriteModel entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            try
            {
                var result = await Service.InsertAsync(Mapper.Map<FavouritePOCO>(entity));
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
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

        // PUT: api/Favourite/5
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Put(string id, FavouriteModel entity)
        {
            try
            {

                if (id == entity.Id)
                {
                    var result = await Service.UpdateAsync(Mapper.Map<FavouritePOCO>(entity));
                    if (result == 1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
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

        // DELETE: api/Favourite/5
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

       
    }
}
