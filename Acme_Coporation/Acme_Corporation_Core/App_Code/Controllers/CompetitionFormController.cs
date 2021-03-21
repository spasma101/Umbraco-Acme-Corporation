using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Umbraco.Web.WebApi;

namespace Acme_Corporation_Core.App_Code.Controllers
{
	public class CompetitionFormController : UmbracoApiController
	{

		[HttpPost]
		public JsonResult<string> CompetitionFormSubmit()
		{
			var firstname = HttpContext.Current.Request.Form["firstname"];
			var lastname = HttpContext.Current.Request.Form["lastname"];

			var name = firstname + " " + lastname;

			return Json($"name: {name}");
		}

	}
}
