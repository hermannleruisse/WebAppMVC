using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC.Helpers
{
    public class FileManager
    {
        public static string ErrorMessage { get; set; }
        public static decimal filesize { get; set; }
        public static string UploadFile(HttpPostedFileBase file, string dir)
        {
            try
            {
                var supportedType = new string[] { "png", "jpg", "jpeg", "gif" };
                var fileExtension = Path.GetExtension(file.FileName).Substring(1);
                if (!supportedType.Contains(fileExtension))
                {
                    ErrorMessage = "Fichier invalid, veuillez charger un fichier png/jpg/jpeg/gif";
                    return ErrorMessage;
                }
                else if (file.ContentLength > (filesize * 1024))
                {
                    ErrorMessage = $"La taille du fichier ne doit pas dépasser {filesize * 1024} MB";
                    return ErrorMessage;
                }
                else
                {
                    string path = Path.Combine(HttpContext.Current.Request.MapPath($"~/UploadedFiles/{dir}/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ErrorMessage = string.Empty;
                    return ErrorMessage;
                }
            }
            catch(Exception exc)
            {
                ErrorMessage = $"Une erreur s'est produite lors du chargement du fichier {exc.Message}";
                return ErrorMessage;
            }
        }

        public static string CustomUploadFile(HttpPostedFileBase myFile, string dir)
        {
            //string newName = "default.PNG";
            //if (!string.IsNullOrEmpty(myFile.FileName))
            //{
                string newName = Guid.NewGuid().ToString() + Path.GetExtension(myFile.FileName);
                string path = Path.Combine(HttpContext.Current.Request.MapPath($"~/UploadedFiles/{dir}"), newName);
                myFile.SaveAs(path);
            //}
            return newName;
        }
    }
}