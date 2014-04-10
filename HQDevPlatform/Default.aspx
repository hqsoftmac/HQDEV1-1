<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register src="template/style01/header.ascx" tagname="header" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
    <title><%=gssitename %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content=<%=gssitedesc %> />
    <meta name="keywords" content=<%=gssitekey %> />
    <meta name="author" content="华强通用软件有限公司 HuaQiang General SoftWare" />
    <!-- CSS -->
    <style type="text/css" media="all">@import url("<%=gssitestyle %>" );</style>
    
    <!--[if lt IE 9]><script src="js/html5.js"></script><![endif]-->
    <!-- END CSS -->

    <!-- JAVASCRIPT -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script>        window.jQuery || document.write('<script src="js/jquery-1.7.2.min.js"><\/script>')</script>
    <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="js/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="js/script.js"></script>
    <script type="text/javascript" src="js/scrolltopcontrol.js"></script>
    <script type="text/javascript" src="js/superfish.js"></script>
    <script type="text/javascript" src="js/custom.js"></script>
    <script type="text/javascript" src="js/jquery.modernizr.min.js"></script>
    <!-- END JAVASCRIPT -->
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div class="slider"><!-- SLIDER -->    
      <link rel="stylesheet" href="layerslider/css/layerslider.css" type="text/css" />
      <div id="layerslider">
			<div class="ls-layer" rel="slidedelay: 3000;">
			    <img class="ls-bg" src="images/slider/browsers.png" alt="layer" />
                <div class="ls-s3" style="padding: 0px; width: 440px; left: 580px; top: 80px;color: white; text-shadow: none; font-size: 30px; font-weight: bold;">
		            华强通用软件有限公司
			    </div>
                <p id="P1" class="ls-s3" style="top:110px;font-size:10pt;left: 580px;color:#fff;">
                    软件企业&nbsp;&nbsp;认定编号:苏R-2012-F0009<br />
				</p>
                <div class="ls-s3" style="padding: 0px; width: 440px; left: 580px; top: 150px;color: white; text-shadow: none; font-size: 25px; font-weight: bold;">
		            10年的成功经验积淀,您的睿智之选
			    </div>
			</div>
            <div class="ls-layer" rel="slidedelay: 3000;">
				<img class="ls-s2" src="images/slider/monitor_01.png" alt="sublayer" rel="durationin: 1900; easingin: easeOutQuad" />
				<img class="ls-s3" src="images/slider/monitor_02.png" alt="sublayer" rel="durationin: 1200; easingin: easeOutQuad" />
				<div class="ls-s11" style="padding: 20px; width: 440px; left: 50px; top: 40px;color: white; text-shadow: none; font-size: 30px; font-weight: bold; line-height:auto;">
				    华强党风廉政建设考评系统
			    </div>
                <p id="l5text1" class="ls-s12" style="top:100px;">
                    3年的用户应用经验价值积淀<br />
                    贯穿责任分解、考核、追究三个重点环节<br />
                    建立承前启后，严格公正的连续考核评价体系<br />
				    轻松组织变年底集中检查为日常考核,得分实时体现<br />
                    加速结果到运用的过程
				</p>
			    <div class="ls-s2" style="left: 70px; top: 220px;"><a class="button large black" href="#">详细了解</a></div>
		    </div>
                
            <div class="ls-layer" rel="slidedelay: 3000;">
			  <div class="ls-s2" style="left: 50px; top: 50px;">
				<a href="index.html"><img src="images/slider/mzcp_01.png" alt="" /></a>
                <!--<iframe src="http://player.vimeo.com/video/40977081" width="500" height="300" frameborder="0" webkitallowfullscreen="" mozallowfullscreen="" allowfullscreen=""></iframe>	-->					
			  </div>
			<div class="ls-s3" style="padding: 20px; width: 440px; left: 580px; top: 40px;            color: white; text-shadow: none; font-size: 30px; font-weight: bold; line-height            : auto;">
		    华强网上民主测评系统
			</div>
              <p id="l5text2" class="ls-s3" style="top:100px; left: 600px;">
			   轻松定制形式多样的测评表单<br />
               可针对不同测评对象定制内容<br />
               一键统计测评各项结果<br />
               排名分析、满意度分析、图形分析<br />
		      </p>
              <div class="ls-s2" style="left: 600px; top: 220px;"><a class="button large grey" href="#">详细了解</a></div>
			</div>
		</div>
  </div><!-- END SLIDER -->
    
    <div class="main" style="margin-top:5px;"><!-- MAIN -->
      <div class="container_12">
        <div class="grid_3">
          <section class="tabs" style="width:220px;">
	            <input id="tab-1" type="radio" name="radio-set" class="tab-selector-1" checked="checked" />
		        <label for="tab-1" class="tab-label-1" style="font-size:1em;">华强新闻</label>
		
	            <input id="tab-2" type="radio" name="radio-set" class="tab-selector-2" />
		        <label for="tab-2" class="tab-label-2" style="font-size:1em;">华强公告</label>
			    <div class="clear-shadow"></div>
		        <div class="content" style="width:220px;height:254px;overflow:hidden;padding:0px;">
                    <div class="content-1" style="padding:10px 0px 10px 5px;">
                        <ul style="width:220px;height:220px;z-index:9999;padding:0px;position:relative;display:block;">
                            <li>
                                Lorem ipsum dolor sit amet
                            </li>
                            <li>
                                Class aptent taciti sociosqu
                            </li>
                            <li>
                                Class aptent taciti sociosqu
                            </li> 
                        </ul>
                        <p style="text-align:right;"><a href="#" style="font-size:0.8em;font-style:italic;">更多...</a>&nbsp;&nbsp;</p>
                    </div>
                    <div class="content-2" style="padding:10px 0px 10px 5px;">
                        <ul style="width:220px;height:220px;padding:0px;position:relative;display:block;">
                            <li>
                                Lorem ipsum dolor sit amet
                            </li>
                            <li>
                                Class aptent taciti sociosqu
                            </li>
                            <li>
                                Class aptent taciti sociosqu
                            </li> 
                        </ul>
                        <p style="text-align:right;"><a href="#" style="font-size:0.8em;font-style:italic;">更多...</a>&nbsp;&nbsp;</p>
                    </div>
                </div>
			</section>
          </div>
          <ul class="portfolio_4_col group"><!-- PORTFOLIO ITEMS -->
            <li class="item" data-id="id-1" data-type="html">
              <a href="images/portfolio/01.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/01.jpg" alt="" /></a>
              <h5 class="uppercase">
                <a href="#">行政事业应用系列</a>
              </h5>
              <p>
                主要面向行政事业单位的应用系统,主要面向党风廉政建设、党员信息管理、廉政档案、三公经费\重大事项监督与管理等.
              </p>
              <a href="portfolio_single.html" class="button large white" style="width:55px;">查看详细</a>
            </li>
            <li class="item" data-id="id-2" data-type="html">
              <a href="images/portfolio/02.png" rel="prettyPhoto[portfolio]"><img src="images/portfolio/02.png" alt="" /></a>
              <h5 class="uppercase">
                <a href="#">企业管理应用系列</a>
              </h5>
              <p>
                企业信息化管理专家,财务管理、进销存管理、生产管理、MES、OA办公、HR、CRM等等.
              </p><a href="portfolio_single.html" class="button large white" style="width:55px;">查看详细</a>
            </li>
            <li class="item" data-id="id-3" data-type="html">
              <a href="images/portfolio/03.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/03.jpg" alt="" /></a>
              <h5 class="uppercase">
                软件定制外包服务
              </h5>
              <p>
                为您量身定制软件,桌面应用、网络应用、手机应用、数据库应用、电子商务应用;B/S架构、C/S架构;
              </p><a href="portfolio_single.html" class="button large white" style="width:55px;">查看详细</a>
            </li>
          </ul><!-- END PORTFOLIO ITEMS -->
        </div>
    </div><!-- END MAIN -->
    <div class="bottom" style="margin-top:-20px;" ><!-- BOTTOM -->
        <div class="container_12" style="border-top-style:dashed;border-top-width:1px;border-top-color:#eeeeee;padding-top:0px;" >
            <div class="grid_3 box_light_gray inner" style="padding-top:0px;">
                <h5 class="uppercase" style="background:transparent url(images/icons/Binder_s.png) no-repeat 5px 5px;height:25px;padding:10px 0px 0px 35px;">
                    产品序列
                </h5>
                <section class="ac-container">
				<div>
					<input id="ac-13" name="accordion-4" type="radio" checked="" />
					<label for="ac-13" style="font-size:1em;">行政事业应用G+系列</label>
					<article class="ac-medium" >
						<ul style="margin:10px;">
                            <li>
                                <a href="#">党风廉政建设责任制考评系统</a>
                            </li>
                            <li>
                                <a href="#">电子党建综合管理系统</a>
                            </li>
                            <li>
                                <a href="#">"三公经费"监督与管理系统</a>
                            </li>
                            <li>
                                <a href="#">网上民主测评系统</a>
                            </li>
                            <li>
                                <a href="#">"三重一大"监督与管理系统</a>
                            </li>
                            <li>
                                <a href="#">廉政档案系统</a>
                            </li>
                        </ul>
					</article>
				</div>
				<div>
					<input id="ac-14" name="accordion-4" type="radio" />
					<label for="ac-14" style="font-size:1em;">企业管理应用H+系列</label>
					<article class="ac-medium">
						<ul style="margin:10px;">
                            <li>
                                <a href="#">华强H3产品系列</a>
                            </li>
                            <li>
                                <a href="#">华强H6产品系列</a>
                            </li>
                            <li>
                                <a href="#">华强H+产品系列</a>
                            </li>
                        </ul>
					</article>
				</div>
				<div>
					<input id="ac-15" name="accordion-4" type="radio" />
					<label for="ac-15" style="font-size:1em;">软件定制应用D+系列</label>
					<article class="ac-large">
						<ul style="margin:10px;">
                            <li>
                                <a href="#">华强H3产品系列</a>
                            </li>
                            <li>
                                <a href="#">华强H6产品系列</a>
                            </li>
                            <li>
                                <a href="#">华强H+产品系列</a>
                            </li>
                        </ul>
					</article>
				</div>
				<div>
					<input id="ac-16" name="accordion-4" type="radio" />
					<label for="ac-16" style="font-size:1em;">网站建设外包W+系列</label>
					<article class="ac-large">
						<ul style="margin:10px;">
                            <li>
                                <a href="#">华强H3产品系列</a>
                            </li>
                            <li>
                                <a href="#">华强H6产品系列</a>
                            </li>
                            <li>
                                <a href="#">华强H+产品系列</a>
                            </li>
                        </ul>
					</article>
				</div>
			</section>
            </div>
            <div class="grid_9" style="padding:0;margin:0;width:720px;">
                <h5 class="uppercase" style="background:transparent url(images/icons/Circlebox9_s.png) no-repeat 5px 5px;height:25px;padding:10px 0px 0px 38px;">
                    最近项目
                </h5>
              <ul class="portfolio_4_col group"><!-- PORTFOLIO ITEMS -->
                <li class="item" data-id="id-1" data-type="html">
                  <a href="images/portfolio/01.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/01.jpg" alt="" /></a>
                  <h5 class="uppercase">
                    如皋市党风廉政建设考评系统
                  </h5>
                  <p>
                    该项目于2013年12月交付，通过该项目的建立，全面实现了如皋市纪律检查委员会对党风廉政建设责任制的落实、考核、评价、应用的数字化，将
                    年底突击检查变成了贯穿全年的常态化考核...
                  </p><a href="portfolio_single.html" class="link_bottom">View details</a>
                </li>
                <li class="item" data-id="id-2" data-type="html">
                  <a href="images/portfolio/02.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/02.jpg" alt="" /></a>
                  <h5 class="uppercase">
                    如皋市"三重一大"监管系统
                  </h5>
                  <p>
                    Lorem ipsum dolor sit amet, consectetur adipisicing
                    elit, sed do eiusmod tempor incididunt ut labore.
                  </p><a href="portfolio_single.html" class="link_bottom">View details</a>
                </li>
                <li class="item" data-id="id-3" data-type="html">
                  <a href="images/portfolio/03.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/03.jpg" alt="" /></a>
                  <h5 class="uppercase">
                    "文钱网"第三方维修服务平台
                  </h5>
                  <p>
                    <!--Lorem ipsum dolor sit amet, consectetur adipisicing
                    elit, sed do eiusmod tempor incididunt ut labore.-->
                  </p><a href="portfolio_single.html" class="link_bottom">View details</a>
                </li>
              </ul><!-- END PORTFOLIO ITEMS -->
            </div>
        </div>
      </div>
      
    <!-- END BOTTOM -->
    
    <div class="footer_middle" style="margin-top:-20px;"><!-- FOOTER MIDDLE -->
      <div class="container_12">
        <div class="grid_2">
          <h5>
            网站导航
          </h5>
          <div class="list-type-footer">
            <ul>
              <li>
                <a href="index.html" class="grey">首页</a>
              </li>
              <li>
                <a href="portfolio_4_col.html" class="grey">产品技术</a>
              </li>
              <li>
                <a href="blog.html" class="grey">服务体验</a>
              </li>
              <li>
                <a href="features.html" class="grey">人才招聘</a>
              </li>
              <li>
                <a href="contact.html" class="grey">我们的团队</a>
              </li>
              <li>
                <a href="contact.html" class="grey">联系我们</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="grid_2">
          <h5>
            技术优势
          </h5>
          <div class="list-type-footer">
            <ul>
              <li>
                <a href="index.html" class="grey">广阔的服务领域</a>
              </li>
              <li>
                <a href="portfolio_4_col.html" class="grey">深厚的行业积累</a>
              </li>
              <li>
                <a href="blog.html" class="grey">丰富的研发经验</a>
              </li>
              <li>
                <a href="features.html" class="grey">充足的人才供应</a>
              </li>
              <li>
                <a href="contact.html" class="grey">严格的保密措施</a>
              </li>
              <li>
                <a href="contact.html" class="grey">完善的售后服务</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="grid_2">
          <h5>
            明星产品
          </h5>
          <div class="list-type-footer">
            <ul>
              <li>
                <a href="#" class="grey">党风廉政建设考评系统</a>
              </li>
              <li>
                <a href="#" class="grey">网上民主测评系统</a>
              </li>
              <li>
                <a href="#" class="grey">电子党员信息管理平台</a>
              </li>
              <li>
                <a href="#" class="grey">手工艺品行业管理软件</a>
              </li>
              <li>
                <a href="#" class="grey">饲料行业管理软件</a>
              </li>
              <li>
                <a href="#" class="grey">园林绿化行业管理软件</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="grid_3 latest_posts">
          <h5>
            最近新闻
          </h5><img class="img_float_left" src="images/thumb_1.jpg" width="40" height="40" alt="staff1" />
          <p>
            <strong>Lorem ipsum dolor sit amet consectetur
            adipisicing elit.</strong><br />
            30 June 2012
          </p><img class="img_float_left" src="images/thumb_2.jpg" width="40" height="40" alt="staff1" />
          <p>
            <strong>Lorem ipsum dolor sit amet consectetur
            adipisicing elit.</strong><br />
            29 June 2012
          </p><img class="img_float_left" src="images/thumb_3.jpg" width="40" height="40" alt="staff1" />
          <p>
            <strong>Lorem ipsum dolor sit amet consectetur
            adipisicing elit.</strong><br />
            28 June 2012
          </p>
        </div>
        <div class="grid_3">
          <h5>
            联系我们
          </h5>
          <div class="list-type-footer">
            <p class="grey" style="font-size:1.2em">
              南通华强通用软件有限公司
            </p><br />
            <p class="grey">
              江苏省南通市留学生创业园附楼2层
            </p><br />
            <p class="grey" style="font-size:1.4em">
              免费电话: 400-666-8049
            </p><br />
            <p class="grey">
              Email: <a href="mailto:mac@hq365.net" class="grey">info@hq365.net</a>
            </p>
          </div>
        </div>
      </div>
    </div><!-- FOOTER MIDDLE -->
    
    <div class="footer"><!-- FOOTER -->
      <div class="container_12">
        <div class="grid_6">
          <p class="copyright">
            &copy; Copyright &copy; 2013.南通华强通用软件有限公司 All rights reserved.
          </p>
        </div>
        <div class="grid_6">
          <div class="social-box">
            <a href="#"><img src="images/social_facebook.png" width="19" height="18" alt="" /></a> <a href="#"><img src="images/social_twitter.png" width="19" height="18" alt="" /></a> <a href="#"><img src="images/social_flickr.png" width="19" height="18" alt="" /></a> <a href="#"><img src="images/social_linkedin.png" width="19" height="19" alt="" /></a> <a href="#"><img src="images/social_dribble.png" width="19" height="18" alt="" /></a>
          </div>
        </div>
      </div>
    </div><!-- END FOOTER -->
    
<script src="layerslider/jQuery/jquery-easing-1.3.js" type="text/javascript"></script>
<script src="layerslider/js/layerslider.kreaturamedia.jquery.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#layerslider').layerSlider({
            skinsPath: 'layerslider/skins/',
            animateFirstLayer: true,
            navPrevNext: true,
            navStartStop: false,
            navButtons: false,
            autoPlayVideos: false,
            skin: 'minimal'
        });
    });		
</script>
    </form>
</body>
</html>