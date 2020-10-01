using BertoniAPP.BLL.Gallery.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BertoniAPP.BLL.Services.Interfaces
{
  public interface IPhotosService
  {
    Task<List<PhotoViewModel>> GetPhotosById(int photoId);
  }
}