namespace Showroom.Domain.Entities
{
    public partial class Class
    {
        public Class()
        {
            Models = new HashSet<Model>();
        }

        public int IdClass { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Model> Models { get; set; }
    }
}
