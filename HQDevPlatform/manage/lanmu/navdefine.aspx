<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="navdefine.aspx.cs" Inherits="HQDevSys.manage.lanmu.navdefine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    栏目导航设置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-back" onclick="backlanmu()">返回</a>
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addnav()">新增导航栏</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="delnav()">删除导航栏</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">导航栏搜索</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchlanmu()">查找导航栏</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="navgrid" class="easyui-datagrid" title="导航列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FNavId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FNavId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FNavName',width:160,align:'center'">导航栏名称</th>
                        <th data-options="field:'FNavTypeName',width:60,align:'center'">导航栏类型</th>
                        <th data-options="field:'FNavPositionName',width:80,align:'center'">导航栏位置</th>
                        <th data-options="field:'FNavOrder',width:60,align:'center'">顺序</th>
                        <th data-options="field:'FNavVisibleName',width:60,align:'center',sortable:true">显示</th>
                        <th data-options="field:'FOperation',width:140,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FNavOrder" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <!-- 新增窗口 Begin-->
    <div id="addwin" iconCls="icon-save" title="栏目导航资料" style="display:none;text-align:center;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    导航栏名称：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hnavid" value="0" />
                    <input type="text" id="txtnavname" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    导航栏类型：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <select id="selnavtype">
                        <option value="" selected>==选择导航栏类型==</option>
                        <option value="0">子栏目</option>
                        <option value="1">文章列表</option>
                        <option value="2">产品列表</option>
                        <option value="3">自定义内容</option>
                        <option value="4">自定义模型</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    导航栏位置：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <select id="selnavposition">
                        <option value="" selected>==选择导航栏位置==</option>
                        <option value="0">页面左侧</option>
                        <option value="1">页面右侧</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    显示：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <select id="selnavvisible">
                        <option value="1" selected>显示</option>
                        <option value="0">隐藏</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    顺序：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtorder" style="width:50px;" value="10" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="#" class="btn1" id="btnsave" iconCls="icon-save" onclick="save()">保存</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div> 
    </div>
    <!--新增窗口 End-->
    <!--样式窗口 Begin-->
    <div id="stylewin" iconCls="icon-save" title="子栏目样式" style="display:none;text-align:center;">  
        <table style="width: 470px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    导航标志：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hnavid1" value="0" />
                    <input type="radio" name="flag" id="flagshow" value="1" /><label for="flagshow">显示</label>
                    &nbsp;&nbsp;
                    <input type="radio" name="flag" id="flaghide" value="0" /><label for="flaghide">隐藏</label>
                </td>
            </tr> 
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    导航样式：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="navstyle"></select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;" >
                    内联地址：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtinurl" style="width:200px;" value="" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="#" class="btn1" id="A3" iconCls="icon-save" onclick="savestyle()">保存</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="A4" iconCls="icon-cancel" onclick="closestylewin()" >取消</a>
        </div> 
    </div>
    <!--样式窗口 End-->

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function closestylewin() {
            $("#stylewin").window("close");
        }

        function savestyle() {
            var _navid = $("#hnavid1").val();
            var _stylevisible = "0";
            if ($("#flagshow").attr("checked") == "checked") {
                _stylevisible = "1";
            }
            var _style = $("#navstyle").val();
            var _url = $("#txtinurl").val();
            var options = {
                type: "POST",
                data: { pnavid: _navid, pvisible: _stylevisible, pstyle: _style, purl: _url },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        closestylewin();
                        loadgriddata();
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveStyle", options);
        }

        function childcolstyle(id) {
            var options = {
                type: "POST",
                data: { pid: id },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $("#hnavid1").val(json.FNavId);
                    if (json.FNavTitleVisible == "1") {
                        $("#flagshow").attr("checked", "checked");
                    }
                    else {
                        $("#flaghide").attr("checked", "checked");
                    }
                    if (!json.FNavStyle) {

                    }
                    else {
                        $("#navstyle").val(json.FNavStyle);
                    }
                    $("#txtinurl").val(json.FNavUrl);
                    openwin("stylewin", 500, 350, true, "loadgriddata");
                }
            };
            common.Ajax("GetItem", options);
        }

        function navedit(id) {
            var options = {
                type: "POST",
                data: { pid: id },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    initnav();
                    $("#hnavid").val(json.FNavId);
                    $("#txtnavname").val(json.FNavName);
                    $("#selnavtype").val(json.FNavType);
                    $("#selnavposition").val(json.FNavPosition);
                    $("#selnavvisible").val(json.FNavVisible);
                    $("#txtorder").val(json.FNavOrder);
                    openwin("addwin", 500, 350, true, "loadgriddata");
                }
            };
            common.Ajax("GetItem", options);
        }

        function backlanmu() {
            window.location = "lanmuset.aspx";
        }

        function closewin() {
            $("#addwin").window("close");
        }

        function childcoldefine(id) {
            window.location = "childcoldefine.aspx?navid=" + id;
        }

        function delnav() {
            var idlist = GetGridData("navgrid", "FNavId");
            $.messager.confirm('确认', '您是否确定要删除选中的导航栏目吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    $.messager.progress();
                    var options = {
                        type: "POST",
                        data: { pparm: idlist },
                        success: function (res) {
                            $.messager.progress('close');
                            var json = common.Util.StringToJson(res);
                            if (json.ErrorCode == common.Consts.SuccessCode) {
                                loadgriddata();
                            }
                            else {
                                $.messager.alert('警告', json.ErrorMessage, 'warning');
                                return;
                            }
                        }
                    };
                    common.Ajax("DelNav", options);
                }
            });
        }

        function save() {
            var _navid = $("#hnavid").val();
            var _navname = $("#txtnavname").val();
            var _navtype = $("#selnavtype").val();
            var _navposition = $("#selnavposition").val();
            var _navvisible = $("#selnavvisible").val();
            var _order = $("#txtorder").val();
            if (!_navname) {
                $.messager.alert("导航栏名称不能为空!");
                return;
            }
            if (!_navtype) {
                $.messager.alert("导航栏类型不能为空!");
                return;
            }
            if (!_navposition) {
                $.messager.alert("导航栏位置不能为空!");
                return;
            }
            if (!_order) {
                $.messager.alert("导航栏顺序不能为空!");
                return;
            }
            var options = {
                type:"POST",
                data:{ 
                    pnavid : _navid,
                    pnavname : _navname,
                    pnavtype: _navtype,
                    pnavposition:_navposition,
                    pnavvisible : _navvisible,
                    porder:_order
                },
                success:function(res){
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        $.messager.progress('close');
                        closewin();
                    }
                    else {
                        $.messager.progress('close');
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SaveItem",options);
        }

        function addnav() {
            initnav();
            openwin("addwin", 500, 350, true, "loadgriddata");
        }

        function initnav() {
            $("#hnavid").val("0");
            $("#txtnavname").val("");
            $("#selnavtype").val("");
            $("#selnavposition").val("");
            $("#selnavvisible").val("1");
            $("#txtorder").val("10");
        }
        
        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("navgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
            var moduledata = common.Data.GetDatasource("stylelist");
            $("#navstyle").empty();
            $("#navstyle").append("<option value=''>==默认样式==</option>");
            common.DropDownList.Load("navstyle", moduledata, "FNavStyleName", "FNavStyleName");
        });

        function loadgriddata() {
            $.messager.progress();
            $('#navgrid').datagrid('loading');
            var _searchcontent = $("#txtsearch").val();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            var options = {
                type: "POST",
                data: {
                    psearchcontent: _searchcontent,
                    psortname: _sortname,
                    psortdirection: _sortdirection,
                    ppagenumber: _pagenumber,
                    ppagesize: _pagesize
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    loadgrid("navgrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }
    </script>
</asp:Content>
