using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NetpeakWebParser.Model
{
    public class DBWebPageInitializator : CreateDatabaseIfNotExists<WebPageContext>//DropCreateDatabaseAlways<WebPageContext>// CreateDatabaseIfNotExists<WebPageContext>
    {
        protected override void Seed(WebPageContext context)
        {
            var header = new Header() { Text = "This is main header on the world!" };
            var image = new Image() { Src = "https://avatars0.githubusercontent.com/u/15878777?v=4&s=40" };
            var innerLink = new HrefInner() { Link = "https://github.com/Juzzver/NetpeakWebParser", Text = "NetpeakWebParser" };
            var outerLink = new HrefOuter() { Link = "http://google.com", Text = "Viva Google!" };

            context.Headers.Add(header);
            context.Images.Add(image);
            context.InnerLinks.Add(innerLink);
            context.OuterLinks.Add(outerLink);

            context.WebPages.Add(new WebPage()
            {
                Title = "My website",
                Description = "Some desc there",
                StatusCode = 200,
                ResponseTime = TimeSpan.FromSeconds(0.23).TotalMilliseconds + " ms",
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}