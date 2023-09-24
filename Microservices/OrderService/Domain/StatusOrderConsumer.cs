using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class StatusOrderConsumer<TStatusOrder> : IConsumer<TStatusOrder> where TStatusOrder : StatusOrder
    {
        private readonly IOrderService _orderService;

        public StatusOrderConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<TStatusOrder> context)
        {
            await _orderService.SetStatus(context.Message, context.CancellationToken);
        }
    }
}
