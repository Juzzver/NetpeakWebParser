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

        public ICollection<Header> HeadersList { get; set; }
        public ICollection<Image> ImagesList { get; set; }
        public ICollection<HrefInner> InnerLinksList { get; set; }
        public ICollection<HrefOuter> OuterLinksList { get; set; }
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

        [ForeignKey("WebPage")]
        public int WebPageId { get; set; }
        public virtual WebPage WebPage { get; set; }

    }

    public class HrefInner
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }

        [ForeignKey("WebPage")]
        public int WebPageId { get; set; }
        public virtual WebPage WebPage { get; set; }
    }

    public class HrefOuter
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }

        [ForeignKey("WebPage")]
        public int WebPageId { get; set; }
        public virtual WebPage WebPage { get; set; }

    }

}
