var builder = WebApplication.CreateBuilder(args);
//Application Lifecycle'da (Http request de DAHİL) kullanacağınız nesneleri; builder.Build() metodunu çağırmadan önce, builder.Services'a ekleyiniz.
//Örneğin uygulamada Session'a ihtiyacınız varsa; bunu belirtmek zorundasınız:
//builder.Services.AddSession();
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Http Request ilerlerken yapılacak işler.
if (app.Environment.IsDevelopment())
{
    //app.MapGet("/", () => "Development mode!");
}
//else
//{
//    app.MapGet("/", () => "Production mode on");
//}

//app.Run demeden önce; HttpRequest üzerinde çalışacak her bir iş (Middleware) çalışma sırasına göre (pipeline) eklenmmelidir.
//app.UseAuthentication();
//app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));



app.Run();
