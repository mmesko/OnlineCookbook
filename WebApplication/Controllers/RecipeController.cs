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
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("api/Recipe")]
    public class RecipeController : ApiController
    {

        private IRecipeService Service { get; set; }
       
        public RecipeController(IRecipeService service)
        {
            Service = service;
            
        }



        // GET: api/Recipe
        [Route("{pageNumber}/{pageSize}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                var result = await Service.GetAsync( new RecipeFilter(pageNumber, pageSize));
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<List<RecipeModel>>(result));
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

        // GET: api/Recipe/5
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Get(string id)
        {
            try
            {
                var result = await Service.GetAsync(id);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<RecipeModel>(result));
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

        // GET: api/Recipe/GetByName/5
        [HttpGet()]
        [Route("getByName/{name}")]
        public async Task<HttpResponseMessage> GetByName(string name)
        {
            try
            {
                var result = await Service.GetByNameAsync(name);

                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<RecipeModel>>(result));
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

        [HttpGet]
        [Route("{categoryId}/{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> GetByCategory(string id, int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                var result = await Service.GetByCategoryAsync(id, new RecipeFilter(pageNumber, pageSize));
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<List<RecipeModel>>(result));
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

        // POST: api/Recipe
        [HttpPost]
        [Route("")]       
        public async Task<HttpResponseMessage> Post(RecipeModel entity)
        {
            entity.Id = Guid.NewGuid().ToString();

            try
            {
                var result = await Service.InsertAsync(Mapper.Map<RecipePOCO>(entity));
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

        // PUT: api/Alergen/5
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Put(string id, RecipeModel model)
        {
            try
            {
                

                if (id == model.Id)
                {
                    var result = await Service.UpdateAsync(Mapper.Map<RecipePOCO>(model));
                    if (result == 1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, model);
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

  

        // DELETE: api/Recipe/5
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Delete(string id)
        {
            try
            {
                if (await Service.DeleteAsync(id) == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted.");
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

       

    }
}
