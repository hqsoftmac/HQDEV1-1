<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="ExamManage.aspx.cs" Inherits="HQDevPlatform.OnlineExam.ExamManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    考试维护管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addpaper()">新增试卷</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="delpaper()">删除试卷</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
	    <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">内容类别选择</label>
            </div>
            <div style="float:left;margin-left:10px;border:1px solid #000;padding:0 5px;margin-top:-3px;">
                <input type="hidden" id="hsearchclassid" value= "" />
                <label id="lblsearchclassname" style="min-width:200px;">===请选择内容类别===</label>
                <a href="javascript:void(0)" class="btn" id="A2" iconCls="icon-search" onclick="searchcontentclass()"></a>
            </div>
		    <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">试卷名称过滤</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="loadgriddata()">查找</a>
            </div>
        </div>
         <div style="width:98%;margin:0 auto;clear:both;">
            <table id="listgrid" class="easyui-datagrid" title="列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FPaperId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
						<th data-options="field:'FPaperId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FPaperName',width:120,align:'center'">试卷名称</th>
                        <th data-options="field:'FExamTypeName',width:40,align:'center'">试卷模式</th>
						<th data-options="field:'FPaperStatusname',width:40,align:'center'">试卷状态</th>
						<th data-options="field:'FPaperTotal',width:40,align:'center'">试卷总分</th>
						<th data-options="field:'FPaperExtractWayname',width:50,align:'center'">抽题模式</th>
						<th data-options="field:'FChooseItemWayname',width:50,align:'center'">答案顺序模式</th>
						<th data-options="field:'FPassScore',width:40,align:'center'">通过得分</th>
						<th data-options="field:'FUserName',width:40,align:'center'">创建人</th>
                        <th data-options="field:'FPaperTimeStr',width:80,align:'center'">试卷创建时间</th>
						<th data-options="field:'FOperation',width:100,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FPaperId" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />

    <div id="contentclasswin" iconCls="icon-save" title="内容类别选择" style="display:none;text-align:center;">
        <table id="treetable">
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function rtn() {

        }
        
        function closewin3() {
            $("#contentclasswin").window('close');
        }
        
        function loadcontentclass() {
            var options = {
                type: "POST",
                data: { pid: "1" },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $('#treetable').treegrid('loadData', json);
                }
            };
            common.Ajax("GetContentClassTree", options);
        }

        function choosecontentclass() {
            var row = $("#treetable").treegrid('getSelected');
            if (!row || row.length == 0) {
                $.messager.alert('提示', '请选择相关内容类别!', 'info');
                return;
            }
            $("#hsearchclassid").val(row.FContentClassId);
            $("#lblsearchclassname").html("[" + row.FContentClassCode + "]" + row.FContentClassName);
            closewin3();
        }

        function searchcontentclass() {
            openwin("contentclasswin", 450, 400, true, "loadgriddata");
            $("#treetable").treegrid({
                rownumbers: true,
                singleSelect: true,
                idField: 'FContentClassId',
                treeField: 'FContentClassCode',
                loadMsg: '数据加载中请稍后……',
                animate: true,
                height: 364,
                columns: [[{ field: 'FContentClassId', title: '选择', width: 80, checkbox: true, align: 'center' },
                            { field: 'FContentClassCode', title: '内容类别编号', width: 150 },
                            { field: 'FContentClassName', title: '内容类别名称', width: 150 }
	                    ]],
                toolbar: [{ text: '选择', iconCls: 'icon-ok', handler: function () { choosecontentclass(); } }, { text: '取消', iconCls: 'icon-cancel', handler: function () { closewin3(); } }]
            });
            loadcontentclass();
        }

        function addpaper() {
            window.parent.addtab("新增考试试卷", "OE000104001", "OEExamPaperAdd.aspx");
        }

        function del() {
            var idlist = GetGridData("listgrid", "FPaperId");
            if (!idlist) {
                $.messager.alert('警告', '请选择相关要删除的数据!', 'warning');
                return;
            }
            $.messager.confirm('确认', '您是否确定要删除选中的数据吗?', function (r) {
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
                    common.Ajax("DelData", options);
                }
            });
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("listgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
        });

        function loadgriddata() {
            var _searchclassid = $("#hsearchclassid").val();
            if (!_searchclassid || _searchclassid == "0") {
                return;
            }
            var _searchcontent = $("#txtsearch").val();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            $.messager.progress();
            $('#listgrid').datagrid('loading');
            var options = {
                type: "POST",
                data: {
                    pcontentclassid: _searchclassid,
                    psearchcontent: _searchcontent,
                    psortname: _sortname,
                    psortdirection: _sortdirection,
                    ppagenumber: _pagenumber,
                    ppagesize: _pagesize
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    loadgrid("listgrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }
        
    </script>
</asp:Content>
