using System;
using System.Linq;
using ToyUniverse.Data.Context;
using ToyUniverse.Data.Models;
using ToyUniverse.Web.Models;

namespace ToyUniverse.Web.Services
{
    public abstract class GenericService
    {
        public ToyUniverseDbContext Context { get; set; }
        public GenericService(ToyUniverseDbContext context)
        {
            this.Context = context;
        }
        public PagedResult<T> GetPaged<T>(IQueryable<T> query,
                                 int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = page == 0 ? 0 : (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}