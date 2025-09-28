using Ecommerce.BLL.DTOs.Social;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.DTOs.Bio
{
    public class BioDto
    {
        public int Id { get; set; }
        public string? Logo { get; set; }
        public string? Mail { get; set; }
        public string? Mobil { get; set; }
        public List<SocialDto> Socials { get; set; } = new List<SocialDto>();
    }
}
