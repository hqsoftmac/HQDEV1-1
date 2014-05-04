using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQOnlineExam.Biz;
using HQOnlineExam.ML;
using HQLib;
using HQConst.Const;
using System.Collections.Specialized;
using HQLib.Util;
using HQLib.Common;

namespace HQDevPlatform.OnlineExam
{
    public partial class OEExamPaperAdd : PageBase
    {
        public OEExamPaper gsitem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _paperid = Parameters["pid"];
                if (string.IsNullOrEmpty(_paperid))
                {
                    gsitem = new OEExamPaper();
                    gsitem.FPaperTotal = 100;
                    gsitem.FPassScore = 60;
                    gsitem.FExamTime = 120;
                    gsitem.FExamType = "0";
                    gsitem.FPaperExtractWay = "0";
                    gsitem.FChooseItemWay = "0";
                    gsitem.FExamAgain = "0";
                }
                else
                {
                    OEExamPaperBiz biz = new OEExamPaperBiz();
                    gsitem = biz.Select(_paperid);
                }
            }
        }

        public void SaveChooseQ()
        {
            string _idlist = Parameters["pidlist"];
            string _paperid = Parameters["ppaperid"];
            string _detailid = Parameters["pdetailid"];
            OEChooseQuestionBiz biz = new OEChooseQuestionBiz();
            OEChooseQuestion item = new OEChooseQuestion();
            ErrorEntity ErrInfo = new ErrorEntity();
            item.FPaperId = Convert.ToInt64(_paperid);
            item.FDetailId = Convert.ToInt32(_detailid);
            string[] qidarray;
            qidarray = _idlist.Split(',');
            for (int i = 0; i < qidarray.Length; i++)
            {
                if(!string.IsNullOrEmpty(qidarray[i]))
                {
                    item.FQuestionId = Convert.ToInt32(qidarray[i]);
                    int result = biz.Insert(item, out ErrInfo);
                    if (result <= 0)
                    {
                        Response.Write(ErrInfo.ToJson());
                        return;
                    }
                }
            }
            Response.Write(ErrInfo.ToJson());
        }

        public void GetChoosenBank()
        {
            string _paperid = Parameters["ppaperid"];
            List<OECombineBank> lists = new List<OECombineBank>();
            OECombineBankBiz biz = new OECombineBankBiz();
            lists = biz.Select(_paperid);
            if (lists.Count > 0)
            {
                Response.Write(Utils.ConvertToJson(lists));
            }
            else
            {
                Response.Write("NULL");
            }
        }

        public void GetQuestionList()
        {
            string _bank = Parameters["pbank"];
            string _title = Parameters["ptitle"];
            string _keyword = Parameters["pkeyword"];
            string _chkpoint = Parameters["ppoint"];
            string _paperid = Parameters["ppaperid"];
            string _detailid = Parameters["pdetailid"];
            string wheresql = "(FQuestionId not in (select FQuestionId from t_oe_choosequestion where FPaperId = " + _paperid + "))";
            wheresql += " and (FQuestionStatus = '1')";
            wheresql += " and (FQuestionDifficulty in (select FDifficulty from t_oe_paperdetailset where FPaperId = " + _paperid + " and FDetailSetId = " + _detailid + "))";
            wheresql += " and (FQuestionType in (select FQuestionType from t_oe_paperdetailset where FPaperId = " + _paperid + " and FDetailSetId = " + _detailid + "))";
            if (string.IsNullOrEmpty(_bank))
            {
                wheresql += " and (FQbankId in (select FQBankId from t_oe_combinebank where FPaperId = " + _paperid + "))";
            }
            else
            {
                wheresql += " and (FQBankId = " + _bank + ")";
            }
            if (!string.IsNullOrEmpty(_title))
            {
                wheresql += " and (FQuestionTitle like '%" + _title + "%')";
            }
            if (!string.IsNullOrEmpty(_keyword))
            {
                string _k = _keyword.Trim();
                string[] k;
                k = _k.Split(' ');
                string _sql = "";
                for (int i = 0; i < k.Length; i++)
                {
                    if (!string.IsNullOrEmpty(_sql))
                    {
                        _sql += " or ";
                    }
                    if (!string.IsNullOrEmpty(k[i].Trim()))
                    {
                        _sql += " ( FKeyWord like '%" + k[i].Trim() + "%') ";
                    }
                }
                if (!string.IsNullOrEmpty(_sql))
                {
                    wheresql += " and (" + _sql + ") ";
                }
            }
            if (!string.IsNullOrEmpty(_chkpoint))
            {
                wheresql += " and (FQuestionDesc like '%" + _chkpoint + "%')";
            }
            List<HQOnlineExam.ML.OEQuestion> lists = new List<HQOnlineExam.ML.OEQuestion>();
            OEQuestionBiz biz = new OEQuestionBiz();
            NameValueCollection where = new NameValueCollection();
            where.Add("condition",wheresql);
            lists = biz.Select(where);
            if (lists.Count > 0)
            {
                Response.Write(Utils.ConvertToJson(lists));
            }
            else
            {
                Response.Write("NULL");
            }
        }

        public void LoadQuestionType()
        {
            string _paperid = Parameters["ppaperid"];
            List<OECombineType> lists = new List<OECombineType>();
            OECombineTypeBiz biz = new OECombineTypeBiz();
            lists = biz.Select(_paperid);
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void LoadQuestionBank()
        {
            string _paperid = Parameters["ppaperid"];
            List<OECombineBank> lists = new List<OECombineBank>();
            OECombineBankBiz biz = new OECombineBankBiz();
            lists = biz.Select(_paperid);
            for (int i = 0; i < lists.Count; i++)
            {
                lists[i].FOperation = "<a href='javascript:void(0)' onclick='setrate(" + lists[i].FQBankId.ToString() + ")'>设置比例</a>";
            }
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void GetChoosenList()
        {
            string _paperid = Parameters["ppaperid"];
            string _detailid = Parameters["pdetailid"];
            List<HQOnlineExam.ML.OEQuestion> lists = new List<HQOnlineExam.ML.OEQuestion>();
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "(FQuestionStatus = '1') and (FQuestionId in (select FQuestionId from t_oe_choosequestion where FPaperId = " + _paperid + " and FDetailId = " + _detailid + "))");
            OEQuestionBiz biz = new OEQuestionBiz();
            lists = biz.Select(where);
            if (lists.Count > 0)
            {
                Response.Write(Utils.ConvertToJson(lists));
            }
            else
            {
                Response.Write("NULL");
            }
        }

        public void SaveDiff()
        {
            string _diff = Parameters["pdiff"];
            string _paperid = Parameters["ppaperid"];
            string _detailid = Parameters["pdetailid"];
            OEPaperDetailQuestionBiz biz = new OEPaperDetailQuestionBiz();
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", _paperid);
            where.Add("FDetailSetId", _detailid);
            ErrorEntity ErrInfo = new ErrorEntity();
            NameValueCollection param = new NameValueCollection();
            param.Add("FDifficulty", _diff);
            if (biz.Select(where).Count > 0)
            {
                biz.Update(param,where, out ErrInfo);
            }
            else
            {
                param.Add("FPaperId", _paperid);
                param.Add("FDetailSetId", _detailid);
                biz.Insert(param, out ErrInfo);
            }
            Response.Write(ErrInfo.ToJson());
        }

        public void GetDetailSet()
        {
            string _paperid = Parameters["ppaperid"];
            OEPaperDetailSetBiz biz = new OEPaperDetailSetBiz();
            List<OEPaperDetailSet> lists = new List<OEPaperDetailSet>();
            lists = biz.Select(_paperid);
            //获取paper关于在线模式的设定
            OEExamPaper item = new OEExamPaper();
            OEExamPaperBiz pbiz = new OEExamPaperBiz();
            item = pbiz.Select(_paperid);
            string _operation = "";
            for (int i = 0; i < lists.Count; i++)
            {
                _operation = "<a href='javascript:void(0)' onclick='adjugedifficulty(" + _paperid + "," + lists[i].FDetailSetId.ToString() + ")'>调整难度等级</a>";
                if (item.FExamType == "0")
                {
                    _operation += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='setquestion(" + _paperid + "," + lists[i].FDetailSetId.ToString() + ")'>指定题目</a>";
                }
                else
                {
                    _operation += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='javascript:void(0)' onclick='setchoosen(" + _paperid + "," + lists[i].FDetailSetId.ToString() + ")'>设置备选题目</a>";
                }
                lists[i].FOperation = _operation;
            }
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void GetQTypeCount()
        {
            OEQuestionBiz biz = new OEQuestionBiz();
            NameValueCollection where = new NameValueCollection();
            string _type = Parameters["ptype"];
            string _banklist = Parameters["pidlist"];
            where.Add("condition", "(FQuestionType = '" + _type + "') and (FQBankId in (" + _banklist + "))");
            Int64 result = biz.SelectCount(where);
            Response.Write(result.ToString());
        }

        public void GetBankList()
        {
            string pcontentclassid = Parameters["pcontentclassid"];
            OEContentClassBiz ccbiz = new OEContentClassBiz();
            string ccidlist = "";
            ccbiz.GetChildrenIdList(pcontentclassid, ref ccidlist);
            List<OEQuestionBank> lists = new List<OEQuestionBank>();
            OEQuestionBankBiz biz = new OEQuestionBankBiz();
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "(FQBankStatus = '1') and (FContentClassId in (" + ccidlist + "))");
            lists = biz.Select(where);
            Response.Write(Utils.ConvertToJson(lists));
        }

        public void GetContentClassTree()
        {
            OEContentClassTreeBiz biz = new OEContentClassTreeBiz();
            Response.Write(biz.JsonSelect());
        }

        public void SaveInfo2()
        {
            string _banklist = Parameters["pbanklist"];
            string _ratelist = Parameters["pratelist"];
            string _typelist = Parameters["ptypelist"];
            string _numlist = Parameters["pnumlist"];
            string _scorelist = Parameters["pscorelist"];
            string _paperid = Parameters["ppaperid"];
            string[] bankarray;
            string[] ratearray;
            string[] typearray;
            string[] numarray;
            string[] scorearray;
            bankarray = _banklist.Split(',');
            ratearray = _ratelist.Split(',');
            typearray = _typelist.Split(',');
            numarray = _numlist.Split(',');
            scorearray = _scorelist.Split(',');
            OECombineBankBiz bbiz = new OECombineBankBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            //check total rate ?= 100
            int _rate = 0;
            for (int i = 0; i < ratearray.Length; i++)
            {
                _rate += string.IsNullOrEmpty(ratearray[i]) ? 0 : Convert.ToInt32(ratearray[i]);
            }
            if (_rate != 100)
            {
                ErrInfo = new ErrorEntity("EP020001", "题库分配比例不等于100%,请检查相关设定!");
                Response.Write(ErrInfo.ToJson());
                return;
            }
            //check all type of question's totalscore ?= papertotal
            OEExamPaperBiz pbiz = new OEExamPaperBiz();
            OEExamPaper pitem = new OEExamPaper();
            pitem = pbiz.Select(_paperid);
            if(pitem == null)
            {
                ErrInfo = new ErrorEntity("EP020002","试卷基本信息尚未设定,请先设定基本信息!");
                Response.Write(ErrInfo.ToJson());
                return;
            }
            decimal papertotal = pitem.FPaperTotal;
            decimal _scoretotal = 0;
            for (int i = 0; i < scorearray.Length; i++)
            {
                _scoretotal += ((string.IsNullOrEmpty(scorearray[i]) ? 0 : Convert.ToDecimal(scorearray[i])) * (string.IsNullOrEmpty(numarray[i]) ? 0 : Convert.ToDecimal(numarray[i])));
            }
            if (_scoretotal != papertotal)
            {
                ErrInfo = new ErrorEntity("EP020003", "各题型的得分设定不等于试卷总分,请检查相关设定!");
                Response.Write(ErrInfo.ToJson());
                return;
            }

            //delete old choosebank
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", _paperid);
            bbiz.Delete(where, out ErrInfo);

            //delete od question type
            OECombineTypeBiz tbiz = new OECombineTypeBiz();
            tbiz.Delete(where, out ErrInfo);

            //insert new choosebank
            for (int i = 0; i < bankarray.Length;i++ )
            {
                if (!string.IsNullOrEmpty(bankarray[i]))
                {
                    OECombineBank item = new OECombineBank();
                    item.FPaperId = Convert.ToInt64(_paperid);
                    item.FQBankId = Convert.ToInt64(bankarray[i]);
                    item.FQBnakRate = Convert.ToDecimal(ratearray[i]);
                    bbiz.Insert(item, out ErrInfo);
                }
            }

            //insert new question type
            for (int i = 0; i < typearray.Length; i++)
            {
                if (!string.IsNullOrEmpty(typearray[i]))
                {
                    OECombineType item = new OECombineType();
                    item.FPaperId = Convert.ToInt64(_paperid);
                    item.FQuestionType = typearray[i];
                    item.FQuestionNum = Convert.ToInt32(numarray[i]);
                    item.FQuestionScore = Convert.ToDecimal(scorearray[i]);
                    tbiz.Insert(item, out ErrInfo);
                }
            }

            //delete old paperdetailset
            OEPaperDetailSetBiz dbiz = new OEPaperDetailSetBiz();
            dbiz.Delete(_paperid, out ErrInfo);
            //insert new paperdetailset
            int j = 1;
            for (int i = 0; i < typearray.Length; i++)
            {
                if (!string.IsNullOrEmpty(typearray[i]))
                {
                    for (int m = 1; m <= Convert.ToInt32(numarray[i]); m++)
                    {
                        OEPaperDetailSet item = new OEPaperDetailSet();
                        item.FPaperId = Convert.ToInt64(_paperid);
                        item.FDetailSetId = j;
                        item.FQuestionType = typearray[i];
                        item.FDifficulty = "0";
                        item.FScore = Convert.ToDecimal(scorearray[i]);
                        dbiz.Insert(item, out ErrInfo);
                        //检测备选题型不符合,将删除备选题目设定
                        List<OEChooseQuestion> choosequestion = new List<OEChooseQuestion>();
                        OEChooseQuestionBiz cqbiz = new OEChooseQuestionBiz();
                        NameValueCollection cqwhere = new NameValueCollection();
                        cqwhere.Add("FPaperId", _paperid);
                        cqwhere.Add("FDetailId", j.ToString());
                        choosequestion = cqbiz.Select(cqwhere);
                        if (choosequestion.Count > 0)
                        {
                            if (choosequestion[0].FQuestionType != item.FQuestionType)
                            {
                                cqbiz.Delete(cqwhere, out ErrInfo);
                            }
                        }
                        j++;
                    }
                }
            }

            Response.Write(ErrInfo.ToJson());
        }

        public void SavePage1()
        {
            string _paperid = Parameters["ppaperid"];
            string _pagename = Parameters["ppagename"];
            string _contentclassid = Parameters["pcontentclassid"];
            string _total = Parameters["ptotal"];
            string _examtype = Parameters["pexamtype"];
            string _extractway = Parameters["pextractway"];
            string _chooseitemway = Parameters["pchooseitemway"];
            string _examtime = Parameters["pexamtime"];
            string _papercontent = Parameters["ppapercontent"];
            string _examagain = Parameters["pexamagain"];
            string _passscore = Parameters["ppassscore"];
            OEExamPaper item = new OEExamPaper();
            item.FChooseItemWay = _chooseitemway;
            item.FContentClassId = string.IsNullOrEmpty(_contentclassid) ? 0 : Convert.ToInt64(_contentclassid);
            item.FExamAgain = _examagain;
            item.FExamTime = string.IsNullOrEmpty(_examtime) ? 0 : Convert.ToInt32(_examtime);
            item.FExamType = _examtype;
            item.FPaperContent = _papercontent;
            item.FPaperExtractWay = _extractway;
            item.FPaperId = string.IsNullOrEmpty(_paperid) ? 0 : Convert.ToInt64(_paperid);
            item.FPaperName = _pagename;
            item.FPaperTotal = string.IsNullOrEmpty(_total) ? 0 : Convert.ToDecimal(_total);
            item.FPassScore = string.IsNullOrEmpty(_passscore) ? 0 : Convert.ToDecimal(_passscore);
            item.AUserId = Convert.ToInt64(userid);
            OEExamPaperBiz biz = new OEExamPaperBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            if (item.FPaperId == 0)
            {
                item.FPaperStatus = "2";
                Int64 result = biz.Insert(item, out ErrInfo);
                if (ErrInfo.ErrorCode == RespCode.Success)
                {
                    ErrInfo.ErrorMessage = result.ToString();
                }
            }
            else
            {
                item.FPaperTime = DateTime.Today;
                biz.Update(item, out ErrInfo);
                if (ErrInfo.ErrorCode == RespCode.Success)
                {
                    ErrInfo.ErrorMessage = item.FPaperId.ToString();
                }
            }
            Response.Write(ErrInfo.ToJson());
            
        }
    }
}