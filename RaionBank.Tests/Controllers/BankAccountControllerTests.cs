using FakeItEasy;
using FluentAssertions;
using MediatR;
using RaionBank.Controllers;
using Services.BankAccounts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RaionBank.Tests.Controllers
{
    public class BankAccountControllerTests
    {
        private readonly BankAccountController _bankAccountController;
        private readonly IMediator _mediator;
        public BankAccountControllerTests()
        {
            _mediator = A.Fake<IMediator>();
            _bankAccountController = new BankAccountController(_mediator);
        }

        [Fact]
        public void BankAccountController_GetSaldo_ReturnOk()
        {
            var result = _bankAccountController.GetSaldo(1);

            result.Should().NotBeNull();
            
        }

        [Fact]
        public void BankAccountController_DepositMoney_ReturnOk()
        {
            var command = new DepositMoneyCommand(1, 100M);
            var result = _bankAccountController.DepositMoney(command);

            result.Should().NotBeNull();

        }

        [Fact]
        public void BankAccountController_WithdrawnMoney_ReturnOk()
        {
            var command = new DepositMoneyCommand(1, 100M);
            var result = _bankAccountController.DepositMoney(command);

            result.Should().NotBeNull();

        }
    }
}
