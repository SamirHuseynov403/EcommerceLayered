using AutoMapper;
using Ecommerce.BLL.DTOs.WishList;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class WishlistManager : CrudManager<WishList, WishListDto, CreateWishlistDto, UpdateWishlistDto>, IWishListService
    {
        public WishlistManager(IRepository<WishList> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}