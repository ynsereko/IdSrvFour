using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerFour.Extentions
{
    public interface IUserService
    {
        Task<bool> CheckPasswordAsync(string userName, string password);
        Task<List<Claim>> GetClaimsAsync(string userName);
    }
}