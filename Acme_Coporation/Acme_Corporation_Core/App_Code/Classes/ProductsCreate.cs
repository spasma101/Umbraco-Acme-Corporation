using System;
using System.IO;
using System.Linq;
using Acme_Corporation_Core.App_Code.Helpers;
using Newtonsoft.Json;
using Umbraco.Web;
using Umbraco.Core.Services;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Acme_Corporation_Core.Classes
{
	public static class ProductsCreate
		{
			private static IPublishedContent GetProducts(UmbracoHelper helper)
			{
				var productsNode = Productshelpers.GetProducts(helper);

				if (productsNode == null)
				{
					throw new NullReferenceException("Products node blew up");
				}

				return productsNode; 
			}

			public static string CreateProducts(string filePath, UmbracoHelper helper)
			{
				try
				{

					IContentService contentService = Umbraco.Core.Composing.Current.Services.ContentService;

					var products_listing_page = GetProducts(helper);

					if (products_listing_page == null)
					{
						throw new NullReferenceException("Expected content : got NULL");
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
									//Console.WriteLine("{0} {1}", item.name, item.product_serial_number);

									//e6d938d7-9e94-4c01-8d13-828ac3e26928 - Parent GUID
									var name = item.name.ToString();
									var product = contentService.Create(name, products_listing_page.Id, "Product");

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