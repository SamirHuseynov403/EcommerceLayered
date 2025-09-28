using AutoMapper;
using Ecommerce.BLL.DTOs.Social;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class SocialManager : CrudManager<Social, SocialDto, CreateSocialDto, UpdateSocialDto>, ISocialService
    {
        public SocialManager(IRepository<Social> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}