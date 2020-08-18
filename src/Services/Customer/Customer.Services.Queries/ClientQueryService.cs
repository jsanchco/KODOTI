namespace Customer.Services.Queries
{
    #region Using

    using Customer.Persistence.Database;
    using Customer.Services.Queries.DTOs;
    using Microsoft.EntityFrameworkCore;
    using Service.Common.Collection;
    using Service.Common.Mapping;
    using Service.Common.Paging;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion

    public interface IClientQueryService
    {
        Task<DataCollection<ClientDto>> GetAllAsync(int page, int take, IEnumerable<int> clients = null);
        Task<ClientDto> GetAsync(int id);
    }

    public class ClientQueryService : IClientQueryService
    {
        private readonly ApplicationDbContext _context;

        public ClientQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ClientDto>> GetAllAsync(int page, int take, IEnumerable<int> clients = null)
        {
            var collection = await _context.Clients
                .Where(x => clients == null || clients.Contains(x.Id))
                .OrderByDescending(x => x.Id)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ClientDto>>();
        }

        public async Task<ClientDto> GetAsync(int id)
        {
            var client = await _context.Clients.SingleAsync(x => x.Id == id);

            return (await _context.Clients.SingleAsync(x => x.Id == id)).MapTo<ClientDto>();
        }
    }
}
