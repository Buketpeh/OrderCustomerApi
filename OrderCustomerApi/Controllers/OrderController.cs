using Microsoft.AspNetCore.Mvc;

namespace OrderCustomerApi.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
