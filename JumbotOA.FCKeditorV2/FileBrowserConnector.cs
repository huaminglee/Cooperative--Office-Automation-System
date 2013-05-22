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
using System.Globalization;
using System.Xml;
using System.Web;

namespace JumbotOA.FCKeditorV2
{
    public class FileBrowserConnector : FileWorkerBase
    {
        protected override void OnLoad(EventArgs e)
        {
            // Get the main request informaiton.
            string sCommand = Request.QueryString["Command"];
            if (sCommand == null) return;

            string sResourceType = Request.QueryString["Type"];
            if (sResourceType == null) return;

            string sCurrentFolder = Request.QueryString["CurrentFolder"];
            if (sCurrentFolder == null) return;

            // Check the current folder syntax (must begin and start with a slash).
            if (!sCurrentFolder.EndsWith("/"))
                sCurrentFolder += "/";
            if (!sCurrentFolder.StartsWith("/"))
                sCurrentFolder = "/" + sCurrentFolder;

            // File Upload doesn't have to return XML, so it must be intercepted before anything.
            if (sCommand == "FileUpload")
            {
                this.FileUpload(sResourceType, sCurrentFolder);
                return;
            }

            // Cleans the response buffer.
            Response.ClearHeaders();
            Response.Clear();

            // Prevent the browser from caching the result.
            Response.CacheControl = "no-cache";

            // Set the response format.
            Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
            Response.ContentType = "text/xml";

            XmlDocument oXML = new XmlDocument();
            XmlNode oConnectorNode = CreateBaseXml(oXML, sCommand, sResourceType, sCurrentFolder);

            // Execute the required command.
            switch (sCommand)
            {
                case "GetFolders":
                    this.GetFolders(oConnectorNode, sResourceType, sCurrentFolder);
                    break;
                case "GetFoldersAndFiles":
                    this.GetFolders(oConnectorNode, sResourceType, sCurrentFolder);
                    this.GetFiles(oConnectorNode, sResourceType, sCurrentFolder);
                    break;
                case "CreateFolder":
                    this.CreateFolder(oConnectorNode, sResourceType, sCurrentFolder);
                    break;
            }

            // Output the resulting XML.
            Response.Write(oXML.OuterXml);

            Response.End();
        }

        private XmlNode CreateBaseXml(XmlDocument xml, string command, string resourceType, string currentFolder)
        {
            // Create the XML document header.
            xml.AppendChild(xml.CreateXmlDeclaration("1.0", "utf-8", null));

            // Create the main "Connector" node.
            XmlNode oConnectorNode = XmlUtil.AppendElement(xml, "Connector");
            XmlUtil.SetAttribute(oConnectorNode, "command", command);
            XmlUtil.SetAttribute(oConnectorNode, "resourceType", resourceType);

            // Add the current folder node.
            XmlNode oCurrentNode = XmlUtil.AppendElement(oConnectorNode, "CurrentFolder");
            XmlUtil.SetAttribute(oCurrentNode, "path", currentFolder);
            XmlUtil.SetAttribute(oCurrentNode, "url", GetUrlFromPath(resourceType, currentFolder));

            return oConnectorNode;
        }

        private void GetFolders(XmlNode connectorNode, string resourceType, string currentFolder)
        {
            // Map the virtual path to the local server path.
            string sServerDir = this.ServerMapFolder(resourceType, currentFolder);

            // Create the "Folders" node.
            XmlNode oFoldersNode = XmlUtil.AppendElement(connectorNode, "Folders");

            System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(sServerDir);
            System.IO.DirectoryInfo[] aSubDirs = oDir.GetDirectories();

            for (int i = 0; i < aSubDirs.Length; i++)
            {
                // Create the "Folders" node.
                XmlNode oFolderNode = XmlUtil.AppendElement(oFoldersNode, "Folder");
                XmlUtil.SetAttribute(oFolderNode, "name", aSubDirs[i].Name);
            }
        }

