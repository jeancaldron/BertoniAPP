using BertoniAPP.BLL.Gallery.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BertoniAPP.BLL.Services.Interfaces
{
  public interface ICommentsService
  {
    Task<List<CommentViewModel>> GetCommentsById(int photoId);
  }
}