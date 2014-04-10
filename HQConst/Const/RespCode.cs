using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQConst.Const
{
    public class RespCode
    {
        public const string Success = "000000";

        public const string SysError = "999999";

        public static readonly string[] SysNullRow = { "999998", "影响行数为空!" };

        #region 用户相关信息
        public static readonly string[] SysUser0001 = { "SYSUSER0001", "用户名不能为空!" };

        public static readonly string[] SysUser0002 = { "SYSUSER0002", "您的用户账号已经被停用!" };

        public static readonly string[] SysUser0003 = { "SYSUSER0003", "您输入的用户账号不存在!" };

        public static readonly string[] SysUser0004 = { "SYSUSER0004", "密码错误,请重新输入!" };

        public static readonly string[] SysUser0005 = { "SYSUSER0005", "模块标志符错误!" };

        public static readonly string[] SysUser0006 = { "SYSUSER0006", "您无权进入该模块!" };

        public static readonly string[] SysUser0007 = { "SYSUSER0007", "新密码两次输入不一致!" };

        public static readonly string[] SysUser0008 = { "SYSUSER0008", "原密码验证错误!" };

        public static readonly string[] SysUser0009 = { "SYSUSER0009", "新密码不能与原密码相同!" };

        public static readonly string[] SysUser0010 = { "SYSUSER0010", "密码长度不能小于6位!" };

        public static readonly string[] SysUser0011 = { "SYSUSER0011", "该用户名已经存在!" };

        public static readonly string[] SysUser0012 = { "SYSUSER0012", "因模块尚未启用,您无法进入该模块!" };

        public static readonly string[] SysUser0013 = { "SYSUSER0013", "该模块未得到正式授权,您无法进入该模块!" };

        #endregion

        #region 角色相关信息
        public static readonly string[] SysRole0001 = { "SYSROLE0001", "角色ID错误,无法保存!" };

        public static readonly string[] SysRole0002 = { "SYSROLE0002", "角色名称不能为空!" };

        public static readonly string[] SysRole0003 = { "SYSROLE0003", "角色名称不能重复!" };

        #endregion

        #region 日志相关信息
        public static readonly string[] SysLog0001 = { "SYSLOG0001", "日志对象不能为空!" };


        #endregion

        #region 门户栏目相关信息
        public static readonly string[] Pt010001 = { "PT010001", "栏目名称不能为空!" };

        public static readonly string[] Pt010002 = { "PT010002", "栏目类型不能为空!" };

        public static readonly string[] Pt010003 = { "PT010003", "栏目链接目标不能为空!" };

        public static readonly string[] Pt010004 = { "PT010004", "栏目顺序不能为空!" };

        public static readonly string[] Pt010005 = { "PT010005", "栏目名称重复,不能保存!" };

        public static readonly string[] Pt010006 = { "PT010006", "首页已经存在,不能保存!" };

        public static readonly string[] Pt010007 = { "PT010007", "栏目类型的参数不正确!" };

        public static readonly string[] Pt010008 = { "PT010008", "首页尚未定义,无法定义普通页面" };

        public static readonly string[] Nv010001 = { "NV010001", "导航名称不能为空!" };

        public static readonly string[] Nv010002 = { "NV010002", "导航名称重复!" };

        public static readonly string[] Nv010003 = { "NV010003", "栏目ID不能为空!" };

        public static readonly string[] Nv010004 = { "NV010004", "导航类型不能为空!" };

        public static readonly string[] Nv010005 = { "NV010005", "导航位置不能为空!" };

        public static readonly string[] Cc010001 = { "CC010001", "子栏目名称不能为空!" };

        public static readonly string[] Cc010002 = { "CC010002", "子栏目类型不能为空!" };

        public static readonly string[] Cc010003 = { "CC010003", "子栏目链接目标不能为空!" };

        public static readonly string[] Cc010004 = { "CC010004", "子栏目名称重复!" };

        public static readonly string[] Cc010005 = { "CC010005", "子栏目序号不能为空!" };

        public static readonly string[] Cc010006 = { "CC010006", "NavId参数错误,不能保存!" };

        #endregion


        #region 门户文章相关信息

        public static readonly string[] Pa010001 = { "PA010001", "文章归属目录不能为空!" };

        public static readonly string[] Pa010002 = { "PA010002", "文章标题不能为空!" };

        public static readonly string[] Pa010003 = { "PA010003", "请上传缩略图!" };

        #endregion

        #region 用户登录
        public static readonly string[] A010001 = { "A010001", "用户名不能为空!" };

        public static readonly string[] A010002 = { "A010002", "密码不能为空!" };

        public static readonly string[] A010003 = { "A010003", "用户名或者密码错误!" };
        #endregion

        #region 用户增删改查
        public static readonly string[] A020001 = { "A020001", "用户账号不能为空!" };

        public static readonly string[] A020002 = { "A020002", "用户姓名不能为空!" };

        public static readonly string[] A020003 = { "A020003", "该用户账号已经存在!" };

        public static readonly string[] A020004 = { "A020004", "关键参数UserId不正确!" };

        public static readonly string[] A020005 = { "A020005", "关键参数UserId不能缺失" };

        public static readonly string[] A020006 = { "A020006", "用户可能已经产生其他相关数据不能删除,您可以暂停账户同样可以限制用户的登录!" };
        #endregion

        #region 功能列表
        public static readonly string[] FUN0001 = { "FUN0001", "功能编号不能为空!" };

        public static readonly string[] FUN0002 = { "FUN0002", "功能名称不能为空!" };

        public static readonly string[] FUN0003 = { "FUN0003", "功能编号已经存在!" };

        public static readonly string[] FUN0004 = { "FUN0004", "功能名称已经存在!" };

        public static readonly string[] FUN0005 = { "A030005", "关键参数FunId不正确!" };

        public static readonly string[] FUN0006 = { "FUN0006", "关键参数FunId不能缺失!" };
        #endregion

        #region 角色列表
        public static readonly string[] A040001 = { "A040001", "角色名称不能为空!" };

        public static readonly string[] A040002 = { "A040002", "角色名称已经存在!" };

        public static readonly string[] A040003 = { "A040003", "关键参数RoleId不正确!" };

        public static readonly string[] A040004 = { "A040004", "关键参数RoleId不能缺失!" };
        #endregion

        #region 部门列表
        public static readonly string[] A050001 = { "A050001", "部门编号不能为空!" };

        public static readonly string[] A050002 = { "A050002", "部门名称不能为空!" };

        public static readonly string[] A050003 = { "A050003", "部门编号已经存在!" };

        public static readonly string[] A050004 = { "A050004", "部门名称已经存在!" };

        public static readonly string[] A050005 = { "A050005", "关键参数部门ID不正确!" };

        public static readonly string[] A050006 = { "A050006", "关键参数部门Id不能缺失!" };

        public static readonly string[] A050007 = { "A050007", "所选部门存在下级!" };
        #endregion

        #region 产品列表
        public static readonly string[] Pp01001 = { "PP01001", "产品目录名称不能为空!" };

        public static readonly string[] Pp01002 = { "PP01002", "产品目录名称不能重复!" };

        public static readonly string[] Pp01003 = { "PP01003", "产品所属目录不能为空!" };

        public static readonly string[] Pp01004 = { "PP01004", "产品名称不能为空!" };

        #endregion

        #region 招聘职位
        public static readonly string[] Pz01001 = { "PZ01001", "招聘职位名称不能为空!" };

        public static readonly string[] Pz01002 = { "PZ01002", "招聘部门不能为空!" };

        public static readonly string[] Pz01003 = { "PZ01003", "招聘开始日期不能大于结束日期" };

        public static readonly string[] Pz01004 = { "PZ01004", "招聘职位要求不能为空!" };

        public static readonly string[] Pz01005 = { "PZ01005", "招聘人数不能为空!" };

        public static readonly string[] Pz01006 = { "PZ01006", "招聘人数输入不正确!" };

        #endregion

        /*--------------------------------------------------------------------------------------
         * 胡俊定义
         * ------------------------------------------------------------------------------------*/

        #region 事项类别
        public static readonly string[] H010001 = { "H010001", "事项类别编号不能为空!" };

        public static readonly string[] H010002 = { "H010002", "事项类别名称不能为空!" };

        public static readonly string[] H010003 = { "H010003", "事项类别归属不能为空!" };

        public static readonly string[] H010004 = { "H010004", "事项类别编号重复,不能保存!" };

        public static readonly string[] H010005 = { "H010005", "事项类别名称重复,不能保存!" };

        #endregion

        #region 系统消息
        public static readonly string[] A060001 = { "A060001", "收件人未定义,不能发送消息!" };

        public static readonly string[] A060002 = { "A060002", "发件人未定义,不能发送消息!" };

        public static readonly string[] A060003 = { "A060003", "消息内容不能为空,不能发送消息!" };

        #endregion


        /*--------------------------------------------------------------------------------------
         * 徐志杰定义
         * ------------------------------------------------------------------------------------*/

        #region 监督组织

        public static readonly string[] C010001 = { "C010001", "组织编号不能为空!" };

        public static readonly string[] C010002 = { "C010002", "组织名称不能为空!" };

        public static readonly string[] C010003 = { "C010003", "组织编号已经存在!" };

        public static readonly string[] C010004 = { "C010004", "组织名称已经存在!" };

        public static readonly string[] C010005 = { "C010005", "关键参数组织ID不正确!" };

        public static readonly string[] C010006 = { "C010006", "关键参数组织Id不能缺失!" };

        public static readonly string[] C010007 = { "C010007", "所选组织存在下级!" };

        #endregion

        #region 监督组织部门

        public static readonly string[] C020001 = { "C020001", "所选部门存在下级!" };

        #endregion

        #region 事项批文
        public static readonly string[] J010001 = { "J010001", "事项ID不能为空!" };

        public static readonly string[] J010002 = { "J010002", "项目批文ID不能为空!" };

        #endregion
    }
}
