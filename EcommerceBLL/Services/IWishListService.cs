using Ecommerce.BLL.DTOs.WishList;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface IWishListService : ICrudService<WishList, WishListDto, CreateWishlistDto, UpdateWishlistDto> { }
}




