﻿using DAL.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DAl.Tests.Integration;

public class CustomWebApplicationFactory<TProgram> :
    WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor =
                services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<ApplicationContext>));

            if (dbContextDescriptor is not null)
                services.Remove(dbContextDescriptor);

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "IntegrationTest");
            });
        });
    }
}