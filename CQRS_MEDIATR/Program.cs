global using Microsoft.EntityFrameworkCore;
global using MediatR;
using AutoMapper;
using CQRS_MEDIATR.Data;
using CQRS_MEDIATR.Mapping;
using CQRS_MEDIATR.Model;
using CQRS_MEDIATR.Services.Abstract.BaseService;
using CQRS_MEDIATR.Services.Abstract.StudentService;
using CQRS_MEDIATR.Services.Concret.StudentService;
using MediatR;
using System.Reflection;

namespace CQRS_MEDIATR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddAutoMapper(typeof(Map));
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddDbContext<DataContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbKey")));
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
        }
    }
}