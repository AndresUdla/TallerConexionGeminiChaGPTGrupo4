using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TallerConexionGeminiChaGPTGrupo4.Models;

namespace TallerConexionGeminiChaGPTGrupo4.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ChatResponse> ChatResponses { get; set; }
    }
}
