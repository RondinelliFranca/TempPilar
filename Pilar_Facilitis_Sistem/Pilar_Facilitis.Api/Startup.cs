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
using Swashbuckle.AspNetCore.Swagger;
//using Microsoft.EntityFrameworkCore;
using Pilar_Facilitis.Infra.Data.Contexts.Base;

namespace Pilar_Facilitis.Api
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
            services.AddDbContext<ContextPilarFacilitis>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PilarFacilitisConnectionString")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();

                options.SwaggerDoc("v1", new Info
                {
                    Title = "Pilar Facilitis",
                    Version = "v1",
                    Description = "Service API",
                    TermsOfService = "Terms Of Service",
                    Contact = new Contact
                    {
                        Name = "Marcus Vinicius",
                        Email = "Marcus@gmail.com.br",
                        Url = "http://www.marcus.com.br"
                    },
                    License = new License
                    {
                        Name = "Apache 2.0",
                        Url = "http://www.apache.org/licenses/LICENSE-2.0.html"
                    }
                });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pilar Facilitis API");
            });
        }
    }
}
