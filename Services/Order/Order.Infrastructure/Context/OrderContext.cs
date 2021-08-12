using Microsoft.EntityFrameworkCore;
using Order.Domain.Models;
using Order.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Infrastructure.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderItemModel> OrderItemModels { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedByUser = Guid.Empty;

                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = Guid.Empty;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
