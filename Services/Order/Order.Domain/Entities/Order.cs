using Order.Domain.Models;
using Order.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class Order : BaseEntity<OrderModel>
    {
        public decimal TotalPrice { get; set; }
        public string UserName { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public Order(OrderModel orderModel) :base(orderModel)
        {
            UserName = orderModel.UserName;
            TotalPrice = orderModel.TotalPrice;
            OrderItems = orderModel.OrderItems?.Select(x => new OrderItem(x)).ToList();
        }

        public override OrderModel MapToModel()
        {
            OrderModel orderModel = new OrderModel();
            orderModel.UserName = UserName;
            orderModel.TotalPrice = TotalPrice;
            orderModel.OrderItems = OrderItems?.Select(x => x.MapToModel()).ToList();
            return orderModel;
        }

        public override OrderModel MapToModel(OrderModel t)
        {
            throw new NotImplementedException();
        }
    }
}
