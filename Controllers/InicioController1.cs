using Microsoft.AspNetCore.Mvc;

public class InicioController : Controller
{
    public IActionResult Inicio()
    {
        return View(); // Buscará Views/Inicio/inicio.cshtml
    }
}