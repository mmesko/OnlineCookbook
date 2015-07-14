using AutoMapper;
using OnlineCookbook.Service.Common;
using WebApplication.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserService userService;
        private UserModel user;

        public SimpleAuthorizationServerProvider()
            : base()
        {
            // Dependency resolver, injects user service
            this.userService = (IUserService)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUserService));
 
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);

        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

           user = Mapper.Map<UserModel>(await userService.FindAsync(context.UserName, context.Password));

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            else
            {
                ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                // Proporties
                IDictionary<string, string> prop = new Dictionary<string, string>()
                {
                    { "username", user.UserName },
                    { "id", user.Id}
                };

                // Add dictionary to auth proporties
                AuthenticationProperties proporties = new AuthenticationProperties(prop);

                AuthenticationTicket ticket = new AuthenticationTicket(identity, proporties);
                
                context.Validated(ticket);
            }

        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}