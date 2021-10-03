using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id=1,
                    Birthday = new DateTime(1998, 10, 24),
                    AccountId = 1
                },
                new Customer
                {
                    Id = 2,
                    Birthday = new DateTime(1997, 10, 24),
                    AccountId = 2
                },
                new Customer
                {
                    Id = 3,
                    Birthday = new DateTime(1996, 10, 24),
                    AccountId=3
                }); 
        }
    }
}
