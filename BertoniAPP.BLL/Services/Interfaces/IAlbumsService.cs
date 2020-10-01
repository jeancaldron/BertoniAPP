using BertoniAPP.BLL.Gallery.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BertoniAPP.BLL.Services.Interfaces
{
  public interface IAlbumsService
  {
    Task<List<AlbumViewModel>> GetAllAlbums();
  }
}