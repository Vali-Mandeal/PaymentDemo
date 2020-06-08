using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PaymentDemo.Helpers;
using PaymentDemo.Persistance;
using PaymentDemo.Persistance.Repositories;
using PaymentDemo.Persistance.Repositories.Interfaces;
using PaymentDemo.Services.Business;
using PaymentDemo.Services.Business.Interfaces;
using PaymentDemo.Services.Validators;

namespace PaymentDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContextPool<DataContext>(options =>
                options.UseSqlServer
                (
                    //Configuration.GetConnectionString("PaymentsDb"
                    Environment.GetEnvironmentVariable(EnvironmentVariables.ConnectionString
                )));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
            services.AddScoped<IValidator, PaymentValidator>();

            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<PaymentGatewayManager>();

            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddScoped<IPremiumPaymentGateway, PremiumPaymentGateway>();

            services.AddAutoMapper(typeof(DataContext).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment Demo API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BMP.HRA API V1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
