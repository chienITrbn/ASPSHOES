using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoesShoppingOnline.Models.DataModel;

namespace Group4_GlassesShop.Models.Authentication
{
	public class AuthenAdmin : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{

			string userJson = context.HttpContext.Session.GetString("User");
			var isExitsUser = JsonConvert.DeserializeObject<AccountModel>(userJson);
			
			if (userJson == null)
			{
				context.Result = new RedirectToRouteResult(
					new RouteValueDictionary
					{
						{ "Controller", "Login" },
						{ "Action", "Login" }
					});
			}
			else if(isExitsUser.Role == 1)
			{
				context.Result = new RedirectToRouteResult(
					new RouteValueDictionary
					{
						{ "Controller", "Home" },
						{ "Action", "Index" }
					});
			}
		}
	}
}
