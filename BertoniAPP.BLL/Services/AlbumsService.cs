using BertoniAPP.BLL.Gallery.ViewModels;
using BertoniAPP.BLL.Services.Interfaces;
using BertoniAPP.Infrastructure.DataSources.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAPP.BLL.Services
{
  public class AlbumsService : IAlbumsService
  {
    private IGalleryApi _galleryApi;

    public AlbumsService(IGalleryApi galleryApi)
    {
      _galleryApi = galleryApi;
    }

    public async Task<List<AlbumViewModel>> GetAllAlbums()
    {
      var response = await _galleryApi.GetAllAlbums();
      var albums = response.Select(x => new AlbumViewModel
      {
        Id = x.Id,
        Title = x.Title
      }).ToList();

      return albums;
    }
  }
}
