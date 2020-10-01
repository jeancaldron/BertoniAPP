using BertoniAPP.BLL.Services;
using BertoniAPP.BLL.Services.Interfaces;
using BertoniAPP.Infrastructure.DataSources;
using BertoniAPP.Infrastructure.DataSources.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BertoniAPP.WEB
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();
      services.AddSingleton<IGalleryApi, GalleryApi>();
      services.AddSingleton<IAlbumsService, AlbumsService>();
      services.AddSingleton<IPhotosService, PhotosService>();
      services.AddSingleton<ICommentsService, CommentsService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Gallery/Error");
      }
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Gallery}/{action=Index}/{id?}");
      });
    }
  }
}
