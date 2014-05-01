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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetChoosenList()
        {
            string _paperid = Parameters["ppaperid"];
            string _detailid = Parameters["pdetailid"];
            List<HQOnlineExam.ML.OEQuestion> lists = new List<HQOnlineExam.ML.OEQuestion>();
            NameValueCollection where = new NameValueCollection();
            where.Add("condition", "(FQuestionStatus = '1') and (FQuestionId in (select FQuestionId from t_oe_paperdetailquestion where FPaperId = " + _paperid + " and FDetailSetId = " + _detailid + "))");
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
            OEPaperDetailSetBiz biz = new OEPaperDetailSetBiz();
            ErrorEntity ErrInfo = new ErrorEntity();
            NameValueCollection param = new NameValueCollection();
            param.Add("FDifficulty", _diff);
            NameValueCollection where = new NameValueCollection();
            where.Add("FPaperId", _paperid);
            where.Add("FDetailSetId", _detailid);
            biz.Update(param, where, out ErrInfo);
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
            item.FPaperTotal = string.IsNullOrEmpty(_total) ? 0 : Convert.ToInt32(_total);
            item.FPassScore = string.IsNullOrEmpty(_passscore) ? 0 : Convert.ToInt32(_passscore);
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
            }
            Response.Write(ErrInfo.ToJson());
            
        }
    }
}