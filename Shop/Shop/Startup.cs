using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Models;
using Shop.Services;
using Shop.ModelsDto;
namespace Shop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connectionString = @"Data Source=localhost;Initial Catalog=Shoop;Integrated Security=True";
            services.AddDbContext<ShoopContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IShopRepository, ShopRepository>();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.Customer, ModelsDto.CustomerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName}"));
                cfg.CreateMap<ModelsDto.CustomerForCreationDto, Models.Customer>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
          

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
