using Microsoft.EntityFrameworkCore;
using TallerConexionGeminiChaGPTGrupo4.Interfaces;
using TallerConexionGeminiChaGPTGrupo4.Repositories;
using TallerConexionGeminiChaGPTGrupo4.DbContext; // Asegúrate de que este namespace coincida con donde creaste el ApplicationDbContext

var builder = WebApplication.CreateBuilder(args);

// Agregar el contexto de base de datos con la cadena de conexión desde appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inyección de HttpClient para los repositorios
builder.Services.AddHttpClient<IGeminiRepository, GeminiRepository>();
builder.Services.AddHttpClient<IGroqRepository, GroqRepository>();

// Inyección del servicio principal del chatbot
builder.Services.AddScoped<IChatBotService, ChatBotServiceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
