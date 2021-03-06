﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQOnlineExam.ML;
using HQLib.Common;
using System.Collections.Specialized;
using HQOnlineExam.DA;
using HQLib;
using HQConst.Const;
namespace HQOnlineExam.Biz
{
    //OEContentClass
    public partial class OEContentClassBiz
    {
        public void GetChildrenIdList(string _id,ref string _idlist)
        {
            if (string.IsNullOrEmpty(_idlist))
            {
                _idlist += _id;
            }
            else
            {
                _idlist += "," + _id;
            }
            OEContentClass item = new OEContentClass();
            item = Select(_id);
            List<OEContentClass> lists = new List<OEContentClass>();
            NameValueCollection where = new NameValueCollection();
            where.Add("FParentId", _id);
            lists = Select(where);
            foreach (OEContentClass newitem in lists)
            {
                GetChildrenIdList(newitem.FContentClassId.ToString(), ref _idlist);
            }
        }

        public List<OEContentClass> Select()
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "1=1");
            return Select(where);
        }

        public OEContentClass Select(string _id)
        {
            List<OEContentClass> lists = new List<OEContentClass>();
            NameValueCollection where = new NameValueCollection();
            where.Add("FContentClassId", _id);
            lists = Select(where);
            if (lists.Count > 0)
            {
                return lists[0];
            }
            else
            {
                return null;
            }
        }

        public List<OEContentClass> Select(NameValueCollection where)
        {
            OEContentClassDA da = new OEContentClassDA();
            return da.Select(where).DataTableToList<OEContentClass>();
        }

        public List<OEContentClass> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEContentClassDA da = new OEContentClassDA();
            return da.Select(where, orderby).DataTableToList<OEContentClass>();
        }

        public List<OEContentClass> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEContentClassDA da = new OEContentClassDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEContentClass>();
        }

        public Int64 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEContentClassDA da = new OEContentClassDA();
            Int64 result = da.InsertAndReturnId64(parameters);
            if (result > 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Success);
            }
            else
            {
                ErrInfo = new ErrorEntity(RespCode.SysError);
            }
            return result;
        }

        public Boolean ChkCodeDuplicate(string _code, string _id)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FContentClassId <>", _id);
            where.Add("FContentClassCode", _code);
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public Int64 Insert(OEContentClass item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define
            if (string.IsNullOrEmpty(item.FContentClassCode))
            {
                ErrInfo = new ErrorEntity("CC010001", "内容类别编号为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FContentClassName))
            {
                ErrInfo = new ErrorEntity("CC010002", "内容类别名称不能为空!");
                return -1;
            }
            if (!ChkCodeDuplicate(item.FContentClassId.ToString(), item.FContentClassCode))
            {
                ErrInfo = new ErrorEntity("CC010003", "内容类别编号不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FContentClassCode", item.FContentClassCode);
            parameters.Add("FContentClassName", item.FContentClassName);
            parameters.Add("FContentClassContent", item.FContentClassContent);
            parameters.Add("FParentId", item.FParentId.ToString());
            parameters.Add("FIconPath", item.FIconPath);
            return Insert(parameters, out ErrInfo);
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEContentClassDA da = new OEContentClassDA();
            int result = da.Update(parameters, where);
            if (result > 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Success);
            }
            else
            {
                ErrInfo = new ErrorEntity(RespCode.SysError);
            }
            return result;

        }

        public Int32 Update(OEContentClass item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define
            if (string.IsNullOrEmpty(item.FContentClassCode))
            {
                ErrInfo = new ErrorEntity("CC010001", "内容类别编号为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FContentClassName))
            {
                ErrInfo = new ErrorEntity("CC010002", "内容类别名称不能为空!");
                return -1;
            }
            if (!ChkCodeDuplicate(item.FContentClassId.ToString(), item.FContentClassCode))
            {
                ErrInfo = new ErrorEntity("CC010003", "内容类别编号不能为空!");
                return -1;
            }
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FContentClassCode", item.FContentClassCode);
            parameters.Add("FContentClassName", item.FContentClassName);
            parameters.Add("FContentClassContent", item.FContentClassContent);
            parameters.Add("FParentId", item.FParentId.ToString());
            parameters.Add("FIconPath", item.FIconPath);
            NameValueCollection where = new NameValueCollection();
            where.Add("FContentClassId", item.FContentClassId.ToString());
            return Update(parameters, where, out ErrInfo);
        }

        public Boolean ChkHasChildren(string idlist)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FParentid in (" + idlist + ")");
            if (Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean ChkHasQuestionBank(string idlist)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "FContentClassId in (" + idlist + ")");
            OEQuestionBankBiz biz = new OEQuestionBankBiz();
            if (biz.Select(where).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int Delete(string idlist, out ErrorEntity ErrInfo)
        {
            if (!ChkHasQuestionBank(idlist))
            {
                ErrInfo = new ErrorEntity("CC010005", "要删除的内容类别下已经设置有题库,不能删除,若要删除,请首先删除该类别下所有的题库!");
                return -1;
            }
            
            if (!ChkHasChildren(idlist))
            {
                ErrInfo = new ErrorEntity("CC010004", "要删除的类别存在下级类别无法删除!");
                return -1;
            }
            else
            {
                NameValueCollection where = new NameValueCollection();
                where.Add("condition", "FContentClassId in (" + idlist + ")");
                return Delete(where, out ErrInfo);
            }
        }

        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEContentClassDA da = new OEContentClassDA();
            int result = da.Delete(where);
            if (result > 0)
            {
                ErrInfo = new ErrorEntity(RespCode.Success);
            }
            else
            {
                ErrInfo = new ErrorEntity(RespCode.SysError);
            }
            return result;
        }

    }
}