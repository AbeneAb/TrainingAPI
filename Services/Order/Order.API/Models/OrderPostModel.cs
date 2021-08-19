using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Models
{
    public class OrderPostModel : BaseModel
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemPostModel> OrderItemPostModels { get; set; }

        public override T MapToEntity<T>()
        {
            Domain.Entities.Order order = new Domain.Entities.Order();
            order.UserName = UserName;
            order.TotalPrice = TotalPrice;
            return order as T;
        }
    }
}
