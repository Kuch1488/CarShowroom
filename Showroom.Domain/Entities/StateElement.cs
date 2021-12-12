namespace Showroom.Domain.Entities
{
    public partial class StateElement
    {
        public int IdStateElement { get; set; }
        public string Name { get; set; } = null!;
        public string VinNumber { get; set; } = null!;
        public int IdState { get; set; }

        public virtual Car? IdCarNavigation { get; set; }
        public virtual State? IdStateNavigation { get; set; }
    }
}
