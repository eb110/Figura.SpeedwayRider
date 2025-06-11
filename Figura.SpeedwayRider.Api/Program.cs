using Figura.SpeedwayRider.Api;
using Microsoft.AspNetCore.Hosting;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return
               Host.CreateDefaultBuilder(args)
           .ConfigureWebHostDefaults(webBuilder =>
           {

               webBuilder
               .UseUrls("http://0.0.0.0:5000")
                        .UseStartup<Startup>();
           });
    }
}