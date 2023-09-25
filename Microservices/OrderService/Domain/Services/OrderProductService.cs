using AutoMapper;

using Microsoft.EntityFrameworkCore;

using OrderService.Storages;

using WebMarket.Common.Messages;

namespace OrderService.Domain.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly OrderDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderProductService> _logger;

        public OrderProductService(OrderDbContext dbContext, IMapper mapper, ILogger<OrderProductService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task SetStatus(StatusOrderProduct message, CancellationToken token = default)
        {
            var orderProduct = await _dbContext.OrderProducts.Where(x => x.OrderId == message.OrderId && x.ProductId == message.ProductId).SingleOrDefaultAsync(token);
            if (orderProduct is null) throw new Exception("Order or product not found");

            orderProduct.Status = message.SetTo;

            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Order product status set to: {status}", message.SetTo);
        }
    }
}
