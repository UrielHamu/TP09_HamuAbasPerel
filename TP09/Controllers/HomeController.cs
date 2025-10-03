using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP09.Models;

namespace TP09.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        Juego juegoAhorcado = new Juego();
        ViewBag.jugadoresCompitieron = juegoAhorcado.devolverListaUsuarios();
        HttpContext.Session.SetString("juegoAhorcado", Objeto.ObjectToString(juegoAhorcado));

        return View("Index");
    }
    public IActionResult comenzar(string username, int dificultad)
    {
        Juego juegoAhorcado = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juegoAhorcado"));
        ViewBag.palabraActual = juegoAhorcado.inicializarJuego(username, dificultad);
        ViewBag.nombreUsuario = juegoAhorcado.mostrarNombre(username);
        HttpContext.Session.SetString("juegoAhorcado", Objeto.ObjectToString(juegoAhorcado));
        return View("Juego");
    }
    public IActionResult finJuego(int intentos)
    {
        Juego juegoAhorcado = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juegoAhorcado"));
        juegoAhorcado.finJuego(intentos);
        HttpContext.Session.SetString("juegoAhorcado", Objeto.ObjectToString(juegoAhorcado));
        return RedirectToAction("Index");
    }
}
