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
    class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasData(
                new Transaction
                {
                    CustomerId =2,
                    Amount = 1000,
                    ReceiverAccount = "0760015555",
                    SenderAccount = "0222833403",
                    IsSuccessful = true,
                    TimeStamp = DateTime.Now,
                    TransactionMode = Enumerators.TransactionMode.Credit,
                    TransactionType = Enumerators.TransactionType.Transfer,
                    Id = 1
                },
                new Transaction
                {
                    CustomerId =1,
                    Amount = 1000,
                    ReceiverAccount = "0760015555",
                    SenderAccount = "0760015555",
                    IsSuccessful = true,
                    TimeStamp = DateTime.Now,
                    TransactionMode = Enumerators.TransactionMode.Debit,
                    TransactionType = Enumerators.TransactionType.Withdraw,
                    Id =2
                },
                
                new Transaction
                {
                    CustomerId = 3,
                    Amount = 11000,
                    ReceiverAccount = "0222833403",
                    SenderAccount = "0222833403",
                    IsSuccessful = true,
                    TimeStamp = DateTime.Now,
                    TransactionMode = Enumerators.TransactionMode.Credit,
                    TransactionType = Enumerators.TransactionType.Deposit,
                    Id = 4
                });
        }
    }
}
