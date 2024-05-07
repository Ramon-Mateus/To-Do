using Microsoft.AspNetCore.Mvc;

namespace To_Do.Controllers;

public class TesteController : Controller
{
    public IActionResult Index() {
        return View();
    }

    public IActionResult Rota2() {
        return View();
    }
}