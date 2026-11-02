using Microsoft.AspNetCore.Mvc;
using FloristeriaBotero.Models;

namespace FloristeriaBotero.Controllers;

public class PedidosController : Controller
{
    private static List<Pedido> _pedidos = new();
    private static int _nextId = 1;

    public IActionResult Index()
    {
        return View(_pedidos);
    }

    public IActionResult Registrar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Registrar(Pedido pedido)
    {
        if (ModelState.IsValid)
        {
            decimal precioBase = 0;
            switch (pedido.Producto)
            {
                case "Ramo de Rosas": precioBase = 45000; break;
                case "Arreglo Primaveral": precioBase = 60000; break;
                case "Orquídea Blanca": precioBase = 80000; break;
                case "Girasoles": precioBase = 35000; break;
            }

            pedido.Total = precioBase * pedido.Cantidad;
            pedido.Id = _nextId++;
            _pedidos.Add(pedido);
            
            TempData["Mensaje"] = $"¡Pedido de {pedido.Cliente} registrado! Total: ${pedido.Total:N0}";
            return RedirectToAction(nameof(Index));
        }
        return View(pedido);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Eliminar(int id)
    {
        var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido != null)
        {
            _pedidos.Remove(pedido);
            TempData["Mensaje"] = "Pedido eliminado correctamente.";
        }
        return RedirectToAction(nameof(Index));
    }
}