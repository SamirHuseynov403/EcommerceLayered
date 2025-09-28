using AutoMapper;
using Ecommerce.BLL.DTOs.Order;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class OrderManager : CrudManager<Order, OrderDto, CreateOrderDto, UpdateOrderDto>, IOrderService
    {
        public OrderManager(IRepository<Order> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}
