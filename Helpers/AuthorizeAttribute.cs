using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Helpers
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles ?? new Role[] { };
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = filterContext.ActionDescriptor.ActionName.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (User)filterContext.HttpContext.Items["User"];
            if(user == null || (_roles.Any() && !_roles.Contains(user.Role)))
            {
                // not logged in or role not authorized
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    TempData = filterContext.Controller.TempData,
                    ViewData = filterContext.Controller.ViewData
                };
            }
        }
    }
}