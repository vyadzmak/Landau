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
Ext.define('enterpriseSheet.demo.WestPanel', {
    extend : 'Ext.Panel',	
	region: 'west',
	split: true, 
	width:  250,
	minWidth: 100,
    border: false,
    style: 'border-right:1px solid silver;',
    collapsible: true,
   // collapsed:true,
    title: 'EnterpriseSheet Examples',
    layout: 'border',
    
    docUrl: 'http://enterprisesheet.com/api/',
    srcHtml: '',
	
	initComponent : function(){
		
		var useCases = [{
	    	iconCls: 'icon-feature',
	    	id: 'cases-feature',
	        text: 'EnterpriseSheet Features',
	        leaf: true
	    }, {
	    	iconCls: 'icon-money',
	    	id: 'cases-expense',
	        text: 'Hour and Expense Tracking',
	        leaf: true
	    }, {
	    	iconCls: 'icon-calendar',
	    	id: 'cases-calendar',
	        text: 'Calendar',
	        leaf: true
	    }, {
	    	iconCls: 'icon-cake',
	    	id: 'cases-wedding',
	        text: 'Wedding Budget',
	        leaf: true
	    }, /** {
	    	iconCls: 'icon-sun',
	    	id: 'cases-garden',
	        text: 'Garden Planner',
	        leaf: true
	    }, **/{
	    	iconCls: 'icon-chart',
	    	id: 'cases-weight',
	        text: 'His and her weight loss tracker',
	        leaf: true
	    }, {
			iconCls: 'icon-invoice',
	    	id: 'feature-special-dataBindingVariable1',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/dataBindingVariable.html',
	    	exampleJson: 'dataBindingVariableJson',
	    	qtip: 'Right click open document',
	        text: 'Invoice (data binding)',
	        leaf: true
		}, {
			iconCls: 'icon-survey',
	    	id: 'feature-special-survey',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/dynamicFormBuilder.html',
	    	exampleJson: 'surveyCaseJson',
	    	qtip: 'Right click open document',
	        text: 'EnterpriseSheet Survey (form builder)',
	        leaf: true
		}, {
			iconCls: 'icon-dataType',
	    	id: 'feature-col-datatype',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/colDataType.html',
	    	exampleJson: 'featureColDataTypeJson',
	        text: 'Define Column Data Types',
	        leaf: true
		}];
		
		// ===============================================================
		var conditionChild = [{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-condition-highlight',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/compareCond.html',
	    	exampleJson: 'featureConditionHighlightJson',
	    	qtip: 'Right click open document',
	        text: 'Number condition rule',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-condition-string',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/stringCompareCond.html',
	    	exampleJson: 'featureConditionStringJson',
	    	qtip: 'Right click open document',
	        text: 'Text condition rule',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-condition-date',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/dateCond.html',
	    	exampleJson: 'featureConditionDateJson',
	    	qtip: 'Right click open document',
	        text: 'Date occurring rule',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-condition-topBottom',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/calculateCond.html',
	    	exampleJson: 'featureConditionTopBottomJson',
	    	qtip: 'Right click open document',
	        text: 'Top/bottom rule',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-condition-bar',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/colorfulBarCond.html',
	    	exampleJson: 'featureConditionBarJson',
	    	qtip: 'Right click open document',
	        text: 'Data bar',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-condition-colorScales',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/colorScalesCond.html',
	    	exampleJson: 'featureConditionColorScalesJson',
	    	qtip: 'Right click open document',
	        text: 'Color scales',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-condition-iconset',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/iconSetsCond.html',
	    	exampleJson: 'featureConditionIconsetJson',
	    	qtip: 'Right click open document',
	        text: 'Icon sets',
	        leaf: true
	    }];
		
		var validationChild = [{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-validation-number',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/validationNum.html',
	    	exampleJson: 'featureValidationNumberJson',
	    	qtip: 'Right click open document',
	        text: 'Number validation',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-validation-text',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/validationText.html',
	    	exampleJson: 'featureValidationTextJson',
	    	qtip: 'Right click open document',
	        text: 'Text validation',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-validation-date',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/validationDate.html',
	    	exampleJson: 'featureValidationDateJson',
	    	qtip: 'Right click open document',
	        text: 'Date validation',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-validation-list',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/validationList.html',
	    	exampleJson: 'featureValidationListJson',
	    	qtip: 'Right click open document',
	        text: 'List item validation',
	        leaf: true
	    }];
		
		var chartChild = [{
			iconCls: 'icon-tag-purple',
	    	id: 'feature-chart-bar',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/chartColumn.html',
	    	exampleJson: 'featureChartBarJson',
	    	qtip: 'Right click open document',
	        text: 'Generate column / bar chart',
	        leaf: true
		}, {
			iconCls: 'icon-tag-purple',
	    	id: 'feature-chart-area',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/chartArea.html',
	    	exampleJson: 'featureChartAreaJson',
	        text: 'Generate area chart',
	        leaf: true
		}, {
			iconCls: 'icon-tag-purple',
	    	id: 'feature-chart-line',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/chartLine.html',
	    	exampleJson: 'featureChartLineJson',
	    	qtip: 'Right click open document',
	        text: 'Generate line / scatter chart',
	        leaf: true
		}, {
			iconCls: 'icon-tag-purple',
	    	id: 'feature-chart-pie',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/chartPie.html',
	    	exampleJson: 'featureChartPieJson',
	    	qtip: 'Right click open document',
	        text: 'Generate pie chart',
	        leaf: true
		}, {
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-sparkline-col',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/sparklineCol.html',
	    	exampleJson: 'featureSparklineJson',
	    	qtip: 'Right click open document',
	        text: 'Sparkline column chart',
	        leaf: true
	    }, {
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-sparkline-winloss',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/sparklineWinloss.html',
	    	exampleJson: 'featureSparklineWinLossJson',
	    	qtip: 'Right click open document',
	        text: 'Sparkline win/loss chart',
	        leaf: true
	    }, {
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-sparkline-line',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/sparklineLine.html',
	    	exampleJson: 'featureSparklineLineJson',
	    	qtip: 'Right click open document',
	        text: 'Sparkline line chart',
	        leaf: true
	    }];	
		
		var cellTypeChild = [{
			iconCls: 'icon-tag-purple',
	    	id: 'feature-cell-checkbox',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/checkbox.html',
	    	exampleJson: 'featureCheckboxJson',
	    	qtip: 'Right click open document',
	        text: 'Checkbox/Radio cell',
	        leaf: true
		}, {
			iconCls: 'icon-tag-purple',
	    	id: 'feature-cell-combobox',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/dropdown.html',
	    	exampleJson: 'featureComboboxJson',
	    	qtip: 'Right click open document',
	        text: 'Combobox cell',
	        leaf: true
		}, {
			iconCls: 'icon-tag-purple',
	    	id: 'feature-cell-link',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/cellLink.html',
	    	exampleJson: 'featureLinkJson',
	    	qtip: 'Right click open document',
	        text: 'Hyperlink cell',
	        leaf: true
		}, {
			iconCls: 'icon-tag-purple',
	    	id: 'feature-cell-button',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/button.html',
	    	exampleJson: 'featureButtonJson',
	    	qtip: 'Right click open document',
	        text: 'Button cell',
	        leaf: true
		}, {
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-special-comment',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/cellComment.html',
	    	exampleJson: 'featureCommentJson',
	    	qtip: 'Right click open document',
	        text: 'Comment cell',
	        leaf: true
	    }];
		
		var dataBindingChild = [{
			iconCls: 'icon-tag-green',
	    	id: 'feature-cellBinding',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/customExtraData.html',
	    	exampleJson: 'callbackCellDataBindingJson',
	    //	exampleCode: 'callbackCellDataBindingCode',
	    	qtip: 'Right click open document',
	        text: 'Bind custom extra data to the cell',
	        leaf: true
		},{
			iconCls: 'icon-tag-green',
	    	id: 'feature-2wayDataBinding',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/customDataBinding.html',
	    	exampleJson: 'callback2wayDataBindingJson',
          //  exampleCode: 'callback2wayDataBindingCode',
	    	qtip: 'Right click open document',
	        text: '2-way cell data binding',
	        leaf: true
		}, {
			iconCls: 'icon-tag-green',
	    	id: 'feature-complexDataBinding1',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/dataBindingSubmit.html',
	    	exampleJson: 'dataBindingSubmitJson',
	    	qtip: 'Right click open document',
	        text: 'Data binding and submit',
	        leaf: true
		}, {
			iconCls: 'icon-tag-green',
	    	id: 'feature-special-dataBindingVariable',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/dataBindingVariable.html',
	    	exampleJson: 'dataBindingVariableJson',
	    	qtip: 'Right click open document',
	        text: 'Data binding with variable',
	        leaf: true
		}, {
			iconCls: 'icon-tag-green',
	    	id: 'feature-cellEventBinding',
	    	//docUrl: 'http://www.enterprisesheet.com/api/docs/customized/dataBindingVariable.html',
	    	exampleJson: 'cellEventBindingJson',
	    	exampleCode: 'cellEventBindingCode',
	    	qtip: 'Right click open document',
	        text: 'Cell event binding',
	        leaf: true
        }];
		
		var dataFormatChild = [{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-money',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/money.html',
	    	exampleJson: 'featureMoneyJson',
	    	qtip: 'Right click open document',
	        text: 'Money format',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-dateFormat',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/dateFormat.html',
	    	exampleJson: 'featureDateJson',
	    	qtip: 'Right click open document',
	        text: 'Date format',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-customNum',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/customNumber.html',
	    	exampleJson: 'featureCustomJson',
	    	qtip: 'Right click open document',
	        text: 'Custom number format',
	        leaf: true
	    }];
		
		var formulaChild = [{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-formula',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/formulaCell.html',
	    	exampleJson: 'featureFormulaJson',
	    	qtip: 'Right click open document',
	        text: 'Formula / Function',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-formula-nmgr',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/nameMgr.html',
	    	exampleJson: 'featureFormulaNmgrJson',
	    	qtip: 'Right click open document',
	        text: 'Name manager',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-customizedFormula',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/addCalculates.html',
	    	exampleJson: 'featureCusomizedFormulaJson',
	        text: 'Add customized calculate function',
	        qtip: 'Right click open document',
	        leaf: true
	    }];
		
		var titleBarChild = [{
		    iconCls: 'icon-tag-green',
	    	id: 'feature-titlebar-freeze',
	        text: 'Toggle freeze',
	        leaf: true	
		},{
		    iconCls: 'icon-tag-green',
	    	id: 'feature-titlebar-search',
	        text: 'Show find/replace window',
	        leaf: true	
		},{
		    iconCls: 'icon-tag-green',
	    	id: 'feature-titlebar-chart',
	        text: 'Show chart window',
	        leaf: true	
		},{
		    iconCls: 'icon-tag-green',
	    	id: 'feature-titlebar-table',
	        text: 'Show table style window',
	        leaf: true	
		},{
		    iconCls: 'icon-tag-green',
	    	id: 'feature-titlebar-cellStyle',
	        text: 'Show cell style window',
	        leaf: true	
		},{
		    iconCls: 'icon-tag-green',
	    	id: 'feature-titlebar-picture',
	        text: 'Show picture window',
	        leaf: true	
		},{
		    iconCls: 'icon-tag-green',
	    	id: 'feature-titlebar-widget',
	        text: 'Show widget window',
	        leaf: true	
		},{
		    iconCls: 'icon-tag-green',
	    	id: 'feature-titlebar-condition',
	        text: 'Show condition window',
	        leaf: true	
		},{
		    iconCls: 'icon-tag-green',
	    	id: 'feature-titlebar-toggleGridLine',
	        text: 'Hide gridline',
	        leaf: true	
		},{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-addPicture',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/insertImage.html',
	    	exampleJson: 'featureInsertPictureJson',
	    	qtip: 'Right click open document',
	        text: 'Insert image',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-addWidget',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/insertWedgit.html',
	    	exampleJson: 'featureInsertWidgetJson',
	    	qtip: 'Right click open document',
	        text: 'Insert a widget',
	        leaf: true
	    }];
		
		var textStyleChild = [{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-basic',
	    	exampleJson: 'featureBasicJson',
	        text: 'Basic Features',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-cellFont',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/cellFont.html',
	    	exampleJson: 'featureCellFontJson',
	    	qtip: 'Right click open document',
	        text: 'Text Decoration',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-cellAlign',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/cellAlign.html',
	    	exampleJson: 'featureCellAlignJson',
	    	qtip: 'Right click open document',
	        text: 'Text align and indent',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-textColor',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/cellColor.html',
	    	exampleJson: 'featureCellColorJson',
	    	qtip: 'Right click open document',
	        text: 'Set cell color',
	        leaf: true
	    }];
		
		var tabActionChild = [{
	    	iconCls: 'icon-tag-green',
		    id: 'feature-default-sheet-style',
		    docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/sheetStyle.html',
		    exampleJson: 'sheetDefaultStyle',
	    	qtip: 'Right click open document',
	        text: 'Set sheet default style',
	        leaf: true
	    }, {
	    	iconCls: 'icon-tag-green',
		    id: 'feature-sheet-group',
		    docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/groupSheet.html',
	    	exampleJson: 'featureGroup',
	    	qtip: 'Right click open document',
	        text: 'Group range',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-sheet-freeze',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/manageDataAPIs/sheetAPI.html#freezeSheet',
	    	exampleJson: 'featureFreezeSheet',
	        text: 'Freezing (cell B2)',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-autoScroll',
	    	exampleJson: 'featureAutoScroll',
	        text: 'Scroll bar',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-sheet-add',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/addTab.html',
	    	exampleJson: 'featureAddSheet',
	        text: 'Add new sheet',
	        leaf: true
	    }, {
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-sheet-retrieve',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/getTabData.html',
	    	exampleJson: 'featureRetrieveSheet',
	        text: 'Retrieve sheet tab data',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-disableSheet',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/readOnly.html',
	    	exampleJson: 'featureDisableSheetJson',
	    	qtip: 'Right click open document',
	        text: 'Disable Sheet',
	        leaf: true
	    },];
		
		var performanceChild = [{
			iconCls: 'icon-tag-purple',
	    	id: 'performance-render-10000',
	        text: 'Render 10,000 data',
	        leaf: true
		},{
			iconCls: 'icon-tag-purple',
	    	id: 'performance-render-50000',
	        text: 'Render 50,000 data',
	        leaf: true
		},{
			iconCls: 'icon-tag-purple',
	    	id: 'performance-render-100000',
	        text: 'Render 100,000 data',
	        leaf: true
		},{
			iconCls: 'icon-tag-purple',
	    	id: 'performance-render-60-200',
	        text: 'Render 60*200 data',
	        leaf: true
		},{
			iconCls: 'icon-tag-purple',
	    	id: 'performance-render-3tabs',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/loadDataSwitchTab.html',
	        text: 'load data during switch sheet tab',
	        exampleJson: 'loadDataSwitchTabJson',
	        leaf: true
		}];
		
		// ============================================================
		
		var rowColActionChild = [{
			iconCls: 'icon-tag-green',
	    	id: 'feature-rowCol-hide',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/rowColsHide.html',
	    	exampleJson: 'featureRowColHideJson',
	    	qtip: 'Right click open document',
	        text: 'Hide rows/columns',
	        leaf: true
		},{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-disable',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/disable.html',
	    	exampleJson: 'featureDisableJson',
	    	qtip: 'Right click open document',
	        text: 'Disable cell/row/column',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-rowCol-heighCol',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/rowColWidth.html',
	    	exampleJson: 'featureRowColColorJson',
	    	qtip: 'Right click open document',
	        text: 'Set row/column height, color',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-special-addNewRow',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/insertRows.html',
	    	exampleJson: 'featureAddRowJson',
	    	qtip: 'Right click open document',
	        text: 'Add new row to sheet',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-special-addNewCol',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/insertCols.html',
	    	exampleJson: 'featureAddColJson',
	    	qtip: 'Right click open document',
	        text: 'Add new column to sheet',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-green',
	    	id: 'feature-special-setrowcolnumber',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/setMaxRowCol.html',
	    	exampleJson: 'featureMaxColRowJson',
	    	qtip: 'Right click open document',
	        text: 'Set max row/column number',
	        leaf: true
	    }];
		
		// =============================================================
		
		var applyTableBorderChild = [{
			iconCls: 'icon-tag-green',
	    	id: 'feature-special-table',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/tableTpl.html',
	    	exampleJson: 'featureTableJson',
	    	qtip: 'Right click open document',
	        text: 'Apply table template to cell range',
	        leaf: true
		},{
			iconCls: 'icon-tag-green',
	    	id: 'feature-sheet-applyBorder',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/codeExample/borderStyle.html',
	    	exampleJson: 'featureApplyBorderJson',
	    	qtip: 'Right click open document',
	        text: 'Apply border to cell range',
	        leaf: true
		}];
		
		// ==============================================================
		
		var filterSortChild = [{
			iconCls: 'icon-tag-green',
	    	id: 'feature-special-filter',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/manageDataAPIs/sheetAPI.html#addFilter2Span',
	    	exampleJson: 'filterCellsJson',
	    	qtip: 'Right click open document',
	        text: 'Add filter to the cell range',
	        leaf: true
		},{
			iconCls: 'icon-tag-green',
	    	id: 'feature-sortitem',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/manageDataAPIs/sheetAPI.html#sortCellByAsc',
	    	exampleJson: 'sortCellsJson',
	    	qtip: 'Right click open document',
	        text: 'Add sort to the cell range',
	        leaf: true
		}];
		
		// ===============================================================
		
		var features = [{
	    	text: 'Apply table, border to cells', 
		    cls: 'folder',
		    expanded: false,
		    children: applyTableBorderChild
	    },{
	    	text: 'Cell type', 
		    cls: 'folder',
		    expanded: false,
		    children: cellTypeChild
	    },{
	    	text: 'Chart features/APIs', 
		    cls: 'folder',
		    expanded: false,
		    children: chartChild
	    },{
	    	text: 'Condition format', 
		    cls: 'folder',
		    expanded: false,
		    children: conditionChild
	    },{
	    	text: 'Data binding', 
		    cls: 'folder',
		    expanded: false,
		    children: dataBindingChild
	    },{
	    	text: 'Data format', 
		    cls: 'folder',
		    expanded: false,
		    children: dataFormatChild
	    },{
	    	text: 'Filter, sort cells', 
		    cls: 'folder',
		    expanded: false,
		    children: filterSortChild
	    },{
	    	text: 'Formula / function', 
		    cls: 'folder',
		    expanded: false,
		    children: formulaChild
	    },{
	    	text: 'Performance', 
		    cls: 'folder',
		    expanded: false,
		    children: performanceChild
	    },{
	    	text: 'Row/Column actions', 
		    cls: 'folder',
		    expanded: false,
		    children: rowColActionChild
	    },{
	    	text: 'Sheet/Tab actions', 
		    cls: 'folder',
		    expanded: false,
		    children: tabActionChild
	    },{
	    	text: 'Text style', 
		    cls: 'folder',
		    expanded: false,
		    children: textStyleChild
	    },{
	    	text: 'Title bar related actions', 
		    cls: 'folder',
		    expanded: false,
		    children: titleBarChild
	    },{
	    	text: 'Validation', 
		    cls: 'folder',
		    expanded: false,
		    children: validationChild
	    }];
		
		// ====================================================
		
		var callbackFn = [{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-groupToggle',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/eventListenerFn.html',
	    	exampleJson: 'groupToggleEventListenerJson',
	    	exampleCode: 'groupToggleEventListenerCode',
	    	qtip: 'Right click open document',
	        text: 'Group event listener Fn',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-oncellBLUR',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/cellEventCallbackFn.html',
	    	exampleJson: 'callbackCellBlurJson',
	    	exampleCode: 'callbackCellBlurCode',
	    	qtip: 'Right click open document',
	        text: 'Cell onBlur call back',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-oncellFocus',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/cellEventCallbackFn.html',
	    	exampleJson: 'callbackCellFocusJson',
	    	qtip: 'Right click open document',
	        text: 'Cell onFocus call back',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-oncellclick',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/cellEventCallbackFn.html',
	    	exampleJson: 'callbackCellClickJson',
	    	qtip: 'Right click open document',
	        text: 'Cell onClick call back',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-ondoubleclick',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/cellEventCallbackFn.html',
	    	exampleJson: 'callbackCellDblClickJson',
	    	qtip: 'Right click open document',
	        text: 'Cell onDoubleClick call back',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-onmousemove',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/cellEventCallbackFn.html',
	    	exampleJson: 'callbackMouseMoveJson',
	    	qtip: 'Right click open document',
	        text: 'Cell onMouseMove call back',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-onmouseDown',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/cellEventCallbackFn.html',
	    	exampleJson: 'callbackMouseDownJson',
	    	qtip: 'Right click open document',
	        text: 'Cell onMouseDown call back',
	        leaf: true
	    },{
			iconCls: 'icon-tag-purple',
	    	id: 'feature-complexDataBinding1',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/dataBindingSubmit.html',
	    	exampleJson: 'dataBindingSubmitJson',
	    	qtip: 'Right click open document',
	        text: 'Data binding and submit',
	        leaf: true
		},{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-onTabClick',
	    	docUrl: 'http://www.enterprisesheet.com/api/docs/customized/switchTabCallbackFn.html',
	    	exampleJson: 'callbackSheetSwitchJson',
	    	exampleCode: 'callbackSheetSwitchCode',
	    	qtip: 'Right click open document',
	        text: 'Switch tab event callback Fn',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-onCopyPaste',
	    	//docUrl: 'http://www.enterprisesheet.com/api/docs/customized/switchTabCallbackFn.html',
	    	exampleJson: 'callbackCopyPasteJson',
	    	exampleCode: 'callbackCopyPasteCode',
	    	qtip: 'Right click open document',
	        text: 'Copy paste event callback Fn',
	        leaf: true
	    },{
	    	iconCls: 'icon-tag-purple',
	    	id: 'feature-afterCellChange',
	    	//docUrl: 'http://www.enterprisesheet.com/api/docs/customized/switchTabCallbackFn.html',
	    	exampleJson: 'callbackAfterCellChangeJson',
	    	exampleCode: 'callbackAfterCellChangeCode',
	    	qtip: 'Right click open document',
	        text: 'aftercellchange event callback Fn',
	        leaf: true
        }, {
            iconCls: 'icon-tag-green',
            id: 'feature-getDataFromRange',
            //docUrl: 'http://www.enterprisesheet.com/api/docs/customized/dataBindingSubmit.html',
            exampleJson: 'getDataFromRangeJson',
            qtip: 'Right click open document',
            text: 'Get data from range',
            leaf: true
        }];
		
		// =====================================================
		
		var restWebService = [{
			iconCls: 'icon-tag-red',
		    id: 'api-restWebService-import',
	        text: 'REST web service Import XLSX',
	        leaf: true
		}];

		// ====================================================== main children
		
		var children = [];
		if (!SCONFIG.js_standalone) {
		    children = [{ text: 'EnterpriseSheet Use Cases', cls: 'folder', expanded: true, children: useCases}];	
		}		
		children.push({ text: 'EnterpriseSheet Samples / APIs',  cls: 'folder', expanded: true, children: features });	
		children.push({ text: 'Event listener & customer callback fn',  cls: 'folder', expanded: false, children: callbackFn });	
		if (!SCONFIG.js_standalone) {
			children.push({ text: 'REST web service Samples', cls: 'folder', expanded: false, children: restWebService});	
		}
		
		children.push({ iconCls: 'icon-help', id: 'link-sheet-document', text: 'EnterpriseSheet Documents', leaf: true });
		
		// ==================================================================
		
		this.treeStore = Ext.create('Ext.data.TreeStore', {
            root: {
	            expanded: true,
	            children: children
	        }
	    });
		
		this.demoTree = Ext.create('Ext.tree.Panel', { 
			region: 'center',
			border: false,
	        useArrows:true,
	        autoScroll:true,
	        animate:true,
	        enableDD: false,
	        containerScroll: false,
	        rootVisible: false,
	        store: this.treeStore,
	        viewConfig:{
		        cls:'large-font'
		    },
	    });
		
		this.treeMenu = new Ext.menu.Menu({
	        items: [{
	            text: 'Detail documents',
	            handler: function() {
	                window.open(this.docUrl,'_blank');
	            },
	            scope: this
	        }, {
	            text: 'Json data',
	            handler: function() {
	                var sourceWin = Ext.create('enterpriseSheet.demo.SourceWin', {srcHtml: this.srcHtml});
	                sourceWin.show();
	            },
	            scope: this
	        }],
	        scope: this
	    });
		
		
    	this.items = [{
    		xtype: 'component',
            region:"south",
            autoHeight:true,                       
            html: '<div class="x-view-emtpytext">Open tree node contextmenu to see detail document and source</div>'
        }, this.demoTree];
    	
        this.callParent();
        
		this.demoTree.on("itemclick", this.onClickHandler, this);		
		this.demoTree.on('itemcontextmenu', this.onContextMenu, this);	
		
	},
	
	selectNode : function() {
		var query = window.location.search.substring(1);
		var pair = query.split("=");
		if (pair[0] == "loadChildId") {
			var node = this.treeStore.getNodeById(pair[1]);
			this.demoTree.getSelectionModel().select(node);
			if (pair[1] == "feature-special-survey") {
				this.centralPanel.specialHandler(node.data.id, node.data.text, "surveyCaseJson");
			}
		}
	},
	
	onClickHandler : function(view, record, obj, options) {
		
		var itemId = record.data.id, titleTxt = record.data.text,  exampleJson = record.raw.exampleJson, 
		    exampleCode = record.raw.exampleCode;
		
		if (itemId && itemId.lastIndexOf("cases-", 0) === 0) {
			this.centralPanel.loadUserCases(itemId, titleTxt);
		}
		
		else if (itemId && itemId.lastIndexOf("link-sheet-", 0) === 0) {
			this.centralPanel.outLink(itemId);
		}
		
		else if (itemId && itemId.lastIndexOf("performance-", 0) === 0) {
			if (itemId == "performance-render-3tabs") 
				this.centralPanel.performanceSheetTab(itemId, titleTxt);
			else 
		        this.centralPanel.performanceSheet(itemId, titleTxt);
		}
		
		else if (itemId && itemId.lastIndexOf("feature-titlebar-") === 0) {
			this.centralPanel.titlebarAction(itemId, titleTxt);
		}
		
		else if (itemId && itemId.lastIndexOf("feature-sheet-") === 0) {
			this.centralPanel.sheetTabHandler(itemId, titleTxt, exampleJson);
		} 
		
		else if (itemId && itemId.lastIndexOf("api-restWebService-") === 0) {
			this.centralPanel.restApiHandler(itemId);
		}

        else if (itemId && itemId.lastIndexOf("feature-customizedFormula") === 0) {
			this.centralPanel.customizedFormula(itemId, titleTxt, exampleJson);
		}
		
		else if (itemId && itemId.lastIndexOf("feature-special-") === 0) {
			this.centralPanel.specialHandler(itemId, titleTxt, exampleJson);
		}
		
		else if (itemId && itemId.lastIndexOf("feature-col-datatype") === 0) {
			this.centralPanel.colDataTypeHandler(itemId, titleTxt, exampleJson);
		}
		
        else if (itemId && itemId.lastIndexOf("feature-formula-nmgr") === 0) {
			this.centralPanel.handleNameMgr(itemId, titleTxt, exampleJson);
		}
		
		else if (itemId) {
		    this.centralPanel.updateSheet(itemId, titleTxt, exampleJson);
		}
		
		if(exampleCode){
			JSON_DATA[exampleCode]();
		}
	},
	
	/**
	 * contextmenu event
	 */
	onContextMenu : function(view, record, item, index, event) {
		var itemId = record.data.id, docHtml = record.raw.docUrl;
		
		if (itemId && docHtml) {
			this.docUrl = docHtml;
			this.srcHtml = record.raw.exampleJson + '.html';
			this.treeMenu.showAt(event.getXY());
	        event.stopEvent();
		}
	}
});