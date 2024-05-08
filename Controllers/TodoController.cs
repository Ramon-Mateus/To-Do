using Microsoft.AspNetCore.Mvc;
using To_Do.Context;
using To_Do.Models;

namespace To_Do.Controllers;

public class TodoController : Controller {

    private readonly TodoContext _context;

    public TodoController(TodoContext context) => _context = context;

    public IActionResult Index()
    {
        ViewData["Title"] = "To Do List";
        var todos = _context.Todos.ToList();
        return View(todos);
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "New Task";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create(Todo todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}