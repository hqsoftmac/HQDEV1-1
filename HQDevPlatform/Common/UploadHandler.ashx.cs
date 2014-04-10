using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Services;
using HQLib.Common;
using HQLib;
using System.Collections.Specialized;

namespace SerWeb.Common
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string SeqFlag = "";
            string disfilename = "";
            string realfilename = "";
            string filepath = "";
            string filetype = "";
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            HttpPostedFile file = context.Request.Files["Filedata"];
            filepath = @context.Request["folder"];
            SeqFlag = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string uploadPath = HttpContext.Current.Server.MapPath(@context.Request["folder"]) + "\\";
            TempAttachmentBiz biz = new TempAttachmentBiz();
            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                disfilename = file.FileName;
                filetype = disfilename.Substring(disfilename.LastIndexOf("."));
                realfilename = Guid.NewGuid().ToString("N") + filetype;
                file.SaveAs(uploadPath + realfilename);
                context.Response.Write(realfilename);
            }
            else
            {
                context.Response.Write("0");
            } 
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
