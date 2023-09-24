using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class GetUserOrdersConsumer : IConsumer<GetUserOrders>
    {
        private readonly IOrderService _orderService;

        public GetUserOrdersConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<GetUserOrders> context)
        {
            var result = await _orderService.GetAll(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
