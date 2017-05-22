using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;
using System.Drawing;

namespace CarOBDMvc.Controllers
{
    public class PhotosController : Controller
    {
        public IPhotosManager PhotosManager { get; set; }

        public ActionResult Index()
        {    
            return View();
        }

        public ActionResult Photo()
        {
            var photos = PhotosManager.LoadAll().ToList();
            return View(photos);
        }

        [HttpPost]
        public ActionResult Index(string urls, FormCollection fc)
        {
            var urlArray = urls.Split(',');
            var desArray = fc["desc"].Split(',');
            for (int i = 0; i < desArray.Length; i++)
            {
                //保存为正式文件
                var filename = urlArray[i].Substring(urlArray[i].LastIndexOf('/') + 1);
                var oldfile = Server.MapPath(urlArray[i]);
                var newfile = Server.MapPath("/UpLoad/photo/") + filename;
                System.IO.File.Move(oldfile, newfile);

                PhotosManager.Save(new Photos
                {
                    Name = filename,
                    Des = desArray[i],
                    //Desc = desArray[i],
                    Src = "/UpLoad/photo/" + filename,
                    PublishTime= DateTime.Now
                });
            }

            return View();
        }
        //图片上传处理
        public ActionResult PictureUpload()
        {
            //保存到临时文件
            HttpPostedFileBase postedfile = Request.Files["Filedata"];
            var filename = postedfile.FileName;
            var newname = Guid.NewGuid() + filename.Substring(filename.LastIndexOf('.'));
            var filepath = Server.MapPath("/UpLoad/temp/") + newname;
            Image image = Image.FromStream(postedfile.InputStream, true);
            image.Save(filepath);//保存为图片
            return Json(new { status = 1, url = "/UpLoad/temp/" + newname });
        }
        
    }
}
