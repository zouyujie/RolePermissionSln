var defaultSelectText = "——请选择——";
function dateTimeConvert(value) {
    if (value == undefined ||value==null|| value == "") {
        return "";
    }
    var reg = new RegExp('/', 'g');
    var d = eval('new ' + value.replace(reg, ''));
    return new Date(d).format('yyyy-MM-dd hh:mm:ss')
}
function dateConvert(value) {
    if (value == undefined || value == "") {
        return "";
    }
    var reg = new RegExp('/', 'g');
    var d = eval('new ' + value.replace(reg, ''));
    return new Date(d).format('yyyy-MM-dd')
}
function returnParent(value) {//获取子窗体取消值
    var parent = window.dialogArguments; //获取父页面
    //parent.location.reload(); //刷新父页面
    if (parent != null && parent != "undefined") {
        window.returnValue = value; //取消值
        window.close(); //关闭子页面
    }
    return;
}
$(function () {
    //时间格式化
    Date.prototype.format = function (format) {
        /*
        * eg:format="yyyy-MM-dd hh:mm:ss";
        */
        if (!format) {
            format = "yyyy-MM-dd hh:mm:ss";
        }

        var o = {
            "M+": this.getMonth() + 1, // month
            "d+": this.getDate(), // day
            "h+": this.getHours(), // hour
            "m+": this.getMinutes(), // minute
            "s+": this.getSeconds(), // second
            "q+": Math.floor((this.getMonth() + 3) / 3), // quarter
            "S": this.getMilliseconds()
            // millisecond
        };

        if (/(y+)/.test(format)) {
            format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        }

        for (var k in o) {
            if (new RegExp("(" + k + ")").test(format)) {
                format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
            }
        }
        return format;
    };
    $.extend($.fn.datagrid.methods, {

        addToolbarItem: function (jq, items) {

            return jq.each(function () {

                var toolbar = $(this).parent().prev("div.datagrid-toolbar");

                for (var i = 0; i < items.length; i++) {

                    var item = items[i];
                    var btn = $("<a href=\"javascript:void(0)\"></a>");
                    btn[0].onclick = eval(item.handler || function () { });
                    btn.css("float", "left").appendTo(toolbar).linkbutton($.extend({}, item, { plain: true }));
                }
                toolbar = null;

            });

        },

        removeToolbarItem: function (jq, param) {

            return jq.each(function () {
                var btns = $(this).parent().prev("div.datagrid-toolbar").children("a");
                var cbtn = null;
                if (typeof param == "number") {
                    cbtn = btns.eq(param);
                } else if (typeof param == "string") {

                    var text = null;
                    btns.each(function () {
                        text = $(this).data().linkbutton.options.text;
                        if (text == param) {
                            cbtn = $(this);
                            text = null;
                            return;
                        }
                    });
                }

                if (cbtn) {
                    var prev = cbtn.prev()[0];
                    var next = cbtn.next()[0];
                    if (prev && next && prev.nodeName == "DIV" && prev.nodeName == next.nodeName) {
                        $(prev).remove();
                    } else if (next && next.nodeName == "DIV") {
                        $(next).remove();
                    } else if (prev && prev.nodeName == "DIV") {
                        $(prev).remove();
                    }
                    cbtn.remove();
                    cbtn = null;
                }
            });
        }
    });
})
function showMyWindow(objDiv, title, href, width, height, isScrolling, modal, minimizable, maximizable) {
    var isScroll = isScrolling == undefined ? "no" : "yes";
    $(objDiv).window({
        title: title,
        width: width === undefined ? 600 : width,
        height: height === undefined ? 450 : height,
        content: '<iframe scrolling="' + isScroll + '" frameborder="0"  src="' + href + '" style="width:100%;height:98%;"></iframe>',
        //        href: href === undefined ? null : href, 
        modal: modal === undefined ? true : modal,
        minimizable: minimizable === undefined ? false : minimizable,
        maximizable: maximizable === undefined ? false : maximizable,
        shadow: false,
        cache: false,
        closed: false,
        collapsible: false,
        resizable: false,
        loadingMessage: '正在加载数据，请稍等片刻......'
    });
}
function CurentDate() {
    var now = new Date();
    var year = now.getFullYear();       //年
    var month = now.getMonth() + 1;     //月
    var day = now.getDate();            //日
    var clock = year + "年";
    if (month < 10)
        clock += "0";
    clock += month + "月";
    if (day < 10)
        clock += "0";
    clock += day + "日";
    return (clock);
}
function getDateByStr(now) {
    if (now == "") { return ""; }
    var year = now.getFullYear();       //年
    var month = now.getMonth() + 1;     //月
    var day = now.getDate();            //日
    var clock = year + "年";
    if (month < 10)
        clock += "0";
    clock += month + "月";
    if (day < 10)
        clock += "0";
    clock += day + "日";
    return (clock);
}
function getWeek(myDate) {
    if (myDate == "") {
        return "";
    }
    var Week = ['日', '一', '二', '三', '四', '五', '六'];
    str = ' 星期' + Week[myDate.getDay()];
    return str;
}
//+---------------------------------------------------  
//| 字符串转成日期类型   
//| 格式 MM/dd/YYYY MM-dd-YYYY YYYY/MM/dd YYYY-MM-dd  
//+---------------------------------------------------  
function StringToDate(DateStr) {
    if (DateStr == "") {
        return "";
    }
    var converted = Date.parse(DateStr);
    var myDate = new Date(converted);
    if (isNaN(myDate)) {
        //var delimCahar = DateStr.indexOf('/')!=-1?'/':'-';  
        var arys = DateStr.split('-');
        myDate = new Date(arys[0], --arys[1], arys[2]);
    }
    return myDate;
}
//-1今天  0：昨天 6：前7天
function getDate(day) {
    var zdate = new Date();
    var sdate = zdate.getTime() - (1 * 24 * 60 * 60 * 1000);
    var edate = new Date(sdate - (day * 24 * 60 * 60 * 1000)).format("yyyy-MM-dd");;
    return edate;
}
function closeErrors() {
    return true;
}
window.onerror = closeErrors;
function isNumber(id) {
    if (isNaN(Number(id.value))) {
        alert("非法数字");
        id.value = "";
    }
}
//多级联动
function bindDropDownList(id, parentid) {
    if ($(parentid).val() != "") {
        var url = "/Home/GetSysFieldByParent";
        $.ajaxSetup({ cache: false });
        $.getJSON(url, { id: id.substring(1), parentid: parentid.substring(1), value: $(parentid).val() }, function (data) {
            if (data == null) {
                return;
            }
            $.each(data, function (i, item) {
                if (item == null) {
                    return;
                }
                $("<option></option>")
                        .val(item["Value"])
                        .text(item["Text"])
                        .appendTo($(id));
            });
        });
    }
}
  
