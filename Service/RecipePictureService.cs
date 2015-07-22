using OnlineCookbook.Common.Filters;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCookbook.Service
{
    public class RecipePictureService : IRecipePictureService
    {

         IRecipePictureRepository repository;

         public RecipePictureService(IRecipePictureRepository repository)
        {
            this.repository = repository;
        }
       

        /// <summary>
        /// Get images that belong to game
        /// </summary>
        /// <param name="gameId">GameId</param>
        /// <param name="filter">Filter</param>
        /// <returns>Collection of games</returns>
        public async Task<List<IRecipePicture>> GetRangeAsync(string recipeId, GenericFilter filter)
        {
            return await repository.GetRangeAsync(recipeId, filter);
        }
        
    }
}
