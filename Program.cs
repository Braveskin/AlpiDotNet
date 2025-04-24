using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;

namespace AlpiDotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            var app = builder.Build();
            app.Urls.Add("http://*:80");
            app.Urls.Add("http://*:5000");




            app.MapGet("/", () => {

                try {
                    var currentProcess = Process.GetCurrentProcess();
                    var processStart = new ProcessStartInfo("cat", "/proc/" + currentProcess.Id + "/smaps | grep -m 1 -e ^Size: | awk '{print $2}'");
                    using var process = Process.Start(processStart);
                
                    if (process == null) {
                        return "Could not start process.";
                    }
                    var size = process.StandardOutput.ReadLine();

                    return "Hello World! Size: " + size;
                }
                catch (Exception ex) {
                    return "Error: " + ex.ToString();
                }

            });

            app.Run();
        }
    }
}
