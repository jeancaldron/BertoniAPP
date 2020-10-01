using BertoniAPP.DAL.Gallery.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BertoniAPP.Infrastructure.DataSources.Interfaces
{
  public interface IGalleryApi
  {
    Task<List<Album>> GetAllAlbums();
    Task<List<Photo>> GetPhotosById(int albumId);
    Task<List<Comment>> GetCommentsByPhotoId(int photoId);
    
  }
}