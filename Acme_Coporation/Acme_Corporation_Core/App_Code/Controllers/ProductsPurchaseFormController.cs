using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using Acme_Corporation_Core.App_Code.Helpers;
using Acme_Corporation_Core.App_Code.Models;
using Acme_Corporation_Core.App_Code.Repository;
using Acme_Corporation_Core.App_Code.Services;
using Acme_Corporation_Core.Classes;
using Acme_Corporation_Core.ViewModels;
using log4net;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using Umbraco.Web.Mvc;


namespace Acme_Corporation_Core.App_Code.Controllers
{
	public class ProductsPurchaseFormController : UmbracoApiController
	{

		private readonly SendEmailService _sendEmailService;

		public ProductsPurchaseFormController()
			: this(
				new SendEmailService()
			)
		{
		}

		public ProductsPurchaseFormController(
			SendEmailService sendEmailService
		)
		{
			_sendEmailService = sendEmailService;
		}

		[System.Web.Http.HttpPost]
		public JsonResult<string> ProductsPurchaseFormSubmit()
		{
			var fullname = HttpContext.Current.Request.Form["fullname"];
			var emailaddress = HttpContext.Current.Request.Form["emailaddress"];
			var productname = HttpContext.Current.Request.Form["productname"];
			var productserialnumber = HttpContext.Current.Request.Form["productserialnumber"];

			var formdetails = fullname + " " + emailaddress + " / " + productserialnumber;

			var formModel = new ProductsPurchaseModel()
			{
				full_name = fullname,
				email_address = emailaddress,
				product_name = productname.Replace("_", " "),
				product_serial_number = productserialnumber
			};

			//GO AND WRITE THE STUFF TO SEND AN EMAIL
			#region Send Confirmation Emails
			try
			{
				//Make Async

				var isTestingEnvironment = AppSettings.IsTestingEnvironment;

				var to = new List<string>();

				// Set a dafault value

				var notificationEmailRecipient = EmailRecipient(formModel);

				formModel.AdminEmail = notificationEmailRecipient;
				const string subject = "Congrats on your purchase!!!";

				to.Add(notificationEmailRecipient);
				const string templatePath = "~/Views/Shared/Emails/ProductPurchaseFormTemplate.cshtml";

				_sendEmailService.SendEmail(to, System.Web.Hosting.HostingEnvironment.MapPath(templatePath), formModel, subject);

			}
			catch (Exception ex)
			{
				string mainError = ex.Message;
				return null;
			}
			#endregion Send email

			return Json($"Status = : {formdetails}");
		}

		private static string EmailRecipient(ProductsPurchaseModel model)
		{
			string emailRecipient = "";

			emailRecipient = model.email_address;

			return emailRecipient;
		}

	}
}
