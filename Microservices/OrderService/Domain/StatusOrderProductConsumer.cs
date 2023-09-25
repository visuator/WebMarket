using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class StatusOrderProductConsumer<TStatusOrderProduct> : IConsumer<TStatusOrderProduct> where TStatusOrderProduct : StatusOrderProduct
    {
        private readonly IOrderProductService _orderProductService;

        public StatusOrderProductConsumer(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        public async Task Consume(ConsumeContext<TStatusOrderProduct> context)
        {
            await _orderProductService.SetStatus(context.Message, context.CancellationToken);
        }
    }
}
