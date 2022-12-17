using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastPay.Profile.Application.Contacts.Commands.CreateContact;
using FastPay.Profile.Application.Contacts.Queries.ListContact;
using FastPay.Profile.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastPay.Profile.WebUI.Controllers
{
    public class ContactsController : ApiControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateContactCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactDto>>> Get()
        {
            return await Mediator.Send(new ListContactQuery());
        }


    }
}

