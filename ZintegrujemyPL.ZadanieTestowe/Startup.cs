using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ZintegrujemyPL.ZadanieTestowe.Infrastructure.Data;
using FluentMigrator.Runner;
using ZintegrujemyPL.ZadanieTestowe.Infrastructure.Migrations;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.DataContexts;
using ZintegrujemyPL.ZadanieTestowe.Core.Settings;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Files;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.Files;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.Csv;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Download;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.Download;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvReaders;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvConfigurations;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvConfigurations;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvMappers;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.CsvMappers;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.CsvReaders;
using ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.AutoMapperProfiles;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Prices;
using ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Prices;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Repositories.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Infrastructure.Repositores.Inventories;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Integrations;
using ZintegrujemyPL.ZadanieTestowe.Core.Services.Integrations;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Products;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Validators.Integrations;
using ZintegrujemyPL.ZadanieTestowe.Core.Validators.Integrations;

namespace ZintegrujemyPL.ZadanieTestowe
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
            services.AddScoped<IAppDbContext>(provider => new AppDbContext(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZintegrujemyPL.ZadanieTestowe", Version = "v1" });
            });

            services.AddHttpClient();

            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(Configuration.GetConnectionString("DefaultConnection"))
                    .ScanIn(typeof(InitialMigration).Assembly).For.Migrations());


            services.AddSingleton<IntegrationSettings>(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();

                return configuration.GetSection("IntegrationSettings")
                    .Get<IntegrationSettings>();
            });

            services.AddAutoMapper(typeof(Startup), typeof(AutoMapperProfile));

            services.AddTransient<IIntegrationService, IntegrationService>();
            services.AddTransient<IFileWriterService, FileWriterService>();
            services.AddTransient<ICsvReaderService, CsvReaderService>();
            services.AddTransient<IDownloadService, DownloadService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<ICsvConfigurationProvider, CsvConfigurationProvider>();
            services.AddTransient<IProductCsvConfigurationProvider, ProductCsvConfigurationProvider>();
            services.AddTransient<IInventoryCsvConfigurationProvider, InventoryCsvConfigurationProvider>();
            services.AddTransient<IPriceCsvConfigurationProvider, PriceCsvConfigurationProvider>();

            services.AddTransient<ICsvMapperService, CsvMapperService>();
            services.AddTransient<IInventoryCsvMapperService, InventoryCsvMapperService>();
            services.AddTransient<IPriceCsvMapperService, PriceCsvMapperService>();

            services.AddTransient<IProductCsvReaderService, ProductCsvReaderService>();
            services.AddTransient<IInventoryCsvReaderService, InventoryCsvReaderService>();
            services.AddTransient<IPriceCsvReaderService, PriceCsvReaderService>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();

            services.AddTransient<IIntegrationSettingsValidator, IntegrationSettingsValidator>();
            services.AddTransient<IIntegrationDescValidator,  IntegrationDescValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZintegrujemyPL.ZadanieTestowe v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            using IServiceScope scope = serviceScope;
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
