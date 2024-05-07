using Microsoft.AspNetCore.Mvc;

namespace To_Do.Controllers;

public class TodoController : Controller {

    public IActionResult Index() {
        return View();
    }
    
}