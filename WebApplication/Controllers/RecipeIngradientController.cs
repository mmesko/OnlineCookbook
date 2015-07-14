using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using OnlineCookbook.Model.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;
using System.Threading.Tasks;
using AutoMapper;

namespace WebApplication.Controllers
{
     [RoutePrefix("api/RecipeIngradient")] 
    public class RecipeIngradientController : ApiController
    {

         private IRecipeIngradientService Service {get; set;}

         public RecipeIngradientController(IRecipeIngradientService service)
        {
            Service = service;
        }
        // GET: api/RecipeIngradient
         [HttpGet]
         [Route("")]
         public async Task<HttpResponseMessage> Get(string sortOrder = "", string sortDirection = "",
             int pageNumber = 0, int pageSize = 0)
         {
             try
             {
                 var result = await Service.GetAsync(new RecipeIngradientFilter(sortOrder, sortDirection, pageNumber, pageSize));
                 if (result != null)
                 {
                     return Request.CreateResponse(HttpStatusCode.OK,
                         Mapper.Map<List<RecipeIngradientModel>>(result));
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


        // GET: api/RecipeIngradient/5
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
                         Mapper.Map<RecipeIngradientModel>(result));
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

        // POST: api/RecipeIngradient
         [HttpPost]
         [Route("")]
         public async Task<HttpResponseMessage> Post(RecipeIngradientModel entity)
         {
             entity.Id = Guid.NewGuid().ToString();
             try
             {
                 var result = await Service.InsertAsync(Mapper.Map<IRecipeIngradient>(entity));
                 if (result == 1)
                 {
                     return Request.CreateResponse(HttpStatusCode.OK, entity);
                 }
                 else
                 {
                     return Request.CreateResponse(HttpStatusCode.InternalServerError,
                         "POST unsuccessful.");
                 }
             }
             catch (Exception e)
             {
                 return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
             }
         }

        // PUT: api/RecipeIngradient/5
         [HttpPut]
         [Route("{id:guid}")]
         public async Task<HttpResponseMessage> Put(string id, RecipeIngradientModel entity)
         {
             try
             {
                 if (id != entity.Id)
                 {
                     return Request.CreateResponse(HttpStatusCode.BadRequest, "IDs do not match.");
                 }

                 var result = await Service.UpdateAsync(Mapper.Map<IRecipeIngradient>(entity));

                 if (result == 1)
                 {
                     return Request.CreateResponse(HttpStatusCode.OK, entity);
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

        // DELETE: api/RecipeIngradient/5
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

         // GET: api/RecipeAlergen/5
         [HttpGet]
         [Route("Alergens/{id:guid}")]
         public async Task<HttpResponseMessage> GetRecipeIngradientAsync(string id, string sortOrder = "",
             string sortDirection = "", int pageNumber = 0, int pageSize = 0)
         {
             try
             {
                 var result = await Service.GetRecipeIngradientAsync(id, new RecipeIngradientFilter(sortOrder, sortDirection, pageNumber, pageSize));

                 if (result != null)
                 {
                     return Request.CreateResponse(HttpStatusCode.OK,
                         Mapper.Map<List<IngradientController.IngradientModel>>(result));
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

        public class RecipeIngradientModel
        {
            public string Id { get; set; }
            public string IngradientId { get; set; }
            public string RecipeId { get; set; }
            public int IngradientQuantity { get; set; }
            public string IngradientUnit { get; set; }
        }
    }
}
