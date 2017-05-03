using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Validation;
using IdentityServerFour.Configuration;
using IdentityServer4.Models;

namespace IdentityServerFour.Extentions
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;
        public ResourceOwnerPasswordValidator(IUserService userService)
        {
            _userService = userService;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var rndNum = new Random().Next(0, 1);
            GrantValidationResult result = null;
            if (_userService.CheckPasswordAsync(context.UserName,context.Password).Result)
            {
                result = new GrantValidationResult(subject: "818727", authenticationMethod: "custom", claims:null);
            }
            else
            {
                result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
            }
            context.Result = result;
            return Task.FromResult(0);
        }
    }
}
