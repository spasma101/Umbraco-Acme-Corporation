using System;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Acme_Corporation_Core.App_Code.Models;
using Lucene.Net.Search.Function;
using Newtonsoft.Json;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Core.Services;
using Umbraco.Core.Composing.CompositionExtensions;
using Umbraco.Core.Models;
namespace Acme_Corporation_Core.Classes
{
	public static class ProductsCreate
		{
			

			public static string CreateProducts(string filePath)
			{
				try
				{

					UmbracoHelper umbracoHelper = Umbraco.Web.Composing.Current.UmbracoHelper;
					IContentService contentService = Umbraco.Core.Composing.Current.Services.ContentService;

					// Sort out where the posts are being migrated to (parent node)
					var homepage = umbracoHelper.ContentAtRoot().FirstOrDefault(n => n.ContentType.Alias == "home");
					var products_listing_page = homepage.Children.FirstOrDefault(n => n.ContentType.Alias == "products");

					var products_listing_page_key = products_listing_page.Key;

					var product_guid = new Guid("e6d938d7-9e94-4c01-8d13-828ac3e26928");

					if (products_listing_page == null)
					{
						return "Failed: No post products_listing_page";
					}

					using (StreamReader r = new StreamReader(filePath))
					{
						string json = r.ReadToEnd();

						dynamic array = JsonConvert.DeserializeObject(json);
						foreach(var items in array)
						{
							foreach(var item in items)
							{

								var allProducts = contentService.GetPagedChildren(products_listing_page.Id, 0, 100000, out var totalExistingProducts);

								IContent existingProduct = null;

								foreach (var product in allProducts)
								{
									if (product.Name == item.name.ToString())
									{
										existingProduct = product;
									}
								}

								if (existingProduct == null)
								{
									Console.WriteLine("{0} {1}", item.name, item.product_serial_number);

									//e6d938d7-9e94-4c01-8d13-828ac3e26928 - Parent GUID
									var name = item.name.ToString();
									var product = contentService.Create(name, product_guid, "Product");

									product.SetValue("productSerialNumber", item.product_serial_number);

									contentService.SaveAndPublish(product);
								}
								else
								{
									existingProduct.SetValue("productSerialNumber", item.product_serial_number);
									contentService.SaveAndPublish(existingProduct);
								}

								

							}
						}
					}

					return "Done!";
				}
				catch (Exception ex)
				{
					string mainError = ex.Message;
					return null;
				}
			}

		}
		
}