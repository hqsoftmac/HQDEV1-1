<%@ Page Title="" Language="C#" MasterPageFile="~/WebContent.Master" AutoEventWireup="true" CodeBehind="deptmember.aspx.cs" Inherits="HQDevPlatform.manage.department.deptmember" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHPageName" runat="server">
    部门人员管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHPageTool" runat="server">
    <a href="javascript:void(0)" class="btn" id="btnadd" iconCls="icon-add" onclick="addmember()">新增人员</a>
    <a href="javascript:void(0)" class="btn" id="btndel" iconCls="icon-remove" onclick="del()">删除人员</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPHContent" runat="server">
    <div style="width:100%;margin:0 auto;">
        <div style="height:24px;clear:both;margin-top:0;padding:0;">
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">部门过滤</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <select id="seldept"></select>
            </div>
            <div style="float:left;margin-left:10px;margin-top:3px;">
                <label for="txtsearch">人员姓名</label>
            </div>
            <div style="float:left;margin-left:10px;">
                <input type="text" id="txtsearch" value="" style="width:150px;" />
            </div>
            <div style="float:left;margin:-2px 0 0 10px;">
                <a href="javascript:void(0)" class="btn1" id="A1" iconCls="icon-search" onclick="loadgriddata()">查找</a>
            </div>
        </div>
        <div style="width:98%;margin:0 auto;clear:both;">
            <table id="articlelistgrid" class="easyui-datagrid" title="人员列表" style="margin:2px auto;" data-options="singleSelect:false,fitColumns:true,idField:'FMemberId',rownumbers:true,pagination:true">
                <thead>
                    <tr>
                        <th data-options="field:'FMemberId',align:'center',checkbox:true">选择</th>
                        <th data-options="field:'FMemberCode',width:60,align:'center'">人员编号</th>
                        <th data-options="field:'FMemberName',width:60,align:'center'">人员姓名</th>
                        <th data-options="field:'FDepartmentName',width:120,align:'center'">所属部门</th>   
                        <th data-options="field:'FMemberGendorName',width:50,align:'center'">性别</th>
                        <th data-options="field:'FEducationName',width:50,align:'center'">学历</th>
                        <th data-options="field:'FAge',width:50,align:'center'">年龄</th>
                        <th data-options="field:'FPosition',width:60,align:'center'">职务</th>
                        <th data-options="field:'FMobile',width:100,align:'center'">移动电话</th>
                        <th data-options="field:'FStatusName',width:60,align:'center'">状态</th>
                        <th data-options="field:'FOperation',width:80,align:'center'">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <input type="hidden" id="hsortname" value="FMemberCode" />
    <input type="hidden" id="hsortdirection" value="asc" />
    <input type="hidden" id="hpagenum" value="1" />
    <input type="hidden" id="hpagesize" value="10" />
    <input type="hidden" id="hparentid" value="0" />
    <!--编辑人员窗口-->
     <div id="addwin" iconCls="icon-save" title="人员资料" style="text-align:center;display:none;">  
        <table style="width: 570px;margin:10px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
            <tr>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 160px;" rowspan="4" >
                    照片：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left; width:100px;" rowspan="4" align="center">
                    <img id="imgpic" src="../../images/defphoto.png" width="140" height="160" alt="人员照片" />
                </td>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    人员编号：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="hidden" id="hmemberid" value="0" />
                    <input type="text" id="txtmembercode" style="width:100px;" /><br />(建议 部门编号+流水号)
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    人员姓名：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtmembername" style="width:150px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    学历：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="seleducation"></select>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    民族：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="selnation"></select>
                </td>
            </tr>
             <tr>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    所属部门：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" colspan="3" >
                    <select id="selmemberdept"></select>
                </td>
            </tr>
            
            <tr>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    性别：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <select id="selgendor">
                        <option value="0">男</option>
                        <option value="1">女</option>
                    </select>
                </td>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    出生日期：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtbirthdate" style="width:100px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    职务：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtposition" style="width:160px;" />
                </td>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    移动电话：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" >
                    <input type="text" id="txtmobile" style="width:160px;" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; background-color: #e1f5fc; height: 25px;" >
                    身份证号码：
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:left;" colspan="3" >
                    <input type="text" id="txtidnumber" style="width:300px;" />
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="#" class="btn1" id="btnsave" iconCls="icon-save" onclick="save()">保存</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="btnclose" iconCls="icon-cancel" onclick="closewin()" >取消</a>
        </div>
    </div>

    <!--end win-->
    <!--照片上传窗口-->
    <div id="picwin" iconCls="icon-save" title="人员照片" style="text-align:center;display:none;">  
        <table style="width:500px;margin:10px auto;line-height:38px;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="left" style="width: 175px; background-color: #e1f5fc; height: 193px;" >
                    <img src="../../images/defphoto.png" id="leaderphoto" width="175" height="193" border="0" />
                    <input type="hidden" id="photoid" value="" />
                    <input type="hidden" id="hmid" value="" />
                </td>
                <td style="background-color: #ffffff; padding-left:5px;text-align:center;" >
                    <input type="file" name="uploadify" id="uploadify" title="上传照片" value="上传照片" /> 
                    <div id="fileQueue">
                    </div>
                </td>
            </tr>
        </table>
        <div style="margin:20px auto;">
            <a href="#" class="btn1" id="A2" iconCls="icon-save" onclick="savepic()">确定</a>&nbsp;&nbsp;
            <a href="#" class="btn1" id="A3" iconCls="icon-cancel" onclick="closewin1()" >取消</a>
        </div>
        <div style="margin:0px auto;">
            若无法看到上传照片按钮,请点击链接下载组件,进行升级。
            <a href="../../addin/install_flash_player_ax.zip">IE升级组件</a>&nbsp;&nbsp;&nbsp;&nbsp;
            <a href="../../addin/install_flash_player.zip">其他浏览器升级组件</a>
        </div>
    </div>

    <!--end 照片上传窗口 -->


