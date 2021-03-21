using System;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace Acme_Corporation_Core.App_Code.Helpers
{
	public static class Productshelpers
	{
		private static IPublishedContent GetHomepage(UmbracoHelper helper)
		{
			var homepageNode = CommonHelpers.GetHomepage(helper);

			if (homepageNode == null)
			{
				throw new NullReferenceException("Homepage node blew up");
			}

			return homepageNode; 
		}

		public static IPublishedContent GetProducts(UmbracoHelper helper)
		{
			var productsNode = GetHomepage(helper).Children.FirstOrDefault( c => c.ContentType.Alias == "products");

			if (productsNode == null)
			{
				throw new NullReferenceException("Content expected : got NULL");
			}

			return productsNode;
		}
	}
}