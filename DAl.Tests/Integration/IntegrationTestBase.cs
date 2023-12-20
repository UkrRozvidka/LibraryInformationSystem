using DAL.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace DAl.Tests.Integration
{
    public abstract class IntegrationTestsBase : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        protected readonly CustomWebApplicationFactory<Program> factory;
        protected readonly ApplicationContext context;
        protected readonly HttpClient client;
        protected readonly IConfiguration configuration;

        public IntegrationTestsBase(CustomWebApplicationFactory<Program> factory)
        {
            this.factory = factory;

            var scope = this.factory.Services.CreateScope();

            this.context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            this.configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            this.client = this.factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}
