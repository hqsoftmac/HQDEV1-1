<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="HQDevPlatform.template.style01.header" %>
<div class="header"><!-- HEADER -->
    <div class="container_12">
        <div class="grid_3">
            <div class="logo"><!-- LOGO -->
                <img src="<%=gslogourl %>" alt="" />
            </div>
        </div><!-- END LOGO -->
        <div class="grid_9"><!-- MENU -->
            <ul class="sf-menu">
                <%=gsmenu%>
            </ul>
        </div><!-- END MENU -->
    </div>  
</div><!-- END HEADER -->