        private void GetFiles(XmlNode connectorNode, string resourceType, string currentFolder)
        {
            // Map the virtual path to the local server path.
            string sServerDir = this.ServerMapFolder(resourceType, currentFolder);

            // Create the "Files" node.
            XmlNode oFilesNode = XmlUtil.AppendElement(connectorNode, "Files");

            System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(sServerDir);
            System.IO.FileInfo[] aFiles = oDir.GetFiles();

            for (int i = 0; i < aFiles.Length; i++)
            {
                Decimal iFileSize = Math.Round((Decimal)aFiles[i].Length / 1024);
                if (iFileSize < 1 && aFiles[i].Length != 0) iFileSize = 1;

                // Create the "File" node.
                XmlNode oFileNode = XmlUtil.AppendElement(oFilesNode, "File");
                XmlUtil.SetAttribute(oFileNode, "name", aFiles[i].Name);
                XmlUtil.SetAttribute(oFileNode, "size", iFileSize.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void CreateFolder(XmlNode connectorNode, string resourceType, string currentFolder)
        {
            string sErrorNumber = "0";

            string sNewFolderName = Request.QueryString["NewFolderName"];

            if (sNewFolderName == null || sNewFolderName.Length == 0)
                sErrorNumber = "102";
            else
            {
                // Map the virtual path to the local server path of the current folder.
                string sServerDir = this.ServerMapFolder(resourceType, currentFolder);

                try
                {
                    Util.CreateDirectory(System.IO.Path.Combine(sServerDir, sNewFolderName));
                }
                catch (ArgumentException)
                {
                    sErrorNumber = "102";
                }
                catch (System.IO.PathTooLongException)
                {
                    sErrorNumber = "102";
                }
                catch (System.IO.IOException)
                {
                    sErrorNumber = "101";
                }
                catch (System.Security.SecurityException)
                {
                    sErrorNumber = "103";
                }
                catch (Exception)
                {
                    sErrorNumber = "110";
                }
            }

            // Create the "Error" node.
            XmlNode oErrorNode = XmlUtil.AppendElement(connectorNode, "Error");
            XmlUtil.SetAttribute(oErrorNode, "number", sErrorNumber);
        }

        private void FileUpload(string resourceType, string currentFolder)
        {
            Response.Clear();

            Response.Write("<script type=\"text/javascript\">");
            Response.Write("window.parent.frames['frmUpload'].OnUploadCompleted(1,'不允许上传文件') ;");
            Response.Write("</script>");

            Response.End();
            //HttpPostedFile oFile = Request.Files["NewFile"];

            //string sErrorNumber = "0";
            //string sFileName = "";

            //if (oFile != null && oFile.ContentLength > 0)
            //{
            //    string sServerDir = this.ServerMapFolder(resourceType, currentFolder);
            //    if (this.UserUploadType.ToLower().IndexOf(System.IO.Path.GetExtension(oFile.FileName).ToLower() + ".") > -1)//检测是否为允许的上传文件类型
            //    {
            //        if (this.UserUploadSize * 1024 >= oFile.ContentLength)//检测文件大小是否超过限制
            //        {
            //            sFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + System.IO.Path.GetExtension(oFile.FileName);
            //            string sFilePath = System.IO.Path.Combine(sServerDir, sFileName);
            //            oFile.SaveAs(sFilePath);
            //        }
            //        else//文件大小超过限制
            //        {
            //            Response.Clear();

            //            Response.Write("<script type=\"text/javascript\">");
            //            Response.Write("window.parent.frames['frmUpload'].OnUploadCompleted(1,'文件大小超出限制:" + oFile.ContentLength + "kb') ;");
            //            Response.Write("</script>");

            //            Response.End();
            //        }
            //    }
            //    else //文件类型不允许上传
            //    {
            //        Response.Clear();

            //        Response.Write("<script type=\"text/javascript\">");
            //        Response.Write("window.parent.frames['frmUpload'].OnUploadCompleted(1,'文件类型超出限制:" + this.UserUploadType.ToLower() + "') ;");
            //        Response.Write("</script>");

            //        Response.End();
            //    }



            //}
            //else
            //    sErrorNumber = "202";

            //Response.Clear();

            //Response.Write("<script type=\"text/javascript\">");
            //Response.Write("window.parent.frames['frmUpload'].OnUploadCompleted(" + sErrorNumber + ",'" + sFileName.Replace("'", "\'") + "') ;");
            //Response.Write("</script>");

            //Response.End();
        }

        private string ServerMapFolder(string resourceType, string folderPath)
        {
            // Get the resource type directory.
            string sResourceTypePath = System.IO.Path.Combine(this.UploadFilesDirectory, resourceType);

            // Ensure that the directory exists.
            Util.CreateDirectory(sResourceTypePath);

            // Return the resource type directory combined with the required path.
            return System.IO.Path.Combine(sResourceTypePath, folderPath.TrimStart('/'));
        }

        private string GetUrlFromPath(string resourceType, string folderPath)
        {
            if (resourceType == null || resourceType.Length == 0)
                return this.UserUploadPath.TrimEnd('/') + folderPath;
            else
                return this.UserUploadPath + resourceType + folderPath;
        }
    }
}
