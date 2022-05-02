using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyUniverse.Data.Context;
using ToyUniverse.Data.Models;

namespace ToyUniverse.Data.Repositories
{
    public interface IShoppingCartRepository : IBaseRepository<ShoppingCart>
    {
    }
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ToyUniverseDbContext context) : base(context)
        {
        }
    }
}