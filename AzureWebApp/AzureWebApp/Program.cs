using Apex.Logging;
using Apex.Logging.Grpc;
using Apex.Logging.Middlewares;
using AzureWebApp.Infrastructure;
using AzureWebApp.Infrastructure.Configuration;
using AzureWebApp.Infrastructure.Swagger;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;

Log.Logger = new LoggerConfiguration()
          .WriteTo.Console()
          .CreateBootstrapLogger();
try
{

    var builder = WebApplication.CreateBuilder(args);
    //builder.WebHost.ConfigureKestrel(options =>
    //{
    //    options.ListenLocalhost(5063, o => o.Protocols = HttpProtocols.Http1);
    //    options.ListenLocalhost(7063, o => o.Protocols = HttpProtocols.Http2);
    //    // options.ConfigureHttpsDefaults(o => o
    //    //     .ClientCertificateMode = ClientCertificateMode.AllowCertificate); // without this setting the server is not looking for certificates;
    //    // this tells Kestrel to accept the certificate and pass it down
    //    // the middleware pipeline
    //});

    builder.Host
        .ConfigureAppConfiguration((ctx, conf) => builder.Host.ConfigureWithManageIdentity(ctx, conf))
        .ConfigureLogging();

    // Add services to the container.
    builder.Services.AddConfigurations(builder.Configuration);
    //builder.Services.AddAzureAppConfiguration();
    builder.Services.AddAppLogging(builder.Environment, builder.Configuration);
    builder.Services.AddControllers();
    //builder.Services.AddServiceBus();
    builder.Services.AddSwagger();
    builder.Services.AddSoapClients(builder.Configuration);
    //builder.Services.AddSaopClientOuterLogging();
    builder.Services.AddGrpcWithLogging(builder.GrpcEnableDratialsErrors());
    var app = builder.Build();

    //app.UseAzureAppConfiguration();

    app.UseInnerRequestResponseLogging();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        //app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    //app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseHttpLogging();
    app.UseRouting();
    app.UseAuthorization();
    app.ConfigureSwagger();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}");

    app.AddGrpcServices();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occured during bootstrapping");
}
finally
{
    Log.CloseAndFlush();
}

