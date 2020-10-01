using BertoniAPP.BLL.Gallery.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BertoniAPP.BLL.Services.Interfaces
{
  public interface IPhotosService
  {
    Task<List<PhotoViewModel>> GetPhotosByAlbumId(int albumId);
    Task<PhotoViewModel> GetPhotoById(int photoId);
  }
}