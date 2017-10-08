using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetpeakWebParser.Model
{
    public class WebPageContext : DbContext
    {
        public WebPageContext() : base("WebPageDB")
        {
        }

        public DbSet<WebPage> WebPages { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<HrefInner> InnerLinks { get; set; }
        public DbSet<HrefOuter> OuterLinks { get; set; }
    }
}
