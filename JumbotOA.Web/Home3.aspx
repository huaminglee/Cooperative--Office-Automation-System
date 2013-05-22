<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home3.aspx.cs"
    Inherits="JumbotOA.Web.Home3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>将博协同办公系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/default.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/menu.js"></script>

    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

    <link href="style/global.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="_libs/jquery.timers.js"></script>

    <script type="text/javascript">
var lastseconds = 11;
$(document).ready(function(){
	$('body').everyTime('1s',function(){
	    lastseconds--;
		if(lastseconds>0){
		// $('#time').html("还剩："+lastseconds+"&nbsp;秒自动刷新");return;}
		}else
		{
		$.ajax({
			type:		"get",
			dataType:	"json",
			data:		"time="+(new Date().getTime()),
			url:		"ajax.aspx?oper=ajaxTest",
			success:	function(d){
			    if(d.result=="1")
			       initMessage(d.title,d.remark,d.pages);
			    lastseconds = 11;
			}
		});
		}
	},0,true);
});
    </script>
<script language="javascript" type="text/javascript">
/*
* 消息构造
*/
function Message(id,width,height,caption,title,message,target,action){
    //init params
    this.id = id;
    this.title = title;
    this.caption =caption;
    this.message = message;
    this.target = target;
    this.action =action;
    this.width =width;
    this.height =height;
    //setting params
    this.timeout = 150;
    this.speed = 30;
    this.step = 1;
    //seting position 
    this.right = screen.width-1;
    this.bottom = screen.height;
    this.left = this.right -this.width;
    this.top = this.bottom - this.height;
    this.timer = 0;
    this.pause = false;
    this.close =false;
}
/*
* 隐藏消息方法
*/
Message.prototype.hide = function(){
    if(this.onunload()){
        var offset = this.height > this.bottom -this.top ? this.height: this.bottom-this.top;
        var me = this;
        if(this.timer>0){
            window.clearInterval(me.timer);
        }
        
        var fun = function(){
            if(me.pause == false || me.close){
                var x = me.left;
                var y = 0;
                var width = me.width;
                var height = 0;
                if(me.offset >0){
                    height = me.offset;
                }
                y = me.bottom - height;
                if(y>=me.bottom){
                    window.clearInterval(me.timer);
                    me.Pop.hide();
                } else {
                    me.offset =me.offset - me.step; //等于0是马上消失,否则为逐渐消失
                }
                me.Pop.show(x,y,width,height);
            }
        }//end fun
        this.timer = window.setInterval(fun,this.speed)
    }//end if 
}
Message.prototype.onunload = function(){
    return true;
}
Message.prototype.oncommand = function(){
  OA.Popup.show(unescape(this.action),-1,-1,true);
     this.hide();   
}
Message.prototype.show = function(){
    var oPopup = window.createPopup(); //IE5.5+
    this.Pop = oPopup;
 
    var w = this.width;
    var h = this.height;
    var str = "<div style='BORDER-RIGHT: #455690 1px solid; BORDER-TOP: #a6b4cf 1px solid; Z-INDEX: 99999; LEFT: 0px; BORDER-LEFT: #a6b4cf 1px solid; WIDTH: " + w + "px; BORDER-BOTTOM: #455690 1px solid; POSITION: absolute; TOP: 0px; HEIGHT: " + h + "px; BACKGROUND-COLOR: #c9d3f3'>"
    str += "<table style='BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid' cellSpacing=0 cellPadding=0 width='100%' bgColor=#cfdef4 border=0>"
    str += "<tr>"
    str += "<td style='background-image:url(/images/message1.jpg); FONT-SIZE: 12px;COLOR: #0f2c8c ;width:30;height:24'></td>"
    str += "<td style='PADDING-LEFT: 4px; FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #1f336b; PADDING-TOP: 4px' vAlign=center width='100%'>" + this.caption + "</td>"
    str += "<td style='PADDING-RIGHT: 2px; PADDING-TOP: 2px' vAlign=center align=right width=19>"
    str += "<span title=关闭 style='FONT-WEIGHT: bold; FONT-SIZE: 12px; CURSOR: hand; COLOR: red; MARGIN-RIGHT: 4px' id='btSysClose' >×</span></td>"
    str += "</tr>"
    str += "<tr>"
    str += "<td style='PADDING-RIGHT: 1px;PADDING-BOTTOM: 1px' colSpan=3 height=" + (h-28) + ">"
    str += "<div style='BORDER-RIGHT: #b9c9ef 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #728eb8 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px; PADDING-BOTTOM: 8px; BORDER-LEFT: #728eb8 1px solid; WIDTH: 100%; COLOR: #1f336b; PADDING-TOP: 8px; BORDER-BOTTOM: #b9c9ef 1px solid; HEIGHT: 100%'>" + this.title + "<br><br>"
     str += "<div style='WORD-BREAK: break-all' align=left><a href='javascript:void(0)' hidefocus=false id='btCommand'><font color=#ff0000>" + this.message + "</font></a></div>"
    str += "</div>"
    str += "</td>"
    str += "</tr>"
    str += "</table>"
    str += "</div>"
    
     
    oPopup.document.body.innerHTML = str;
    
    this.offset = 0;
    var me = this;
    
    oPopup.document.body.onmouseover = function(){me.pause=true;}
    oPopup.document.body.onmouseout = function(){me.pause=false;}
    var fun = function(){
        var x = me.right;
        var y = 0;
        var width = me.width;
        var height = me.height;

        if(me.offset>me.height){
            height = me.height;
        } else {
            height = me.offset;
        }

        y = me.bottom - me.offset;
        if(y<=me.top)//让消息框消失
        {
            me.timeout--;
            if(me.timeout==0)//当消息框在页面中显示的时间到期时，将消息框隐藏
            {
                //alert(me.timer);
                window.clearInterval(me.timer);
                me.hide();
            }
        }else{
            me.offset = me.offset + me.step;
        }
        me.Pop.show(x,y,width,height);
       
    }//end fun

    this.timer = window.setInterval(fun,this.speed)
    var btClose = oPopup.document.getElementById("btSysClose");

    btClose.onclick = function(){
        me.close = true;
        me.hide();
    }
    var btCommand = oPopup.document.getElementById("btCommand");
    btCommand.onclick = function(){
        me.oncommand();
    }
}//end show

