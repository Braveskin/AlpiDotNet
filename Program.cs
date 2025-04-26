
using System.Net;
using System.Net.WebSockets;

namespace AlpiDotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            var app = builder.Build();
            
            //app.Urls.Add("http://*:80");
            //app.Urls.Add("http://*:5000");
            //app.Urls.Add("http://*:5226");


            app.UseStaticFiles();
            app.UseRouting();
            //app.UseWebSockets();

            app.MapRazorPages();
            app.MapControllers();
            /*
            app.Map("/ws", async ctx => {

                if (!ctx.WebSockets.IsWebSocketRequest) {
                    ctx.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return;
                }

                using var ws = await ctx.WebSockets.AcceptWebSocketAsync();
                try {
                    //await CameraController.HandleWebsocketConnectionAsync(ws);
                }
                catch (WebSocketException) {}
            });*/

            app.Run();
        }
    }
}
