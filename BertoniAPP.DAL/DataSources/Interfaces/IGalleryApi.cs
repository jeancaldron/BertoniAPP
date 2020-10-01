using BertoniAPP.DAL.Gallery.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BertoniAPP.Infrastructure.DataSources.Interfaces
{
  public interface IGalleryApi
  {
    Task<List<Album>> GetAllAlbums();
    Task<List<Photo>> GetPhotosByAlbumId(int albumId);
    Task<Photo> GetPhotoById(int photoId);    
    Task<List<Comment>> GetCommentsByPhotoId(int photoId);
    
  }
}