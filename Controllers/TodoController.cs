using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        if (ModelState.IsValid)
        {
            todo.CreatedAt = DateTime.Now;
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "New Task";
        return View("Form", todo);
    }

    public IActionResult Edit(int id) 
    {
        ViewData["Title"] = "Edit Task";
        var todo = _context.Todos.Find(id);
        if(todo is null)
        {
            return NotFound();
        }
        return View("Form", todo);
    }

    [HttpPost]
    public IActionResult Edit(Todo todo)
    {
        if (ModelState.IsValid)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Edit Task";
        return View("Form", todo);
    }

    public IActionResult Delete(int id)
    {
        ViewData["Title"] = "Delete task";
        var todo = _context.Todos.Find(id);
        if(todo is null)
        {
            return NotFound();
        }
        return View(todo);
    }

    [HttpPost]
    public IActionResult Delete(Todo todo)
    {
        _context.Todos.Remove(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Finish(int id)
    {
        var todo = _context.Todos.Find(id);
        if(todo is null)
        {
            return NotFound();
        }
        todo.Finish();
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}