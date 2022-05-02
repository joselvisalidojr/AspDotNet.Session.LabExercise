using System;
using System.Linq;
using ToyUniverse.Data.Context;
using ToyUniverse.Data.Models;
using ToyUniverse.Data.Repositories;
using ToyUniverse.Web.Models;


namespace ToyUniverse.Web.Services
{
    public interface IToyService
    {
        public PagedResult<Toy> GetToyPage(int currentPage, int pageSize);
    }

    public class ToyService : GenericService, IToyService
    {
        private IToyRepository toyRepository;
        public ToyService(IToyRepository toyRepository, ToyUniverseDbContext context) : base(context)
        {
            this.toyRepository = toyRepository;
        }
        public PagedResult<Toy> GetToyPage(int currentPage, int pageSize)
        {
            return GetPaged<Toy>(toyRepository.Context.Toys, currentPage, pageSize);
        }
    }
}