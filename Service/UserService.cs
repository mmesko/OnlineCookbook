using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.Service.Common;
using OnlineCookbook.Common.Filters;

namespace OnlineCookbook.Service
{
    public class UserService : IUserService
    {

         protected IUserRepository Repository { get; private set; }

         public UserService(IUserRepository repository)
        {
            Repository = repository;
        }

         public async Task<IUser> FindAsync(string username)
         {
             try
             {
                 return await Repository.GetAsync(username);
             }
             catch (Exception e)
             {

                 throw e;
             }
         }

         public async Task<IUser> FindAsync(string username, string password)
         {
             try
             {
                 return await Repository.GetAsync(username, password);
             }
             catch (Exception e)
             {

                 throw e;
             }
         }

         /// <summary>
         /// Register add user
         /// </summary>
         public async Task<bool> RegisterUser(Model.Common.IUser user)
         {
             try
             {
                 return await Repository.RegisterUser(user);
             }
             catch (Exception e)
             {

                 throw e;
             }
         }

         public async Task<int> UpdateEmailOrUsernameAsync(Model.Common.IUser user, string password)
         {
             return await Repository.UpdateEmailOrUsernameAsync(user, password);
         }

    }
}
