using System;
using System.Collections.Generic;
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
        private readonly string PROFILEIMAGES = "~/Content/ProfileImages/";

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Upload()
        {

            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string relativePath = "";
            string fileName = "";
            
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                // do something with the file in this space 
                if (file != null && file.ContentLength > 0)
                {
                    var extension = Path.GetExtension(file.FileName);
                    fileName = Guid.NewGuid().ToString() + extension;
                    relativePath = Path.Combine(PROFILEIMAGES, fileName);
                    var path = System.Web.HttpContext.Current.Server.MapPath(relativePath);
                    file.SaveAs(path);
                }
                // end ofl8 file doing
            }

            // Now we need to wire up a response so that the calling script understands what happened
            HttpContext.Current.Response.ContentType = "text/plain";
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var result = new { name = fileName, imageLocation = relativePath, success = true };

            HttpContext.Current.Response.Write(serializer.Serialize(result));
            HttpContext.Current.Response.StatusCode = 200;

            // For compatibility with IE's "done" event we need to return a result as well as setting the context.response
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
