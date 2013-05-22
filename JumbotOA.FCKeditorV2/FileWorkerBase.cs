/*
 * ������������: ����Эͬ�칫ϵͳ���װ�
 * 
 * ����Ӣ������: JumbotOA
 * 
 * ����汾: 1.1.X
 * 
 * ��������: ���������Ŷ� (���ƿ�������ϵ��jumbot114@126.com,�������޳��ļ�������,�����)
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

        private const string DEFAULT_UPLOAD_FILES_UPLOADTYPE = ".jpg.jpeg.bmp.gif.png.zip.rar.swf";//Ĭ�������ϴ��ļ�����
        private const int DEFAULT_UPLOAD_FILES_UPLOADSIZE = 1024;//Ĭ�������ϴ��ļ���С(1024KB)

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
        /// ��ȡ�����ϴ�������
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
        /// ��ȡ�����ϴ����ļ��������
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