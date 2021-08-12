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
        public OrderRepository(OrderContext orderContext):base(orderContext)
        {

        }
        public async Task<List<OrderModel>> GetByUser(string user)
        {
            var orderList = (await GetAsync(x => x.UserName == user)).ToList();
            return orderList;
        }
    }
}
