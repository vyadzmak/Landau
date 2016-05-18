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
Ext.define('EnterpriseSheet.pop.OpenFileWin', {
	
	/* Begin Definitions */
		
	extend : 'Ext.window.Window',
	
	/* End Definitions */
    requires: [
        'Ext.form.field.Text',
        'Ext.layout.container.Form',
        'EnterpriseSheet.model.FileModel'
    ],
           
    bodyStyle : 'background-color:white;',
           
    title: SLANG['open_sheet'],
           
    plain: true,
           
    modal: true,
           
    resizable: false,
           
    shim : true,
           
    closeAction: 'hide',
           
    layout: 'fit',
           
    buttonAlign: 'right',
           
    initComponent : function(){
           
        // create the Data Store
	    this.fileStore = Ext.create('Ext.data.Store', {
	        pageSize: 50,
	        model: EnterpriseSheet.model.FileModel,
	        remoteSort: true,
	        proxy: {
	            type: 'ajax',
                url: SCONFIG.urls['listOpen'],
	            reader: {
	                root: 'results',
	                totalProperty: 'totalCount'
	            }
	        }
	    });
        
        this.queryField = Ext.create('Ext.form.field.Text', {
            width: 300,
            enableKeyEvents: true,
            listeners: {
                'keydown': {
                    fn: this.onQueryKeyDown,
                    scope: this
                }
            }
        });
         
        this.fileGrid = Ext.create('Ext.grid.Panel', {
	        store: this.fileStore,
	        loadMask: true,
            border: false,
	        columns:[{
				width: 56,
				dataIndex: 'exname',
				menuDisabled: true,
				resizable: false,
				draggable: false,
				renderer: this.renderIcon
			},{
	            text: SLANG['file_name'],
	            dataIndex: 'name',
	            flex: 1,
	            sortable: true
	        }, {
				text: SLANG['update_date'],
				dataIndex: 'updateDate',
                style: 'border-right:none;',
				minWidth: 150,
	            maxWidth: 250,
				menuDisabled: true,
				resizable: false,
				draggable: false
			}],
	        dockedItems: [{
                dock: 'top',
                xtype: 'toolbar',
                style: 'padding-left:10px;background:white;',
                height: 36,
                layout: {
                    type: 'hbox',
                    align: 'middle'
                },
                items: [this.queryField, {
                    style: 'margin-left:2px;',
                    text: SLANG['search'],
                    handler: this.onSearchFn,
                    scope: this
                }]
            }],
	        // paging bar on the bottom
	        bbar: Ext.create('Ext.PagingToolbar', {
	            store: this.fileStore,
	            displayInfo: true,
	            displayMsg: 'Displaying items {0} - {1} of {2}',
	            emptyMsg: "No items to display"
	        })
	    });
        this.fileStore.load();
           
        this.openBtn = Ext.create('Ext.button.Button', {
            disabled: true,
            text: SLANG['open'],
            handler: this.onOpenFn,
            scope: this
        });
           
        this.items = [this.fileGrid];
           
        this.buttons = [this.openBtn];
           
        this.callParent(arguments);
           
        this.on({
            scope: this,
            'hide': this.onHideFn
        });
        
        this.fileGrid.on({
            scope: this,
            'itemclick': this.onRowSelectFn,
            'itemdblclick': this.onRowDblClickFn
        });
    },
    
    /**
	 * render the photo
	 */
	renderIcon : function(val, meta, rec, rowIndex, colIndex, store, view){
		var result = '<img src="' + SCONFIG.IMAGES_PATH + '/icons/open.png' + '"></img>';

		if (rec.data.exname == 'xls') {
			result = '<img src="' + SCONFIG.IMAGES_PATH + '/sheet_darkgreen.png' + '"></img>';
		} else if (rec.data.exname == 'xlt') {
			result = '<img src="' + SCONFIG.IMAGES_PATH + '/sheet_tpl.png' + '"></img>';
		} 
		return result;
	},       
           
    onHideFn : function(){
        if(this.hideCallback){
           this.hideCallback.call(this.scope, this);
        }
    },
           
    setTitle : function(title){
        this.titleBox.update(title);
    },
           
    /**
     * setup the config and show
     */
    popup : function(config){
        if(config){
            Ext.apply(this, config);
        }
        this.show();
    },
           
    /**
     * on save the file
     */
    onOpenFn : function() {
        var sels = this.fileGrid.getSelectionModel().getSelection();

        this.hide();
        if(this.callback){
            this.callback.call(this.scope, sels[0].data.id);
        }
    },
           
    onCancelFn : function(){
        this.hide();
    },
           
    /**
     * when select a node in dir tree
     */
    onRowSelectFn : function(list, rec, item, index, e){
        var selectedId = rec.data.id;
        var exname = rec.data.exname;
        
        if (exname == 'xls' || exname == 'xlt')
            this.openBtn.enable();
        else 
            this.openBtn.disable();
    },
    
    onRowDblClickFn : function(list, rec, item, index, e) {
        var selectedId = rec.data.id;
        var exname = rec.data.exname;
        if (exname == 'xls' || exname == 'xlt'){
            this.hide();
            if(this.callback){
                this.callback.call(this.scope, selectedId);
            }
        }
    },
           
    // this is for search function ...
    onQueryKeyDown : function(field, e){
        var key = e.getKey();
        var keyObj = Ext.EventObject ? Ext.EventObject : Ext.event.Event;
        if(keyObj.ENTER === key){
           this.onSearchFn();
        }else if(keyObj.ESC === key){
           if('' !== this.queryField.getValue()){
                this.queryField.setValue('');
                this.onSearchFn();
           }
        }
    },
           
    /**
     * search files ...
     */
    onSearchFn : function(){
        var query = this.queryField.getValue();
        this.fileStore.load({
            params:{
                query: query
            }
        });
    }
}, function(){
    SOPEN = (function(){
        var win;
        return {
            popup : function(config){
                if(!win){
                    win = new EnterpriseSheet.pop.OpenFileWin({
                        width: 550,
                        height: 400
                    });
                }
                Ext.apply(win, config);
                win.popup();
             }
        }
    })();
});