using System.Web.Mvc;
using ExportDanych.Models;
using ExportDanych.Configuration;
using ExportDanych.Zip;

namespace ExportDanych.Controllers
{
    public class BackupController : Controller
    {
        public ActionResult Index()
        {
            return View(new ExportModel());
        }

        [HttpPost]
        public FileResult Create(ExportModel exportModel)
        {
            string HomeDirectory = ((BaseCatalogDir)System.Web.Configuration.WebConfigurationManager.GetSection("katalogBazowyDanych")).BaseDir;
            Backup backup = new Backup(HomeDirectory);
            string fileName = prepareAttachmentName(exportModel);
            return File(backup.ZipFilesInRange(exportModel), "application/force-download", fileName);
        }

        private static string prepareAttachmentName(ExportModel exportModel)
        {
            return exportModel.FromDate.ToString("yyyy-MM-dd") + "_" + exportModel.ToDate.ToString("yyyy-MM-dd") + ".zip";
        }
    }
}
