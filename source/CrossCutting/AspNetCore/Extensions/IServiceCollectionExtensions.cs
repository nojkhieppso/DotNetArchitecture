using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Solution.CrossCutting.AspNetCore.Providers;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Security;
using Swashbuckle.AspNetCore.Swagger;

namespace Solution.CrossCutting.AspNetCore.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAuthenticationCustom(this IServiceCollection services)
        {
            var jsonWebToken = services.GetService<IJsonWebToken>();

            void JwtBearer(JwtBearerOptions jwtBearer)
            {
                jwtBearer.TokenValidationParameters = jsonWebToken.TokenValidationParameters;
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
        }

        public static void AddMvcCustom(this IServiceCollection services)
        {
            void Mvc(MvcOptions mvc)
            {
                mvc.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            }

            void Json(MvcJsonOptions json)
            {
                json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }

            services.AddMvc(Mvc).AddJsonOptions(Json);
        }

        public static void AddResponseCompressionCustom(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
            });
        }

        public static void AddSpaStaticFilesCustom(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(spa => spa.RootPath = "Frontend/dist");
        }

        public static void AddSwaggerCustom(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg => cfg.SwaggerDoc("api", new Info()));
        }
    }
}
