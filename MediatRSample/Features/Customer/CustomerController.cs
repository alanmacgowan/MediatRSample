using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Features.Customer
{
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ViewResult> Index(Index.Query query)
        {
            var model = await _mediator.Send(query);

            return View(model);
        }
    }
}
