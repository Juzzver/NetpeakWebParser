using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetpeakWebParser
{
    public class WebPage
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseTime { get; set; }
  //      [ForeignKey("Header")]
    //    public int HeaderId { get; set; }
  /*      public int ImageId { get; set; }
        public int HrefInnedId { get; set; }
        public int HrefOuterId { get; set; }*/

    //    public virtual Header Header { get; set; }
     /*   public virtual Image Image { get; set; }
        public virtual HrefInner HrefInner { get; set; }
        public virtual HrefOuter HrefOuter { get; set; }*/

       public ICollection<Header> HeadersList { get; set; } 
    }

    public class Header
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        [ForeignKey("WebPage")]
        public int WebPageId { get; set; }
        public virtual WebPage WebPage { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }
        public string Src { get; set; }

    }

    public class HrefInner
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }
    }

    public class HrefOuter
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }

    }

}
