using Mahwous.API.Helpers;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text;

namespace Mahwous.API.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }


        //[Route("sitemap.xml")]
        [HttpGet("sitemap.xml")]
        public ActionResult SitemapXml()
        {
            SitemapHelper helper = new SitemapHelper(context);

            var sitemapNodes = helper.GetSitemapNodes(Url);
            string xml = helper.GetSitemapDocument(sitemapNodes);
            return this.Content(xml, MediaTypeNames.Application.Xml, Encoding.UTF8);
        }
    }
}
