﻿using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using OrderService.Entities;
using OrderService.Storages;
using WebMarket.Common.Enums;
using WebMarket.Common.Messages;

namespace OrderService.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public OrderService(OrderDbContext dbContext, IMapper mapper, ILogger<OrderService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Create(CreateOrder message, CancellationToken token = default)
        {
            var entity = _mapper.Map<Order>(message, opt => opt.AfterMap((_, dst) =>
            {
                dst.Status = OrderStatus.Created;
            }));
            await _dbContext.Orders.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Order created: {id}", entity.Id);
        }
        public async Task<GetOrderStatusResult> GetStatus(GetOrderStatus message, CancellationToken token = default)
        {
            var order = await _dbContext.Orders.AsNoTracking().Where(x => x.Id == message.OrderId).SingleOrDefaultAsync(token);
            if (order is null) throw new Exception("Order not found");
            return new() { Status = order.Status };
        }

        public async Task<GetOrderPackageInfoResult> GetPackageInfo(GetOrderPackageInfo message, CancellationToken token = default)
        {
            var order = await _dbContext.Orders.AsNoTracking().Include(x => x.User).Include(x => x.Products).ThenInclude(x => x.Product).Where(x => x.Id == message.OrderId).ProjectTo<GetOrderPackageInfoResult>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(token);
            if (order is null) throw new Exception("Order not found");
            return order;
        }
        public virtual async Task SetStatus(StatusOrder message, CancellationToken token = default)
        {
            var order = await _dbContext.Orders.Where(x => x.Id == message.OrderId).SingleOrDefaultAsync(token);
            if (order is null) throw new Exception("Order not found");
            order.Status = message.SetTo;
            await _dbContext.SaveChangesAsync(token);

            _logger.LogInformation("Order {id} changed status to: {status}", order.Id, message.SetTo);
        }
    }
}