using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces.Repository;
using Order.Domain.Models;
using Order.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repository
{
    public class OrderRepository :AsyncRepository<OrderModel>, IOrderRepository
    {
        private readonly OrderContext _orderContext;
        public OrderRepository(OrderContext orderContext):base(orderContext)
        {
            _orderContext = orderContext;
        }
        public override async Task<IReadOnlyList<OrderModel>> GetAllAsync()
        {
            var orders = _orderContext.Orders.Include(order => order.OrderItems).ToListAsync();
            return await orders;
        }

        public async Task<List<OrderModel>> GetByUser(string user)
        {
            var orderList = (await GetAsync(x => x.UserName == user)).ToList();
            return orderList;
        }
    }
}
