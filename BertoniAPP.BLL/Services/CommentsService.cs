using BertoniAPP.BLL.Gallery.ViewModels;
using BertoniAPP.BLL.Services.Interfaces;
using BertoniAPP.Infrastructure.DataSources.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniAPP.BLL.Services
{
  public class CommentsService : ICommentsService
  {
    private IGalleryApi _galleryApi;

    public CommentsService(IGalleryApi galleryApi)
    {
      _galleryApi = galleryApi;
    }

    public async Task<List<CommentViewModel>> GetCommentsById(int photoId)
    {
      var response = await _galleryApi.GetCommentsByPhotoId(photoId);
      var comments = response.Select(x => new CommentViewModel
      {
        Id = x.Id,
        Name = x.Name,
        Body = x.Body
      }).ToList();

      return comments;
    }
  }
}
