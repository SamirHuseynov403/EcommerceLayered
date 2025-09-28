using AutoMapper;
using Ecommerce.BLL.DTOs.OrderItem;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class OrderItemManager : CrudManager<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>, IOrderItemService
    {
        public OrderItemManager(IRepository<OrderItem> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}