using System;
using System.Collections.Generic;
using System.Text;

namespace BertoniAPP.DAL.Gallery.Models
{
  public class Album
  {
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }

    public virtual List<Photo> Photos { get; set; }
  }
}
