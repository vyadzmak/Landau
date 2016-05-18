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
Ext.define('customer.CellEditor', {
	
	extend : 'Ext.window.Window',
    bodyStyle : 'background-color:white;padding:1px;',         
	width : 550,    	
	height: 300,
    plain: true,          
    resizable: false,       
    shim : true,  
    closeAction: 'hide',    
	layout: 'fit',  
	title: "Please select one of the items (Load data from customer server)",
	
	initComponent : function(){
		
		Ext.define('customer.ContactModel', {
	        extend: 'Ext.data.Model',
	        fields: [
	            {name: 'id'},
	            {name: 'name'},
	            {name: 'email'}
	         ]
	    });
		
		Ext.grid.dummyData = [
		    [1, "Adam Featherstone", "adam@gmail.com"],
		    [2, "Eric Wang", "eric@gmail.com"],
		    [3, "Jerry Thomas", "jerry@gmail.com"],
		    [4, "Christina Angella", "christina@gmail.com"],
		    [5, "Jonshon Mary", "johnson@gmail.com"],
		    [6, "Marina Chris", "marina@gmail.com"],
		    [7, "Heleon Johm", "heleon@gmail.com"],
		    [8, "Eva Mat", "eva@gmail.com"],
		    [9, "John Marc", "john@abc.com"],
		    [10, "Marry Marc", "marry@abc.com"],
		    [11, "Welsey Marc", "wesley@abc.com"],
		    [12, "Terry Marc", "terry@abc.com"],
		    [13, "Kelly Marc", "kelly@abc.com"],
		    [14, "Mena Marc", "mena@abc.com"]
	    ];
		
		this.dummyDataStore = Ext.create('Ext.data.ArrayStore', {
            model: 'customer.ContactModel',
            data: Ext.grid.dummyData
        });
	    
		this.contactGrid = Ext.create('Ext.grid.Panel', {			
			autoScroll: true,
			store: this.dummyDataStore,
	        selType: 'checkboxmodel',	        
	        columns: [
	            {text: "Name", width: 170, dataIndex: 'name'},
	            {text: "Email", width: 200, dataIndex: 'email'}
	        ],
	        columnLines: true,
	        listeners: {
	            afterrender: function() {
	            	this.contactGrid.getEl().swallowEvent('mousewheel');	            	
	            },
	            scope: this
	        },
	        scope: this
		});
		
		this.items = [this.contactGrid];
		
		this.dockedItems = [{
			xtype: 'container',
			dock: 'right',
			width: 100,
			style: 'padding:0px 10px;',
			layout: {
				type: 'vbox',
				align: 'stretch'
			},
			items: [{
				xtype: 'button',
				text: "Update",
				handler: this.onUpdate,
				scope: this
			}, {
				xtype: 'button',
				text: "Cancel",
				style: 'margin-top:10px;',
				handler: this.onCancel,
				scope: this
			}]
		}];
		
		this.callParent();	
		
		var sm = this.sheet.getSelectionModel();
		sm.on('selectionchange', function(){
			if(this.isVisible()){
				this.hide();
			}			
		}, this);
	},
	
	popup : function(config) {
		Ext.apply(this, config);
		var region = config.region, row = config.row, col = config.col;
		var cellEl = region.getCellEl(row, col);
		var el = this.getEl();
		if(!el){
			this.render(region.ifbodyEl);
		}else{
			el.appendTo(region.ifbodyEl);
		}
		
		this.showBy(cellEl, 'tl-tl?');
		
		this.contactGrid.getSelectionModel().deselectAll();
		var cellJson = this.sheet.getCellValue(this.sheetId, this.row, this.col);
		var contactObjs = Ext.decode(cellJson.itms);
		if (contactObjs) {
			for (var i=0; i<contactObjs.length; i++) {
				var contactId = contactObjs[i].id;
				var rec = this.contactGrid.store.findRecord('id', contactId);			
				this.contactGrid.getSelectionModel().select(rec,true,false);		
			}
		}
	},
	
	// check whether field is ok ...
	onUpdate : function() {		
		var arr = [], itms = [];	
		var selected = this.contactGrid.getSelectionModel().getSelection();
		Ext.each(selected, function (item) {
		    arr.push(item.data.name);
			itms.push({
				name: item.data.name,
				email: item.data.email,
				id: item.data.id
			});
		});		
		if(0 < arr.length){
			this.sheet.setCell(this.sheetId, this.row, this.col, {
				data: arr.join(', '),
				itms: Ext.encode(itms),
				render: 'contactRender'
			});
			this.sheet.focus(100);
			this.close();
		}else{
			Ext.Msg.alert('Hint', 'Please select at least one item');
		}
	},
	
	onCancel : function() {
	    this.hide();	
	}
});
