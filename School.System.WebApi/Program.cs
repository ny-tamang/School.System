using Microsoft.EntityFrameworkCore;
using School.System.Data;
using School.System.Repository;
using School.System.Services;

namespace School.System.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //manually added dependy to applicationDbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            static void DependeciesConfig(IServiceCollection services)
            {
                #region Repositories

                services.AddTransient<IStudentRepository, StudentRepository>();

                #endregion Repositories

                #region Services

                services.AddTransient<IStudentService, StudentService>();

                #endregion Services
            }
        }
    }
}