using Example.Services.Order.Application.Dtos;
using Example.Services.Order.Application.Mapping;
using Example.Services.Order.Application.Queries;
using Example.Services.Order.Infrastructure;
using Example.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Services.Order.Application.Handlers
{
    class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrderByUserIdQuery, Response<List<OrderDto>>>
    {
        private readonly OrderDbContext _context;

        public GetOrdersByUserIdQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();
            
            if (!orders.Any())
                return Response<List<OrderDto>>.Success(new List<OrderDto>(), 200);

            var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);
            return Response<List<OrderDto>>.Success(ordersDto, 200);
        }
    }
}
