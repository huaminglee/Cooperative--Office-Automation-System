<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Add.aspx.cs" Inherits="JumbotOA.Web.Message_Add" %>

<%@ Register Assembly="JumbotOA.FCKeditorV2" Namespace="JumbotOA.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送新短信</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        站内短信</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td>
                                <a href="Message_List.aspx">收件箱</a>
                            </td>
                            <td>
                                <a href="Message_MySend.aspx">已发短信</a>
                            </td>
                            <td class="active">
                                发送新短信
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="right">
        <div class="cntre">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%; padding: 10px;">
                        <div class="jsatp">
                            <div id="myTab1_Content0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">短信主题：</span>
                                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="20" Width="220px" Height="24px"
                                                CssClass="ipt"></asp:TextBox><asp:RequiredFieldValidator ID="rfvTitle" runat="server"
                                                    ControlToValidate="txtTitle" ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="ren" visible="true">
                                        <td bgcolor="#f6f9fe"  style="border-bottom: 1px solid #f3f6fb;
                                            border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">收信人：</span>
                                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                               
                                            </asp:DropDownList>
                                            &nbsp;<asp:DropDownList ID="DropDownList2" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">短信内容：</span>
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
                                    <img alt="取消返回" src="images/btn_cancel.gif" style="cursor: pointer;" onclick="location.href='Message_List.aspx'" /></li>
                            </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>

    <script type="text/javascript"> 
	parent.document.getElementById("spanTitle").innerText = document.title;
    </script>

</body>
</html>
