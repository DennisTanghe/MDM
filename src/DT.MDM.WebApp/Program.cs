using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DT.MDM.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseWebRoot(@"ng\dist\mdm");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
