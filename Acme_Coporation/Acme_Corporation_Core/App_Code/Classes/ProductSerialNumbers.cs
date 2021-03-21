using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Acme_Corporation_Core.App_Code.Models;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Acme_Corporation_Core.Classes
{
	public static class ProductSerialNumbers
	{
		public static string GetSerialNumbers()
		{
			Int64 x;
			try
			{
				UmbracoHelper umbracoHelper = Umbraco.Web.Composing.Current.UmbracoHelper;
				IContentService contentService = Umbraco.Core.Composing.Current.Services.ContentService;
				var homepage = umbracoHelper.ContentAtRoot().FirstOrDefault(n => n.ContentType.Alias == "home");
				var products_listing_page = homepage.Children.FirstOrDefault(n => n.ContentType.Alias == "products");

				Dictionary<string, string> productsDictionary = new Dictionary<string, string>();

				//foreach (var product in products_listing_page.Children)
				//{
				//	productsDictionary.Add(product.Name, product.Value("productSerialNumber").ToString());
				//}

				//Open the File
				StreamWriter sw = new StreamWriter(@"C:\Repo\Personal\Umbraco_Acme_Corporation\Acme_Coporation\Acme_Coporation\src\Products_And_Serial_Numbers.txt", true, Encoding.ASCII);

				foreach (var product in products_listing_page.Children)
				{
					sw.Write(product.Name + " " + product.Value("productSerialNumber"));
					sw.Write(Environment.NewLine);
				}

				//close the file
				sw.Close();

				return "File can be found at: " + @"C:\Repo\Personal\Umbraco_Acme_Corporation\Acme_Coporation\Acme_Coporation\src\Products_And_Serial_Numbers.txt";
			}
			catch (Exception ex)
			{
				string mainError = ex.Message;
				return null;
			}

		}
	}
}