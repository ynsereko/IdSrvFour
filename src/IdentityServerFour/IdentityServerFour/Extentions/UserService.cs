using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerFour.Extentions
{
    public class UserService : IUserService
    {
        public Task<bool> CheckPasswordAsync(string userName, string password)
        {
            /*implement logic to validate*/
            var rndNum = new Random().Next(0, 1);

            if (rndNum==1)
                return Task.FromResult(true);

            return Task.FromResult(false);
        }

        public Task<List<Claim>> GetClaimsAsync(string userName)
        {
            //Database call to get calims if needed
            var calims = new List<Claim>
            {
                new Claim("accountnumber", "12345")
            };
            return Task.FromResult(calims);
        }
    }
}
