using System;
using System.Linq;
using ToyUniverse.Data.Context;
using ToyUniverse.Data.Models;
using ToyUniverse.Data.Repositories;
using ToyUniverse.Web.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace ToyUniverse.Web.Services
{
    public class CartService
    {
    }
    public interface ICartService
    {
        public PagedResult<Toy> GetToyPage(int currentPage);
    }
}