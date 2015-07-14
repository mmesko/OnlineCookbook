using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using OnlineCookbook.Model.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;

namespace WebApplication.Controllers
{
     [RoutePrefix("api/RecipeAlergen")]
    public class RecipeAlergenController : ApiController
    {
         private IRecipeAlergenService Service {get; set;}

         public RecipeAlergenController(IRecipeAlergenService service)
        {
            Service = service;
        }

        // GET: api/RecipeAlergen
         [HttpGet]
         [Route("")]
         public async Task<HttpResponseMessage> Get(string sortOrder = "", string sortDirection = "",
             int pageNumber = 0, int pageSize = 0)
         {
             try
             {
                 var result = await Service.GetAsync(new RecipeAlergenFilter(sortOrder, sortDirection, pageNumber, pageSize));
                 if (result != null)
                 {
                     return Request.CreateResponse(HttpStatusCode.OK,
                         Mapper.Map<List<RecipeAlergenModel>>(result));
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
         [Route("{id:guid}")]
         public async Task<HttpResponseMessage> Get(string id)
         {
             try
             {
                 var result = await Service.GetAsync(id);
                 if (result != null)
                 {
                     return Request.CreateResponse(HttpStatusCode.OK,
                         Mapper.Map<RecipeAlergenModel>(result));
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

        // POST: api/RecipeAlergen
         [HttpPost]
         [Route("")]
         public async Task<HttpResponseMessage> Post(RecipeAlergenModel entity)
         {
             entity.Id = Guid.NewGuid().ToString();
             try
             {
                 var result = await Service.InsertAsync(Mapper.Map<IRecipeAlergen>(entity));
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


        // PUT: api/RecipeAlergen/5
         [HttpPut]
         [Route("{id:guid}")]
         public async Task<HttpResponseMessage> Put(string id, RecipeAlergenModel entity)
         {
             try
             {
                 if (id != entity.Id)
                 {
                     return Request.CreateResponse(HttpStatusCode.BadRequest, "IDs do not match.");
                 }

                 var result = await Service.UpdateAsync(Mapper.Map<IRecipeAlergen>(entity));

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

        // DELETE: api/RecipeAlergen/5
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
         public async Task<HttpResponseMessage> GetRecipeAlergenAsync(string id, string sortOrder = "",
             string sortDirection = "", int pageNumber = 0, int pageSize = 0)
         {
             try
             {
                 var result = await Service.GetRecipeAlergenAsync(id, new RecipeAlergenFilter(sortOrder, sortDirection, pageNumber, pageSize));

                 if (result != null)
                 {
                     return Request.CreateResponse(HttpStatusCode.OK,
                         Mapper.Map<List<AlergenController.AlergenModel>>(result));
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

         public class RecipeAlergenModel
         {
             public string Id { get; set; }
             public string AlergenId { get; set; }
             public string RecipeId { get; set; }
             public int AlergenQuantity { get; set; }
             public string AlergenUnit { get; set; }
         
         }
    }
}
