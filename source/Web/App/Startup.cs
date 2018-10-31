using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.CrossCutting.AspNetCore.Extensions;

namespace Solution.Web.App
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            Configuration = environment.Configuration();
            Environment = environment;
        }

        private IConfiguration Configuration { get; }

        private IHostingEnvironment Environment { get; }

        public void Configure(IApplicationBuilder application)
        {
            application.UseExceptionCustom(Environment);
            application.UseAuthentication();
            application.UseCorsCustom();
            application.UseHstsCustom(Environment);
            application.UseHttpsRedirection();
            application.UseResponseCompression();
            application.UseResponseCaching();
            application.UseStaticFiles();
            application.UseMvcWithDefaultRoute();
            application.UseSwaggerCustom();
            application.UseSpaStaticFiles();
            application.UseSpaCustom(Environment);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjectionCustom(Configuration);
            services.AddAuthenticationCustom();
            services.AddCors();
            services.AddResponseCompressionCustom();
            services.AddResponseCaching();
            services.AddMvcCustom();
            services.AddSwaggerCustom();
            services.AddSpaStaticFilesCustom();
        }
    }
}
