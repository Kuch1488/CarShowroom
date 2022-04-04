using Showroom.Domain.Entitis.UserEntities;
using System.Text.Json.Serialization;

namespace Showroom.Domain.Models
{
    public class AuthenticateResponse
    {
        public string Token { get; set; } = null!;

        [JsonIgnore]
        public int IdUser { get; set; }

        public virtual User? UserNavigation { get; set; }
    }
}
