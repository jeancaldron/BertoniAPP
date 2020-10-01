using BertoniAPP.DAL.Gallery.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using BertoniAPP.Infrastructure.DataSources.Interfaces;

namespace BertoniAPP.Infrastructure.DataSources
{
  public class GalleryApi : IGalleryApi
  {
    private readonly HttpClient httpClient;

    public GalleryApi()
    {
      httpClient = new HttpClient
      {
        BaseAddress = new Uri("http://jsonplaceholder.typicode.com/")
      };
    }

    public async Task<List<Album>> GetAllAlbums()
    {
      var response = await httpClient.GetAsync("/albums");
      var jsonResponse = await response.Content.ReadAsStringAsync();
      List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(jsonResponse);

      return albums;
    }

    public async Task<List<Photo>> GetPhotosById(int albumId)
    {
      var response = await httpClient.GetAsync("/photos");
      var jsonResponse = await response.Content.ReadAsStringAsync();
      List<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(jsonResponse).Where(photo => photo.AlbumId == albumId).ToList();

      return photos;
    }

    public async Task<List<Comment>> GetCommentsByPhotoId(int photoId)
    {
      var response = await httpClient.GetAsync("/comments");
      var jsonResponse = await response.Content.ReadAsStringAsync();
      List<Comment> comments = JsonConvert.DeserializeObject<List<Comment>>(jsonResponse).Where(comment => comment.PostId == photoId).ToList();

      return comments;
    }
  }
}
