using BookMarket.Web;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Web.Controllers;

[Controller]
[Route("{controller}")]
public class HomeController : Controller
{
    [Route("{action}")]
    public async Task<IActionResult> Index()
    {
        return View();
    }
}