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
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly ILoggerManager loggerManager;

        public CustomerController(IRepositoryManager repository, ILoggerManager loggerManager)
        {
            this.repository = repository;
            this.loggerManager = loggerManager;
        }
        [HttpGet]
        public IActionResult GetCustomers()
        {  
            try
            {
               var customers = repository.Customers.GetAllCustomers();
                var customerDTO = customers.Select(c => new CustomerTransferObject()
                {
                    AccountId = c.AccountId,
                    Birthday = c.Birthday,
                    Id = c.Id,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt =c.UpdatedAt,
                }).ToList();
                return Ok(customerDTO);
            } catch (Exception error)
            {
                loggerManager.LogError(error.Message);
                return StatusCode(500, "Internal error");
            }
        }
        [HttpGet("Id/{id}")]
        public IActionResult GetCustomerbyId(int id)
        {  
            try
            {
               var customer = repository.Customers.GetCustomer(id);
                var customerDTO = new CustomerTransferObject
                {
                    AccountId = customer.AccountId,
                    Birthday = customer.Birthday,
                    Id = customer.Id,
                    CreatedAt = customer.CreatedAt,
                    UpdatedAt = customer.UpdatedAt,
                };
                return Ok(customerDTO);
            } 
            catch (Exception error)
            {
                loggerManager.LogError(error.Message);
                return StatusCode(500, "Internal error");
            }
        }
        [HttpGet("accountId/{accountId}")]
        public IActionResult GetCustomerByAccountId(int accountId)
        {  
            try
            {
               var customer = repository.Customers.GetCustomerWithAccountId(accountId);

                var customerDTO = new CustomerTransferObject
                {
                    AccountId = customer.AccountId,
                    Birthday = customer.Birthday,
                    Id = customer.Id,
                    CreatedAt = customer.CreatedAt,
                    UpdatedAt = customer.UpdatedAt,
                };
                return Ok(customerDTO);
            } 
            catch (Exception error)
            {
                loggerManager.LogError(error.Message);
                return StatusCode(500, "Internal error");
            }
        }
          
    }
}