function deleteTable(table, hidden) { //删除table和隐藏的值
    var tableId = document.getElementById(table); //获取要删除的项
    $(tableId).remove();
    // tableId.style.display = "none";//table隐藏isNaN(Number())
    var hiddenValue = document.getElementById(hidden); //获取隐藏的控件
    //  hiddenValue.value+="";
    if (hiddenValue.value.indexOf(table) > -1) {
        hiddenValue.value = hiddenValue.value.replace(table, ""); //为隐藏控件赋值
    }
}
function showModalMany(me, url, dialogWidth,callback) { //弹出窗体，多选   
    if (dialogWidth == null || dialogWidth == "undefined" || dialogWidth == "") {
        dialogWidth = 968;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:" + dialogWidth + "px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果取消值为空，就取消
    }
	
    var index = reValue.split("^"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    var hid = index[0].split('&'); //为隐藏控件赋值
    var view = index[1].split('&'); //显示值
    var content = ""; //需要添加到check中的内容
    var h = "";
    for (var i = 0; i < hid.length - 1; i++) {
        if (hid[i] != "undefined" && hid[i] != "" && view[i + 1] != "undefined" && view[i + 1] != "") {
            
			var tableId = document.getElementById(hid[i] + "&" + view[i + 1]); //获取表格
			if(tableId==null)
			{
			h += "^" + hid[i] + "&" + view[i + 1];
//            content += '<table  id="' + hid[i] + "&" + view[i + 1] + '" class="deleteStyle"><tr><td><img src="../../../Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable(' + "'" + hid[i] + "&" + view[i + 1] + "'," + "'" + me + "'" + ');" /></td><td>' + view[i + 1] + '</td></tr></table>';
			content += '<li  id="' + hid[i] + "&" + view[i + 1] + '" class="deleteStyle"><img src="/Content/Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable(' + "'" + hid[i] + "&" + view[i + 1] + "'," + "'" + me + "'" + ');" />' + view[i + 1] + '</li>';
            }
        }
    }
    var hidden = document.getElementById(me); //获取隐藏的控件
    hidden.value += h; //为隐藏控件赋值
    var c = document.getElementById("check" + me);
    c.innerHTML += content;
	if(callback!=null)
	{
		callback()
	}
}

function showTreeOnlyEdit(me, url) { //弹出窗体 ,单选
    var hidden = document.getElementById(me); //获取隐藏的控件
    if (hidden.value != null && hidden.value.length > 0) {
        alert("此处为单选，请先删除已有的选项，再次尝试选择。");
        return;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:987px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果取消值为空，就取消
    }
    var index = reValue.split("&"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    if (index[1] == null || index[1] == "undefined" || index[1].length < 1) {
        return;
    }
    var hid = index[0]; //为隐藏控件赋值
    var view = index[1]; //显示值
    var content = ""; //需要添加到check中的内容

    var href = window.location.href;
    var ref = href.substr(href.lastIndexOf('/') + 1);

    if (hid != null) {
        if (ref == hid) {
            alert("请不要选择同一条数据。");
            return;
        }
        if (hid != "undefined" && hid != "" && view != "undefined" && view != "") {

            content += '<table  id="' + hid + "&" + view
            + '" class="deleteStyle"><tr><td><img src="/Content/Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable('
            + "'" + hid + "&" + view
             + "'," + "'" + me + "'" + ');" /></td><td>' + view
              + '</td></tr></table>';

            hidden.value = hid; //为隐藏控件赋值
            var c = document.getElementById("check" + me);
            c.innerHTML += content;
            return;
        }
    }
    alert("请只选择一条数据。");
    return;
}

function showModalOnly(me, url) { //弹出窗体 ,单选
    var hidden = document.getElementById(me); //获取隐藏的控件
    if (hidden != null && hidden.value != null && hidden.value.length > 0) {
        alert("此处为单选，请先删除已有的选项，再次尝试选择。");
        return;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:987px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果取消值为空，就取消
    }
    var index = reValue.split("^"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    var hid = index[0].split('&'); //为隐藏控件赋值
    var view = index[1].split('&'); //显示值
    var content = ""; //需要添加到check中的内容

    if (hid != null && hid.length == 2) {
        var i = 0;

        if (hid[i] != "undefined" && hid[i] != "" && view[i + 1] != "undefined" && view[i + 1] != "") {

            content += '<table  id="' + hid[i]
            + '" class="deleteStyle"><tr><td><img src="/Content/Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable('
            + "'" + hid[i] + "'," + "'" + me + "'" + ');" /></td><td>' + view[i + 1] + '</td></tr></table>';

            hidden.value = hid[i]; //为隐藏控件赋值
            var c = document.getElementById("check" + me);
            c.innerHTML += content;
            return;
        }
    }
    alert("请只选择一条数据。");
    return;
}

function isInt(t) {
    t.value = t.value.replace(/[^0-9]/g, '')
}
function dia() {
    if ($("#dialo").dialog("isOpen")) {
        $("#dialo").dialog({
            autoOpen: true,

            buttons: {
                "确定": function () {
                    $("#dialo").dialog("close");
                }
            }
        });
    }
}
function BackList(url) {
    window.location.href = '/' + url;
}
function manyTreeChecked(node, checked, hidControl, treeId) {
    var hidArr = $('#' + hidControl).val().split(',');
    //debugger;
    //alert(hidArr.join(','));
    if (checked) {
        hidArr.push(node.id);
        var nodeChildren = $('#' + treeId).tree("getChildren", node.target);
        if (nodeChildren != null) {
            for (var i = 0; i < nodeChildren.length; i++) {
                treeChecked(nodeChildren[i].id,treeId,"tree-checkbox1");
                hidArr.push(nodeChildren[i].id);
            }
        }
    }
    else {
        //debugger;
        for (var i = 0; i < hidArr.length; i++) {
            if (hidArr[i] == node.id) {
                hidArr.splice(i, 1);
            }
        }
        var nodeChildren = $('#' + treeId).tree("getChildren", node.target);
        if (nodeChildren != null) {
            for (var i = 0; i < nodeChildren.length; i++) {
                treeChecked(nodeChildren[i].id, treeId, "tree-checkbox0");
                for (var j = 0; j < hidArr.length; j++) {
                    if (hidArr[j] == nodeChildren[i].id) {
                        hidArr.splice(j, 1);
                    }
                }
            }
        }
    }
    $('#' + hidControl).val(hidArr.join(','));
}
function bindmanyTreeChecked(checkData, hidControl, treeId) {
    if (checkData == null || checkData == "" || checkData == "undefined") {
        return;
    }
    var menuids = checkData.split(',');
    var hidArr = $('#' + hidControl).val().split(',');
    for (i = 0; i < menuids.length; i++) {
        treeChecked(menuids[i], treeId, "tree-checkbox1");
        hidArr.push(menuids[i]);
    }
    $('#' + hidControl).val(hidArr.join(','));
}
function bindSonTreeChecked(oldData, newData, treeId) {
    if (oldData == null || oldData == "" || oldData == "undefined") {
        return;
    }
    var menuids = oldData.split(',');
    var sonids = newData.split(',');
    for (i = 0; i < menuids.length; i++) {
        for (j = 0; j < sonids.length; j++) {
            if (menuids[i] == sonids[j]) {
                treeChecked(menuids[i], treeId, "tree-checkbox1");
                break;
            }
        }
    }
}
function treeChecked(node, treeId, className) {
    var nodeid = $("#" + treeId).tree("find", node);
    if (nodeid) {
        var ck = $(nodeid.target).find('.tree-checkbox');
        ck.removeClass("tree-checkbox0 tree-checkbox1 tree-checkbox2");
        ck.addClass(className);
    }
}
 

 