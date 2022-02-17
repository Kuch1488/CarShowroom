using System.Text.Json.Serialization;

namespace Showroom.Domain.Entities
{
    public partial class State
    {
        public State()
        {
            StateElements = new HashSet<StateElement>();
        }

        public int IdState { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<StateElement> StateElements { get; set; }
    }
}
