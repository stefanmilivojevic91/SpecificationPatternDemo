﻿using Data;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Shared;
using Domain.UseCases.Reports.Read;
using Domain.UseCases.Reports.Create;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.UseCases.Reports.ReadReport;
using Domain.UseCases.Reports.DeleteReport;
using System;
using Domain.UseCases.Reports.Update;

namespace SpecificationPatternDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = @"User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=test";

            services.AddScoped<IReportRepository, ReportRepository>();

            services.AddScoped<IValidationService, ValidationService>();

            services.AddScoped<IUseCase<ReadReportsRequest, ReadReportsResponse>, ReadReportsUseCase>();
            services.AddScoped<IUseCase<int, ReadReportResponse>, ReadReportUseCase>();
            services.AddScoped<IUseCase<int, DeleteReportResponse>, DeleteReportUseCase>();
            services.AddScoped<IUseCase<CreateReportRequest, CreateReportResponse>, CreateReportUseCase>();
            services.AddScoped<IUseCase<UpdateReportRequest, UpdateReportResponse>, UpdateReportUseCase>();

            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
