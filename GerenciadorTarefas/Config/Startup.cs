using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionsApp.Config.Startup))]

namespace FunctionsApp.Config
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddScoped((s) => new TarefasDao());
        }
    }
}