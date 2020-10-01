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
    private ICommentsService _commentsService;

    public PhotosService(IGalleryApi galleryApi, ICommentsService commentsService)
    {
      _galleryApi = galleryApi;
      _commentsService = commentsService;
    }

    public async Task<List<PhotoViewModel>> GetPhotosByAlbumId(int albumId)
    {
      var response = await _galleryApi.GetPhotosByAlbumId(albumId);
      var photos = response.Select(x => new PhotoViewModel
      {
        Id = x.Id,
        ThumbnailUrl = x.ThumbnailUrl,
        Title = x.Title,
        Comments = x.Comments.Select(y => new CommentViewModel
                    {
                      Id = y.Id,
                      Body =y.Body,
                      Name = y.Name
                    }).ToList()
      }).ToList();

      return photos;
    }
    public async Task<PhotoViewModel> GetPhotoById(int photoId)
    {
      var response = await _galleryApi.GetPhotoById(photoId);
      var comments = await _commentsService.GetCommentsByPhotoId(photoId);

      PhotoViewModel photo = new PhotoViewModel() 
      {
        Id = response.Id,
        Title = response.Title,
        Url = response.Url,
        Comments = comments ?? comments
      };

      return photo;
    }


  }
}