Message.prototype.speed = function(s){
    var t = 20;
    try {
        t = praseInt(s);
    } catch(e){}
    this.speed = t;    
}
Message.prototype.step =function(s){
    var t = 1;
    try {
        t = praseInt(s);
    } catch(e){}
    this.step = t;    
}

Message.prototype.rect = function(left,right,top,bottom){
    try {
        this.left = left !=null?left:this.right-this.width;
        this.right = right !=null?right:this.left +this.width;
        this.bottom = bottom!=null?(bottom>screen.height?screen.height:bottom):screen.height;
        this.top = top !=null?top:this.bottom - this.height;
    } catch(e){}    
}

function initMessage(title,content,action)
{
    var count = 1;//initMessage
    if(count<=1)
    {
        var msg = new Message(count,200,120,"将博OA平台",title,content,"content3",action);
        msg.rect(null,null,null,screen.availHeight);//screen 是任务栏，availHeight代表当前任务栏的高度
        msg.speed = 10;
        msg.step =5;
        msg.show();
    }else if(count>1)
    {
//        for(i=1;i<=count;i++){
//            var msg = new Message(i,200,120,"将博OA平台",title,content,"content3",action);
//            var pophieght;
//            if(i==1){
//                popheight=screen.availHeight;
//            }else{
//                popheight=popheight-120;
//            }
//            msg.rect(null,null,null,popheight); //screen 是任务栏，availHeight代表当前任务栏的高度
//            msg.speed = 10;
//            msg.step = 5;
//            window.setTimeout('Ktime()',10000);
//            msg.show();
//        }//end for
    }//end if
}//end init
function Ktime(){
    window.setTimeout('Ktime()',10000);
}
    </script>
</head>
<body onload="javascript:border_left('left_tab3','left_menu_cnt3');">
<span id="time" style="display:none;"></span>
    <form id="form1" runat="server">
    <table id="IndexTableBody" cellpadding="0" cellspacing="0" border="0">
        <thead>
            <tr>
                <th><span style="color: #ffffff;">人员：<%=UserName %>（<%=UserPosition %>）</span></th>
            <th> 
               <div style="float:left; width:330px;margin-top:10px; "><marquee width="262px" direction="right" behavior="alternate" scrollamount="2" onmouseover="stop()" onmouseout="start()"><%=email()%></marquee><asp:LinkButton 
                       ID="LinkButton1" runat="server" onclick="LinkButton1_Click">检索新邮件</asp:LinkButton></div>
                <div style="float:right; width:410px;">
              <div style="float:left;margin-top:5px;">
                  <asp:Label ID="oktime" runat="server" Font-Bold="False" ForeColor="Black"></asp:Label> 
                   </div>
