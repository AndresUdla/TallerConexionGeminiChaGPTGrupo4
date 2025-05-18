using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TallerConexionGeminiChaGPTGrupo4.DbContext;
using TallerConexionGeminiChaGPTGrupo4.Interfaces;
using TallerConexionGeminiChaGPTGrupo4.Models;

namespace TallerConexionGeminiChaGPTGrupo4.Controllers
{
    public class ChatBotController : Controller
    {
        private readonly IChatBotService _chatBotService;
        private readonly ApplicationDbContext _dbContext;

        public ChatBotController(IChatBotService chatBotService, ApplicationDbContext dbContext)
        {
            _chatBotService = chatBotService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string prompt, string provider)
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(prompt) || string.IsNullOrWhiteSpace(provider))
            {
                ViewBag.Error = "Por favor selecciona un proveedor y escribe una pregunta.";
                return View();
            }

            try
            {
                // Obtener respuesta desde el proveedor (Gemini o Groq)
                string response = await _chatBotService.GetChatBotResponse(prompt, provider);

                // Guardar en base de datos
                var chatResponse = new ChatResponse
                {
                    Respuesta = response,
                    Fecha = DateTime.Now,
                    Proveedor = provider,
                    GuardadoPor = User.Identity?.Name ?? "Invitado"
                };

                _dbContext.ChatResponses.Add(chatResponse);
                await _dbContext.SaveChangesAsync();

                // Pasar datos a la vista
                ViewBag.Prompt = prompt;
                ViewBag.Provider = provider;
                ViewBag.Response = response;
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al obtener respuesta: {ex.Message}";
            }

            return View();
        }
    }
}
