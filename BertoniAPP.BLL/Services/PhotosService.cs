using BertoniAPP.BLL.Gallery.ViewModels;
using BertoniAPP.BLL.Services.Interfaces;
using BertoniAPP.Infrastructure.DataSources.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAPP.BLL.Services
{
  public class PhotosService : IPhotosService
  {
    private IGalleryApi _galleryApi;

    public PhotosService(IGalleryApi galleryApi)
    {
      _galleryApi = galleryApi;
    }

    public async Task<List<PhotoViewModel>> GetPhotosById(int photoId)
    {
      var response = await _galleryApi.GetPhotosById(photoId);
      var comments = response.Select(x => new PhotoViewModel
      {
        Id = x.Id,
        Title = x.Title,
        Url = x.Url,
        ThumbnailUrl = x.ThumbnailUrl
      }).ToList();

      return comments;
    }
  }
}
