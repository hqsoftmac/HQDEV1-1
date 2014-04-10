<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="productcontent.aspx.cs" Inherits="HQDevSys.manage.product.productcontent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery.min.js" type="text/javascript"></script>
    <script src="../../jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    产品管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addproduct()">新增产品</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="delproduct()">删除产品</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">产品目录:</label>
                <label id="lbllist" style="min-width:200px;font-style:italic;text-decoration:underline; ">根目录</label> &nbsp;&nbsp;&nbsp;&nbsp;
                <input type="hidden" id="hproductlist" value="" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="searchlanmu()">选择目录</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="productgrid" class="easyui-datagrid" title="文章列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FProductId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FProductId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FProductName',width:100,align:'left'">产品名称</th>
                        <th data-options="field:'FProductModule',width:80,align:'center'">产品型号</th>
                        <th data-options="field:'FProductDesc',width:140,align:'center'">产品描述</th>
                        <th data-options="field:'FOperation',width:100,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FProductId" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />

    <!--选择类别窗口-->
    <div id="listwin" iconCls="icon-save" title="文章目录选择" style="display:none;text-align:center;">
        <table id="treetable">
        </table>
    </div>
    <!--选择类别窗口结束-->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
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
                $("#lbllist").html("根目录");
            }
            else {
                var options = {
                    type: "POST",
                    data: { plistid: id },
                    success: function (res) {
                        $("#lbllist").html(res);
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
            loadgriddata();
            closewin1();
        }

        function delproduct() {
            var idlist = GetGridData("productgrid", "FProductId");
            $.messager.confirm('确认', '您是否确定要删除选中的产品信息吗?', function (r) {
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
                    common.Ajax("DelProduct", options);
                }
            });
        }

        function addproduct() {
            window.location = "productcontentadd.aspx";
        }

        function editproduct(id) {
            window.location = "productcontentedit.aspx?id=" + id;
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("productgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
        });

        function loadgriddata() {
            $.messager.progress();
            $('#productgrid').datagrid('loading');
            var _listid = $("#hproductlist").val();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            var options = {
                type: "POST",
                data: {
                    plistid: _listid,
                    psortname: _sortname,
                    psortdirection: _sortdirection,
                    ppagenumber: _pagenumber,
                    ppagesize: _pagesize
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    loadgrid("productgrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }

    </script>
</asp:Content>
