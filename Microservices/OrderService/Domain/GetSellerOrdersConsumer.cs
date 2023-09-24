using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class GetSellerOrdersConsumer : IConsumer<GetSellerOrders>
    {
        private readonly IOrderService _orderService;

        public GetSellerOrdersConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<GetSellerOrders> context)
        {
            var result = await _orderService.GetAll(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
