using Example.Services.Order.Application.Commands;
using Example.Services.Order.Application.Queries;
using Example.Shared.BaseController;
using Example.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Services.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediatR;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrdersController(IMediator mediatR, ISharedIdentityService sharedIdentityService)
        {
            _mediatR = mediatR;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mediatR.Send(new GetOrderByUserIdQuery { UserId = _sharedIdentityService.GetUserId });
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            var response = await _mediatR.Send(createOrderCommand);
            return CreateActionResultInstance(response);
        }
    }
}
