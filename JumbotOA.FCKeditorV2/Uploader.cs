

using System ;
using System.Globalization ;
using System.Xml ;
using System.Web ;

namespace JumbotOA.FCKeditorV2
{
	public class Uploader : FileWorkerBase
	{
        protected override void OnLoad(EventArgs e)
        {
            // Get the posted file.
            HttpPostedFile oFile = Request.Files["NewFile"];

            // Check if the file has been correctly uploaded
            if (oFile == null || oFile.ContentLength == 0)
            {
                SendResults(202);
                return;
            }

            int iErrorNumber = 0;
            string sFileUrl = "";
            string sFileName = "";



            //if (this.UserUploadSize * 1024 >= oFile.ContentLength)//检测文件大小是否超过限制
            //{
            //    sFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + System.IO.Path.GetExtension(oFile.FileName);
            //    string sFilePath = System.IO.Path.Combine(this.UploadFilesDirectory, sFileName);
            //    oFile.SaveAs(sFilePath);

            //    sFileUrl = this.UserUploadPath + sFileName;
            //}
            //else//文件大小超过限制
            //{
            //    SendResults(1, "", "", "文件大小超出限制" + oFile.ContentLength + "kb");

            //}

            /**/
            /////////////////////////////////////////////////////////////////////////////
            SendResults(1, "", "", "不允许上传");
            SendResults(iErrorNumber, sFileUrl, sFileName);
        }

		#region SendResults Method

		private void SendResults( int errorNumber )
		{
			SendResults( errorNumber, "", "", "" ) ;
		}

		private void SendResults( int errorNumber, string fileUrl, string fileName )
		{
			SendResults( errorNumber, fileUrl, fileName, "" ) ;
		}

		private void SendResults( int errorNumber, string fileUrl, string fileName, string customMsg )
		{
			Response.Clear() ;

			Response.Write( "<script type=\"text/javascript\">" ) ;
			Response.Write( "window.parent.OnUploadCompleted(" + errorNumber + ",'" + fileUrl.Replace( "'", "\\'" ) + "','" + fileName.Replace( "'", "\\'" ) + "','" + customMsg.Replace( "'", "\\'" ) + "') ;" ) ;
			Response.Write( "</script>" ) ;

			Response.End() ;
		}

		#endregion
	}
}
