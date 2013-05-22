/*
 * 程序中文名称: 将博协同办公系统简易版
 * 
 * 程序英文名称: JumbotOA
 * 
 * 程序版本: 1.1.X
 * 
 * 程序作者: 将博开发团队 (定制开发请联系：jumbot114@126.com,不接受无偿的技术答疑,请见谅)
 * 
 * 
 * 
 * 
 * 
 */

using System;
using System.Configuration;

namespace JumbotOA.FCKeditorV2
{
    public abstract class FileWorkerBase : System.Web.UI.Page
    {
        private const string DEFAULT_UPLOAD_FILES_PATH = "/uploadfiles/";

        private const string DEFAULT_UPLOAD_FILES_UPLOADTYPE = ".jpg.jpeg.bmp.gif.png.zip.rar.swf";//默认允许上传文件类型
        private const int DEFAULT_UPLOAD_FILES_UPLOADSIZE = 1024;//默认允许上传文件大小(1024KB)

        private string sUserUploadPath;
        private string sUploadFilesDirectory;

        private string sUserUploadType;
        private int iUserUploadSize = 0;

        protected string UserUploadPath
        {
            get
            {
                if (sUserUploadPath == null)
                {
                    // Try to get from the "Application".
                    sUserUploadPath = (string)Application["FCKeditor:UserUploadPath"];

                    // Try to get from the "Session".
                    if (sUserUploadPath == null || sUserUploadPath.Length == 0)
                    {
                        sUserUploadPath = (string)Session["FCKeditor:UserUploadPath"];

                        // Try to get from the Web.config file.
                        if (sUserUploadPath == null || sUserUploadPath.Length == 0)
                        {

                            sUserUploadPath = System.Web.Configuration.WebConfigurationManager.AppSettings["FCKeditor:UserUploadPath"];

                            // Otherwise use the default value.
                            if (sUserUploadPath == null || sUserUploadPath.Length == 0)
                                sUserUploadPath = DEFAULT_UPLOAD_FILES_PATH;

                            // Try to get from the URL.
                            if (sUserUploadPath == null || sUserUploadPath.Length == 0)
                            {
                                sUserUploadPath = Request.QueryString["ServerPath"];
                            }
                        }
                    }

                    // Check that the user path ends with slash ("/")
                    if (!sUserUploadPath.EndsWith("/"))
                        sUserUploadPath += "/";
                }
                return sUserUploadPath;
            }
        }


        /**/
        /// <summary>
        /// The absolution path (server side) of the user files directory. It 
        /// is based on the <see cref="FileWorkerBase.UserUploadPath"/>.
        /// </summary>
        protected string UploadFilesDirectory
        {
            get
            {
                if (sUploadFilesDirectory == null)
                {
                    // Get the local (server) directory path translation.
                    sUploadFilesDirectory = Server.MapPath(this.UserUploadPath);
                }
                return sUploadFilesDirectory;
            }
        }

        /**/
        /// <summary>
        /// 获取允许上传的类型
        /// </summary>
        protected string UserUploadType
        {
            get
            {
                if (sUserUploadType == null)
                {
                    // Try to get from the "Application".
                    sUserUploadType = (string)Application["FCKeditor:UserUploadType"];

                    // Try to get from the "Session".
                    if (sUserUploadType == null || sUserUploadType.Length == 0)
                    {
                        sUserUploadType = (string)Session["FCKeditor:UserUploadType"];

                        // Try to get from the Web.config file.
                        if (sUserUploadType == null || sUserUploadType.Length == 0)
                        {

                            sUserUploadType = System.Web.Configuration.WebConfigurationManager.AppSettings["FCKeditor:UserUploadType"];

                            // Otherwise use the default value.
                            if (sUserUploadType == null || sUserUploadType.Length == 0)
                                sUserUploadType = DEFAULT_UPLOAD_FILES_UPLOADTYPE;

                        }
                    }

                    // Check that the user path starts and ends with slash (".")
                    if (!sUserUploadType.StartsWith("."))
                        sUserUploadType = "." + sUserUploadType;

                    if (!sUserUploadType.EndsWith("."))
                        sUserUploadType += ".";
                }
                return sUserUploadType;
            }
        }

        /**/
        /// <summary>
        /// 获取允许上传的文件最大限制
        /// </summary>
        protected int UserUploadSize
        {
            get
            {
                if (iUserUploadSize < 1)
                {
                    iUserUploadSize = Convert.ToInt32(Application["FCKeditor:UserUploadSize"]);
                    if (iUserUploadSize < 1)
                    {
                        iUserUploadSize = Convert.ToInt32(Session["FCKeditor:UserUploadSize"]);
                        if (iUserUploadSize < 1)
                        {
                            iUserUploadSize = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["FCKeditor:UserUploadSize"]);
                            if (iUserUploadSize < 1)
                            {
                                iUserUploadSize = DEFAULT_UPLOAD_FILES_UPLOADSIZE;
                            }
                        }
                    }
                }

                return iUserUploadSize;
            }
        }
    }
}