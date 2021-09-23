using MahwousWeb.Persistent;
using MahwousWeb.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.API.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [Route("sitemap.xml")]
        public ActionResult SitemapXml()
        {
            SitemapHelper helper = new SitemapHelper(context);

            var sitemapNodes = helper.GetSitemapNodes(Url);
            string xml = helper.GetSitemapDocument(sitemapNodes);
            return this.Content(xml, MediaTypeNames.Application.Xml, Encoding.UTF8);
        }
    }
}
