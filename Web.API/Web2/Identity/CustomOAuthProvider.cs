using Microsoft.AspNetCore.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Web2.Identity
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IUserService _userService { get; set; }
        public CustomOAuthProvider(IUserService src)
        {
            _userService = src;
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = _userService.Query(u => u.UserId == context.UserName && u.Password == context.Password).FirstOrDefault();
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name is not registered with CSPS.");
                context.Rejected();
                //return Task.FromResult<object>(null);
            }
            else
            {
                var claims = await _userService.GetUserClaims(user);
                var properties = new AuthenticationProperties(await _userService.GetAuhenticationProperties(user));
                AuthenticationTicket ticket = new AuthenticationTicket(claims, properties);
                context.Validated(ticket);
            }
            //var user = context.OwinContext.Get<BooksContext>().Users.FirstOrDefault(u => u.UserName == context.UserName);
            //if (!context.OwinContext.Get<BookUserManager>().CheckPassword(user, context.Password))
            //{
            //    context.SetError("invalid_grant", "The user name or password is incorrect");
            //    context.Rejected();
            //    return Task.FromResult<object>(null);
            //}

            //var ticket = new AuthenticationTicket(SetClaimsIdentity(context, user), new AuthenticationProperties());
            //context.Validated(ticket);

            //return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context, IdentityUser user)
        {
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));

            //var userRoles = context.OwinContext.Get<BookUserManager>().GetRoles(user.Id);
            //foreach (var role in userRoles)
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, role));
            //}

            return identity;
        }
    }
}