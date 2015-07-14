using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Model.Common;
using System.Threading.Tasks;


namespace WebApplication.Controllers
{
    [RoutePrefix("api/Picture")]
    public class PictureController : ApiController
    {
        private IRecipePictureService RecipePictureService { get; set; }


        public PictureController(IRecipePictureService recipePictureService)
        {
            RecipePictureService = recipePictureService;
        }

        // GET: api/Picture
        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get(string url)
        {
            try
            {
                var id = new Guid(url.Split('/').Last()).ToString();

               if (url.Contains("Recipe")) //kasnije dodati i za preparation step picture
                {
                    return Request.CreateResponse(HttpStatusCode.OK, await RecipePictureService.GetAsync(id));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Url.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        
    }
}
