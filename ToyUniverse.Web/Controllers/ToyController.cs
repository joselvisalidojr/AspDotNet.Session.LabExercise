using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ToyUniverse.Data.Repositories;
using ToyUniverse.Web.Services;

namespace ToyUniverseWeb.Controllers
{
    public class ToyController : Controller
    {
        private readonly IToyRepository toyRepository;
        private readonly IToyService toyService;

        public ToyController(IToyService toyService, IToyRepository toyRepository)
        {
            this.toyService = toyService;
            this.toyRepository = toyRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(toyService.GetToyPage(1, 10));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex, int pageSize)
        {
            return View(toyService.GetToyPage(currentPageIndex, pageSize));
        }

        public IActionResult Details(string id)
        {
            var toy = this.toyRepository.FindByPrimaryKey(id);
            ViewData["Toy"] = toy;
            return View();
        }
    }
}