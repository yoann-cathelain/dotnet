
using Microsoft.EntityFrameworkCore;
using WebAPI_TP3.Models.DataManager;
using WebAPI_TP3.Models.EntityFramework;
using WebAPI_TP3.Models.Repository;

namespace WebAPI_TP3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddScoped<IDataRepository<Utilisateur>, UtilisateurManager>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<PostgresContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PgContext")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
