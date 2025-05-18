namespace TallerConexionGeminiChaGPTGrupo4.Models
{
    public class ChatResponse
    {
        public int Id { get; set; }
        public string Respuesta { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }  // "Gemini" o "Groq"
        public string GuardadoPor { get; set; }  // El nombre del usuario que hizo la pregunta
    }
}
