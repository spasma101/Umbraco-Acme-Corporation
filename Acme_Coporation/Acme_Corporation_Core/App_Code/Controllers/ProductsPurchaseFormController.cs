using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using Acme_Corporation_Core.App_Code.Helpers;
using Acme_Corporation_Core.App_Code.Models;
using Acme_Corporation_Core.App_Code.Repository;
using Acme_Corporation_Core.Classes;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using Umbraco.Web.Mvc;


namespace Acme_Corporation_Core.App_Code.Controllers
{
	public class ProductsPurchaseFormController : UmbracoApiController
	{

		

		[System.Web.Http.HttpPost]
		public JsonResult<string> ProductsPurchaseFormSubmit()
		{
			var fullname = HttpContext.Current.Request.Form["fullname"];
			var emailaddress = HttpContext.Current.Request.Form["emailaddress"];
			var productserialnumber = HttpContext.Current.Request.Form["productserialnumber"];

			var formdetails = fullname + " " + emailaddress + " / " + productserialnumber;

			//GO AND WRITE THE STUFF TO SEND AN EMAIL

			return Json($"Status = : {formdetails}");
		}

		public async Task fireEmailToAdmins(BCContactFormViewModel model)
		{

			var isTestingEnvironment = AppSettings.IsTestingEnvironment;

			var to = new List<string>();

			// Set a dafault value

			var notificationEmailRecipient = EmailRecipient(model, isTestingEnvironment);

			model.AdminEmail = notificationEmailRecipient;
			const string subject = "New Client Lead from Business Centre Page Contact Form";

			to.Add(notificationEmailRecipient);
			const string templatePath = "~/Views/Shared/Emails/BCContactFormTemplate.cshtml";
			string mappedTemplatePath = Server.MapPath(templatePath);

			await Task.Run(() => _sendEmailService.SendEmail(to, Server.MapPath(templatePath), model, subject));
		}

	}
}
