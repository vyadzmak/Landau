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
Ext.onReady(function() {

    Ext.QuickTips.init();
    
    /**
     * Define those 2 methods as global variable
     */
    SHEET_API = Ext.create('EnterpriseSheet.api.SheetAPI', {
        openFileByOnlyLoadDataFlag: true
    });
    
    SHEET_API_HD = SHEET_API.createSheetApp({
	   withoutTitlebar: false,
       withoutSheetbar: false,
       withoutToolbar: false,
       withoutContentbar: false,
       withoutSidebar: false
	});
    
    // this is tab panel include main and details 
    var centralPanel = Ext.create('enterpriseSheet.templates.CenterPanel', {
    });
    	
    Ext.create('Ext.Viewport', {
        layout: 'border',
        items: [ centralPanel],
        listeners: {
	      afterlayout: function(v, layout, eOpts) {
		      // westPanel.selectNode();
	      }
	    }
    });
    
    // =============================================================================================
    // ok inject data now ...
    var json = {
		fileName: "Employee Directory",
		sheets:[{id:1, name:"Main view", actived:true, color:"orange"}],
		floatings: [
	        { sheet:1, name:"colGroups", ftype:"colgroup", json: "[{level:1, span:[2,3]}, {level:1, span:[4,6]}]" },
	    ],
		cells:[
		    { sheet: 1, row: 0, col: 0, json: { height: 20, va: "middle"} },
		    { sheet: 1, row: 0, col: 1, json: { data: "ID", width: 50, dcfg: "{dt:0, io:true, min:0, max:10000, op:0, ignoreBlank: true, titleIcon: \"number\"}", ticon:"number" } },
			{ sheet: 1, row: 0, col: 2, json: { data: "Name", width: 100, ticon:"profile"} },
			{ sheet: 1, row: 0, col: 3, json: { data: "Dept.(Remote)", width: 130, drop: "list", dcfg: "{dt:15, url: \"fakeData/dropdownList\", titleIcon:  \"remoteList\"}", ticon:"remoteList" } },
			{ sheet: 1, row: 0, col: 4, json: { data: "Email", width: 110, dcfg: "{dt:9, ignoreBlank: true}", ticon:"email" } },
			{ sheet: 1, row: 0, col: 5, json: { data: "Phone", width: 100, dcfg: "{dt:8, ignoreBlank: true}", ticon:"phone" } },
			{ sheet: 1, row: 0, col: 6, json: { data: "Gender", width: 80, drop: "list", dcfg: "{dt:13, list: [\"Male\",\"Female\"], ignoreBlank: true}", ticon:"dropdown" } },
			{ sheet: 1, row: 0, col: 7, json: { data: "Birth date", width: 120, drop: "date", fm: "date", dfm: "F d, Y", ticon:"calendar"  } },			
			{ sheet: 1, row: 0, col: 8, json: { data: "Contact picker", width: 170, ticon:"contact", beforeEdit: "_beforeeditcell_" } },
			{ sheet: 1, row: 0, col: 9, json: { data: "Manager?", width: 100, it: "checkbox", itchk: false, ta: "center", ticon:"checkbox" } },
			{ sheet: 1, row: 0, col: 10, json: { data: "Images", width: 130, dcfg: "{dt:7}", ticon:"image" } },
			{ sheet: 1, row: 0, col: 11, json: { data: "Salary", dcfg: "{dt:11, format: \"money|$|2|none|usd|true\"}",  ticon:"money_dollar" } },
			{ sheet: 1, row: 0, col: 12, json: { data: "Percent", dcfg: "{dt:12, format: \"0.00%\"}",  ticon:"percent" } },
			{ sheet: 1, row: 0, col: 13, json: { data: "Notes", dcfg: "{dt:14, titleIcon: \"textLong\"}",  ticon:"textLong" } },
			
			{ sheet: 1, row: 1, col: 1, json: { data: 1 } },
			{ sheet: 1, row: 1, col: 2, json: { data: 'Jerry Marc' } },
			{ sheet: 1, row: 1, col: 3, json: { render:'dropRender', data: 'HR Dept', dropId: 1} },
			{ sheet: 1, row: 1, col: 4, json: { data: 'john.marc@abc.com'} },
			{ sheet: 1, row: 1, col: 5, json: { data: '1 (888) 456-7654'} },
			{ sheet: 1, row: 1, col: 6, json: { data: 'Female'} },
			{ sheet: 1, row: 1, col: 7, json: { data: '1982-01-15', fm: "date", dfm: "F d, Y" } },
			{ sheet: 1, row: 1, col: 8, json: { render:'contactRender', data: "Eva Mat, John Marc", itms: '[{name: "Eva Mat", email: "eva@gmail.com", id: 8}, {name: "John Marc", email: "john@abc.com", id: 9}]' } },
			{ sheet: 1, row: 1, col: 10, json: { render:'attachRender', itms: '[{aid: "rT7KfpHA8cI_", url: "sheetAttach/downloadFile?attachId=rT7KfpHA8cI_", type: "img", name: "blue.jpg"},{aid: "2ZisVQ1-*Lo_", url: "sheetAttach/downloadFile?attachId=2ZisVQ1-*Lo_", type: "img", name: "green.jpg"}]' } },
			{ sheet: 1, row: 1, col: 11, json: { data: 82334.5678 } },
			{ sheet: 1, row: 1, col: 12, json: { data: 0.96 } },
			{ sheet: 1, row: 1, col: 13, json: { data: 'This is notes, it is a long text. Double click to edit it.' } },
			
			{ sheet: 1, row: 2, col: 1, json: { data: 2 } },
			{ sheet: 1, row: 2, col: 2, json: { data: 'Dave Smith' } },
			{ sheet: 1, row: 2, col: 3, json: { render:'dropRender', data: 'Software Dept', dropId: 2} },
			{ sheet: 1, row: 2, col: 4, json: { data: 'dave.smith@abc.com'} },
			{ sheet: 1, row: 2, col: 5, json: { data: '1 (888) 231-7654'} },
			{ sheet: 1, row: 2, col: 6, json: { data: 'Male'} },
			{ sheet: 1, row: 2, col: 7, json: { data: '1980-01-15', fm: "date", dfm: "F d, Y" } },
			{ sheet: 1, row: 2, col: 8, json: { render:'contactRender', data: "Christina Angela, Marina Chris", itms: '[{name: "Christina Angela", email: "christina@gmail.com", id: 4}, {name: "Marina Chris", email: "marina@abc.com", id: 6}]' } },
			{ sheet: 1, row: 2, col: 10, json: { render:'attachRender', itms: '[{aid: "CIBHu3ffG8Q_", url: "sheetAttach/downloadFile?attachId=CIBHu3ffG8Q_", type: "img", name: "admin.png"},{aid: "VcrhEYAyrzA_", url: "sheetAttach/downloadFile?attachId=VcrhEYAyrzA_", type: "img", name: "asset.png"}]' } },
			{ sheet: 1, row: 2, col: 11, json: { data: 81234.5678 } },
			{ sheet: 1, row: 2, col: 12, json: { data: 0.95 } },
			{ sheet: 1, row: 2, col: 13, json: { data: 'This is notes, it is a long text. Double click to edit it.' } },
			
			{ sheet: 1, row: 3, col: 1, json: { data: 3 } },
			{ sheet: 1, row: 3, col: 2, json: { data: 'Kevin Featherstone' } },
			{ sheet: 1, row: 3, col: 3, json: { render:'dropRender', data: 'Software Dept', dropId: 2} },
			{ sheet: 1, row: 3, col: 4, json: { data: 'kevin@abc.com'} },
			{ sheet: 1, row: 3, col: 5, json: { data: '1 (888) 232-7654'} },
			{ sheet: 1, row: 3, col: 6, json: { data: 'Male'} },
			{ sheet: 1, row: 3, col: 7, json: { data: '1990-01-15', fm: "date", dfm: "F d, Y" } },
			{ sheet: 1, row: 3, col: 8, json: { render:'contactRender', data: "Christina Angela, Marina Chris", itms: '[{name: "Christina Angela", email: "christina@gmail.com", id: 4}, {name: "Marina Chris", email: "marina@abc.com", id: 6}]' } },
			{ sheet: 1, row: 3, col: 10, json: { render:'attachRender', itms: '[{aid: "CIBHu3ffG8Q_", url: "sheetAttach/downloadFile?attachId=CIBHu3ffG8Q_", type: "img", name: "admin.png"},{aid: "VcrhEYAyrzA_", url: "sheetAttach/downloadFile?attachId=VcrhEYAyrzA_", type: "img", name: "asset.png"}]' } },
			{ sheet: 1, row: 3, col: 11, json: { data: 81934.5678 } },
			{ sheet: 1, row: 3, col: 12, json: { data: 0.98 } },
			{ sheet: 1, row: 3, col: 13, json: { data: 'This is notes, it is a long text. Double click to edit it.' } }
		]
	};	
    
	SHEET_API.loadData(SHEET_API_HD, json, null, this);
	SHEET_API.setFocus(SHEET_API_HD, 2, 1); 
   
	// add event listener - this shows the code to add customer function 
	var sheet = SHEET_API_HD.sheet;
	var editor = sheet.getEditor();
	editor.on('quit', function(editor, sheetId, row, col) {		
		if (col === 1) {
			// this is the method to query customer existing backend and auto fill data
			var employeeId = SHEET_API.getCellValue(SHEET_API_HD, sheetId, row, col).data;
			if (employeeId) AUTO_FILL_CUSTOMER_DATA_BY_EMPLOYEEID(employeeId, sheetId, row, col);
		}			
	}, this); 
	
	// add cell on select event ...
	/**
	var sm = sheet.getSelectionModel();
	sm.on('selectionchange', function(startPos, endPos, region, sm) {
	    if (startPos.row == endPos.row && startPos.col == endPos.col && startPos.col == 8) {
	    	this.customEditor = Ext.create('customer.CellEditor', {
	    		sheetId: region.sheetId,
	    		row: startPos.row,
	    		col: startPos.col
	    	});
	    	this.customEditor.popup();
	    }
	}, this);
	**/
	var contactWin;
	sheet.on('_beforeeditcell_', function(sheetId, row, col, cellData, sheet, opt){
		if(!contactWin){
			contactWin = Ext.create('customer.CellEditor', {
	    		sheetId: sheetId,
	    		row: row,
	    		col: col,
	    		cellData: cellData,
	    		sheet: sheet
	    	});
		}			
		contactWin.popup({
			region: opt.region, 
			sheetId: sheetId, 
			row: row, 
			col: col, 
			cellData: cellData
		});
		return false;
	}, this);
	
});
	