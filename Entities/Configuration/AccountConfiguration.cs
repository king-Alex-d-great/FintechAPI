using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                    new Account { Id = 1, AccountNumber = "0760015555", AccountType = Enumerators.AccountType.Savings, Balance = 20000, IsActive = true },
                    new Account { Id = 2, AccountNumber = "0222833403", AccountType = Enumerators.AccountType.Student, Balance = 300000, IsActive = true },
                    new Account { Id = 3, AccountNumber = "8179265533", AccountType = Enumerators.AccountType.Savings, Balance = 2320000, IsActive = true }
                );
        }
    }
}
