using Microsoft.AspNetCore.Mvc;

public class InicioController : Controller
{
    public IActionResult Inicio()
    {
        return View("Inicio");
    }
}