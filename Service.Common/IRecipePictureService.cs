using OnlineCookbook.Common.Filters;
using OnlineCookbook.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCookbook.Service.Common
{
    public interface IRecipePictureService
    {
        Task<List<IRecipePicture>> GetRangeAsync(string recipeId, GenericFilter filter);
      
    }
}
