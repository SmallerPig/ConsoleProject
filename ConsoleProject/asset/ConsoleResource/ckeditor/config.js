/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
    config.language = 'zh-cn'; // 语言
    config.uiColor = 'white'; // 背景颜色
    config.skin = 'v2'; // 编辑器样式
    config.resize_enabled = false; //拖拽以改变大小
    //config.width = '850';
    config.height = '265';
    config.filebrowserBrowseUrl = '/asset/ConsoleResource/ckfinder/ckfinder.html'; //上传文件时浏览服务文件夹
    config.filebrowserImageBrowseUrl = '/asset/ConsoleResource/ckfinder/ckfinder.html?Type=Images'; //上传图片时浏览服务文件夹
    config.filebrowserFlashBrowseUrl = '/asset/ConsoleResource/Content/ConsoleResource/ckfinder/ckfinder.html?Type=Flash'; //上传Flash时浏览服务文件夹
    config.filebrowserUploadUrl = '/asset/ConsoleResource/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files'; //上传文件按钮(标签)
    config.filebrowserImageUploadUrl = '/asset/ConsoleResource/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';  //上传图片按钮(标签)
    config.filebrowserFlashUploadUrl = '/asset/ConsoleResource/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';  //上传Flash按钮(标签)
    config.extraPlugins = 'video';
    config.toolbar =
    [
        { name: 'tools', items: ['Maximize', 'ShowBlocks', 'Source'] },
        { name: 'text', items: ['Styles', 'Format', 'Font', 'FontSize'] },
//        { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
        { name: 'forms', items: ['TextField', 'Select'] },
        { name: 'insert', items: ['Image',  'Video', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'fmath_formula'] }
    ];

//    config.toolbar =
//    [
//        ['Source', '-', 'Save', 'NewPage', 'Preview', '-', 'Templates'],
//        ['Undo', 'Redo', '-', 'SelectAll', 'RemoveFormat'],
//        ['Styles', 'Format', 'Font', 'FontSize'],
//        ['TextColor', 'BGColor'],
//        ['Maximize', 'ShowBlocks', '-', 'About'],
//        '/',
//        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
//        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote', 'CreateDiv'],
//        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
//        ['Link', 'Unlink', 'Anchor'],
//        ['Image', 'video', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],
//        ['Code']
//    ];
};
