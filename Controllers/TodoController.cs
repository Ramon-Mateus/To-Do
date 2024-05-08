using Microsoft.AspNetCore.Mvc;
using To_Do.Context;

namespace To_Do.Controllers;

public class TodoController : Controller {

    private readonly TodoContext _context;

    public TodoController(TodoContext context) => _context = context;

    public IActionResult Index() {
        ViewData["Title"] = "To Do List";
        var todos = _context.Todos.ToList();
        return View(todos);
    }
    
}