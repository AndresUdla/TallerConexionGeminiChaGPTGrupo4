using System.Collections.Generic;

namespace TallerConexionGeminiChaGPTGrupo4.Models
{
    public class GeminiResponse
    {
        public List<Candidate> candidates { get; set; }
    }

    public class Candidate
    {
        public Content content { get; set; }
    }
}
