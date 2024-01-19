using Banking.Application.Interfaces;
using Banking.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Api.Banking.Controllers
{
    [ApiController]
    [Route("banking")]

    public class BankingController : ControllerBase
    {
        private readonly IAccountService _service;

        public BankingController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(_service.GetAccounts());
        }

        [HttpPost("post")]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _service.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
