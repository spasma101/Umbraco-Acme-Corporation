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
	public class CompetitionFormController : UmbracoApiController
	{

		private readonly CompetitionFormRepository _competitionFormRepository;

		public CompetitionFormController()
			: this(
				new CompetitionFormRepository(AppSettings.umbracoDbDSN)
			)
		{
		}

		public CompetitionFormController(
			CompetitionFormRepository competitionFormRepository
		)
		{
			_competitionFormRepository = competitionFormRepository;
		}

		[System.Web.Http.HttpPost]
		public JsonResult<string> CompetitionFormSubmit()
		{
			var firstname = HttpContext.Current.Request.Form["firstname"];
			var lastname = HttpContext.Current.Request.Form["lastname"];
			var emailaddress = HttpContext.Current.Request.Form["emailaddress"];
			var productserialnumber = HttpContext.Current.Request.Form["productserialnumber"];

			var formdetails = firstname + " " + lastname + " " + emailaddress + " / " + productserialnumber;

			var formModel = new CompetitionSubmit
			{
				FirstName = firstname,
				LastName = lastname,
				Email = emailaddress,
				ProductSerialNumber = productserialnumber
			};

			var createFormEntryUmbraco = FormsCreate.CreateFormEntries(formModel, Umbraco);

			var fireDataToDB = _competitionFormRepository.Add(formModel);

			return Json($"Status = : {createFormEntryUmbraco}");
		}

	}
}
