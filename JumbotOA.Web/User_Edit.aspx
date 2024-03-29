﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Edit.aspx.cs" Inherits="JumbotOA.Web.User_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <title>重设密码</title>
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
                                    <li>重设密码</li>
                                </ul>
                            </div>
                            <div id="myTab1_Content0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">用户名：</span>
                                            <asp:TextBox ID="txtUname" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">新密码：</span>
                                            <asp:TextBox ID="txtNewpwd" runat="server" Width="220px" Height="24px" CssClass="ipt" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewpwd"
                                                ErrorMessage="*必填！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">重复密码：</span>
                                            <asp:TextBox ID="txtAgainpwd" runat="server" Width="220px" Height="24px" CssClass="ipt" TextMode="Password"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewpwd"
                                                ControlToValidate="txtAgainpwd" ErrorMessage="*请保持密码一致！"></asp:CompareValidator>
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