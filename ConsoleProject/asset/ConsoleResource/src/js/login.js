﻿//浏览器判断
if (!document.getSelection) {
    window.location = "oldBrowser.html";
}

//判断浏览器版本
var Sys = {};
var ua = navigator.userAgent.toLowerCase();
if (window.ActiveXObject) {
    Sys.ie = ua.match(/msie ([\d.]+)/)[1]
    if (Sys.ie == "6.0" || Sys.ie == "7.0" || Sys.ie == "8.0" || Sys.ie == "9.0") {
        window.location = "oldBrowser.html";
    }
}


var isposting = false;

var successfn = function (data) {
    var logininfo = $("#loginInfor");
    if (data == "Success") {
        var ref = getQueryString("ref");
        if (ref) {
            window.location.replace(ref);
        }else{
            window.location.replace("/admin/console/main");
        };        
    }
    else if (data.length == 0) {
        smp.show("链接超时！", "warn");
    }
    else {
        smp.show("用户名密码错误！", "warn");
    }
}
var errorfn = function (data) {
    smp.show("服务器错误，请联系管理员！", "warn");


}
var beforesend = function () {
    isposting = true;
    var submitbutton = $("#loginButton");
    var submitInterval = 3;

    var timer = setInterval(function () {
        submitInterval--;
        $("#loginButton").text("登录(" + submitInterval + ")")
        if (submitInterval == 0) {
            $("#loginButton").text("登录");
            isposting = false;
            clearInterval(timer);
        }
    }, 1000);
}
var complete = function () {
}

function doSubmit() {
    if (!isposting) {
        if (simple.validator.validate() == true) {
            var usernama = $("#userName").val();
            var password = $("#password").val();
            var data = { 'username': usernama, 'password': password };
            core.AJAX(data, "/admin/console/login", beforesend, successfn, errorfn, complete);
        }        
    };
}

function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

if (typeof (core) == "undefined") {
    core = {};
}

//提交POST Ajax请求，需要引用jQuery库
//data：Json格式数据
//url：请求地址
//success：成功回调函数
//error:失败回调函数
core.AJAX = function (data, url, beforesendfn, onsuccessfn, onerrorfn, oncomplete, functiontype) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: beforesendfn,
        success: onsuccessfn,
        error: onerrorfn,
        complete: oncomplete
    });
}
