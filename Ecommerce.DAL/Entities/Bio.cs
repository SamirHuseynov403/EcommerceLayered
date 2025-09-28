
namespace Ecommerce.DAL.Entities
{
    public class Bio : Base
    {
        public string? Logo { get; set; }
        public string? Mail { get; set; }
        public string? Mobil { get; set; }
        public string? Address { get; set; }
        public List<Social> Socials { get; set; } = new List<Social>();
    }
}
