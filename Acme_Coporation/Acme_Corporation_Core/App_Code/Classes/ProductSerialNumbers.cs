using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Acme_Corporation_Core.App_Code.Helpers;
using Acme_Corporation_Core.App_Code.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Acme_Corporation_Core.App_Code.Classes
{
	public static class ProductSerialNumbers
	{
		private static IPublishedContent GetProducts(UmbracoHelper helper)
		{
			var homepageNode = Productshelpers.GetProducts(helper);

			if (homepageNode == null)
			{
				throw new NullReferenceException("Products node blew up");
			}

			return homepageNode; 
		}

		public static string GetSerialNumbers(UmbracoHelper helper)
		{
			Int64 x;
			try
			{
				var products_listing_page = GetProducts(helper);
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