using GameEndpoints.Common.Resources;
using GameEndpoints.Domain.Contracts.Services;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GameEndpoints.Api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IPlayerService _service;

        public AuthorizationServerProvider(IPlayerService service)
        {
            _service = service;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var player = _service.Authenticate(context.UserName, context.Password);

                if (player == null)
                {
                    context.SetError("invalid_grant", ErrorMessages.InvalidCredentials);
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, player.PlayerName));

                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ErrorMessages.InvalidCredentials);
            }
        }
    }
}