using System.Collections.Generic;

namespace TallerConexionGeminiChaGPTGrupo4.Models
{
    public class GroqRequest
    {
        public string model { get; set; } = "llama3-8b-8192";
        public List<Message> messages { get; set; }
    }

    public class Message
    {
        public string role { get; set; }  // "user" o "assistant"
        public string content { get; set; }
    }
}
