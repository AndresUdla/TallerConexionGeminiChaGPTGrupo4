using System.Collections.Generic;

namespace TallerConexionGeminiChaGPTGrupo4.Models
{
    public class GroqResponse
    {
        public List<Choice> choices { get; set; }
    }

    public class Choice
    {
        public Message message { get; set; }
    }
}
