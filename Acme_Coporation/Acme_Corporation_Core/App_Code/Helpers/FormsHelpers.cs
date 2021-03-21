using System;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace Acme_Corporation_Core.App_Code.Helpers
{
	public static class Formshelpers
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

		public static IPublishedContent GetForms(UmbracoHelper helper)
		{
			var formsNode = GetHomepage(helper).Children.FirstOrDefault( c => c.ContentType.Alias == "forms");

			if (formsNode == null)
			{
				throw new NullReferenceException("Content expected : got NULL");
			}

			return formsNode;
		}
	}
}