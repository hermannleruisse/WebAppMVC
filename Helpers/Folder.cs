using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebAppMVC.Helpers
{
    public static class Folder
    {
        public static string DirDep = WebConfigurationManager.AppSettings["CustomFolderDepImage"];
        public static string DirDoc = WebConfigurationManager.AppSettings["CustomFolderDocImage"];
    }
}