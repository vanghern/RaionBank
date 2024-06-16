using BankLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BankAccounts.Commands
{
    public record WithdrawMoneyCommand(int id, decimal amount) : IRequestWrapper<decimal?>
    {
    }

    public class WithdrawMoneyCommandHandler(BankContext context) : IHandlerWrapper<WithdrawMoneyCommand, decimal?>
    {
        public async Task<Response<decimal?>> Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            var saldo = await context.Users
                .Include(e => e.BankAccount)
                .FirstOrDefaultAsync(e => e.Id == request.id);
            if (saldo == null)
            {
                return await Task.FromResult(Response.Fail<decimal?>("Unable to withdrawn the money"));
            }
            if (saldo.BankAccount.Saldo < request.amount)
            {
                return await Task.FromResult(Response.Fail<decimal?>("Unable to withdrawn the money"));
            }
            else
            {
                saldo.BankAccount.Saldo -= request.amount;
                context.SaveChanges();
                
            }
            return await Task.FromResult(Response.Ok(saldo.BankAccount.Saldo, "Withdraw Successful"));
        }
    }
}
