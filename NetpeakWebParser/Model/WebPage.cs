using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetpeakWebParser
{
    public class WebPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ResponseCode { get; set; }
        public TimeSpan ResponseTime { get; set; }

        public int HeaderId { get; set; }
        public int ImageId { get; set; }
        public int HrefInnedId { get; set; }
        public int HrefOuterId { get; set; }

        public virtual Header Header { get; set; }
        public virtual Image Image { get; set; }
        public virtual HrefInner HrefInner { get; set; }
        public virtual HrefOuter HrefOuter { get; set; }
    }

    public class Header
    {
        public int Id { get; set; }
        public string Text { get; set; }
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
