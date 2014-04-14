using System;
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
    public class OEChooseQuestionBiz
    {
        public List<OEChooseQuestion> select(NameValueCollection where)
        {
            OEChooseQuestionDA da = new OEChooseQuestionDA();
            return da.Select(where).DataTableToList<OEChooseQuestion>();
        }

   
        public List<OEChooseQuestion> select(NameValueCollection where,NameValueCollection orderby)
        {
            OEChooseQuestionDA da = new OEChooseQuestionDA();
            return da.select(where,orderby).DataTableToList<OEChooseQuestion>();

        }
        public List<OEChooseQuestion> select(NameValueCollection where,NameValueCollection orderby,int pageIndex,int pageSize,out int totalCount)
        {
            OEChooseQuestionDA da = new OEChooseQuestionDA();
            return da.select(where,orderby,pageIndex,pageSize,out totalCount).DataTableToList<OEChooseQuestion>();

        }
        public Int64 Insert(OEChooseQuestion item,out ErrorEntity ErrInfo)
        {
            if(item.FPaperId==0)
            {
               ErrInfo=new ErrorEntity("0010001","试卷id不能为空");
               return -1;
            }
            if(string.IsNullOrEmpty(item.FQuestionType))
            {
                ErrInfo=new ErrorEntity("0010002","试卷类型标志不能为空");
                return -1;
            }
            if(item.FQuestionId==0)
            {
                ErrInfo=new ErrorEntity("0010003","题目id不能为空");
                    return -1;
            }
            NameValueCollection parameters=new NameValueCollection();
            parameters.Add("FPaperId",item.FPaperId.ToString());
            parameters.Add("FQuestionType",item.FQuestionType);
            parameters.Add ("FQuestionId",item.FQuestionId.ToString());
            return Insert(parameters,out ErrInfo);
        }
        public Int64 Insert(NameValueCollection parameters,out ErrorEntity ErrInfo)
        {
            OEChooseQuestionDA da=new OEChooseQuestionDA();
            Int64 result=da.InsertAndReturnId64(parameters);
            if(result>0)
            {
                ErrInfo=new ErrorEntity(RespCode.Success);

            }
            else
            {
                ErrInfo=new ErrorEntity(RespCode.SysError);
            }
            return result;
        }
        public int Update(OEChooseQuestion item,out ErrorEntity ErrInfo)
        {
            if(item.FPaperId==0)
            {
               ErrInfo=new ErrorEntity("0010001","试卷id不能为空");
               return -1;
            }
            if(string.IsNullOrEmpty(item.FQuestionType))
            {
                ErrInfo=new ErrorEntity("0010002","试卷类型标志不能为空");
                return -1;
            }
            if(item.FQuestionId==0)
            {
                ErrInfo=new ErrorEntity("0010003","题目id不能为空");
                    return -1;
            }
            NameValueCollection parameters=new NameValueCollection();
            parameters.Add("FPaperId",item.FPaperId.ToString());
            parameters.Add("FQuestionType",item.FQuestionType);
            parameters.Add ("FQuestionId",item.FQuestionId.ToString());
            NameValueCollection where=new NameValueCollection();
            where.Add("FPaperId",item.FPaperId.ToString());
            return Update(parameters,where,out ErrInfo);
        }
        public int Update(NameValueCollection parameters,NameValueCollection where,out ErrorEntity ErrInfo)
        {
            OEChooseQuestionDA da=new OEChooseQuestionDA();
            int result=da.Update(parameters,where);
            if(result >0)
            {
                ErrInfo=new ErrorEntity(RespCode.Success);
            }
            else
            {
                ErrInfo=new ErrorEntity(RespCode.SysError);
            }
            return result;
        }
        public int Delete(string idlist,out ErrorEntity ErrorInfo)
        {
            NameValueCollection where=new NameValueCollection();
            where.Add("condition","FPaperId in ("+idlist+")");
            return Delete(where,out ErrorInfo);
        }
        public int Delete(NameValueCollection where,out ErrorEntity ErrInfo)
        {
            
            OEChooseQuestionDA da=new OEChooseQuestionDA();
            int result=da.Delete(where);
            if(result>0)
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

