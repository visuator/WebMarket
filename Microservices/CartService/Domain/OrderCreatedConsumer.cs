using CartService.Domain.Services;

using MassTransit;

using WebMarket.Common.Messages;

namespace CartService.Domain
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly IUserProductService _userProductService;

        public OrderCreatedConsumer(IUserProductService userProductService)
        {
            _userProductService = userProductService;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            await _userProductService.Remove(context.Message, context.CancellationToken);
        }

        public class Definition : ConsumerDefinition<OrderCreatedConsumer>
        {
            public Definition()
            {
                Endpoint(x => x.Name = $"{nameof(OrderCreated)}CartConsumer");
            }
        }
    }
}
