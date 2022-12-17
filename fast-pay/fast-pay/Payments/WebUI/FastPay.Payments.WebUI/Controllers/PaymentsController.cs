using System;
using FastPay.Payments.Application.Payments.Commands.CreatePayment;
using Microsoft.AspNetCore.Mvc;

namespace FastPay.Payments.WebUI.Controllers
{
	public class PaymentsController: ApiControllerBase
	{
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePaymentCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}

