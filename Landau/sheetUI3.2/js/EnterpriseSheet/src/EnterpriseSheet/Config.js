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
Ext.define('EnterpriseSheet.Config', {

    singleton: true,

    constructor: function() {

            this.callParent(arguments);

            this.setupDir('');

        Ext.apply(this, {
            // please select one of the following currency code:
            //    'usd', 'rmb', 'eur', 'ars' , 'aud', 'brl', 'cad', 'clp', 'cop', 'dkk', 'hkd', 'isk', 'inr', 'idr', 'ils', 'jpy'		
            //	  'won', 'mxn', 'myr', 'nzd', 'nok', 'pln', 'rub', 'sar', 'sgd', 'zar', 'sek', 'chf', 'twd', 'try', 'gbp', 'afn'
            //    'bob', 'bgn', 'egp', 'ltl', 'vnd', 'uah', 'irr', 'huf', 'cup', 'ron', 'jmd', 'kzt', 'lbp', 'thb', 'ngn', 'zwd'
            //    'all', ''
            default_currency: 'usd',

            // Please select one of the following items:
            //       english_us, chinese
            default_locale: 'english_us',

            // this is for chinese character
            fontFamilyStore_cn: new Ext.data.ArrayStore({
                fields: ['id', 'text'],
                data: [
                    ['\u5B8B\u4F53', '<font face="STXihei">\u5B8B\u4F53</font>'],
                    ['\u6977\u4F53', '<font face="STSong">\u6977\u4F53</font>'],
                    ['\u4EFF\u5B8B\u4F53', '<font face="STKaiti">\u4EFF\u5B8B\u4F53</font>'],
                    ['\u65B0\u5B8B\u4F53', '<font face="STHeiti">\u65B0\u5B8B\u4F53</font>'],
                    ['\u9ED1\u4F53', '<font face="Hiragino Sans GB">\u9ED1\u4F53</font>'],
                    ['Arial', '<font face="arial">Arial</font>'],
                    ['Antiqua', '<font face="antiqua">Antiqua</font>'],
                    ['Calibri', '<font face="calibri">Calibri</font>'],
                    ['Comic Sans MS', '<font face="Comic Sans MS">Comic Sans MS</font>'],
                    ['Courier New', '<font face="courier">Courier New</font>'],
                    ['Garamond', '<font face="Garamond">Garamond</font>'],
                    ['Georgia', '<font face="Georgia">Georgia</font>'],
                    ['Helvetica', '<font face="helvetica">Helvetica</font>'],
                    ['Lucida Console', '<font face="Lucida Console">Lucida Console</font>'],
                    ['MS Serif', '<font face="MS Serif">MS Serif</font>'],
                    ['Monospace', '<font face="Monospace">Monospace</font>'],
                    ['Tahoma', '<font face="tahoma">Tahoma</font>'],
                    ['Times New Roman', '<font face="times">Times New Roman</font>'],
                    ['Verdana', '<font face="verdana">Verdana</font>']
                ]
            }),

            fontFamilyStore_en: new Ext.data.ArrayStore({
                fields: ['id', 'text'],
                data: [
                    ['Arial', '<font face="arial">Arial</font>'],
                    ['Antiqua', '<font face="antiqua">Antiqua</font>'],
                    ['Calibri', '<font face="calibri">Calibri</font>'],
                    ['Comic Sans MS', '<font face="Comic Sans MS">Comic Sans MS</font>'],
                    ['Courier New', '<font face="courier">Courier New</font>'],
                    ['Garamond', '<font face="Garamond">Garamond</font>'],
                    ['Georgia', '<font face="Georgia">Georgia</font>'],
                    ['Helvetica', '<font face="helvetica">Helvetica</font>'],
                    ['Lucida Console', '<font face="Lucida Console">Lucida Console</font>'],
                    ['MS Serif', '<font face="MS Serif">MS Serif</font>'],
                    ['Monospace', '<font face="Monospace">Monospace</font>'],
                    ['Tahoma', '<font face="tahoma">Tahoma</font>'],
                    ['Times New Roman', '<font face="times">Times New Roman</font>'],
                    ['Verdana', '<font face="verdana">Verdana</font>'],
                    ['\u5B8B\u4F53', '<font face="STXihei">\u5B8B\u4F53</font>'],
                    ['\u6977\u4F53', '<font face="STSong">\u6977\u4F53</font>'],
                    ['\u4EFF\u5B8B\u4F53', '<font face="STKaiti">\u4EFF\u5B8B\u4F53</font>'],
                    ['\u65B0\u5B8B\u4F53', '<font face="STHeiti">\u65B0\u5B8B\u4F53</font>'],
                    ['\u9ED1\u4F53', '<font face="Hiragino Sans GB">\u9ED1\u4F53</font>']
                ]
            }),

            // Please contact us for add more date, time format
            english_us_moreDateTimeFm: ['M d, Y, H:i:s', 'M d, Y, H:i', 'M d, Y, g:i:s A', 'l, M d, Y, g:i:s A', 'Y/m/d H:i', 'Y/m/d H:i:s'],
            chinese_moreDateTimeFm: [
                'Y\u5E74m\u6708j\u65E5', 'y\u5E74m\u6708j\u65E5', 'm\u6708j\u65E5', 'Y\u5E74m\u6708j\u65E5 G\u70B9i\u5206', 'Y\u5E74m\u6708j\u65E5 H\u70B9i\u5206', 'Y\u5E74m\u6708j\u65E5 G\u70B9i\u5206s\u79D2',
                'M d, Y, H:i:s', 'M d, Y, H:i', 'M d, Y, g:i:s A', 'l, M d, Y, g:i:s A', 'Y/m/d H:i', 'Y/m/d H:i:s'
            ],

            // set sheet tab bar position: top OR bottom
            sheet_tab_bar_position: 'top',

            // hide or show language menu
            language_menu_hide: true,

            // disable file menu if set as false
            file_menu_hide: true,

            // disable import / export
            enableExport: false,
            enableImport: false,

            // Set the contextmenu items - here list the default list, please update the list as your needed.
            // Default are those actions:
            //        ["freeze", "split", "-", "insert", "insertCopied", "delete", "clean", "-", "hideRow", "showRow", "rowHeight", "hideColumn", "showColumn", "columnWidth", "-", "insertComment", "markRange", "insertVariable", "-", "addGroup", "cancelGroup", "hyperlink", "validate"],
            // If you want add your customized item, follow this example:
            //        {text: 'My customized item', handler: function() { alert("ok"); } }
            contextmenu_items: [
                //    {
                //    text: 'Аналитика', handler: function () {
                //        $("body").append("<div id=\"dvLoading\"></div>");
                //        $("#page-wraper").append("<div id=\"mask\"></div>");
                //        $.ajax({
                //            type: "POST",
                //            url: urlGetChart,
                //            data: choosedCell // На контроллере мы получим все id шитов, принадлежащие данному документу, а по id шитов извлечем границы
                //        }).then(function (result) {
                //            if (result == '') { return 0; }
                //            chartsResultHandler(result);
                //            choosedCell.documentId = 0;
                //            choosedCell.rowNumber = 0;
                //            choosedCell.columnNumber = 0;
                //            choosedCell.sheetNumber = 0;
                //        }).then(function () {
                //            $("#dvLoading").remove();
                //            $("#mask").remove();
                //        });


                //    }
                //},
                {
                    text: 'Подробнее',
                    handler: function() {
                        $("body").append("<div id=\"dvLoading\"></div>");
                        if (choosedCell.sheetNumber == 1)
                        {
                                $("#page-wraper").append("<div id=\"mask\"></div>");
                                $.ajax({
                                    type: "POST",
                                    url: urlGetChart,
                                    data: choosedCell // На контроллере мы получим все id шитов, принадлежащие данному документу, а по id шитов извлечем границы
                                }).then(function (result) {
                                    if (result == '') { return 0; }
                                    chartsResultHandler(result);
                                    choosedCell.documentId = 0;
                                    choosedCell.rowNumber = 0;
                                    choosedCell.columnNumber = 0;
                                    choosedCell.sheetNumber = 0;
                                }).then(function () {
                                    $("#dvLoading").remove();
                                    $("#mask").remove();
                                });

                                return 0;
                           }
                        

                        $.ajax({
                            type: "POST",
                            url: urlGetDetails, // На контроллере мы получим все id шитов, принадлежащие данному документу, а по id шитов извлечем границы
                            data: choosedCell
                        }).then(function(result) {
                            if (result == '' || result == "null") {
                                createModalWindow(empty, "Данные отсутствуют");
                                return 0;
                            }
                            var tableHtml = "<div id=\"jacket_for_table\" style=\"position: relative;\">" +
            "<div style=\"margin-top: 10%;\"><table id=\"card_table\" class=\"table table-bordered\"><tbody id=\"modal_table_body\">" +
            "</tbody></table></div></div>";



                            var sc = angular.element(document.getElementById("sv")).scope();
                            var d = JSON.parse(result);
                            createModalWindow(tableHtml, "Просмотр " + d.Name + "." + d.Extension);

                            var columns = new Array();
                            var data = new Array();

                            columns.push({ 'checkbox': true, 'field': "state" });

                            for (head_key in d.Sheets[0].Rows[0].Cells) {
                                columns.push(new Object({
                                    'title': d.Sheets[0].Rows[0].Cells[head_key].Value,
                                    'field': d.Sheets[0].Rows[0].Cells[head_key].Value,
                                    'sortable': true
                                }));
                            }

                            columns.push({
                                'title': "Тип документа",
                                'field': "Тип документа",
                                'sortable': true
                            });

                            columns.push({
                                'title': "Тип данных",
                                'field': "Тип данных",
                                'sortable': true
                            });

                            for (var i = 1; i < d.Sheets[0].Rows.length; i++) {

                                var rowNew = new Object();

                                for (var j = 0; j < d.Sheets[0].Rows[i].Cells.length; j++) {
                                    rowNew[columns[j + 1].title] = d.Sheets[0].Rows[i].Cells[j].Value;
                                }

                                rowNew["Id"] = d.Sheets[0].Rows[i].Cells[0].RowId;
                                rowNew["Тип данных"] = d.Sheets[0].Rows[i]["AnalyticDataType"];
                                rowNew["Тип документа"] = d.Sheets[0].Rows[i]["DocumentType"];

                                // Добавляем поле индекса для обновления рядов
                                rowNew["Index"] = i - 1;
                                data.push(rowNew);
                            }

                            sc.$apply(function () {

                                sc.appendSelectionSheetModal(d.CellTypes);
                            });

                                $('#card_table').bootstrapTable({
                                    data: data,
                                    striped: true,
                                    pagination: true,
                                    pageSize: 20,
                                    pageList: [10, 25, 50, 100, 200],
                                    search: true,
                                    showColumns: false,
                                    showRefresh: false,
                                    height: 500,
                                    sortable: true,
                                    minimumCountColumns: 2,
                                    columns: columns,
                                    maintainSelected: true,
                                    onCheck: function(row, $element) {
                                        if (row["X1"] != "" && row["X1"] != " ") {
                                            sc.creditSubsum = sc.creditSubsum + parseInt(row["X1"]);
                                        }
                                        if (row["X2"] != "" && row["X2"] != " ") {
                                            sc.debitSubsum = sc.debitSubsum + parseInt(row["X2"]);
                                        }
                                    },
                                    onUncheck: function(row, $element) {
                                        if (row["X1"] != "" && row["X1"] != " ") {
                                            sc.creditSubsum = sc.creditSubsum - parseInt(row["X1"]);
                                        }
                                        if (row["X2"] != "" && row["X2"] != " ") {
                                            sc.debitSubsum = sc.debitSubsum - parseInt(row["X2"]);
                                        }
                                    },
                                    onCheckAll: function(rows) {
                                        sc.creditSubsum = sc.creditSum;
                                        sc.debitSubsum = sc.debitSum;
                                    },
                                    onUncheckAll: function(rows) {
                                        sc.creditSubsum = 0;
                                        sc.debitSubsum = 0;
                                    }
                                });

                                $("div").remove("#dvLoading");
								sc.debitSum = 0;
								sc.creditSum = 0;
                                for (itemKey in data) {
                                    if (data[itemKey]["X1"] != "" && data[itemKey]["X1"] != " ") {
                                        
										sc.creditSum =sc.creditSum + parseInt(data[itemKey]["X1"]);
                                    }
                                    if (data[itemKey]["X2"] != "" && data[itemKey]["X2"] != " ") {
                                       
										sc.debitSum = sc.debitSum + parseInt(data[itemKey]["X2"]);
                                    }
                                }


                            choosedCell.documentId = 0;
                            choosedCell.rowNumber = 0;
                            choosedCell.columnNumber = 0;
                            choosedCell.sheetNumber = 0;

                        }).then(function() {
                            $("#dvLoading").remove();
                        });
                    }
                },// {text: 'My customized item',handler: function() { alert("ok"); } }, 
	                             "freeze", "split", "-", "insert", "insertCopied", "delete", "clean", "-",
                                 "hideRow", "showRow", "rowHeight", "hideColumn", "showColumn", "columnWidth", "-",
                                 "insertComment", "markRange", "insertVariable", "-", "addGroup", "cancelGroup",
                                 "hyperlink", "validate", "setHeaderTitle", "hideTitle", "showTitle"],

            // this is used for set arrow menu
            // Default are those actions:
            //     ['sortAsc', 'sortDesc', 'filter', 'columnWidth', 'rowHeight', '-', 'hide', 'delete']
            arrowmenu_items: ['config', "colTitle", "icon", "hideTitle", "showTitle", '-', 'sortAsc', 'sortDesc', 'filter', 'columnWidth', 'rowHeight', '-', 'hide', 'delete'],

            // this flag is set to see whether it is standalone version - only js code
            js_standalone: true,

            /*
             * can be one of below value, if empty or '' then means default
             * default: means paste everything from the copied cells, included data and style
             * data: only paste the data from the copied cells
             * style: only paste the style from the copied cells
             * reverse: paste the copied cells in the reverse way
             */
            DEFAULT_PASTE_TYPE: '',

            // during popup sort 
            DISABLE_SORT_CURRENT_RANGE: false,

            // this is the check whether scroll bar always show ...
            SCROLLER_ALWAYS_VISIBLE: false
        })
    },

    setupDir: function (dir) {
        Ext.apply(this, {
            baseDir: dir,

            IMAGES_PATH: dir + 'js/EnterpriseSheet/resources/images',

            ICONS_PATH: dir + 'js/EnterpriseSheet/resources/images/icons',

            TITLE_ICONS_PATH: dir + 'js/EnterpriseSheet/resources/images/icons/title',

            CONDITION_ICONS_PATH: dir + 'js/EnterpriseSheet/resources/images/icons/conditional_icons',

            urls: {
                'list': dir + 'document/list',
                'changeFileName': dir + 'document/changeFileName',
                'changeFileStared': dir + 'document/changeFileStared',
                'createFile': dir + 'document/createFile',
                'updateLang': dir + 'userSetting/updateLang',

                'findCells': dir + 'sheet/findCells',
                'loadCells': dir + 'sheet/loadCells',
                'loadSheet': dir + 'sheet/loadSheet',
                'loadSheetInfo': dir + 'sheet/loadSheetInfo',
                'loadActivedSheetOfFile': dir + 'sheet/loadActivedSheetOfFile',
                'loadSheetsOfFile': dir + 'sheet/loadSheetsOfFile',
                'loadCellOnDemand': dir + 'sheet/loadCellOnDemand',
                'loadElementOnDemand': dir + 'sheet/loadElementOnDemand',
                'loadCalCellOnDemand': dir + 'sheet/loadCalCellOnDemand',
                'loadFile': dir + 'sheet/loadFile',
                'copyFromTpl': dir + 'sheet/copyFromTpl',
                'importExcelUpload': dir + 'sheet/uploadFile',
                'exportExcel': dir + 'sheet/export',
                'uploadImage': dir + 'sheet/uploadImage',

                'update': dir + 'sheetCell/updateBatchCells',
                'createSheet': dir + 'sheetTab/create',
                'renameSheet': dir + 'sheetTab/renameSheet',
                'changeSheetColor': dir + 'sheetTab/changeSheetColor',
                'deleteSheet': dir + 'sheetTab/deleteSheet',
                'copySheet': dir + 'sheetTab/copySheet',
                'changeSheetOrder': dir + 'sheetTab/changeSheetOrder',
                'updateSheetTab': dir + 'sheetTab/update',

                'listCustom': dir + 'sheetCustom/list',
                'addCustom': dir + 'sheetCustom/create',
                'deleteCustom': dir + 'sheetCustom/delete',
                'listDataset': dir + 'sheetDropdown/list',
                'createDataset': dir + 'sheetDropdown/createUpdate',
                'loadDataset': dir + 'sheetDropdown/load',
                'deleteDataset': dir + 'sheetDropdown/delete',
                'saveJsonFile': dir + 'sheetapi/saveJsonFile',
                'saveFileAs': dir + 'sheet/saveFileAs',
                'createServerErrorReport': dir + 'forumPosting/createServerErrorReport',
                'uploadFile': dir + 'sheetAttach/uploadFile',
                'downloadFile': dir + 'sheetAttach/downloadFile',
                'deleteAttach': dir + 'sheetAttach/deleteFile',
                'loadRangeStyle': dir + 'sheet/loadRangeStyle'
            },
            BLANK_PHOTO: dir + 'js/EnterpriseSheet/resources/images/photo_.png',
            ATTACH_ICON16: dir + 'js/EnterpriseSheet/resources/images/icons/attach1.png',
            ATTACH_ICON32: dir + 'js/EnterpriseSheet/resources/images/icons/32px/attach.png'
        });
    }
}, function () {
    SCONFIG = EnterpriseSheet.Config;
});