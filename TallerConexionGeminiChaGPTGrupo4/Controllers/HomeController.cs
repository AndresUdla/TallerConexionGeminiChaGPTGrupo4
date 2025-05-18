using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TallerConexionGeminiChaGPTGrupo4.Interfaces;
using TallerConexionGeminiChaGPTGrupo4.Models;
using TallerConexionGeminiChaGPTGrupo4.Repositories;

namespace TallerConexionGeminiChaGPTGrupo4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChatBotService _chatBotService;

        public HomeController(ILogger<HomeController> logger, IChatBotService chatBotService)
        {
            _logger = logger;
            _chatBotService = chatBotService;
        }

        public async Task<IActionResult> Index()
        {
            
            string answer = await _chatBotService.GetChatBotResponse("¿Que es el FC Barcelona?");

            return View(answer);
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
}
