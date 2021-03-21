using System;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace Acme_Corporation_Core.App_Code.Helpers
{
	public static class CommonHelpers
	{
		public static IPublishedContent GetHomepage(UmbracoHelper umbracoHelper)
		{
			var homepageNode = umbracoHelper.ContentAtRoot()
				.FirstOrDefault(n => n.ContentType.Alias == "home");

			if (homepageNode == null)
			{
				throw new NullReferenceException("Content expected : got NULL");
			}

			return homepageNode;
		}
	}
}