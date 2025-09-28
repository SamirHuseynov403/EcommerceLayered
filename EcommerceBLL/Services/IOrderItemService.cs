using Ecommerce.BLL.DTOs.OrderItem;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface IOrderItemService : ICrudService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto> { }
}




