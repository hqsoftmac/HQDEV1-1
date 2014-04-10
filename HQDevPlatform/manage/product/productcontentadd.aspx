<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="productcontentadd.aspx.cs" Inherits="HQDevSys.manage.product.productcontentadd" %>
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
    新增产品
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="saveproduct()">保存</a>
    <a href="productcontent.aspx" class="btn" id="btndel" iconCls="icon-back">返回</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div id="tt" class="easyui-tabs">  
        <div title="基本信息" style="padding:5px;">
            <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        产品名称：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtproductname" value="" style="width:550px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        产品类别：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="hidden" id="hproductlist" value=""/>
                        <label id="lbllistname" style="min-width:200px;font-style:italic;text-decoration:underline;">根目录</label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchlanmu()">选择目录</a>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        产品型号：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtproductmodule" value="" style="width:550px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        产品描述：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtproductdesc" value="" style="width:550px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        缩略图：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtbriefpicpath" value="" style="width:550px;" disabled />&nbsp;&nbsp;
                        <a href="javascript:void(0)" class="btn1" id="A2" iconCls="icon-search" onclick="updatepic(1)">上传图片</a>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        产品图片：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtpicpath" value="" style="width:550px;" disabled />&nbsp;&nbsp;
                        <a href="javascript:void(0)" class="btn1" id="A5" iconCls="icon-search" onclick="updatepic(2)">上传图片</a>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        简要内容：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <textarea id="txtbriefcontent" style="width:98%;height:300px;"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div title="详细内容" style="padding:5px;">
            <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        详细内容：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <textarea id="txtcontent" style="width:98%;height:420px;"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div title="SEO信息" style="padding:5px;">
            <table style="width:100%;margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        SEO标题：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtseotitle" value="" style="width:550px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        SEO关键字：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <input type="text" id="txtseokeyword" value="" style="width:550px;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                        SEO描述：
                    </td>
                    <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                        <textarea id="txtseodesc" style="width:98%;height:350px;"></textarea>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!--选择类别窗口-->
    <div id="listwin" iconCls="icon-save" title="产品目录选择" style="display:none;text-align:center;">
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
                    <img src="" id="leaderphoto" height="120" width="160" border="1" />
                    <input type="hidden" id="rntway" value="1" />
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
        function saveproduct() {
            var _productname = $("#txtproductname").val();
            var _productlist = $("#hproductlist").val();
            var _productmodule = $("#txtproductmodule").val();
            var _productdesc = $("#txtproductdesc").val();
            var _briefpath = $("#txtbriefpicpath").val();
            var _path = $("#txtpicpath").val();
            var _briefcontent = $("#txtbriefcontent").val();
            var _content = $("#txtcontent").val();
            var _seotitle = $("#txtseotitle").val();
            var _seokeyword = $("#txtseokeyword").val();
            var _seodesc = $("#txtseodesc").val();
            if (!_productname) {
                $.messager.alert("产品名称不能为空!");
                return;
            }
            if (!_productlist) {
                $.messager.alert("产品目录不能为空!");
                return;
            }
            var options = {
                type: "POST",
                data: {
                    pproductname: _productname,
                    pproductlist: _productlist,
                    pproductmodule: _productmodule,
                    pproductdesc: _productdesc,
                    pbriefpath: _briefpath,
                    ppath: _path,
                    pbriefcontent: _briefcontent,
                    pcontent: _content,
                    pseotitle: _seotitle,
                    pseokeyword: _seokeyword,
                    pseodesc: _seodesc
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        window.location = "productcontent.aspx";
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveProduct", options);
        }

        function updatepic(id) {
            $("#rntway").val(id);
            $("#leaderphoto").attr("src","");
            openwin("updatewin", 440, 360, true, "loadpic");
        }

        function savepic() {
            var _id = $("#rntway").val();
            var picpath = $("#leaderphoto").attr("src");
            if (_id == "1") {
                $("#txtbriefpicpath").val(picpath);
            }
            else {
                $("#txtpicpath").val(picpath);
            }
            $("#updatewin").window("close");
        }

        function loadpic() {

        }

        function searchlanmu() {
            openwin("listwin", 450, 400, true, "refreshtitle");
            $("#treetable").treegrid({
                title: '产品目录',
                rownumbers: true,
                singleSelect: true,
                idField: 'FProductListID',
                treeField: 'FProductListName',
                loadMsg: '数据加载中请稍后……',
                animate: true,
                height: 364,
                columns: [[{ field: 'FProductListID', title: '选择', width: 80, checkbox: true, align: 'center' },
                            { field: 'FProductListName', title: '目录名称', width: 370 }
	                    ]],
                toolbar: [{ text: '选择', iconCls: 'icon-save', handler: function () { savelist(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin1(); } }]
            });
            loadartlist();
        }

        function closewin1() {
            $("#listwin").window("close");
        }

        function refreshtitle() {
            var id = $("#hproductlist").val();
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

        function loadartlist() {
            var options = {
                type: "POST",
                data: { pdata: "1" },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $('#treetable').treegrid('loadData', json);
                }
            };
            common.Ajax("GetProductList", options);
        }

        function savelist() {
            var _listid = 0;
            var row = $("#treetable").datagrid("getSelected");
            if (row == null) {
                _listid = 0;
            }
            else {
                _listid = row.FProductListID;
            }
            $("#hproductlist").val(_listid);
            closewin1();
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            $("#txtbriefcontent").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
            $("#txtcontent").xheditor({ upLinkUrl: "../upload.aspx", upLinkExt: "zip,rar,txt,doc,xls,docx,xlsx,ppt,pptx,rft", upImgUrl: "../upload.aspx", upImgExt: "jpg,jpeg,gif,png", upFlashUrl: "../upload.aspx", upFlashExt: "swf", upMediaUrl: "../upload.aspx", upMediaExt: "avi" });
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
        });
    </script>
</asp:Content>
