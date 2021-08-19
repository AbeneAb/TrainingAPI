using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces.Facade
{
    public interface IOrderService
    {
        Task<List<Entities.Order>> GetAllOrders();
        Task<Guid> Add(Entities.Order order);
        Task<List<Entities.Order>> GetByUser(string user);
        Task<Entities.Order> GetOrder(Guid id);
        Task UpdateOrder(Entities.Order order);
        Task DeleteOrder(Guid id);

    }
}
