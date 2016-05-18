/// <reference path="../../Views/Partial/DocumentsTable.cshtml" />

function UploadProgress(evt) {
    if (evt.lengthComputable) {
        var percentComplete = Math.round(evt.loaded * 100 / evt.total);
        $("#uploading").text("Загрузка файлов" + " " + percentComplete + "% ");

    }
}

function UploadFailed(evt) {
    alert("There was an error attempting to upload the file.");
}

function UploadCanceled(evt) {
    alert("The upload has been canceled by the user or the browser dropped the connection.");
}


usersApp.controller("FileCtr", function ($scope, $http, $interval, $rootScope, contactFactory, $compile) {
    $scope.creditSum = 0;
    $scope.debitSum = 0;
    $scope.creditSubsum = 0;
    $scope.debitSubsum = 0;
    $scope.projectId = 0;
    $scope.tableData = new Array();
    $scope.readyFlag = false;
    
    $scope.zakup = function (id) {
        var zakupArray = new Array();
        $.ajax({
            type: "POST",
            url: "/Documents/Zakup",
            data: { 'id': id }
        }).then(function (result) {

            if (result == "") { createModalWindow(empty, "Даннные отсутствуют"); return 0; };

            zakupArray = JSON.parse(result);

            var tableHtml = "<div id=\"jacket_for_table\"><button type=\"button\" class=\"btn btn-default\" " +
            "id=\"btn_move_checked\">Перенести</button><table id=\"card_table\" class=\"table table-bordered\"><tbody id=\"modal_table_body\" style=\"overflow-y: scroll;\">" +
           "</tbody></table></div>"

            createModalWindow(tableHtml, "Просмотр");

            var columns = new Array();
            var data = new Array();

            columns.push({ 'checkbox': true, 'field': "state" });
            columns.push({ 'field': "Name", 'title': "Аналитика Дт" });
           

            for (var i = 0; i < zakupArray.length; i++) {

                var rowNew = new Object();

                // zakupArray[i].Value = zakupArray[i].Value.slice(0, zakupArray[i].Value.indexOf('\n'));

                rowNew["Name"] = zakupArray[i].Value;

                rowNew["Id"] = zakupArray[i].Id;

                // Добавляем поле индекса для обновления рядов
                rowNew["Index"] = i;

                data.push(rowNew);
            }

            var $table = $('#card_table');

            $('#card_table').bootstrapTable({
                data: data,
                striped: true,
                pagination: true,
                pageSize: 20,
                pageList: [10, 25, 50, 100, 200],
                search: true,
                showColumns: true,
                showRefresh: false,
                sortable: true,
                minimumCountColumns: 2,
                columns: columns
            });

            $("div").remove("#dvLoading");

            $('#btn_move_checked').click(function () {
                // получаем все помеченные ряды
                var changes = $table.bootstrapTable('getSelections');
                //alert(JSON.stringify(checkedRows));
                // отправляем 
                $.ajax({
                    type: "POST",
                    url: urlMakePurchase,
                    data: {
                        'changes': JSON.stringify(changes)
                    }
                });
                $table.bootstrapTable('uncheckAll');
                $table.bootstrapTable('resetView');
            });
        });


    }

    $scope.downloadFile = function (id) {

        window.open(urlDownload + "/?id=" + id, '_self');
        ////var downloadDiv = document.createElement("iframe");
        ////downloadDiv.style.height = 0;
        ////downloadDiv.style.width = 0;
        ////downloadDiv.setAttribute("src", urlDownload + "/?id=" + id);

        ////$('body').append(downloadDiv);

        //////$.ajax({
        //////    type: "POST",
        //////    url: urlDownload,
        //////    data: { 'id': id },
        //////    success: function (data) {
        //////        console.log(data);
        //////    }
        //////})
    }

    function uploadComplete(fileInput, idList) {
        $scope.checktable = true;

        for (i = 0; i < fileInput.files.length; i++) {
            $scope.Files.push({
                FileName: fileInput.files[i].name,
                State: "загружен"
            });
        }
        console.log(idList);
        $scope.Contact = [];
        contactFactory.GetDocuments().then(function (d) {
            $scope.Contact = d.data;


        });

    }

    function pageiantion() {

        $scope.currentPage = 0;

        $scope.range = function () {

            var rangeSize = Math.ceil($scope.filteredContact.length / $scope.itemsPerPage);
            var ret = [];
            var start;
            start = $scope.currentPage;

            if (start > $scope.pageCount() - rangeSize) {
                start = $scope.pageCount() - rangeSize + 1;

            }

            for (var i = start; i < start + rangeSize; i++) {

                ret.push(i);
            }
            return ret;
        };
        $scope.pageCount = function () {

            return Math.ceil($scope.filteredContact.length / $scope.itemsPerPage) - 1;
        };

        $scope.prevPage = function () {
            if ($scope.currentPage > 0) {
                $scope.currentPage--;
            }
        };

        $scope.prevPageDisabled = function () {
            return $scope.currentPage === 0 ? "disabled" : "";
        };


        $scope.nextPage = function () {
            if ($scope.currentPage < $scope.pageCount()) {
                $scope.currentPage++;
            }
        };

        $scope.nextPageDisabled = function () {
            return $scope.currentPage === $scope.pageCount() ? "disabled" : "";
        };

        $scope.setPage = function (n) {
            $scope.currentPage = n;
        };
    }


    $scope.$watch("query", function () {

        $scope.currentPage = 0;
    });
    $scope.$watch("selectedformat", function () {

        $scope.currentPage = 0;
    });



    function loadFile(formdata, fileInput) {
        console.log("Form");
        var xhr = new XMLHttpRequest();
        xhr.upload.addEventListener("progress", function (evt) { UploadProgress(evt); }, false);
        xhr.addEventListener("load", function (idList) { uploadComplete(fileInput, idList); }, false);
        xhr.addEventListener("error", function (evt) { UploadFailed(evt); }, false);
        xhr.addEventListener("abort", function (evt) { UploadCanceled(evt); }, false);
        xhr.open("POST", "Documents/Upload");
        xhr.send(formdata);
        $scope.showLink = false;

        $scope.descriptioncheck = false;
        return false;
    }


    $scope.LoadFileData = function () {

        if ($scope.descriptioncheck === true) {

            if ($scope.value.$invalid) {

                $scope.submitted = true;

            } else {


                var formdata = new FormData(); //FormData object
                var fileInput = document.getElementById("etlfileToUpload");
                $scope.Files = [];
                for (i = 0; i < fileInput.files.length; i++) {

                    console.log(fileInput.files.length);
                    formdata.append("files", fileInput.files[i]);
                    formdata.append("description", $scope.Description);


                }

                loadFile(formdata, fileInput);

            }
        } else {

            var formdatanew = new FormData(); //FormData object
            var fileInputnew = document.getElementById("etlfileToUpload");
            $scope.Files = [];
            for (i = 0; i < fileInputnew.files.length; i++) {

                console.log(fileInputnew.files.length);
                formdatanew.append("files", fileInputnew.files[i]);
                formdatanew.append("description", '');


            }
            loadFile(formdatanew, fileInputnew);
        }


    };

    $scope.confirm = function () {
        $http.get("Documents/WaitConfirm").success(function (data) {
            $scope.Files = [];
            $scope.Files = data;
            $rootScope.$emit("CallOrderForUser", {});
        });

        setTimeout(function () {
            var b = angular.element(document.getElementsByTagName("BODY")[0]).scope();
            b.$apply(function () {
                b.switchPartials(0);
            });
        }, 150);
    }

    function parseToBootstrapTableData() {

        var columns = new Array();
        var tableData = new Array();

        columns.push({ 'field': "Id", 'title': "Id" });
        columns.push({ 'field': "Название документа", 'title': "Название документа" });
        columns.push({ 'field': "Размер", 'title': "Размер" });
        columns.push({ 'field': "Пользователь", 'title': "Пользователь" });
        columns.push({ 'field': "Время загрузки", 'title': "Время загрузки" });
        columns.push({ 'field': "Описание", 'title': "Описание" });
        columns.push({ 'field': "Действие", 'title': "Действие" });

        var dropdownElementString = "<div data-toggle=\"dropdown\" class=\"dropdown-toggle col-md-4\">" +
            "<button style=\"background-color: #e7e7e7;\" class=\"btn btn-default\" " +
            "dropdown-toggle\" type=\"button\" id=\"dropdownMenu1\" data-toggle=\"dropdown\" " +
            "aria-haspopup=\"true\" aria-expanded=\"true\">" +
            "<span class=\"glyphicon glyphicon-align-justify\" />" +
            "</button>" +
            "<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenu1\">" +
            "<li>" +
            "<a ng-click=\"switchPartials(10);\" href=\"\"><i class=\"glyphicon glyphicon-arrow-left\"></i>Заменить</a>" +
            "</li>" +
            "</ul>" +
            "</div>";

        for (var i = 0; i < $scope.Contact.length; i++) {

            var objDataNew = new Object();

            for (key in columns) {
                switch (columns[key].field) {
                    case "Id": objDataNew[columns[key].field] = $scope.Contact[i].Id;
                        break;
                    case "Название документа": objDataNew[columns[key].field] = $scope.Contact[i].FileName;
                        break;
                    case "Размер": objDataNew[columns[key].field] = $scope.Contact[i].FileSize;
                        break;
                    case "Пользователь": objDataNew[columns[key].field] = $scope.Contact[i].User;
                        break;
                    case "Время загрузки": objDataNew[columns[key].field] = $scope.Contact[i].DataUpload;
                        break;
                    case "Описание": objDataNew[columns[key].field] = $scope.Contact[i].Description;
                        break;
                    case "Действие":
                        objDataNew[columns[key].field] = dropdownElementString;
                        break;
                }
            }

            objDataNew["DocumentTypeInt"] = $scope.Contact[i].DocumentTypeInt;
            

            tableData.push(objDataNew);
        }

        return { 'columns': columns, 'data': tableData };
    }

    function refreshTable(tableData) {
        $("#documents_list_table").bootstrapTable('refresh', tableData);
    }

    $scope.getListOfDocsById = function (id) {
        $scope.showdvLoading = true;
        $scope.tableData = null;
        $scope.projectId = parseInt(id);
        $scope.Contact = [];
        contactFactory.GetDocuments(id).then(function (d) {
            $scope.Contact = d.data;
            $scope.showdvLoading = false;

            $scope.tableData = parseToBootstrapTableData();
            $scope.readyFlag = true;
            //$scope.ststOfDocs($scope.tableData.columns, $scope.tableData.data);
        });
        $scope.TypeDocument = [];
        contactFactory.GetTypeDocument().then(function (d) {
            $scope.TypeDocument = d.data;
        });

        setInterval(function () {
            var i = $("#documents_list_table").children().length
            if ((i == 0 || i == 2) && $scope.tableData != null) {
                setTimeout(function () {
                    $scope.showListOfDocs();
                }, 50);
            }
        }, 100)

        $scope.Order = [];

        contactFactory.GetOrders(id).then(function (d) {
            console.log(d.data);
            $scope.Order = d.data;
            //    $scope.showdvLoading = false;


        });

    }

    setInterval(function () {
        if ($scope.projectId != 0) {
            contactFactory.GetDocuments($scope.projectId).then(function (d) {
                $scope.Contact = d.data;
                var tableData = parseToBootstrapTableData();
                refreshTable(tableData.data);
            });
            return 0;
        }
        else { return 0; }
    }, 10000)


    $scope.showDescription = function () {

        var fileInput = document.getElementById("etlfileToUpload");

        if (fileInput.files.length > 0) {
            $scope.showLink = true;
            $scope.Description = [];
        } else {
            $scope.showLink = false;
        }


    };
    pageiantion();

    $scope.sortField = undefined;
    $scope.reverse = false;
    $scope.sort = function (fieldName) {

        if ($scope.sortField === fieldName) {

            $scope.reverse = !$scope.reverse;

        } else {

            $scope.sortField = fieldName;
            $scope.reverse = false;
        }
    };
    $scope.isSortUp = function (fieldName) {
        return $scope.sortField === fieldName && !$scope.reverse;
    };
    $scope.isSortDown = function (fieldName) {
        return $scope.sortField === fieldName && $scope.reverse;
    };

    $scope.showXlsModal = function (currId) {


        var tableHtml = "<div id=\"jacket_for_table\" style=\"position: relative;\">" +
            "<div style=\"margin-top: 10%;\"><table id=\"card_table\" class=\"table table-bordered\"><tbody id=\"modal_table_body\">" +
            "</tbody></table></div></div>";


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
                if (head_key == "5") {
                    columns.push(new Object({
                        'title': "X1",
                        'field': "X1",
                        'sortable': true
                    }));
                } else {
                    if (head_key == "7") {
                        columns.push(new Object({
                            'title': "X2",
                            'field': "X2",
                            'sortable': true
                        }));
                    } else {
                        columns.push(new Object({
                            'title': d.Sheets[0].Rows[0].Cells[head_key].Value,
                            'field': d.Sheets[0].Rows[0].Cells[head_key].Value,
                            'sortable': true
                        }));
                    }
                }
                
                
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

                $('#card_table').bootstrapTable({
                    data: data,
                    striped: true,
                    pagination: true,
                    pageSize: 20,
                    pageList: [10, 25, 50, 100, 200],
                    search: true,
                    showColumns: false,
                    showRefresh: false,
                    sortable: true,
                    minimumCountColumns: 2,
                    columns: columns,
                    maintainSelected: true,
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

            $("div").remove("#dvLoading");

            $scope.appendSelectionDocumentModal(d.CellTypes);
            $scope.creditSum = 0;

            for (itemKey in data) {
                if (data[itemKey]["X1"] != "" && data[itemKey]["X1"] != " ") {
                    $scope.creditSum = $scope.creditSum + parseInt(data[itemKey]["X1"]);
                }
                if (data[itemKey]["X2"] != "" && data[itemKey]["X2"] != " ") {
                    $scope.debitSum = $scope.debitSum + parseInt(data[itemKey]["X2"]);
                }
            }



        });
    }

    $scope.showListOfDocs = function () {
        $("#documents_list_table").bootstrapTable({
            data: $scope.tableData.data,
            striped: true,
            pagination: true,
            pageSize: 10,
            pageList: [10, 25, 50, 100, 200],
            search: true,
            showColumns: false,
            showRefresh: false,
            sortable: true,
            minimumCountColumns: 2,
            columns: $scope.tableData.columns,
            onClickRow: function (row, $element) {
                if ($element.context.cellIndex != 6)
                $scope.showXlsModal(row.Id);
            }
        });
    }

    $scope.getListOfDocsBIdForUser = function (id) {
        $scope.showdvLoading = true;
        $scope.Docs = [];
        contactFactory.GetDocuments(id).then(function (d) {
            $scope.Docs = d.data;
            $scope.showdvLoading = false;
        });

        

        $scope.TypeDocument = [];
        contactFactory.GetTypeDocument().then(function (d) {
            $scope.TypeDocument = d.data;
            console.log("type");
        });

    }

   
    $scope.appendSelectionDocumentModal = function (cTypes) {
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
            var documentTypeObject = cTypes.filter(function (obj) {
                return obj.Id == parseInt($scope.selectedCellType);
            })



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
            })
            $('#card_table').bootstrapTable('uncheckAll');
        });
    }


});
usersApp.filter("offset", function () {
    return function (input, start) {

        return input.slice(start);
    };
});
usersApp.factory("contactFactory", function ($http) {
    var fac = {};


    fac.GetDocuments = function (id) {

        return $http(
        {
            url: "Documents/GetDocuments?id=" + id,
            method: "GET"
        });
    };
    fac.GetTypeDocument = function () {
        return $http(
        {
            url: "Documents/GetDocumentType",
            method: "GET"

        });
    };
    fac.GetOrders = function (id) {
        return $http(
        {
            url: "Documents/GetOrders?id=" + id,
            headers: {
                'Content-Type': 'json'
            },
            method: "GET"

        });
    }

    return fac;
});
