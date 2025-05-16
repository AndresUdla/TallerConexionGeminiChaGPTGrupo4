namespace TallerConexionGeminiChaGPTGrupo4.Interfaces
{
    public interface IChatBotService
    {
        public Task<string> GetChatBotResponse(string prompt);
    }
}
