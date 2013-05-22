<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="JumbotOA.Web.Index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>将博协同办公系统</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<script type="text/javascript">if (top!=self)top.location=self.location;</script>
<style type="text/css">
        body
        {
            background: url(images/login/bg_01.jpg);
            font-size: 12px;
        }
        body, form, td, img
        {
            margin: 0;
            padding: 0;
            border: none;
        }
        .bqc
        {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 12px;
            font-weight: 100;
            color: #369;
        }
        .ipt
        {
            border: 1px #000;
            width: 140px;
            height: 16px;
            font-size: 12px;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center"><table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td><img src="images/login/login_r1_c2.jpg" width="572" height="152" /></td>
                    </tr>
                    <tr>
                        <td><img src="images/login/login_logo.png" width="572" height="50" /></td>
                    </tr>
                    <tr>
                        <td><img src="images/login/login_r3_c2.jpg" width="572" height="97" /></td>
                    </tr>
                    <tr>
                        <td width="572" height="77" background="images/login/login_r4_c2.jpg"><table width="100%" height="77" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="19%"></td>
                                    <td width="33%"><table width="100%" height="77" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td><input id="tbUname" type="text" maxlength="20" runat="server" class="ipt"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td><input id="tbPwd" type="password" maxlength="20" runat="server"
                                                        class="ipt"/>
                                                </td>
                                            </tr>
                                        </table></td>
                                    <td width="48%"></td>
                                </tr>
                            </table></td>
                    </tr>
                    <tr>
                        <td><img src="images/login/login_r5_c2.jpg" width="572" height="11" /></td>
                    </tr>
                    <tr>
                        <td width="572" height="32" background="images/login/login_r6_c2.jpg"><table width="100%" height="32" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="19%"></td>
                                    <td width="13%"><asp:ImageButton ID="ibLogin" runat="server" ImageUrl="images/login/an_dl.jpg" OnClick="ibLogin_Click" /></td>
                                    <td width="4%"></td>
                                    <td width="12%"><img src="images/login/an_qx.jpg" height="32" onclick="form1.reset();" /></td>
                                    <td width="52%"></td>
                                </tr>
                            </table></td>
                    </tr>
                    <tr>
                        <td><img src="images/login/login_r7_c2.jpg" width="572" height="74" /></td>
                    </tr>
                    <tr>
                        <td align="right" class="bqc"> 将博开发团队 &copy; 版权所有 </td>
                    </tr>
                </table></td>
        </tr>
    </table>
</form>
</body>
</html>
