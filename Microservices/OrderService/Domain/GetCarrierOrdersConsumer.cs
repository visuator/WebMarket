using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class GetCarrierOrdersConsumer : IConsumer<GetCarrierOrders>
    {
        private readonly IOrderService _orderService;

        public GetCarrierOrdersConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<GetCarrierOrders> context)
        {
            var result = await _orderService.GetAll(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
