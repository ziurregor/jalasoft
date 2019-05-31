namespace Jalasoft.Eva.Evaluations.Api.Rest.AppStart
{
    using System.Configuration;
    using Jalasoft.Eva.Evaluations.Services.Facade;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            this.RegisterServices();
            services.AddCors()
                .AddMvcCore()
                .AddFormatterMappings()
                .AddJsonFormatters()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
        }

        private void RegisterServices()
        {
            var servicesDll = ConfigurationManager.AppSettings["servicesDll"];
            ServicesFacade.Instance.RegisterHealthService(servicesDll);
            ServicesFacade.Instance.RegisterEvaluationsService(servicesDll);
            ServicesFacade.Instance.RegisterTemplatesService(servicesDll);
            ServicesFacade.Instance.RegisterAnswersService(servicesDll);
            ServicesFacade.Instance.RegisterScoreService(servicesDll);
        }
    }
}
