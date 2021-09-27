using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace MahwousWeb.API.Helpers
{

    public class SitemapHelper
    {
        private readonly ApplicationDbContext context;

        public SitemapHelper(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(IUrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            // The Main Pages
            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent(""),
                Priority = 1
            });

            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent("aboutUs"),
                Priority = 0.9
            });

            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent("contactUs"),
                Priority = 0.9
            });

            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent("privacyPolicy"),
                Priority = 0.9
            });

            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent("statistics"),
                Priority = 0.9
            });

            // Videos
            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent("videos"),
                Priority = 0.9
            });
            var videoIds = context.VideoStatuses.Select(x => x.Id);
            foreach (int videoId in videoIds)
            {
                nodes.Add(
                   new SitemapNode()
                   {
                       Url = urlHelper.AbsoluteContent($"videos/{videoId }"),
                       Frequency = SitemapFrequency.Weekly,
                       Priority = 0.8
                   });
            }

            // Images
            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent("images"),
                Priority = 0.9
            });
            var imageIds = context.ImageStatuses.Select(x => x.Id);
            foreach (int imageId in imageIds)
            {
                nodes.Add(
                   new SitemapNode()
                   {
                       Url = urlHelper.AbsoluteContent($"images/{imageId }"),
                       Frequency = SitemapFrequency.Weekly,
                       Priority = 0.8
                   });
            }

            // Quotes
            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent("quotes"),
                Priority = 0.9
            });
            var quoteIds = context.QuoteStatuses.Select(x => x.Id);
            foreach (int quoteId in quoteIds)
            {
                nodes.Add(
                   new SitemapNode()
                   {
                       Url = urlHelper.AbsoluteContent($"quotes/{quoteId }"),
                       Frequency = SitemapFrequency.Weekly,
                       Priority = 0.8
                   });
            }

            // Posts
            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent("posts"),
                Priority = 0.9
            });
            var postIds = context.Posts.Select(x => x.Id);
            foreach (var postId in postIds)
            {
                nodes.Add(
                   new SitemapNode()
                   {
                       Url = urlHelper.AbsoluteContent($"posts/{postId }"),
                       Frequency = SitemapFrequency.Weekly,
                       Priority = 0.7
                   });
            }

            // Apps
            nodes.Add(new SitemapNode()
            {
                Url = urlHelper.AbsoluteContent("apps"),
                Priority = 0.9
            });
            var appIds = context.MobileApps.Select(x => x.Id);
            foreach (int appId in appIds)
            {
                nodes.Add(
                   new SitemapNode()
                   {
                       Url = urlHelper.AbsoluteContent($"apps/{appId }"),
                       Frequency = SitemapFrequency.Weekly,
                       Priority = 0.9
                   });
            }

            return nodes;
        }

        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }

    }
    public class SitemapNode
    {
        public SitemapFrequency? Frequency { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Priority { get; set; }
        public string Url { get; set; }
    }

    public enum SitemapFrequency
    {
        Never,
        Yearly,
        Monthly,
        Weekly,
        Daily,
        Hourly,
        Always
    }

    /// <summary>
    /// <see cref="IUrlHelper"/> extension methods.
    /// </summary>
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Generates a fully qualified URL to an action method by using the specified action name, controller name and
        /// route values.
        /// </summary>
        /// <param name="url">The URL helper.</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns>The absolute URL.</returns>
        public static string AbsoluteAction(
            this IUrlHelper url,
            string actionName,
            string controllerName,
            object routeValues = null)
        {
            return url.Action(actionName, controllerName, routeValues, url.ActionContext.HttpContext.Request.Scheme);
        }

        /// <summary>
        /// Generates a fully qualified URL to the specified content by using the specified content path. Converts a
        /// virtual (relative) path to an application absolute path.
        /// </summary>
        /// <param name="url">The URL helper.</param>
        /// <param name="contentPath">The content path.</param>
        /// <returns>The absolute URL.</returns>
        public static string AbsoluteContent(
            this IUrlHelper url,
            string contentPath)
        {
            HttpRequest request = url.ActionContext.HttpContext.Request;
            return new Uri(new Uri(request.Scheme + "://" + request.Host.Value), url.Content(contentPath)).ToString();
        }

        /// <summary>
        /// Generates a fully qualified URL to the specified route by using the route name and route values.
        /// </summary>
        /// <param name="url">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns>The absolute URL.</returns>
        public static string AbsoluteRouteUrl(
            this IUrlHelper url,
            string routeName,
            object routeValues = null)
        {
            return url.RouteUrl(routeName, routeValues, url.ActionContext.HttpContext.Request.Scheme);
        }
    }
}