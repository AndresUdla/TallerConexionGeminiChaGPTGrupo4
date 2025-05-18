namespace TallerConexionGeminiChaGPTGrupo4.Interfaces
{
    public interface IGroqRepository
    {
        Task<string> GetResponseAsync(string prompt);
    }
}
