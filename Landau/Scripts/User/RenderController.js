var renderController = usersApp.controller("renderController", function doit($scope, $compile) {

    $scope.creditSum = 0;
    $scope.debitSum = 0;
    $scope.creditSubsum = 0;
    $scope.debitSubsum = 0;
    $scope.selectedRows = new Array();
    $scope.isDocRow = false;
    $scope.changes = new Array();
    $scope.getElement = function (id) {
        $scope.el = Ext.get(id);
    }
    $scope.getSign = function (id) {
        if (id == "docRow") {
            $scope.isDocRow = true;
        }
    }

    $scope.showModal = function (currId) {

        $scope.Doc = undefined;
        $.ajax({
            type: "POST",
            url: urlGetDocument,
            data: { 'id': currId }
        }).then(function (result) {
            if (result == "") { createModalWindow(empty, "Данные отсутствуют"); return 0; }

            $scope.Doc = JSON.parse(result);

            createModalWindow("<div id=\"sheet-markup\" style=\"position: absolute; width: 100%; height:100%;\"></div>", "Test");
            for (index in $scope.Doc.cells) {
                if ($scope.Doc.cells[index].row == 0 && $scope.Doc.cells[index].json.fz !== undefined &&
                    $scope.Doc.cells[index].json.height !== undefined && $scope.Doc.cells[index].json.cal) {
                    delete $scope.Doc.cells[index].json.fz;
                    delete $scope.Doc.cells[index].json.height;
                    delete $scope.Doc.cells[index].json.cal;
                }
            }
            ///$scope.Doc = JSON.parse(JSON.parse(JSON.stringify(result)));
        }).then(function () {
            $.ajax({
                type: "POST",
                url: urlGetBorders,
                data: { 'id': currId } // На контроллере мы получим все id шитов, принадлежащие данному документу, а по id шитов извлечем границы
            }).then(function (result) {
                $scope.Borders = result;
                $scope.ParsedBorders = JSON.parse(result);
            }).then(function () {
                $scope.render();
                SHEET_API.loadData(SHEET_API_HD, $scope.Doc/*, function () {
                                for (var i = 0; i < $scope.ParsedBorders.length; i++) {
                                    var singleBorderStr = JSON.stringify($scope.ParsedBorders[i]);
                                    var ranges = singleBorderStr.match(/(\[\[\d+\,\d+\,\d+\,\d+\,\d+\]\])/);
                                    var range = JSON.parse(ranges[0]);

                                    var singleBorderWithoutRange = singleBorderStr.replace(/(\,\"range":\{\"Range\":\[\[\d+\,\d+\,\d+\,\d+\,\d+\]\]\})/, "");
                                    singleBorderWithoutRange = JSON.parse(singleBorderWithoutRange);
                                    SHEET_API.applyCellsBorder(SHEET_API_HD, range, singleBorderWithoutRange);
                                }
                            }*/);
            });
        });
        //SHEET_API.loadData({});
    }

    $scope.showXlsModal = function (currId) {


        var tableHtml = "<div id=\"jacket_for_table\">" +
            "<table id=\"card_table\" class=\"table table-bordered\"><tbody id=\"modal_table_body\">" +
            "</tbody></table></div>";


        $("body").append("<div id=\"dvLoading\"></div>");

        $scope.Doc = undefined;
        $.ajax({
            type: "POST",
            url: urlGetModalXls,
            data: { 'documentId': currId }
        }).then(function (result) {

            if (result == "") { createModalWindow(empty, "Данные отсутствуют"); return 0; }
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

            for (var i = 1; i < d.Sheets[0].Rows.length; i++) {

                var rowNew = new Object();

                for (var j = 0; j < d.Sheets[0].Rows[i].Cells.length; j++) {
                    rowNew[columns[j + 1].title] = d.Sheets[0].Rows[i].Cells[j].Value;
                }

                rowNew["Id"] = d.Sheets[0].Rows[i].Cells[0].RowId;

                // Добавляем поле индекса для обновления рядов
                rowNew["Index"] = i - 1;
                data.push(rowNew);
            }

            if ($('#card_table') == null) {
                $('#card_table').bootstrapTable({
                    data: data,
                    striped: true,
                    pagination: true,
                    pageSize: 20,
                    pageList: [10, 25, 50, 100, 200],
                    search: true,
                    height: 500,
                    showColumns: false,
                    showRefresh: false,
                    sortable: true,
                    minimumCountColumns: 2,
                    columns: columns,
                    onCheck: function (row, $element) {
                        if (row["X1"] != "" && row["X1"] != " ") {
                            $scope.creditSubsum = $scope.creditSubsum + parseInt(row["X1"]);
                        }
                        if (row["X2"] != "" && row["X2"] != " ") {
                            $scope.debitSubsum = $scope.debitSubsum + parseInt(row["X2"]);
                        }
                    },
                    onUncheck: function (row, $element) {
                        if (row["X1"] != "" && row["X1"] != " ") {
                            $scope.creditSubsum = $scope.creditSubsum - parseInt(row["X1"]);
                        }
                        if (row["X2"] != "" && row["X2"] != " ") {
                            $scope.debitSubsum = $scope.debitSubsum - parseInt(row["X2"]);
                        }
                    },
                    onCheckAll: function (rows) {
                        $scope.creditSubsum = $scope.creditSum;
                        $scope.debitSubsum = $scope.debitSum;
                    },
                    onUncheckAll: function (rows) {
                        $scope.creditSubsum = 0;
                        $scope.debitSubsum = 0;
                    }
                });
            }
            

            $("div").remove("#dvLoading");

            $scope.appendSelectionSheetModal(d.CellTypes);



        });

       
    }
    $scope.appendSelectionSheetModal = function (cTypes) {
        var selectionString = "<div class=\"row\" style=\"width: 78%; position: fixed;" +
             " background-color: white; z-index: 5000; padding: 5px; margin-top: -90px;" +
             "margin-left: -1px;\"><div class=\"col-md-6\">" +

             "<select name=\"singleSelect\" class=\"form-control\" ng-model=\"selectedCellType\">";

        for (type in cTypes) {
            selectionString = selectionString + "<option value=\"" + cTypes[type].Id + "\">" + cTypes[type].Title + "</option>";
        }

        selectionString = selectionString + "</select><button type=\"button\" class=\"btn btn-default\" " +
            "id=\"btn_move_checked\">Перенести</button></div><div class=\"col-md-6\">";
        selectionString = selectionString + "<div>Сумма по кредиту: {{creditSum}}</div>" +
            "<div>Сумма по дебету: {{debitSum}}</div>" +
            "<div>Сумма по кредиту (выделенное): {{creditSubsum}}</div>" +
            "<div>Сумма по дебету (выделенное): {{debitSubsum}}</div>" +
            "</div>";

        var select = $compile(selectionString)($scope);

        var ss = $("#jacket_for_table");

        $("#jacket_for_table").prepend(select);

        $('#btn_move_checked').click(function () {

            // получаем все помеченные ряды
            var checkedRows = $('#card_table').bootstrapTable('getSelections');

            // получаем тип документа, на который мы хотим заменить 
            // тип документа помеченных рядов
            var documentTypeObject = cTypes.filter(function(obj) {
                return obj.Id == parseInt($scope.selectedCellType);
            });



            // изменяем тип документа в помеченных рядах и 
            // обновляем таблицу
            for (checked in checkedRows) {
                checkedRows[checked]["Тип данных"] = documentTypeObject[0].Title;
                $('#card_table').bootstrapTable('updateRow', { index: checkedRows[checked]["Index"], row: checkedRows[checked] });
            }

            // создаем массив объектов, 
            // содержащий информацию об ID и измененном значении ячейки
            var changes = new Array();
            for (rowItem in checkedRows) {
                changes.push(new Object({ 'Id': checkedRows[rowItem]["Id"], 'Value': $scope.selectedCellType }));
            }

            // отправляем 
            $.ajax({
                type: "POST",
                url: urlUpdateSource,
                data: {
                    'changes': JSON.stringify(changes)
                }
            });
            $('#card_table').bootstrapTable('uncheckAll');
        });
    }

    $scope.render = function () {

        SCONFIG.setupDir('');

        while (true) {
            SHEET_API = Ext.create('EnterpriseSheet.api.SheetAPI', {
                openFileByOnlyLoadDataFlag: true
            });

            if (SHEET_API != 'undefined') { break; }
        }
        while (true) {
            SHEET_API_HD = SHEET_API.createSheetApp({
                //withoutSidebar: true,
                renderTo: 'sheet-markup',
                style: 'background:white;border-left:1px solid silver;',
                height: '93%'
            });

            if (SHEET_API_HD != 'undefined') { break; }

        }

        document.documentElement.style.background = 'none';
        Ext.getBody().setStyle('background-image', 'none');


        var sheet = SHEET_API_HD.sheet;
        sheet.on({
            scope: this,
            'switchsheet': function (oldSheetId, sheetId) {
                console.log("sheet switched");

            }
        });

        $scope.evBlock = false;
        var storeStyle = SHEET_API_HD.store;
        storeStyle.on({
            scope: this,
            'aftercellchange': function (modified, deleted, origin, current, store, sheetId, row, col) {

                if (current.config === undefined && current.autoHeight === undefined && !$scope.evBlock) {

                    var js = SHEET_API.getJsonData(SHEET_API_HD);

                    for (sheetItem in js.sheets) {
                        if (js.sheets[sheetItem].id == sheetId) {
                            var sheetName = js.sheets[sheetItem].name;
                        }
                    }

                    $scope.changes.push(new Object({ "current": current, "sheetId": sheetId, "sheetName": sheetName, "row": row, "col": col }));
                }
            }
        });
    };

    setInterval(function () {
        if ($scope.Doc !== undefined && $scope.Doc != null) {
            (function () {
                $.ajax({
                    type: "POST",
                    url: "/Cabinet/Cabinet",
                    data: { 'docId': currentDocId, 'version': $scope.Doc.version, 'changes': JSON.stringify($scope.changes) }
                }).then(function (result) {
                    if (result != "uptodate" && result != "" && result != "fail") {
                        // После принятия изменений - обновляем версию документа
                        if (!isNaN(result)) { $scope.Doc.version = result; $scope.changes = []; return 0; }
                        $scope.changes = [];
                        $scope.evBlock = true;
                        $scope.Doc = JSON.parse(result);

                        for (index in $scope.Doc.cells) {
                            if ($scope.Doc.cells[index].row == 0 && $scope.Doc.cells[index].json.fz !== undefined &&
                                $scope.Doc.cells[index].json.height !== undefined && $scope.Doc.cells[index].json.cal !== undefined) {
                                delete $scope.Doc.cells[index].json.fz;
                                delete $scope.Doc.cells[index].json.height;
                                delete $scope.Doc.cells[index].json.cal;
                            }
                        }

                        SHEET_API.updateCells(SHEET_API_HD, $scope.Doc.cells);
                        setTimeout(function () { $scope.evBlock = false; }, 500);
                    }
                })
            })();
        }
    }, 10000);

    Ext.onReady(function () {
        var el = Ext.get('piece');
        var iter = 0;

        el.on('click', function (e, target, options) {
            $("#sv").append("<div id=\"dvLoading\"></div>");

            $scope.Doc = 'undefined';
            currentDocId = $scope.Id;
            if ($scope.isDocRow) {
                $.ajax({
                    type: "POST",
                    url: urlGetDocument,
                    data: { 'id': $scope.Id }
                }).then(function (result) {
                    $scope.Doc = JSON.parse(result);
                    for (index in $scope.Doc.cells) {
                        if ($scope.Doc.cells[index].row == 0 && $scope.Doc.cells[index].json.fz !== undefined &&
                            $scope.Doc.cells[index].json.height !== undefined && $scope.Doc.cells[index].json.cal !== undefined) {
                            delete $scope.Doc.cells[index].json.fz;
                            delete $scope.Doc.cells[index].json.height;
                            delete $scope.Doc.cells[index].json.cal;
                        }
                    }

                }).then(function () {
                    $.ajax({
                        type: "POST",
                        url: urlGetBorders,
                        data: { 'id': $scope.Id } // На контроллере мы получим все id шитов, принадлежащие данному документу, а по id шитов извлечем границы
                    }).then(function (result) {
                        $scope.Borders = result;
                        $scope.ParsedBorders = JSON.parse(result);
                    }).then(function () {
                        if (iter == 1) {
                            $scope.render();
                            $scope.evBlock = true;
                            $.when(SHEET_API.loadData(SHEET_API_HD, $scope.Doc, function () {
                                for (var i = 0; i < $scope.ParsedBorders.length; i++) {
                                    var singleBorderStr = JSON.stringify($scope.ParsedBorders[i]);
                                    var ranges = singleBorderStr.match(/(\[\[\d+\,\d+\,\d+\,\d+\,\d+\]\])/);
                                    var range = JSON.parse(ranges[0]);

                                    var singleBorderWithoutRange = singleBorderStr.replace(/(\,\"range":\{\"Range\":\[\[\d+\,\d+\,\d+\,\d+\,\d+\]\]\})/, "");
                                    singleBorderWithoutRange = JSON.parse(singleBorderWithoutRange);
                                    SHEET_API.applyCellsBorder(SHEET_API_HD, range, singleBorderWithoutRange);
                                }
                            })).done(function () { $scope.evBlock = false; });

                            $("div").remove("#dvLoading");
                        }
                        else {
                            $scope.render();
                            $scope.evBlock = true;
                            $.when(SHEET_API.loadData(SHEET_API_HD, $scope.Doc, function () {
                                for (var i = 0; i < $scope.ParsedBorders.length; i++) {
                                    var singleBorderStr = JSON.stringify($scope.ParsedBorders[i]);
                                    var ranges = singleBorderStr.match(/(\[\[\d+\,\d+\,\d+\,\d+\,\d+\]\])/);
                                    var range = JSON.parse(ranges[0]);
                                    var singleBorderWithoutRange = singleBorderStr.replace(/(\,\"range":\{\"Range\":\[\[\d+\,\d+\,\d+\,\d+\,\d+\]\]\})/, "");
                                    singleBorderWithoutRange = JSON.parse(singleBorderWithoutRange);
                                    SHEET_API.applyCellsBorder(SHEET_API_HD, range, singleBorderWithoutRange);
                                }
                            })).done(function () { $scope.evBlock = false; });
                            $("div").remove("#dvLoading");
                        }
                    });
                    iter = iter + 1;
                    console.log(iter);
                });
            }
        }, this, {
            delegate: '#clikableCell'
        });
    });

});