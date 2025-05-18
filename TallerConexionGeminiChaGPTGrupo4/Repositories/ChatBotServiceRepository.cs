using System.Threading.Tasks;
using TallerConexionGeminiChaGPTGrupo4.Interfaces;

namespace TallerConexionGeminiChaGPTGrupo4.Repositories
{
    public class ChatBotServiceRepository : IChatBotService
    {
        private readonly IGeminiRepository _geminiRepository;
        private readonly IGroqRepository _groqRepository;

        public ChatBotServiceRepository(IGeminiRepository geminiRepository, IGroqRepository groqRepository)
        {
            _geminiRepository = geminiRepository;
            _groqRepository = groqRepository;
        }

        public async Task<string> GetChatBotResponse(string prompt, string provider)
        {
            // provider puede ser "gemini" o "groq"
            if (provider.ToLower() == "gemini")
            {
                return await _geminiRepository.GetResponseAsync(prompt);
            }
            else if (provider.ToLower() == "groq")
            {
                return await _groqRepository.GetResponseAsync(prompt);
            }
            else
            {
                return "Proveedor no soportado.";
            }
        }
    }
}
