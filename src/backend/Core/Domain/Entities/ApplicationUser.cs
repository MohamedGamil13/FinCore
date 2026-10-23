using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; } = new();
    }
}
