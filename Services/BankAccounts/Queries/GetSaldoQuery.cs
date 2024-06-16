using BankLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BankAccounts.Queries
{
    public record GetSaldoQuery(int id) : IRequestWrapper<decimal?>
    {
      
    }

    public class GetSaldoQueryHandler : IHandlerWrapper<GetSaldoQuery, decimal?>
    {
        private readonly BankContext context;

        public GetSaldoQueryHandler(BankContext context)
        {
            this.context = context;
        }

        public async Task<Response<decimal?>> Handle(GetSaldoQuery request, CancellationToken cancellationToken)
        {
            var saldo = await context.Users
                .Include(e => e.BankAccount)
                .FirstOrDefaultAsync(e => e.Id == request.id);
            if (saldo == null || saldo.BankAccount == null) 
            {
                return await Task.FromResult(Response.Fail<decimal?>("Account not found", null));
            }
            return await Task.FromResult(Response.Ok(saldo.BankAccount.Saldo, "Saldo"));
        }
    }
}
