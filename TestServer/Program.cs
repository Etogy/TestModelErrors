using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TestServer {
  /// <summary>
  /// The main entry point of the program.
  /// </summary>
  public class Program {
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    /// <param name="args">A collection of arguments passed to the program.</param>
    public static void Main(string[] args) {
      CreateWebHostBuilder(args).Build().Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
  }
}
