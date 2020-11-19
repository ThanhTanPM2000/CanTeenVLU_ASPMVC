/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.syntaxhighlight_hideControls = true;
    
    config.filebrowserBrowseUrl = '/Plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Plugins/ckfinder/ckfinder.html?Types=Images';
    config.filebrowserFlashBrowseUrl = '/Plugins/ckfinder/ckfinder.html?Types=Flash';
    config.filebrowserUploadUrl = '/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=File';
    config.filebrowserImageUploadUrl = '/Images';
    config.filebrowserFlashUploadUrl = '/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.height = 730;
};


