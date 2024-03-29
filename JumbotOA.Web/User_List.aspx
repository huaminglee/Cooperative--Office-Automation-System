﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_List.aspx.cs" Inherits="JumbotOA.Web.User_List" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>人员列表</title>
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
                        人员管理</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                         
                        <%--  <td><a href="role.aspx?roleid=1">部门管理</a></td>
                          <td><a href="role.aspx?roleid=0">角色管理</a></td>--%>
                            <td class="active">人员列表</td>
                            <td><a href="User_Add1.aspx">添加管理员</a></td>
                            <td><a href="User_Add2.aspx">添加主管</a></td>
                            <td><a href="User_Add3.aspx">添加副主管</a></td>
                            <td><a href="User_Add4.aspx">添加员工</a></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="right1">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="0%" valign="top">
                    <h1>
                        <img src="images/ht16_03.gif" /></h1>
                </td>
                <td width="99%" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="154" valign="top">
                                <div class="envthp">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding-bottom: 2px;">
                                                <asp:Repeater ID="user_repeater" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td style="width: 60px">
                                                                    序号
                                                                </td>
                                                                <td width="*">
                                                                    用户名
                                                                </td>
                                                                <td style="width: 130px">
                                                                    角色
                                                                </td>
                                                                <td style="width: 70px">
                                                                    部门
                                                                </td>
                                                             <%--   <td style="width: 130px">
                                                                    职位名称
                                                                </td>--%>
                                                                <td style="width: 190px">
                                                                    操作
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%# Container.ItemIndex + 1 %>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Uname")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Pname")%>
                                                            </td>
                                                           <td align="center">
                                                                <%# Eval("Dname")%>
                                                            </td>
                                                            <%--<td align="center">
                                                                <%# Eval("Position")%>
                                                            </td>--%>
                                                            <td align="center">
                                                                <a href="User_Setting.aspx?id=<%#Eval("Uid") %>">修改信息</a> | <a href="User_Edit.aspx?id=<%#Eval("Uid") %>">
                                                                    重设密码</a> |
                                                                <asp:LinkButton ID="lbDel" runat="server" Text="删除" OnCommand="lbDel_Click" CommandArgument='<%# Eval("Uid") %>'
                                                                    OnClientClick="javascript:return confirm('删除人员后，与其相关的任何信息都将删除，确定要删除吗？');"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="right2">
                                    <ul>
                                      
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="0%" valign="top">
                    <h2>
                        <img src="images/ht28_03.gif" /></h2>
                </td>
            </tr>
        </table>
    </div>
    </form>
<script type="text/javascript"> 
	parent.document.getElementById("spanTitle").innerText = document.title;
</script>

</body>
</html>
