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
    [RoutePrefix("api/Recipe")]
    public class RecipeController : ApiController
    {

        private IRecipeService Service { get; set; }
        private IRecipePictureService PictureService { get; set; }

        public RecipeController(IRecipeService service, IRecipePictureService pictureService)
        {
            Service = service;
            PictureService = pictureService;
        }



        // GET: api/Recipe
        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get(string sortOrder = "", string sortDirection = "",
            int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                var result = await Service.GetAsync(new RecipeFilter(sortOrder, sortDirection, pageNumber, pageSize));
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
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<RecipeModel>(result));
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
        [Route("Category/{id:guid}")]
        public async Task<HttpResponseMessage> GetByCategory(string id)
        {
            try
            {
                var result = await Service.GetByCategoryAsync(id, new RecipeFilter("CategoryId", 0, 0));
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

        // PUT: api/Recipe/5
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Put(string id, RecipeModel entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "IDs do not match.");
                }

                var result = await Service.UpdateAsync(Mapper.Map<IRecipe>(entity));

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


        // PUT: api/Recipe/Picture/5
        [HttpPut]
        [Route("Picture/{id:guid}")]
        public async Task<HttpResponseMessage> Put(string id, RecipePictureModel entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        "IDs do not match.");
                }

                var result = await PictureService.UpdateAsync(Mapper.Map<IRecipePicture>(entity));

                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Updated.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        "PUT unsuccessful.");
                }
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

        public class RecipeModel
        {

            public string Id { get; set; }
            public string CategoryId { get; set; }
            public string UserId { get; set; }
            public string RecipeTitle { get; set; }
            public string RecipeDescription { get; set; }
            public bool RecipeComplexity { get; set; }
            public string RecipeText { get; set; }
            public string Abrv { get; set; } //dodati u bazu picture Url?
        
        }

        public class RecipePictureModel
        {
            public string Id { get; set; }
            public string RecipeId { get; set; }
            public byte[] RecipePicture1 { get; set; }
        }
    }
}
