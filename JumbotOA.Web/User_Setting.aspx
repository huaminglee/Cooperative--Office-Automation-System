﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Setting.aspx.cs" Inherits="JumbotOA.Web.User_Setting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <title>权限设置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="cntre">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%; padding: 10px;">
                        <div class="jsatp">
                            <div class="TabTitle">
                                <ul id="myTab1">
                                    <li>权限设置</li>
                                </ul>
                            </div>
                            <div id="myTab1_Content0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                     <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">用户名字：</span>
                                            <asp:TextBox ID="txtUname" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUname"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                            <asp:Label ID="pidtxt" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">部门名称：</span>
                                            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="185px" 
                                                AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                               
                                            </asp:DropDownList>
                                            <asp:Label ID="depid" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">角色名称：</span>
                                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                                                Height="20px" onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                                                Width="185px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                  <%--  <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">职位名称：</span>
                                            <asp:TextBox ID="txtPosition" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPosition"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                    
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">IP地址：</span><span id="Span1"></span>
                                            <asp:TextBox ID="txtIpaddress" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; （最好限制其IP地址）
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">权限选择：</span><br />
                                            <asp:Literal ID="ltMasterSetting" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <ul><li>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_submit.gif" OnClick="ImageButton1_Click" /></li>
                            <li>
                                        <img alt="取消返回" src="images/btn_cancel.gif" style="cursor:pointer;" onclick="location.href='User_List.aspx'" /></li>
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