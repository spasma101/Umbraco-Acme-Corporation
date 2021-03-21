using System;
using System.IO;
using System.Linq;
using Acme_Corporation_Core.App_Code.Helpers;
using Acme_Corporation_Core.App_Code.Models;
using Newtonsoft.Json;
using Umbraco.Web;
using Umbraco.Core.Services;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Acme_Corporation_Core.Classes
{
	public static class FormsCreate
		{
			private static IPublishedContent GetFormsNode(UmbracoHelper helper)
			{
				var formsNode = Formshelpers.GetForms(helper);

				if (formsNode == null)
				{
					throw new NullReferenceException("Products node blew up");
				}

				return formsNode; 
			}

			public static string CreateFormEntries(CompetitionSubmit formModel, UmbracoHelper helper)
			{
				try
				{

					IContentService contentService = Umbraco.Core.Composing.Current.Services.ContentService;

					var forms_listing_page = GetFormsNode(helper);

					if (forms_listing_page == null)
					{
						throw new NullReferenceException("Expected content : got NULL");
					}

					var allForms = contentService.GetPagedChildren(forms_listing_page.Id, 0, 100000, out var totalExistingProducts);

					IContent existingFormEntry = null;

					foreach (var formEntry in allForms)
					{
						if (formEntry.Name == formModel.FirstName + " " + formModel.LastName + " " + formModel.ProductSerialNumber)
						{
							existingFormEntry = formEntry;
						}
					}

					if (existingFormEntry == null)
					{
					var name = formModel.FirstName + " " + formModel.LastName + " " + formModel.ProductSerialNumber;
					var form = contentService.Create(name, forms_listing_page.Id, "Form");

					form.SetValue("firstName", formModel.FirstName);
					form.SetValue("lastName", formModel.LastName);
					form.SetValue("emailAddress", formModel.Email);
					form.SetValue("productSerialNumber", formModel.ProductSerialNumber);

					contentService.SaveAndPublish(form);
					return "Done!: One Code added";
					}
					if(existingFormEntry.GetValue("productSerialNumber2") == null)
					{
						existingFormEntry.SetValue("productSerialNumber2", formModel.ProductSerialNumber);
						contentService.SaveAndPublish(existingFormEntry);
						return "Done!: Second code added";
					}
					if (existingFormEntry.GetValue("productSerialNumber2") != null)
					{
						return "Error: too many entries made";
					}

					return "Error: Form Creation Failed";

				}
				catch (Exception ex)
				{
					string mainError = ex.Message;
					return null;
				}
			}

		}
		
}