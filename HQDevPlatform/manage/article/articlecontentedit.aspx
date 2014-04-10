<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="articlecontentedit.aspx.cs" Inherits="HQDevSys.manage.article.articlecontentedit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../js/jquery.uploadify-v2.1.0/example/css/default.css" rel="stylesheet" type="text/css" />
    <link href="../../js/jquery.uploadify-v2.1.0/example/css/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
    <script charset="gb2312" language="javascript" src="../../js/jquery.uploadify-v2.1.0/example/scripts/swfobject.js" type="text/javascript"></script>
    <script charset="gb2312" language="javascript" src="../../js/jquery.uploadify-v2.1.0/example/scripts/jquery.uploadify.v2.1.0.min.js" type="text/javascript"></script>
    <link href="../../Scripts/xheditor_skin/default/iframe.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/xheditor_skin/default/ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/xheditor-1.1.13-zh-cn.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    编辑文章
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="savearticle()">保存</a>
    <a href="articlecontent.aspx" class="btn" id="btndel" iconCls="icon-back">返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div id="tt" class="easyui-tabs">  
        <div title="文章内容" style="padding:5px;">
            <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        文章标题：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="hidden" id="harticleid" value="<%=sartid %>" />
                        <input type="text" id="txtarticletitle" value="<%=sarttitle %>" style="width:550px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        文章类别：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="hidden" id="hartlist" value="<%=sartlistid %>"/>
                        <label id="lbllistname" style="min-width:200px;font-style:italic;text-decoration:underline;">根目录</label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchlanmu()">选择目录</a>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        文章内容：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <textarea id="txtcontent" style="width:98%;height:400px;"><%=sarticlecontent %></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div title="SEO信息" style="padding:20px;">
            <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        SEO标题：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtseotitle" value="<%=sseotitle %>" style="width:550px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        SEO关键字：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtseokeyword" value="<%=sseokeyword %>" style="width:550px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        SEO描述：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <textarea id="txtseodesc" style="width:98%;height:350px;"><%=sseodesc %></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div title="附属设定" style="padding:20px;">
            <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">  
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        标题样式：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <textarea id="txttitlestyle" style="width:98%;height:50px;"><%=stitlestyle %></textarea>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        作者：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtauthor" value="<%=sauthor %>" style="width:250px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        来源：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtcomefrom" value="<%=scomefrom %>" style="width:250px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        发布时间：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtreleasetime" value="" style="width:150px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        初始阅读次数：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtclicknum" value="<%=sclicknum %>" style="width:150px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        自定义地址：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txturl" value="<%=surl %>" style="width:550px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        缩略图：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtpicpath" style="width:550px;" value="<%=spicpath %>" disabled />&nbsp;&nbsp;
                        <a href="javascript:void(0)" class="btn1" id="A2" iconCls="icon-search" onclick="updatepic()">上传图片</a>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        缩略图标志：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <select id="selpicflag">
                            <option value="0">关闭缩略图</option>
                            <option value="1" selected>显示缩略图</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        评论控制：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <select id="selcommentflag">
                            <option value="0">关闭评论</option>
                            <option value="1" selected>开启评论(直接显示)</option>
                            <option value="2">开启评论(需要审核)</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        简要内容：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <textarea id="txtbriefcontent" rows="10" style="width:98%;height:18px;"><%=sbriefcontent%></textarea>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!--选择类别窗口-->
    <div id="listwin" iconCls="icon-save" title="文章目录选择" style="display:none;text-align:center;">
        <table id="treetable">
        </table>
    </div>
    <!--选择类别窗口结束-->
    <!--上传窗口-->
    <div id="updatewin" iconCls="icon-save" title="图片上传" style="display:none;text-align:center;">
        <div style="width:100%;text-align:left;background-color:#cccccc;">
            <a href="javascript:void(0)" class="btn" id="A3" iconCls="icon-ok" onclick="savepic()">确定</a>
            <a href="javascript:void(0)" class="btn" id="A4" iconCls="icon-cancel" onclick="closewin2()">取消</a>
        </div>
        <table style="width:100%;margin:0px auto;line-height:38px;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    上传图片尺寸请保持4:3的比例,否则图片将会有所失真。
                </td>
            </tr>
            <tr>
                <td align="left" style="height: 120px;text-align:center;" >
                    <img src="" id="leaderphoto" height="120" width="160" border="1"/>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; padding-top:10px;text-align:center;" >
                    <input type="file" name="uploadify" id="uploadify" title="上传图片" value="上传图片" /> 
                </td>
            </tr>
        </table>
        <div id="fileQueue" style="margin:10px auto;">
        </div>
    </div>
    <!--上传窗口End-->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function savearticle() {
            var _artid = $("#harticleid").val();
            var _arttitle = $("#txtarticletitle").val();
            var _artlist = $("#hartlist").val();
            var _artcontent = $("#txtcontent").val();
            var _seotitle = $("#txtseotitle").val();
            var _seokeyword = $("#txtseokeyword").val();
            var _seodesc = $("#txtseodesc").val();
            var _titlestyle = $("#txttitlestyle").val();
            var _author = $("#txtauthor").val();
            var _comefrom = $("#txtcomefrom").val();
            var _releasetime = $("#txtreleasetime").datebox("getValue");
            var _clicknum = $("#txtclicknum").val();
            var _url = $("#txturl").val();
            var _picpath = $("#txtpicpath").val();
            var _picflag = $("#selpicflag").val();
            var _commentflag = $("#selcommentflag").val();
            var _briefcontent = $("#txtbriefcontent").val();
            if (!_arttitle) {
                $.messager.alert("错误", "文章标题不能为空!", "warning");
                return;
            }
            if (!_artlist) {
                _artlist = "0";
            }
            if (!common.Validate.ValidateNumber(_clicknum)) {
                $.messager.alert("错误", "初始阅读次数输入不正确!", "warning");
                return;
            }
            if (_picflag == "1") {
                if (!_picpath) {
                    $.messager.alert("错误", "请设置缩略图!", "warning");
                    return;
                }
            }
            var options = {
                type: "POST",
                data: {
                    partid: _artid,
                    parttitle: _arttitle,
                    ptitlestyle: _titlestyle,
                    pauthor: _author,
                    pcomefrom: _comefrom,
                    preleasetime: _releasetime,
                    pclicknum: _clicknum,
                    purl: _url,
                    ppicflag: _picflag,
                    ppicpath: _picpath,
                    pcommentflag: _commentflag,
                    pseotitle: _seotitle,
                    pseokeyword: _seokeyword,
                    pseodesc: _seodesc,
                    pbriefcontent: _briefcontent,
                    pcontent: _artcontent,
                    plistid: _artlist
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        window.location = "articlecontent.aspx";
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveContent", options);
        }

        function closewin2() {
            $("#leaderphoto").attr("src", "");
            $("#updatewin").window("close");
        }

        function updatepic() {
            var picpath = $("#txtpicpath").val();
            if (picpath) {
                $("#leaderphoto").attr("src", picpath);
            }
            openwin("updatewin", 440, 360, true, "loadpic");
        }

        function savepic() {
            var picpath = $("#leaderphoto").attr("src");
            $("#txtpicpath").val(picpath);
            $("#updatewin").window("close");
        }

        function loadpic() {

        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            $("#txtbriefcontent").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            $("#txtcontent").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            $('#txtreleasetime').datebox({ currentText: '今天', closeText: '关闭', okText: '确定', formatter: formatD });
            $("#uploadify").uploadify({
                'uploader': '../../js/jquery.uploadify-v2.1.0/uploadify.swf',
                'script': '../../Common/UploadHandler.ashx',
                'cancelImg': '../../js/jquery.uploadify-v2.1.0/cancel.png',
                'folder': '../../UploadFile',
                'queueID': 'fileQueue',
                'fileDesc': '图片文件',
                'fileExt': '*.png;*.jpg;*.gif;*.jpeg',
                'auto': true,
                'multi': false,
                'buttonText': '上传图片',
                'queueSizeLimit': 1,
                'sizeLimit': 2 * 1024 * 1024,
                'onComplete': function (e, queueId, fileObj, response, data) {
                    if (response && response != "0") {
                        $("#leaderphoto").attr("src", "../../UploadFile/" + response);
                    }
                }
            });
            refreshtitle();
            $("#txtreleasetime").datebox('setValue', '<%=sreleasetime %>');
            $("#selpicflag").val('<%=picflag %>');
            $("#selcommentflag").val('<%=scommentflag %>');

        });

        function formatD(date) {
            var _mon = date.getMonth() + 1;
            return date.getFullYear() + "-" + _mon + "-" + date.getDate();
        }

        function refreshtitle() {
            var id = $("#hartlist").val();
            if (id == "0") {
                $("#lbllistname").html("根目录");
            }
            else {
                var options = {
                    type: "POST",
                    data: { plistid: id },
                    success: function (res) {
                        $("#lbllistname").html(res);
                    }
                };
                common.Ajax("GetListTitleName", options);
            }
        }

        function searchlanmu() {
            openwin("listwin", 450, 400, true, "refreshtitle");
            $("#treetable").treegrid({
                title: '文章目录',
                rownumbers: true,
                singleSelect: true,
                idField: 'FListId',
                treeField: 'FListCode',
                loadMsg: '数据加载中请稍后……',
                animate: true,
                height: 364,
                columns: [[{ field: 'FListId', title: '选择', width: 80, checkbox: true, align: 'center' },
                            { field: 'FListCode', title: '目录编号', width: 150 },
                            { field: 'FListName', title: '目录名称', width: 150 }
	                    ]],
                toolbar: [{ text: '保存', iconCls: 'icon-save', handler: function () { savelist(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin1(); } }]
            });
            loadartlist();
        }

        function closewin1() {
            $("#listwin").window("close");
        }

        function savelist() {
            var _listid = 0;
            var row = $("#treetable").datagrid("getSelected");
            if (row == null) {
                _listid = 0;
            }
            else {
                _listid = row.FListId;
            }
            $("#hartlist").val(_listid);
            closewin1();
        }

        function loadartlist() {
            var options = {
                type: "POST",
                data: { pdata: "1" },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $('#treetable').treegrid('loadData', json);
                }
            };
            common.Ajax("GetArticleList", options);
        }
    </script>
</asp:Content>
