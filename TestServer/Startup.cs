using TestServer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TestServer {
  public class Startup {
    public Startup(IConfiguration configuration, IHostingEnvironment env) {
      Configuration = configuration;
      CurrentEnvironment = env;
    }

    private IConfiguration Configuration { get; }
    private IHostingEnvironment CurrentEnvironment { get; }

    public void ConfigureServices(IServiceCollection services) {
      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    public void Configure(IApplicationBuilder app, IApplicationLifetime lifetime, ILogger<Startup> logger) {
      if (CurrentEnvironment.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      } else {
        app.UseHsts();
        app.UseHttpsRedirection();
      }

      app.UseMvc();
    }
  }
}
