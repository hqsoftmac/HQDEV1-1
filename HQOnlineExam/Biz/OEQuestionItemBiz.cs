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
    //OEExamItem
    public partial class OEQuestionItemBiz
    {
        public List<OEQuestionItem> Select(string _qid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FQuestionId", _qid);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FItemId", "asc");
            return Select(where, orderby);
        }
        
        public List<OEQuestionItem> Select(NameValueCollection where)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
            return da.Select(where).DataTableToList<OEQuestionItem>();
        }

        public List<OEQuestionItem> Select(NameValueCollection where, NameValueCollection orderby)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
            return da.Select(where, orderby).DataTableToList<OEQuestionItem>();
        }

        public List<OEQuestionItem> Select(NameValueCollection where, NameValueCollection orderby, int pageIndex, int pageSize, out int totalCount)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
            return da.Select(where, orderby, pageIndex, pageSize, out totalCount).DataTableToList<OEQuestionItem>();
        }

        public Int32 Insert(NameValueCollection parameters, out ErrorEntity ErrInfo)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
            Int32 result = da.Insert(parameters);
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

        public Int32 GenerateItemId(string _questionid)
        {
            NameValueCollection where = new NameValueCollection();
            where.Add("FQuestionId", _questionid);
            NameValueCollection orderby = new NameValueCollection();
            orderby.Add("FItemId", "desc");
            List<OEQuestionItem> lists = new List<OEQuestionItem>();
            lists = Select(where,orderby);
            if (lists.Count > 0)
            {
                Int32 _itemid = lists[0].FItemId;
                _itemid++;
                return _itemid;
            }
            else
            {
                return 1;
            }
        }

        public Int32 Insert(OEQuestionItem item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define
            if (item.FQuestionId == 0)
            {
                ErrInfo = new ErrorEntity("QI010001", "归属题目ID不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FItemContent))
            {
                ErrInfo = new ErrorEntity("QI010002", "题目答案内容不能为空!");
                return -1;
            }
            if (string.IsNullOrEmpty(item.FItemFlag))
            {
                item.FItemFlag = "0";
            }
            //判断题型
            NameValueCollection where = new NameValueCollection();
            where.Add("FQuestionId", item.FQuestionId.ToString());
            List<OEQuestionItem> itemlists = new List<OEQuestionItem>();
            itemlists = Select(where);
            if (itemlists.Count > 0)
            {
                OEQuestion qitem = new OEQuestion();
                OEQuestionBiz biz = new OEQuestionBiz();
                qitem = biz.Select(item.FQuestionId.ToString());
                if (qitem.FQuestionType == "0")
                {
                    if(itemlists.Count > 1)
                    {
                        ErrInfo = new ErrorEntity("QI010003", "判断题型只能有2个备选答案!");
                        return -1;
                    }
                }
                if (qitem.FQuestionType == "1")
                {
                    if (item.FItemFlag == "1")
                    {
                        if (itemlists.Where(p => p.FItemFlag == "1").ToList<OEQuestionItem>().Count > 0)
                        {
                            ErrInfo = new ErrorEntity("QI010004", "单选题只能有一个正确答案!");
                            return -1;
                        }
                    }
                }
            }

            item.FItemId = GenerateItemId(item.FQuestionId.ToString());
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FItemId", item.FItemId.ToString());
            parameters.Add("FItemContent", item.FItemContent);
            parameters.Add("FItemFlag", item.FItemFlag);
            return Insert(parameters, out ErrInfo);
        }

        public int UpdateError(string _qid, string _itemid, out ErrorEntity ErrInfo)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FItemFlag", "0");
            NameValueCollection where = new NameValueCollection();
            where.Add("FQuestionId", _qid);
            where.Add("FItemId", _itemid);
            return Update(parameters, where, out ErrInfo);
        }

        public int UpdateRight(string _qid, string _itemid, out ErrorEntity ErrInfo )
        {
            OEQuestionBiz biz = new OEQuestionBiz();
            OEQuestion item = new OEQuestion();
            item = biz.Select(_qid);
            string _type = item.FQuestionType;
            switch (_type)
            {
                case "1": //判断题
                    NameValueCollection parameters = new NameValueCollection();
                    parameters.Add("FItemFlag", "0");
                    NameValueCollection where = new NameValueCollection();
                    where.Add("FQuestionId", _qid);
                    Update(parameters, where, out ErrInfo);
                    parameters.Clear();
                    parameters.Add("FItemFlag", "1");
                    where.Add("FItemId", _itemid);
                    return Update(parameters, where, out ErrInfo);
                case "2":
                    NameValueCollection parameters1 = new NameValueCollection();
                    parameters1.Add("FItemFlag", "0");
                    NameValueCollection where1 = new NameValueCollection();
                    where1.Add("FQuestionId", _qid);
                    Update(parameters1, where1, out ErrInfo);
                    parameters1.Clear();
                    parameters1.Add("FItemFlag", "1");
                    where1.Add("FItemId", _itemid);
                    return Update(parameters1, where1, out ErrInfo);
                default:
                    NameValueCollection parameters2 = new NameValueCollection();
                    NameValueCollection where2 = new NameValueCollection();
                    parameters2.Add("FItemFlag", "1");
                    where2.Add("FQuestionId", _qid);
                    where2.Add("FItemId", _itemid);
                    return Update(parameters2, where2, out ErrInfo);
            }
        }

        public int Update(NameValueCollection parameters, NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
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

        public Int32 Update(OEQuestionItem item, out ErrorEntity ErrInfo)
        {
            //Error Judge Define

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("FQuestionId", item.FQuestionId.ToString());
            parameters.Add("FItemId", item.FItemId.ToString());
            parameters.Add("FItemContent", item.FItemContent);
            parameters.Add("FItemFlag", item.FItemFlag);
            NameValueCollection where = new NameValueCollection();
            where.Add("FQuestionId", item.FQuestionId.ToString());
            where.Add("FItemId", item.FItemId.ToString());
            return Update(parameters, where, out ErrInfo);
        }


        public int Delete(NameValueCollection where, out ErrorEntity ErrInfo)
        {
            OEQuestionItemDA da = new OEQuestionItemDA();
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