using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebAppMVC.Helpers
{
    public static class ValidateFileCustom
    {
        public static bool IsValid(this HttpPostedFileBase value)
        {
            if (value == null) {
                return false;
            }

            var file = value;
            var supportedType = new string[] { "png", "jpg", "jpeg", "gif" };
            var fileExtension = Path.GetExtension(file.FileName).Substring(1);
            if (!supportedType.Contains(fileExtension.ToLower()))
            {
                return false;
            }

            int.TryParse(WebConfigurationManager.AppSettings["Customfilesize"], out int v);

            if (file.ContentLength > (v * 1024 * 1024))
            {
                return false;
            }
            return true;
        }

    }
}