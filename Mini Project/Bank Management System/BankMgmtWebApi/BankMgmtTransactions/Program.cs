
using BankMgmtTransactions.Data;
using BankMgmtTransactions.Repository;
using BankMgmtTransactions.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BankMgmtTransactions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();
            builder.Services.AddScoped<ITransactionService, TransactionServices>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<TransactionServices>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidIssuer = "BankMgmtWAPIAuth",
                  ValidAudience = "BankMgmtTransactions",
                  IssuerSigningKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
              };
          });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();


            app.Run();
        }
    }
}
