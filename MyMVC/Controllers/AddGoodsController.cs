using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC.Controllers
{
    public class AddGoodsController : Controller
    {
        // GET: AddGoods
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Indexs(HttpPostedFileBase file)
        {
            if (null != file && file.ContentLength > 0)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "uploads";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = string.Empty;
                fileName = Path.GetFileName(file.FileName);
                file.SaveAs(Path.Combine(path, fileName));
                return Json(new { filePath = "/uploads/" + fileName, code = 1 });
            }
            return Json(new { filePath = "请选择需要上传的文件", code = 0 });
        }
    }
}