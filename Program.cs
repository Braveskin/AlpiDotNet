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


            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
