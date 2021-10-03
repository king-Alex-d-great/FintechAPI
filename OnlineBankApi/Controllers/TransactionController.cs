using System;
using System.Linq;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace OnlineBankApi.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public TransactionController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }
        [HttpGet]
        public IActionResult GetTransactions()
        {
            try
            {
                var transactions = _repositoryManager.Transactions.GetAllTransactions();
                var transactionDTO = transactions.Select(t => new TransactionTransferObject()
                {
                    Amount = t.Amount,
                    CustomerId = t.CustomerId,
                    Id = t.Id,
                    ReceiverAccount = t.ReceiverAccount,
                    IsSuccessful = t.IsSuccessful,
                    SenderAccount = t.SenderAccount,
                    TimeStamp = t.TimeStamp,
                    TransactionMode = t.TransactionMode,
                    TransactionType = t.TransactionType

                }).ToList();
                return Ok(transactionDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error\nSomething went wrong in the {nameof(GetTransactions)} action {ex}");
            }
        }
        [HttpGet("Id/{id}")]
        public IActionResult GetTransaction(int id)
        {
            try
            {
                var transaction = _repositoryManager.Transactions.GetTransaction(id);
                if (transaction == null) return NotFound();
                var transactionDTO = new TransactionTransferObject()
                {
                    Amount = transaction.Amount,
                    CustomerId = transaction.CustomerId,
                    Id = transaction.Id,
                    ReceiverAccount = transaction.ReceiverAccount,
                    IsSuccessful = transaction.IsSuccessful,
                    SenderAccount = transaction.SenderAccount,
                    TimeStamp = transaction.TimeStamp,
                    TransactionMode = transaction.TransactionMode,
                    TransactionType = transaction.TransactionType
                };
               
                return Ok(transactionDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Internal server error\nSomething went wrong in the {nameof(GetTransaction)} action {ex}");
            }
        }

        [HttpGet("CustomerId/{customerId}")]
        public IActionResult GetTransactionsForCUstomer(int customerId)
        {
            try
            {
                var transactions = _repositoryManager.Transactions.GetAllTransactionsForSpecificCustomer(customerId);
                if (transactions == null) return NotFound();
                var transactionDTO = transactions.Select(t => new TransactionTransferObject()
                {
                    Amount = t.Amount,
                    CustomerId = t.CustomerId,
                    Id = t.Id,
                    ReceiverAccount = t.ReceiverAccount,
                    IsSuccessful = t.IsSuccessful,
                    SenderAccount = t.SenderAccount,
                    TimeStamp = t.TimeStamp,
                    TransactionMode = t.TransactionMode,
                    TransactionType = t.TransactionType
                }).ToList();
                return Ok(transactionDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Internal server error\nSomething went wrong in the {nameof(GetTransactionsForCUstomer)} action {ex}");
            }

        }
    }
}
