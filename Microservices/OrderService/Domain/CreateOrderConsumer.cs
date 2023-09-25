using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class CreateOrderConsumer : IConsumer<CreateOrder>
    {
        private readonly IOrderService _orderService;

        public CreateOrderConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<CreateOrder> context)
        {
            var result = await _orderService.Create(context.Message, context.CancellationToken);
            await context.Publish(result, context.CancellationToken);
        }
    }
}
