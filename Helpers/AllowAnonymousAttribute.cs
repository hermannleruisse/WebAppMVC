using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMVC.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {
    }
}