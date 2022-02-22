using Showroom.Domain.Entitis.UserEntities;

namespace Showroom.Infrastructure.Helpers.Interface
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public string RandomTokenString();
    }
}
