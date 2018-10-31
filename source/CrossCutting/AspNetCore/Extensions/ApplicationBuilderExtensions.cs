using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Solution.CrossCutting.AspNetCore.Middlewares;

namespace Solution.CrossCutting.AspNetCore.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCorsCustom(this IApplicationBuilder application)
        {
            application.UseCors(cors => cors.AllowAnyOrigin().AllowCredentials().AllowAnyHeader().AllowAnyMethod());
        }

        public static void UseExceptionCustom(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDatabaseErrorPage();
                application.UseDeveloperExceptionPage();
            }

            application.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseHstsCustom(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            if (!environment.IsDevelopment())
            {
                application.UseHsts();
            }
        }

        public static void UseSpaCustom(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            application.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Frontend";

                if (environment.IsDevelopment())
                {
                    spa.UseAngularCliServer("serve");
                }
            });
        }

        public static void UseSwaggerCustom(this IApplicationBuilder application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(cfg => cfg.SwaggerEndpoint("/swagger/api/swagger.json", "API"));
        }
    }
}