</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="CPHJavascript" runat="server">
    <script type="text/javascript">
        function savepic() {
            var picpath = $("#leaderphoto").attr("src");
            var id = $("#hmid").val();
            $.messager.progress();
            var options = {
                type: "POST",
                data: { ppath: picpath ,pid:id },
                success: function (res) {
                    $.messager.progress('close');
                    var json = common.Util.StringToJson(res);
                    if (json.ErrorCode == common.Consts.SuccessCode) {
                        closewin1();
                    }
                    else {
                        $.messager.alert('警告', json.ErrorMessage, 'warning');
                        return;
                    }
                }
            };
            common.Ajax("SavePic", options);
        }

        function uppic(id) {
            $.messager.progress();
            $("#hmid").val(id);
            var options = {
                type: "POST",
                data: { pid: id },
                success: function (res) {
                    $.messager.progress('close');
                    $("#leaderphoto").attr("src", res);
                }
            };
            common.Ajax("GetPic", options);
            openwin("picwin", 700, 330, true, "loadgriddata");
        }

        function stop(id) {
            $.messager.confirm('确认', '您是否确定要停用选中的人员吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    $.messager.progress();
                    var options = {
                        type: "POST",
                        data: { pparm: id },
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
                    common.Ajax("StopData", options);
                }
            });
        }

        function start(id) {
            $.messager.confirm('确认', '您是否确定要启用选中的人员吗?', function (r) {
                if (!r) {
                    return;
                }
                else {
                    $.messager.progress();
                    var options = {
                        type: "POST",
                        data: { pparm: id },
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
                    common.Ajax("StartData", options);
                }
            });
        }
        
        function closewin() {
            $("#addwin").window('close');
        }

        function closewin1() {
            $("#picwin").window('close');
        }

        function edit(id) {
            initmember();
            var options = {
                type: "POST",
                data: { pid: id },
                success: function (res) {
                    if (res) {
                        var json = common.Util.StringToJson(res);
                        $("#hmemberid").val(json.FMemberId);
                        //other controls fill here
                        $("#txtmembercode").val(json.FMemberCode);
                        $("#txtmembername").val(json.FMemberName);
                        $("#seleducation").val(json.FEductionId);
                        $("#selnation").val(json.FNationId);
                        $("#selmemberdept").val(json.FDepartmentId);
                        $("#selgendor").val(json.FMemberGendor);
                        $("#txtbirthdate").datebox('setValue', json.FBirthDateStr);
                        $("#txtposition").val(json.FPosition);
                        $("#txtmobile").val(json.FMobile);
                        $("#txtidnumber").val(json.FIDNumber);
                        $("#imgpic").attr("src", json.FPicPathStr);
                        openwin("addwin", 600, 400, true, "loadgriddata");
                    }
                    else {
                        $.messager.alert("警告", "无法获取数据,请刷新后重试!", 'warning');
                        return;
                    }
                }
            };
            common.Ajax("GetItem", options);
        }

        function save() {
            var _FMemberId = $("#hmemberid").val();
            //get data fill here
            var _FMemberCode = $("#txtmembercode").val();
            var _FMemberName = $("#txtmembername").val();
            var _FEductionId = $("#seleducation").val();
            var _FNationId = $("#selnation").val();
            var _FDepartmentId = $("#selmemberdept").val();
            var _FMemberGendor = $("#selgendor").val();
            var _FBirthDate = $("#txtbirthdate").datebox('getValue');
            var _FPosition = $("#txtposition").val();
            var _FMobile = $("#txtmobile").val();
            var _FIDNumber = $("#txtidnumber").val();
            var _FPicPath = $("#imgpic").attr("src");
            //judge data fill here
            if (!_FMemberCode) {
                $.messager.alert("警告", "人员编号不能为空!", "warning");
                return;
            }

            if (!_FMemberName) {
                $.messager.alert("警告", "人员姓名不能为空!", "warning");
                return;
            }

            if (!_FEductionId) {
                $.messager.alert("警告", "学历字段不能为空!", "warning");
                return;
            }

            if (!_FNationId) {
                $.messager.alert("警告", "民族字段不能为空!", "warning");
                return;
            }

            if (!_FDepartmentId) {
                $.messager.alert("警告", "部门字段不能为空!", "warning");
                return;
            }

            if (!_FBirthDate) {
                $.messager.alert("警告", "出生日期字段不能为空!", "warning");
                return;
            }
            else {
                if (!common.Validate.ValidateDateTime(_FBirthDate)) {
                    $.messager.alert("警告", "出生日期输入不合法,请使用选择日期的方式!", "warning");
                    return;
                }
            }

            if (!_FIDNumber) {
                $.messager.alert("警告", "身份证号码字段不能为空!", "warning");
                return;
            }
            else {
                if (!common.Validate.ValidateIdCard(_FIDNumber)) {
                    $.messager.alert("警告", "身份证号码输入不合法,请正确输入,若最后一位为x,请使用小写!", "warning");
                    return;
                }
            }
            if (!_FMobile) {
                $.messager.alert("警告", "移动电话字段不能为空!", "warning");
                return;
            }

            var options = {
                type: "POST",
                data: {
                    pFMemberId : _FMemberId,
                    pFMemberCode: _FMemberCode,
                    pFMemberName: _FMemberName,
                    pFEductionId: _FEductionId,
                    pFNationId: _FNationId,
                    pFDepartmentId: _FDepartmentId,
                    pFMemberGendor: _FMemberGendor,
                    pFBirthDate: _FBirthDate,
                    pFPosition: _FPosition,
                    pFMobile: _FMobile,
                    pFIDNumber: _FIDNumber,
                    pFPicPath: _FPicPath
                },
                success: function (res) {
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
            common.Ajax("SaveItem", options);
        }

        function del() {
            var idlist = GetGridData("articlelistgrid", "FMemberId");
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

        function initmember() {
            $("#hmemberid").val("0");
            $("#txtmembercode").val("");
            $("#txtmembername").val("");
            var nationdata = common.Data.GetDatasource("nationlist");
            $("#selnation").empty();
            $("#selnation").append("<option value=''>==请选择民族==</option>");
            common.DropDownList.Load("selnation", nationdata, "FNationName", "FNationID");
            var deptdata = common.Data.GetDatasource("deptlist");
            $("#selmemberdept").empty();
            $("#selmemberdept").append("<option value=''>==请选择部门==</option>");
            common.DropDownList.Load("selmemberdept", deptdata, "FDepartmentName", "FDepartmentID");
            var educationdata = common.Data.GetDatasource("educationlist");
            $("#seleducation").empty();
            $("#seleducation").append("<option value=''>==请选择学历==</option>");
            common.DropDownList.Load("seleducation", educationdata, "FEducationName", "FEducationID");
            $("#seleducation").val("");
            $("#selnation").val("");
            $("#selmemberdept").val("");
            $("#selgendor").val();
            $("#txtposition").val("");
            $("#txtmobile").val("");
            $("#txtidnumber").val("");
            $("#imgpic").attr("src", "../../images/defphoto.png");
        }

        function addmember() {
            initmember();
            openwin("addwin", 600, 400, true, "loadgriddata");
        }

        $(function () {
            $('.btn').linkbutton({ plain: true });
            $('.btn1').linkbutton();
            formatgrid("articlelistgrid", "loadgriddata", "hpagenum", "hpagesize", "hsortname", "hsortdirection");
            loadgriddata();
            var deptdata = common.Data.GetDatasource("deptlist");
            $("#seldept").empty();
            $("#seldept").append("<option value='0'>所有部门</option>");
            common.DropDownList.Load("seldept", deptdata, "FDepartmentName", "FDepartmentID");
            $('#txtbirthdate').datebox({ currentText: '今天', closeText: '关闭', okText: '确定', formatter: formatD });

            $("#uploadify").uploadify({
                'uploader': '../../js/jquery.uploadify-v2.1.0/uploadify.swf',
                'script': '../../Common/UploadHandler.ashx',
                'cancelImg': '../../js/jquery.uploadify-v2.1.0/cancel.png',
                'folder': '../../UploadFile',
                'queueID': 'fileQueue',
                'fileDesc': '照片文件',
                'fileExt': '*.png;*.jpg;*.gif;*.jpeg',
                'auto': true,
                'multi': false,
                'buttonText': '上传附件',
                'queueSizeLimit': 1,
                'sizeLimit': 2 * 1024 * 1024,
                'onComplete': function (e, queueId, fileObj, response, data) {
                    if (response && response != "0") {
                        $("#leaderphoto").attr("src", "../../UploadFile/" + response);
                        $("#photoid").val(response);
                    }
                }
            });
        });

        function loadgriddata() {
            $.messager.progress();
            $('#articlelistgrid').datagrid('loading');
            var _searchcontent = $("#txtsearch").val();
            var _deptid = $("#seldept").val();
            var _sortname = $("#hsortname").val();
            var _sortdirection = $("#hsortdirection").val();
            var _pagenumber = $("#hpagenum").val();
            var _pagesize = $("#hpagesize").val();
            var _parentid = $("#hparentid").val();
            var options = {
                type: "POST",
                data: {
                    psearchcontent: _searchcontent,
                    psortname: _sortname,
                    psortdirection: _sortdirection,
                    ppagenumber: _pagenumber,
                    ppagesize: _pagesize,
                    pdeptid: _deptid
                },
                success: function (res) {
                    var json = common.Util.StringToJson(res);
                    $.messager.progress('close');
                    loadgrid("articlelistgrid", json);
                }
            };
            common.Ajax("GetGridData", options);
        }

        function formatD(date) {
            var _mon = date.getMonth() + 1;
            return date.getFullYear() + "-" + _mon + "-" + date.getDate();
        }

    </script>
</asp:Content>
