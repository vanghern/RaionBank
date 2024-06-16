using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.BankAccounts.Commands;
using Services.BankAccounts.Queries;

namespace RaionBank.Controllers
{
    [ApiController]
    [Route("bankaccounts")]
    public class BankAccountController : Controller
    {
        private IMediator mediator;

        public BankAccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }
                
        [HttpGet]
        public Task<Response<decimal?>> GetSaldo(int id)
        {
            return mediator.Send(new GetSaldoQuery(id));
        }

        [HttpPost]
        [Route("depositmoney")]
        public Task<Response<decimal?>> DepositMoney([FromBody] DepositMoneyCommand command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("withdrawmoney")]
        public Task<Response<decimal?>> WithdrawMoney([FromBody] WithdrawMoneyCommand command)
        {
            return mediator.Send(command);
        }
    }
}
