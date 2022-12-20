using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using usingDependenciInjection.Models;
using usingDependenciInjection.Services;

namespace usingDependenciInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            //Bağımlılığın; o nesneye bağlı olan (HomeController) nesnenin içerisinde üretilmemesi gerekir.
            //var productService = new ProductService();

            var products = _productService.GetProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class SimsHuman
    {
        public void TakeOn(IKiyafet kiyafet)
        {

        }
    }

    public interface IKiyafet
    {
        string Name { get; }
    }

    public class RedSweeter
    {

    }
}
