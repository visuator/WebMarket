using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class GetOrdersConsumer : IConsumer<GetOrders>
    {
        private readonly IOrderService _orderService;

        public GetOrdersConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<GetOrders> context)
        {
            var result = await _orderService.GetAll(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
