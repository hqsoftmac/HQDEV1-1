﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQLib.Page;
using HQPortal.ML;
using HQPortal.Biz;
using HQLib;

namespace HQDevSys.manage.article
{
    public partial class articlecontentadd : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetListTitleName()
        {
            string _id = Parameters["plistid"];
            if (string.IsNullOrEmpty(_id) || _id == "0")
            {
                Response.Write("根目录");
            }
            else
            {
                string _titlename = "";
                PortalArticleListBiz biz = new PortalArticleListBiz();
                biz.GetListName(_id, ref _titlename);
                Response.Write(_titlename);
            }
        }

        public void GetArticleList()
        {
            List<PortalArticleListTree> lists = new List<PortalArticleListTree>();
            List<PortalArticleList> lists1 = new List<PortalArticleList>();
            PortalArticleListBiz biz = new PortalArticleListBiz();
            lists1 = biz.Select();
            PortalArticleListTreeBiz treebiz = new PortalArticleListTreeBiz();
            lists = treebiz.select(lists1);
            PortalArticleListTree newitem = new PortalArticleListTree();
            newitem.FListId = 0;
            newitem.FListCode = "";
            newitem.FListName = "根目录";
            newitem.FListOrder = 10;
            newitem.FParentListId = 0;
            newitem.children = lists;
            List<PortalArticleListTree> newlists = new List<PortalArticleListTree>();
            newlists.Add(newitem);
            string datasource = treebiz.ConvertToJson(newlists);
            Response.Write(datasource);
        }

        public void SaveContent()
        {
            string _arttitle = Parameters["parttitle"];
            string _titlestyle = Parameters["ptitlestyle"];
            string _author = Parameters["pauthor"];
            string _comefrom = Parameters["pcomefrom"];
            string _releasetime = Parameters["preleasetime"];
            string _clicknum = Parameters["pclicknum"];
            string _url = Parameters["purl"];
            string _picflag = Parameters["ppicflag"];
            string _picpath = Parameters["ppicpath"];
            string _commentflag = Parameters["pcommentflag"];
            string _seotitle = Parameters["pseotitle"];
            string _seokeyword = Parameters["pseokeyword"];
            string _seodesc = Parameters["pseodesc"];
            string _briefcontent = Parameters["pbriefcontent"];
            string _content = Parameters["pcontent"];
            string _listid = Parameters["plistid"];
            PortalArticleBiz biz = new PortalArticleBiz();
            PortalArticle item = new PortalArticle();
            item.FArticleAuthor = _author;
            item.FArticleClickNum = Convert.ToInt32(_clicknum);
            item.FArticleComeFrom = _comefrom;
            if (string.IsNullOrEmpty(_releasetime))
            {
                item.FArticleTime = DateTime.Now;
            }
            else
            {
                item.FArticleTime = Convert.ToDateTime(_releasetime);
            }
            item.FArticlePic = _picpath;
            item.FArticlePicFlag = _picflag;
            item.FArticleStyle = _titlestyle;
            item.FArticleTitle = _arttitle;
            item.FArticleUrl = _url;
            item.FBriefContent = _briefcontent;
            item.FCommentFlag = _commentflag;
            item.FContent = _content;
            item.FSEODescription = _seodesc;
            item.FSEOKeyWord = _seokeyword;
            item.FSEOTitle = _seotitle;
            if (string.IsNullOrEmpty(_listid))
            {

            }
            else
            {
                item.FListId = Convert.ToInt64(_listid);
            }
            ErrorEntity ErrInfo = new ErrorEntity();
            biz.Insert(item, out ErrInfo);
            Response.Write(ErrInfo.ToJson());
        }
    }
}