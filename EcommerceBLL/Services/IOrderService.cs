using Ecommerce.BLL.DTOs.Order;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface IOrderService : ICrudService<Order, OrderDto, CreateOrderDto, UpdateOrderDto> { }
}




