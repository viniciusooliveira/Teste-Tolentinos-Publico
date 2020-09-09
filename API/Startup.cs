using Amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tolentinos.Domain.Entities;
using Tolentinos.Domain.Interfaces;
using Tolentinos.Infra.Data.IO;
using Tolentinos.Infra.Data.Repository;
using Tolentinos.Service.Services;
using Amazon.S3;
using Tolentinos.Infra.Data.Cache;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Newtonsoft.Json;

namespace API
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
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });


            //Db
            services.AddDbContext<Tolentinos.Infra.Data.Context.TolentinosContext>(o => o.UseMySql(Configuration.GetConnectionString("mariadb")));

            //AWS Services
            Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", Configuration["AWS:AccessKey"]);
            Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", Configuration["AWS:SecretKey"]);
            Environment.SetEnvironmentVariable("AWS_REGION", Configuration["AWS:Region"]);

            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();

            //Upload
            services.AddScoped<IFileUploadHandler, S3FileUploadHandler>(x => 
                new S3FileUploadHandler("teste-tolentinos", 
                Amazon.RegionEndpoint.SAEast1, 
                x.GetService<IAmazonS3>()));

            //Redis cache
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("redis");
            });

            var distributedCacheEntryOptions = new DistributedCacheEntryOptions();
            distributedCacheEntryOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            distributedCacheEntryOptions.SetSlidingExpiration(TimeSpan.FromDays(1));

            services.AddScoped<DistributedCacheHandler>(x =>
                new DistributedCacheHandler(
                    x.GetService<IDistributedCache>(), 
                    distributedCacheEntryOptions
                )
            );

            //Repositórios
            services.AddScoped<IRepository<Carrinho>, BaseRepository<Carrinho>>();
            services.AddScoped<IRepository<Categoria>, BaseRepository<Categoria>>();
            services.AddScoped<IRepository<ImagemProduto>, BaseRepository<ImagemProduto>>();
            services.AddScoped<IRepository<ItemCarrinho>, BaseRepository<ItemCarrinho>>();
            services.AddScoped<IRepository<Marca>, BaseRepository<Marca>>();
            services.AddScoped<IRepository<Produto>, BaseRepository<Produto>>();

            //Serviços
            services.AddScoped<CarrinhoService>();
            services.AddScoped<CategoriaService>();
            services.AddScoped<ImagemProdutoService>();
            services.AddScoped<ItemCarrinhoService>();
            services.AddScoped<MarcaService>();
            services.AddScoped<ProdutoService>();
            services.AddScoped<IService<Produto>, ProdutoService>();

            services.AddSwaggerGen();

        }

        public void InitializeBd(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Tolentinos.Infra.Data.Context.TolentinosContext>();

                // auto migration
                context.Database.Migrate();

            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeBd(app.ApplicationServices);
        }
    }
}
