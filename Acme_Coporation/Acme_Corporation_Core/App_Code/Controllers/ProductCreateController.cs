using System;
using System.Web.Mvc;
using Acme_Corporation_Core.Classes;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace Acme_Corporation_Core.App_Code.Controllers
{
	public class ProductCreateController : SurfaceController
	{
		public ActionResult CreateProducts()
		{
			return Content(ProductsCreate.CreateProducts(@"C:\Repo\Personal\Umbraco_Acme_Corporation\Acme_Coporation\Acme_Coporation\src\json_files\products.json"));
		}

		public ActionResult GetAllProductSerialNumbers()
		{
			return Content(ProductSerialNumbers.GetSerialNumbers());
		}
	}
}