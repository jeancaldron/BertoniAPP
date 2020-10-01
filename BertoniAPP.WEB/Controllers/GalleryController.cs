using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BertoniAPP.WEB.Models;
using BertoniAPP.BLL.Services.Interfaces;
using System.Threading.Tasks;

namespace BertoniAPP.WEB.Controllers
{
  public class GalleryController : Controller
  {
    private readonly IAlbumsService _albumsService;
    private readonly IPhotosService _photosService;

    public GalleryController(IAlbumsService albumsService,IPhotosService photosService,ICommentsService commentsService)
    {
      _albumsService = albumsService;
      _photosService = photosService;
    }

    public async Task<IActionResult> Index()
    {
      var albums = await _albumsService.GetAllAlbums();

      return View(albums);
    }

    public async Task<IActionResult> Photos(int Id)
    {
      var photos = await _photosService.GetPhotosByAlbumId(Id);

      return View(photos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
