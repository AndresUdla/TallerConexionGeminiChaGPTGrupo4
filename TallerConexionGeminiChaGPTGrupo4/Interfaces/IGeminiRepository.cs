namespace TallerConexionGeminiChaGPTGrupo4.Interfaces
{
    public interface IGeminiRepository
    {
        Task<string> GetResponseAsync(string prompt);
    }
}