<div style="float:right; margin-top:5px;"> <iframe src="http://m.weather.com.cn/m/pn7/weather.htm " width="195" height="17" marginwidth="0" marginheight="0" hspace="0" vspace="0" frameborder="0"  allowtransparency="true"  scrolling="no"></iframe>
</div></div>
                </th></tr>
        </thead>
        <tbody>
            <tr>
                <td class="menu" style="height: 30px">
                    <ul class="bigbtu">
                        <li id="now01"><a title="安全退出" href="Logout.aspx">安全退出</a></li>
                        <li id="now02"></li>
                    </ul>
                </td>
                <td class="tab" style="height: 30px">
                    <ul id="TabPage1">
                        <li id="Tab1" title="我的桌面"><span id="spanTitle">我的桌面</span></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="t1">
                    <div id="contents">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr class="t1">
                                <td style="width: 201px">
                                    <div class="menu_top">
                                    </div>
                                </td>
                            </tr>
                            <tr class="t2">
                                <td style="width: 201px">
                                    <div id="menu" class="menu">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 32px" valign="top">
                                                    <ul class="tabpage2">
                                                        <li id="left_tab3" onclick="javascript:border_left('left_tab3','left_menu_cnt3');"
                                                            title="管理"><span>管理</span></li>
                                                    </ul>
                                                    <div id="left_menu_cnt3" class="left_menu_cnt">
                                                    </div>
                                                </td>
                                                <td align="left" valign="top">
                                                    <div id="left_menu_cnt1" class="left_menu_cnt">
                                                        <ul id="goodmenu">
                                                        </ul>
                                                        <ul id="dleft_tab3">
                                                            <li id="now_desktop"><a title="我的桌面" onclick="show_title('我的桌面')" href="DeskTop2.aspx" target="content3"><span>我的桌面</span></a></li>
                                                            <li id="now_time"><a title="个人考勤" onclick="show_title('个人考勤')" href="My_Time_List.aspx"
                                                                target="content3"><span>个人考勤</span></a></li>
                                                            <li id="now_message"><a title="站内短信" onclick="show_title('站内短信')" href="Message_List.aspx" target="content3"><span>站内短信</span></a></li>
                                                            <li id="now_learning"><a title="学习资料" href="Learning_List.aspx" onclick="show_title('学习资料')" target="content3"><span>学习资料</span></a></li>
                                                            <li id="now_placard"><a title="通知公告" href="Placard_List.aspx" onclick="show_title('通知公告')" target="content3"><span>通知公告</span></a></li>
                                                            <li id="now_password"><a title="密码修改" href="Password_Edit.aspx" onclick="show_title('密码修改')" target="content3"><span>密码修改</span></a></li>
                                                            <li id="now_summarize"><a title="个人总结" href="My_Summarize_List.aspx" onclick="show_title('个人总结')"
                                                                target="content3"><span>个人总结</span></a></li>
                                                            <li id="now_summarize"><a title="员工工作总结" href="Summarize_List.aspx" onclick="show_title('员工工作总结')" target="content3"><span>员工工作总结</span></a></li>
                                                            <li id="now_summarize"><a title="在线评分" onclick="show_title('在线评分')" href="Scorelist.aspx" target="content3"><span>在线评分</span></a></li>
                                                           <li id="now_summarize"><a title="项目测试汇报" onclick="show_title('项目测试汇报')" href="Squestion.aspx" target="content3"><span>项目测试汇报</span></a></li>

                                                            <li id="now_worklog"><a title="员工办公日志" href="Worklog_List.aspx" onclick="show_title('员工办公日志')" target="content3"><span>员工办公日志</span></a></li>
                                                            <li id="now_callinfo"><a title="员工来电处理" href="Callinfo_List.aspx" onclick="show_title('员工来电处理')" target="content3"><span>员工来电处理</span></a></li>
                                                            <li id="now_time"><a title="员工日常考勤" onclick="show_title('员工日常考勤')" href="Time_List.aspx" target="content3"><span>员工日常考勤</span></a></li>
                                                            <li id="now_task"><a title="员工任务分配" onclick="show_title('员工任务分配')" href="Task_List.aspx" target="content3"><span>员工任务分配</span></a></li>
                                                            <li id="now_plan"><a title="员工计划" href="Plan_List.aspx" onclick="show_title('员工计划')" target="content3"><span>员工计划</span></a></li>
                                                        <li id="now_time"><a title="设置考核指标" onclick="show_title('设置考核指标')" href="Scorelist.aspx" target="content3"><span>设置考核指标</span></a></li>
                                                        <li id="now_message"><a title="我的邮箱" href="myemail.aspx" onclick="show_title('我的邮箱')" target="content3"><span>我的邮箱</span></a></li>
                                                      </ul>
                                                    </div>
                                                    <div class="clear">
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <tr class="t3">
                                        <td style="width: 201px">
                                            <div class="menu_end">
                                            </div>
                                        </td>
                                    </tr>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td class="t2">
                    <div id="cnt">
                        <table cellpadding="0">
                            <tr><td><iframe id="content3" name="content3" src="DeskTop3.aspx" frameborder="0" width="100%"
                                height="100%"></iframe></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>

    <script type="text/javascript">
        //修改标题
        function show_title(str){
	        document.getElementById("spanTitle").innerHTML=str;
        }
    </script>

    </form>
</body>
</html>
