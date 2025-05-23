﻿using System.Collections.Generic;

namespace TallerConexionGeminiChaGPTGrupo4.Models
{
    public class GeminiRequest
    {
        public List<Content> contents { get; set; }
    }

    public class Content
    {
        public List<Part> parts { get; set; }
    }

    public class Part
    {
        public string text { get; set; }
    }
}
