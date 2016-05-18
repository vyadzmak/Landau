/**
 * Enterprise Spreadsheet Solutions
 * Copyright(c) FeyaSoft Inc. All right reserved.
 * info@enterpriseSheet.com
 * http://www.enterpriseSheet.com
 * 
 * Licensed under the EnterpriseSheet Commercial License.
 * http://enterprisesheet.com/license.jsp
 * 
 * You need to have a valid license key to access this file.
 */
Ext.define('EnterpriseSheetApp.view.Viewport', {
    extend: 'Ext.container.Viewport',

    requires:[
        'Ext.layout.container.Fit',
        'Ext.layout.container.Border',
        'Ext.layout.container.Form',
        'EnterpriseSheet.Config',
        'EnterpriseSheet.api.SheetAPI'      
    ],

    layout: {
        type: 'fit'
    },

    constructor : function(config){
        config = config || {};

        var SHEET_API = Ext.create('EnterpriseSheet.api.SheetAPI');
        var SHEET_API_HD = SHEET_API.createSheetApp({
        	scrollerAlwaysVisible: SCONFIG.SCROLLER_ALWAYS_VISIBLE
        });
        config.items = [SHEET_API_HD.appCt];

        this.callParent([config]);

        /*
         * load the file
         */
        if(Ext.isDefined(config.fileId)){
            SHEET_API.loadFile(SHEET_API_HD, config.fileId, function(data){
            }, this);
        }
    }

});
