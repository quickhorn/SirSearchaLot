using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SirSearchALot.Web.Controllers.WebApi
{
    //File upload brought to you by https://weblogs.asp.net/bryansampica/AsyncMVCFileUpload
    //This wasn't working as expected. The post got called multiple times, and the last time didn't have the correct content in it.
    //We may consider 
    public class UploadController : ApiController
    {
        private readonly string PROFILEIMAGES = "/Content/ProfileImages/";
        private readonly string[] IMAGEEXENSIONS = new string[6] { ".tif", ".tiff", ".gif", ".jpeg", ".jpg", ".png" };

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Upload()
        {

            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            string relativePath = "";
            string fileName = "";
            
            // do something with the file in this space 
            if (file != null && file.ContentLength > 0)
            {
                var extension = Path.GetExtension(file.FileName);
                //check that we got an image. This isn't the best way to verify,
                //but other options had speed concerns
                //Consider checking headers instead of extensions./
                if (!IMAGEEXENSIONS.Contains(extension))
                {
                    var errorResult = new { message = "The uploaded file is not an image. " };
                    HttpContext.Current.Response.Write(serializer.Serialize(errorResult));
                    return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
                }
                fileName = Guid.NewGuid().ToString() + extension;
                relativePath = Path.Combine(PROFILEIMAGES, fileName);
                var path = System.Web.HttpContext.Current.Server.MapPath(relativePath);
                file.SaveAs(path);
            }
            // end ofl8 file doing
            
            // Now we need to wire up a response so that the calling script understands what happened
            HttpContext.Current.Response.ContentType = "text/plain";
            var result = new { name = fileName, imageLocation = relativePath, success = true };

            HttpContext.Current.Response.Write(serializer.Serialize(result));
            HttpContext.Current.Response.StatusCode = 200;

            // For compatibility with IE's "done" event we need to return a result as well as setting the context.response
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
