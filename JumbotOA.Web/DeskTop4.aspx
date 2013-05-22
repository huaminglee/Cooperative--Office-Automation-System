<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeskTop4.aspx.cs" Inherits="JumbotOA.Web.DeskTop4" %>
<%@ Register Src="webcontrol/WebDate.ascx" TagName="WebDate" TagPrefix="uc1" %>
<%@ Register Src="webcontrol/address.ascx" TagName="address" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的桌面</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <link href="style/global.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form runat="server" id="fm1">
   
    
    <table border="0" cellpadding="0" cellspacing="10" style="width: 100%; " align="center">
        <tr>
            <td valign="top" colspan="2">
                <uc1:WebDate ID="WebDate1" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="50%" valign="top">
                <table cellspacing="1" cellpadding="6" width="100%" align="center" border="0">
                    <tr>
                        <td>
                            <div class="TabTitle">
                                <ul>
                                    <li>通知公告</li>
                                </ul>
                            </div>
                            <asp:Repeater ID="Repeater_Placard" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                        <tr class="dataTableHead" align="center">
                                            <td width="*" align="center">
                                                标题
                                            </td>
                                            <td style="width: 120px;" align="center">
                                                发布时间
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <a href="javascript:void(0);" onclick="top.OA.Popup.show('My_Placard_Show.aspx?id=<%#Eval("Pid") %>',-1,-1,true)">
                                                <%#Eval("Ptitle") %></a>
                                        </td>
                                        <td align="center">
                                            <%#Eval("Pdate") %>
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
            </td>
            <td width="50%" valign="top">
                <table cellspacing="1" cellpadding="6" width="100%" align="center" border="0">
                    <tr>
                        <td>
                            <div class="TabTitle">
                                <ul>
                                    <li>最新任务</li>
                                </ul>
                            </div>
                            <asp:Repeater ID="Repeater_Work" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                        <tr class="dataTableHead" align="center">
                                            <td width="*" align="center">
                                                工作任务
                                            </td>
                                            <td width="217" align="center">
                                                任务时间进度
                                            </td>
                                             <td width="70" align="center">
                                                截止日期
                                            </td>
                                           
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <a href="javascript:void(0);" onclick="top.OA.Popup.show('My_Work_Show.aspx?id=<%#Eval("Tlid") %>',1050,700,true)">
                                                <%# JumbotOA.Utils.Strings.Left(Eval("Tasktitle").ToString(),14) %></a>
                                        </td>
                                        <td width="216" align="left">
                                            <%#strimg(Eval("sumtime"), Eval("progresstime"))%>
                                        </td >
                                        <td align="center">
                                        <%#Eval("Plantime","{0:yyyy-MM-dd}")%>
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
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
                <uc2:address ID="address1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
