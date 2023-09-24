using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class GetOrderStatusConsumer : IConsumer<GetOrderStatus>
    {
        private readonly IOrderService _orderService;

        public GetOrderStatusConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<GetOrderStatus> context)
        {
            var result = await _orderService.GetStatus(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
