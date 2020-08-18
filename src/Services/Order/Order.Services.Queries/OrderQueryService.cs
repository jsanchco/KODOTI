namespace Order.Services.Queries
{
    #region Using

    using Microsoft.EntityFrameworkCore;
    using Order.Persistence.Database;
    using Order.Services.Queries.DTOs;
    using Service.Common.Collection;
    using Service.Common.Mapping;
    using Service.Common.Paging;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion

    public interface IOrderQueryService
    {
        Task<DataCollection<OrderDto>> GetAllAsync(int page, int take, IEnumerable<int> clients = null);
        Task<OrderDto> GetAsync(int id);
    }

    public class OrderQueryService : IOrderQueryService
    {
        private readonly ApplicationDbContext _context;

        public OrderQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<OrderDto>> GetAllAsync(int page, int take, IEnumerable<int> orders = null)
        {
            var collection = await _context.Orders
                .Where(x => orders == null || orders.Contains(x.Id))
                .OrderByDescending(x => x.Id)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<OrderDto>>();
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            var client = await _context.Orders.SingleAsync(x => x.Id == id);

            return (await _context.Orders.SingleAsync(x => x.Id == id)).MapTo<OrderDto>();
        }
    }
}
