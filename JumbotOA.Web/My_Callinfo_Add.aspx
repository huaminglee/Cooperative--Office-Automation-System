<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My_Callinfo_Add.aspx.cs"
    Inherits="JumbotOA.Web.My_Callinfo_Add" %>

<%@ Register Assembly="JumbotOA.FCKeditorV2" Namespace="JumbotOA.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增日志</title>
    <meta http-equiv="Unit-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <script src="_libs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript">
	var config1 = {isShowClear:false,startDate:'<%=System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%>',dateFmt:'yyyy-MM-dd HH:mm:ss',readOnly:true,minDate:'<%=System.DateTime.Today.ToString("yyyy-MM-dd")%> 08:00:00',maxDate:'<%=System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%>'};
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        客户来电</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td>
                                <a href="My_Callinfo_List.aspx">列表</a>
                            </td>
                            <td class="active">
                                新增记录
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="right">
        <div class="cntre">
            <asp:HiddenField ID="hidRecordID" runat="server" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%; padding: 10px;">
                        <div class="jsatp">
                            <div id="myTab1_Unit0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">来电时间：</span>
                                            <asp:TextBox ID="txtAddtime" runat="server" Width="150px" Height="24px" style="border: 1px solid; border-color: #cccccc;" onfocus="WdatePicker(config1)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">对方单位：</span>
                                            <asp:TextBox ID="txtUnit" runat="server" Width="240px" MaxLength="40" Height="24px" style="border: 1px solid; border-color: #cccccc;"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUnit" ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">对方姓名及职务：</span>
                                            <asp:TextBox ID="txtUserinfo" runat="server" Width="240px" MaxLength="40" Height="24px" style="border: 1px solid; border-color: #cccccc;"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserinfo" ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">咨询内容：</span>
                                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="80" Width="400px" Height="24px" style="border: 1px solid; border-color: #cccccc;"></asp:TextBox><asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">答复要点：</span>
                                            <asp:TextBox ID="txtReply" runat="server" Width="400px" MaxLength="200" Height="24px" style="border: 1px solid; border-color: #cccccc;"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReply" ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">反馈及备注信息：</span>
                                            <div style="width: 98%; margin: auto;">
                                                <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Simple" Height="200px">
                                                </FCKeditorV2:FCKeditor>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <ul>
                                <li>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_submit.gif"
                                        OnClick="ImageButton1_Click" /></li>
                                        <li>
                                        <img alt="取消返回" src="images/btn_cancel.gif" style="cursor:pointer;" onclick="location.href='My_Callinfo_List.aspx'" /></li>
                            </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
