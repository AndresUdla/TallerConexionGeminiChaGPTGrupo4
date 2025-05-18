namespace TallerConexionGeminiChaGPTGrupo4.Interfaces
{
    public class IGroqRepository
    {
        Task<string> GetResponseAsync(string prompt);
    }
}
