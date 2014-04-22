$(function () {
    $.messager.progress();
    $("#menu").accordion({
        width: 150,
        height: 200,
        fit: true
    });

    $('#tt').tabs('add', {
        title: "我的桌面",
        content: "<iframe id='MainFrame' frameborder='no' marginheight='0' marginwidth='0' border='0'  width='100%' height='100%' src='myweb.aspx'></iframe>",
        closable: true,
        iconCls: "icon-home"
    });

    $(".menulink").click(function () {
        var _title = $(this).attr("framename");
        var _url = $(this).attr("url");
        var _rel = $(this).attr("rel");
        if (_url.length > 4) {
            if (!$('#tt').tabs('exists', _title)) {
                $('#tt').tabs('add', {
                    title: _title,
                    content: "<iframe id='" + _rel + "' frameborder='no' marginheight='0' marginwidth='0' border='0'  width='100%' height='100%' src='" + _url + "'></iframe>",
                    closable: true,
                    iconCls: "icon-win"
                });
            }
            else {
                $('#tt').tabs('select', _title);
                var currTab = $('#tt').tabs('getTab', _title);
                $('#tt').tabs('update', {
                    tab: currTab,
                    options: {
                        content: "<iframe id='" + _rel + "' frameborder='no' marginheight='0' marginwidth='0' border='0'  width='100%' height='100%' src='" + _url + "'></iframe>"
                    } 
                });
            }
        }
    });
    $.messager.progress("close");
});

function refreshtab(_title,_rel,_url) {
    var currTab = $('#tt').tabs('getTab', _title);
    $('#tt').tabs('update', {
        tab: currTab,
        options: {
            content: "<iframe id='" + _rel + "' frameborder='no' marginheight='0' marginwidth='0' border='0'  width='100%' height='100%' src='" + _url + "'></iframe>"
        }
    });
}

function addtab(_title, _rel, _url) {
    if (!$("#tt").tabs('exists', _title)) {
        $("#tt").tabs('add', {
            title: _title,
            content: "<iframe id='" + _rel + "' frameborder='no' marginheight='0' marginwidth='0' border='0'  width='100%' height='100%' src='" + _url + "'></iframe>",
            closable: true
        });
    }
    else {
        $("#tt").tabs('select', _title);
        var currTab = $("#tt").tabs('getTab', _title);
        $("#tt").tabs('update', {
            tab: currTab,
            options: {
                content: "<iframe id='" + _rel + "' frameborder='no' marginheight='0' marginwidth='0' border='0'  width='100%' height='100%' src='" + _url + "'></iframe>"
            }
        });
    }
}

function closetab(_title) {
    $('#tt').tabs('close', _title);
}

function closecurtab() {
    var curtab = $('#tt').tabs('getSelected');
    var tabname = curtab.panel('options').title;
    closetab(tabname);
}