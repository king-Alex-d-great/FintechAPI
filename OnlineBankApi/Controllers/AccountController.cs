using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineBankApi.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public AccountsController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }
        [HttpGet]
        public IActionResult GetAccounts()
        {
            try
            {
                var accounts = _repositoryManager.Accounts.GetAllAccounts();
                var accountDTO = accounts.Select(a => new AccountTransferObject()
                {
                    AccountNumber = a.AccountNumber,
                    AccountType = a.AccountType,
                    Balance = a.Balance,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt,
                    Id = a.Id,
                    IsActive = a.IsActive,
                    CreatedBy = a.CreatedBy,
                    UpdatedBy = a.UpdatedBy
                }).ToList();
                return Ok(accountDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error\nSomething went wrong in the {nameof(GetAccounts)} action {ex}");
            }
        }
        [HttpGet("Id/{id}")]
        public IActionResult GetAccount(int id)
        {
            try
            {
                var account = _repositoryManager.Accounts.GetAccount(id);
                if (account == null) return NotFound();
                var accountDTO = new AccountTransferObject()
                {
                    AccountNumber = account.AccountNumber,
                    AccountType = account.AccountType,
                    Balance = account.Balance,
                    CreatedAt = account.CreatedAt,
                    UpdatedAt = account.UpdatedAt,
                    Id = account.Id,
                    IsActive = account.IsActive,
                    CreatedBy = account.CreatedBy,
                    UpdatedBy = account.UpdatedBy
                };
                return Ok(accountDTO);                
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Internal server error\nSomething went wrong in the {nameof(GetAccount)} action {ex}");
            }
        }

        [HttpGet("AccountNumber/{accNumber}")]
        public IActionResult GetAccountByAccountNumber(string accNumber)
        {
            try
            {
                var account = _repositoryManager.Accounts.GetAccount(accNumber);
                if (account == null) return NotFound();
                var accountDTO = new AccountTransferObject()
                {
                    AccountNumber = account.AccountNumber,
                    AccountType = account.AccountType,
                    Balance = account.Balance,
                    CreatedAt = account.CreatedAt,
                    UpdatedAt = account.UpdatedAt,
                    Id = account.Id,
                    IsActive = account.IsActive,
                    CreatedBy = account.CreatedBy,
                    UpdatedBy = account.UpdatedBy
                };
                return Ok(accountDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Internal server error\nSomething went wrong in the {nameof(GetAccountByAccountNumber)} action {ex}");
            }

        }
    }
}
