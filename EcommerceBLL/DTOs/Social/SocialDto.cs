using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.DTOs.Social
{
    public class SocialDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
    }
    public class CreateSocialDto
    {
        public string? Name { get; set; }
        public string? Icon { get; set; }
    }
    public class UpdateSocialDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
    }
}
