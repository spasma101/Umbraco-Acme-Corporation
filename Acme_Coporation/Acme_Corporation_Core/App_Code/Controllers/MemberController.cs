using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Acme_Corporation_Core.App_Code.Controllers
{
	public class MemberController : SurfaceController
	{
		//Action to Render login partial
		public ActionResult RenderLogin()
		{
			return PartialView("~/Views/Partials/Membership/_Login.cshtml", new LoginModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitLogin(LoginModel model, string returnUrl)
		{
			//Check model state
			if (ModelState.IsValid)
			{
				//Validate user via Umbraco with credentials
				if (Membership.ValidateUser(model.Username, model.Password))
				{
					//Set a cookie for auth
					FormsAuthentication.SetAuthCookie(model.Username, false);
					UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);
					if (myHelper.IsLocalUrl(returnUrl))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return Redirect("/home/");
					}
				}
				else
				{
					ModelState.AddModelError("", "The username or password provided is incorrect.");
				}
			}
			return CurrentUmbracoPage();
		}
		//Action to Render logout partial
		public ActionResult RenderLogout()
		{
			return PartialView("~/Views/Partials/Membership/_Logout.cshtml", null);
		}
		//Action to logout, clear tempdata and session data then redirect to root (login page)
		public ActionResult SubmitLogout()
		{
			TempData.Clear();
			Session.Clear();
			FormsAuthentication.SignOut();
			//return RedirectToCurrentUmbracoPage();
			return Redirect("/");
		}
		//Action to Render register partial
		public ActionResult RenderRegister()
		{
			return PartialView("~/Views/Partials/Membership/_Register.cshtml", null);
		}
	}
}
