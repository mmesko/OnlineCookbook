using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
namespace OnlineCookbook.Service.Common
{
    public interface IRecipePictureService
    {

        Task<List<IRecipePicture>> GetAsync();
        Task<IRecipePicture> GetAsync(string id);
        Task<int> InsertAsync(IRecipePicture entity);
        Task<int> UpdateAsync(IRecipePicture entity);
        Task<int> DeleteAsync(IRecipePicture entity);
        Task<int> DeleteAsync(string id);
    }
}
