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
    <meta name="author" content="��ǿͨ��������޹�˾ HuaQiang General SoftWare" />
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
		            ��ǿͨ��������޹�˾
			    </div>
                <p id="P1" class="ls-s3" style="top:110px;font-size:10pt;left: 580px;color:#fff;">
                    �����ҵ&nbsp;&nbsp;�϶����:��R-2012-F0009<br />
				</p>
                <div class="ls-s3" style="padding: 0px; width: 440px; left: 580px; top: 150px;color: white; text-shadow: none; font-size: 25px; font-weight: bold;">
		            10��ĳɹ��������,�������֮ѡ
			    </div>
			</div>
            <div class="ls-layer" rel="slidedelay: 3000;">
				<img class="ls-s2" src="images/slider/monitor_01.png" alt="sublayer" rel="durationin: 1900; easingin: easeOutQuad" />
				<img class="ls-s3" src="images/slider/monitor_02.png" alt="sublayer" rel="durationin: 1200; easingin: easeOutQuad" />
				<div class="ls-s11" style="padding: 20px; width: 440px; left: 50px; top: 40px;color: white; text-shadow: none; font-size: 30px; font-weight: bold; line-height:auto;">
				    ��ǿ�����������迼��ϵͳ
			    </div>
                <p id="l5text1" class="ls-s12" style="top:100px;">
                    3����û�Ӧ�þ����ֵ����<br />
                    �ᴩ���ηֽ⡢���ˡ�׷�������ص㻷��<br />
                    ������ǰ�����ϸ�������������������ϵ<br />
				    ������֯����׼��м��Ϊ�ճ�����,�÷�ʵʱ����<br />
                    ���ٽ�������õĹ���
				</p>
			    <div class="ls-s2" style="left: 70px; top: 220px;"><a class="button large black" href="#">��ϸ�˽�</a></div>
		    </div>
                
            <div class="ls-layer" rel="slidedelay: 3000;">
			  <div class="ls-s2" style="left: 50px; top: 50px;">
				<a href="index.html"><img src="images/slider/mzcp_01.png" alt="" /></a>
                <!--<iframe src="http://player.vimeo.com/video/40977081" width="500" height="300" frameborder="0" webkitallowfullscreen="" mozallowfullscreen="" allowfullscreen=""></iframe>	-->					
			  </div>
			<div class="ls-s3" style="padding: 20px; width: 440px; left: 580px; top: 40px;            color: white; text-shadow: none; font-size: 30px; font-weight: bold; line-height            : auto;">
		    ��ǿ������������ϵͳ
			</div>
              <p id="l5text2" class="ls-s3" style="top:100px; left: 600px;">
			   ���ɶ�����ʽ�����Ĳ�����<br />
               ����Բ�ͬ��������������<br />
               һ��ͳ�Ʋ���������<br />
               ��������������ȷ�����ͼ�η���<br />
		      </p>
              <div class="ls-s2" style="left: 600px; top: 220px;"><a class="button large grey" href="#">��ϸ�˽�</a></div>
			</div>
		</div>
  </div><!-- END SLIDER -->
    
    <div class="main" style="margin-top:5px;"><!-- MAIN -->
      <div class="container_12">
        <div class="grid_3">
          <section class="tabs" style="width:220px;">
	            <input id="tab-1" type="radio" name="radio-set" class="tab-selector-1" checked="checked" />
		        <label for="tab-1" class="tab-label-1" style="font-size:1em;">��ǿ����</label>
		
	            <input id="tab-2" type="radio" name="radio-set" class="tab-selector-2" />
		        <label for="tab-2" class="tab-label-2" style="font-size:1em;">��ǿ����</label>
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
                        <p style="text-align:right;"><a href="#" style="font-size:0.8em;font-style:italic;">����...</a>&nbsp;&nbsp;</p>
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
                        <p style="text-align:right;"><a href="#" style="font-size:0.8em;font-style:italic;">����...</a>&nbsp;&nbsp;</p>
                    </div>
                </div>
			</section>
          </div>
          <ul class="portfolio_4_col group"><!-- PORTFOLIO ITEMS -->
            <li class="item" data-id="id-1" data-type="html">
              <a href="images/portfolio/01.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/01.jpg" alt="" /></a>
              <h5 class="uppercase">
                <a href="#">������ҵӦ��ϵ��</a>
              </h5>
              <p>
                ��Ҫ����������ҵ��λ��Ӧ��ϵͳ,��Ҫ���򵳷��������衢��Ա��Ϣ����������������������\�ش�����ල������.
              </p>
              <a href="portfolio_single.html" class="button large white" style="width:55px;">�鿴��ϸ</a>
            </li>
            <li class="item" data-id="id-2" data-type="html">
              <a href="images/portfolio/02.png" rel="prettyPhoto[portfolio]"><img src="images/portfolio/02.png" alt="" /></a>
              <h5 class="uppercase">
                <a href="#">��ҵ����Ӧ��ϵ��</a>
              </h5>
              <p>
                ��ҵ��Ϣ������ר��,������������������������MES��OA�칫��HR��CRM�ȵ�.
              </p><a href="portfolio_single.html" class="button large white" style="width:55px;">�鿴��ϸ</a>
            </li>
            <li class="item" data-id="id-3" data-type="html">
              <a href="images/portfolio/03.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/03.jpg" alt="" /></a>
              <h5 class="uppercase">
                ��������������
              </h5>
              <p>
                Ϊ�����������,����Ӧ�á�����Ӧ�á��ֻ�Ӧ�á����ݿ�Ӧ�á���������Ӧ��;B/S�ܹ���C/S�ܹ�;
              </p><a href="portfolio_single.html" class="button large white" style="width:55px;">�鿴��ϸ</a>
            </li>
          </ul><!-- END PORTFOLIO ITEMS -->
        </div>
    </div><!-- END MAIN -->
    <div class="bottom" style="margin-top:-20px;" ><!-- BOTTOM -->
        <div class="container_12" style="border-top-style:dashed;border-top-width:1px;border-top-color:#eeeeee;padding-top:0px;" >
            <div class="grid_3 box_light_gray inner" style="padding-top:0px;">
                <h5 class="uppercase" style="background:transparent url(images/icons/Binder_s.png) no-repeat 5px 5px;height:25px;padding:10px 0px 0px 35px;">
                    ��Ʒ����
                </h5>
                <section class="ac-container">
				<div>
					<input id="ac-13" name="accordion-4" type="radio" checked="" />
					<label for="ac-13" style="font-size:1em;">������ҵӦ��G+ϵ��</label>
					<article class="ac-medium" >
						<ul style="margin:10px;">
                            <li>
                                <a href="#">�����������������ƿ���ϵͳ</a>
                            </li>
                            <li>
                                <a href="#">���ӵ����ۺϹ���ϵͳ</a>
                            </li>
                            <li>
                                <a href="#">"��������"�ල�����ϵͳ</a>
                            </li>
                            <li>
                                <a href="#">������������ϵͳ</a>
                            </li>
                            <li>
                                <a href="#">"����һ��"�ල�����ϵͳ</a>
                            </li>
                            <li>
                                <a href="#">��������ϵͳ</a>
                            </li>
                        </ul>
					</article>
				</div>
				<div>
					<input id="ac-14" name="accordion-4" type="radio" />
					<label for="ac-14" style="font-size:1em;">��ҵ����Ӧ��H+ϵ��</label>
					<article class="ac-medium">
						<ul style="margin:10px;">
                            <li>
                                <a href="#">��ǿH3��Ʒϵ��</a>
                            </li>
                            <li>
                                <a href="#">��ǿH6��Ʒϵ��</a>
                            </li>
                            <li>
                                <a href="#">��ǿH+��Ʒϵ��</a>
                            </li>
                        </ul>
					</article>
				</div>
				<div>
					<input id="ac-15" name="accordion-4" type="radio" />
					<label for="ac-15" style="font-size:1em;">�������Ӧ��D+ϵ��</label>
					<article class="ac-large">
						<ul style="margin:10px;">
                            <li>
                                <a href="#">��ǿH3��Ʒϵ��</a>
                            </li>
                            <li>
                                <a href="#">��ǿH6��Ʒϵ��</a>
                            </li>
                            <li>
                                <a href="#">��ǿH+��Ʒϵ��</a>
                            </li>
                        </ul>
					</article>
				</div>
				<div>
					<input id="ac-16" name="accordion-4" type="radio" />
					<label for="ac-16" style="font-size:1em;">��վ�������W+ϵ��</label>
					<article class="ac-large">
						<ul style="margin:10px;">
                            <li>
                                <a href="#">��ǿH3��Ʒϵ��</a>
                            </li>
                            <li>
                                <a href="#">��ǿH6��Ʒϵ��</a>
                            </li>
                            <li>
                                <a href="#">��ǿH+��Ʒϵ��</a>
                            </li>
                        </ul>
					</article>
				</div>
			</section>
            </div>
            <div class="grid_9" style="padding:0;margin:0;width:720px;">
                <h5 class="uppercase" style="background:transparent url(images/icons/Circlebox9_s.png) no-repeat 5px 5px;height:25px;padding:10px 0px 0px 38px;">
                    �����Ŀ
                </h5>
              <ul class="portfolio_4_col group"><!-- PORTFOLIO ITEMS -->
                <li class="item" data-id="id-1" data-type="html">
                  <a href="images/portfolio/01.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/01.jpg" alt="" /></a>
                  <h5 class="uppercase">
                    ����е����������迼��ϵͳ
                  </h5>
                  <p>
                    ����Ŀ��2013��12�½�����ͨ������Ŀ�Ľ�����ȫ��ʵ��������м��ɼ��ίԱ��Ե����������������Ƶ���ʵ�����ˡ����ۡ�Ӧ�õ����ֻ�����
                    ���ͻ��������˹ᴩȫ��ĳ�̬������...
                  </p><a href="portfolio_single.html" class="link_bottom">View details</a>
                </li>
                <li class="item" data-id="id-2" data-type="html">
                  <a href="images/portfolio/02.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/02.jpg" alt="" /></a>
                  <h5 class="uppercase">
                    �����"����һ��"���ϵͳ
                  </h5>
                  <p>
                    Lorem ipsum dolor sit amet, consectetur adipisicing
                    elit, sed do eiusmod tempor incididunt ut labore.
                  </p><a href="portfolio_single.html" class="link_bottom">View details</a>
                </li>
                <li class="item" data-id="id-3" data-type="html">
                  <a href="images/portfolio/03.jpg" rel="prettyPhoto[portfolio]"><img src="images/portfolio/03.jpg" alt="" /></a>
                  <h5 class="uppercase">
                    "��Ǯ��"������ά�޷���ƽ̨
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
            ��վ����
          </h5>
          <div class="list-type-footer">
            <ul>
              <li>
                <a href="index.html" class="grey">��ҳ</a>
              </li>
              <li>
                <a href="portfolio_4_col.html" class="grey">��Ʒ����</a>
              </li>
              <li>
                <a href="blog.html" class="grey">��������</a>
              </li>
              <li>
                <a href="features.html" class="grey">�˲���Ƹ</a>
              </li>
              <li>
                <a href="contact.html" class="grey">���ǵ��Ŷ�</a>
              </li>
              <li>
                <a href="contact.html" class="grey">��ϵ����</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="grid_2">
          <h5>
            ��������
          </h5>
          <div class="list-type-footer">
            <ul>
              <li>
                <a href="index.html" class="grey">�����ķ�������</a>
              </li>
              <li>
                <a href="portfolio_4_col.html" class="grey">������ҵ����</a>
              </li>
              <li>
                <a href="blog.html" class="grey">�ḻ���з�����</a>
              </li>
              <li>
                <a href="features.html" class="grey">������˲Ź�Ӧ</a>
              </li>
              <li>
                <a href="contact.html" class="grey">�ϸ�ı��ܴ�ʩ</a>
              </li>
              <li>
                <a href="contact.html" class="grey">���Ƶ��ۺ����</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="grid_2">
          <h5>
            ���ǲ�Ʒ
          </h5>
          <div class="list-type-footer">
            <ul>
              <li>
                <a href="#" class="grey">�����������迼��ϵͳ</a>
              </li>
              <li>
                <a href="#" class="grey">������������ϵͳ</a>
              </li>
              <li>
                <a href="#" class="grey">���ӵ�Ա��Ϣ����ƽ̨</a>
              </li>
              <li>
                <a href="#" class="grey">�ֹ���Ʒ��ҵ�������</a>
              </li>
              <li>
                <a href="#" class="grey">������ҵ�������</a>
              </li>
              <li>
                <a href="#" class="grey">԰���̻���ҵ�������</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="grid_3 latest_posts">
          <h5>
            �������
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
            ��ϵ����
          </h5>
          <div class="list-type-footer">
            <p class="grey" style="font-size:1.2em">
              ��ͨ��ǿͨ��������޹�˾
            </p><br />
            <p class="grey">
              ����ʡ��ͨ����ѧ����ҵ԰��¥2��
            </p><br />
            <p class="grey" style="font-size:1.4em">
              ��ѵ绰: 400-666-8049
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
            &copy; Copyright &copy; 2013.��ͨ��ǿͨ��������޹�˾ All rights reserved.
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