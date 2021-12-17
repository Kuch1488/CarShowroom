namespace Showroom.Domain.Entities
{
    public partial class Generation
    {
        public Generation()
        {
            Models = new HashSet<Model>();
        }

        public int IdGeneration { get; set; }
        public Int16 Year { get; set; }
        public int Produced { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
