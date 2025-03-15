using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.ViewModels;


namespace TechStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Produto> produtos = _context.Produtos
        .Where(p => p.Destaque)
        .Include(p => p.Fotos)
        .ToList();
        return View(produtos);
    }

    public IActionResult Produto(int id)
    {
        Produto produto = _context.Produtos
        .Where(p => p.Id == id)
        .Include(p => p.categoria)
        .Include(p => p.Fotos)
        .SingleOrDefault();

        ProdutoVM produtoVM = new()
        {
            Produto = produto
        };

        produtoVM.Produtos = _context.Produtos
        .Where(p => p.CategoriaId == produto.CategoriaId
            && p.Id != produto.Id)
        .Take(4)
        .Include(p => p.Fotos)
        .ToList();

        return View(produtoVM);
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
