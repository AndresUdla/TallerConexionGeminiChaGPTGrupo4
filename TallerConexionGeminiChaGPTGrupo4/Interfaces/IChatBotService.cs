namespace TallerConexionGeminiChaGPTGrupo4.Interfaces
{
    public interface IChatBotService
    {
        Task<string> GetChatBotResponse(string prompt, string provider);
    }
}
