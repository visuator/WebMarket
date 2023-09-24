using MassTransit;

using OrderService.Domain.Services;

using WebMarket.Common.Messages;

namespace OrderService.Domain
{
    public class GetOrderPackageInfoConsumer : IConsumer<GetOrderPackageInfo>
    {
        private readonly IOrderService _orderService;

        public GetOrderPackageInfoConsumer(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<GetOrderPackageInfo> context)
        {
            var result = await _orderService.GetPackageInfo(context.Message, context.CancellationToken);
            await context.RespondAsync(result);
        }
    }
}
