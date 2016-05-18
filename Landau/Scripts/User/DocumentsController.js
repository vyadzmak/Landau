usersApp.controller("docsController", function ($scope, $http, $rootScope, $compile) {

    function pageiantion() {

        $scope.currentPage = 0;
        $scope.tableData = new Array();
        $scope.readyFlag = false;
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



    $scope.showOpen = false;
    $scope.isRowClicked = {
        clicked: false
    };
    $scope.getDocList = function () {
        $http({
            method: "GET"
        }).success(function (list) {
            url: urlGetDocumentsList,
                $scope.DocumentsList = JSON.parse(JSON.stringify(list));
        }
        );
    };


    $rootScope.$on("CallOrderForUser", function () {

        $scope.getOrdersList();
    });

    function refreshTable(tableData) {
        $("#orders_list_table").bootstrapTable('load', tableData);

        for (key in tableData) {
            $("#order_operation_dropdown" + key).html($compile("<li><a ng-click=\"removeProject(" +
                tableData[key]["Номер заявки"] + ")\">Удалить</a></li><li><a>Переименовать</a></li>" +
                "<li><a>Добавить файл</a></li>")($scope));
        }
    }

    $scope.showListOfDocs = function (columns, data) {
        $("#orders_list_table").bootstrapTable({
            data: data,
            striped: true,
            pagination: true,
            pageSize: 10,
            pageList: [10, 25, 50, 100, 200],
            search: true,
            showColumns: false,
            showRefresh: false,
            sortable: true,
            minimumCountColumns: 2,
            columns: columns,
            onClickRow: function (row, $element) {

                if ($element.context.cellIndex != 5) {
                    var b = angular.element(document.getElementsByTagName("BODY")[0]).scope();
                    b.$apply(function () {
                        b.switchModes(3);
                    });

                    var cc = angular.element(document.getElementById("content_cover")).scope();
                    cc.$apply(function () {
                        cc.getListOfDocsById(row["Номер заявки"]);
                    });
                }

            }
        });

        for (key in data) {
            $("#order_operation_dropdown" + key).html($compile("<li><a ng-click=\"removeProject(" +
                data[key]["Номер заявки"] + ")\">Удалить</a></li><li><a>Переименовать</a></li>")($scope));
        }

        $("#orders_list_table").append("<div style=\"width: 100px; height: 100px\"></div>");
    }


    $scope.removeProject = function (id) {
        $http({
            url: urlRemoveProject,
            method: "POST",
            data: { 'id': id }
        });
    }

    function parseToBootstrapTableData() {

        var columns = new Array();
        var tableData = new Array();

        columns.push({ 'field': "#", 'title': "#" });
        columns.push({ 'field': "Номер заявки", 'title': "Номер заявки" });
        columns.push({ 'field': "Компания", 'title': "Компания" });
        columns.push({ 'field': "Название проекта", 'title': "Название проекта" });
        columns.push({ 'field': "Статус", 'title': "Статус" });
        columns.push({ 'field': "Действие", 'title': "Действие", 'data-switchable': false });

        for (var i = 0; i < $scope.OrdersList.length; i++) {

            var objDataNew = new Object();

            for (key in columns) {
                switch (columns[key].field) {
                    case "Номер заявки": objDataNew[columns[key].field] = $scope.OrdersList[i].Id;
                        break;
                    case "Компания": objDataNew[columns[key].field] = $scope.OrdersList[i].Name;
                        break;
                    case "Статус": objDataNew[columns[key].field] = $scope.OrdersList[i].State;
                        break;
                    case "Название проекта": objDataNew[columns[key].field] = $scope.OrdersList[i].ProjectName;
                        break;
                }
            }

            objDataNew["Действие"] = "<div class=\"dropdown\">" +
                                    "<button class=\"btn btn-default dropdown-toggle\" type=\"button\" id=\"dropdownMenu1\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"true\">" +
                                        "<span class=\"glyphicon glyphicon-align-justify\"/>" +
                                    "</button>" +
                                    "<ul id=\"order_operation_dropdown" + i + "\" class=\"dropdown-menu\" aria-labelledby=\"dropdownMenu1\">" +
                                       
                                    "</ul>" +
                                "</div>";
            objDataNew["#"] = i + 1;
            tableData.push(objDataNew);
        }

        return { 'columns': columns, 'data': tableData };
    }

    $scope.getOrdersList = function () {
        $http({
            url: urlGetOrdersList,
            method: "GET"
        }).success(function (list) {
            $scope.OrdersList = list;
            $scope.tableData = parseToBootstrapTableData();
            $scope.readyFlag = true;
            $scope.showListOfDocs($scope.tableData.columns, $scope.tableData.data)
            $('#dvLoading').hide();
        });
    };

    setInterval(function () {
        if ($("#orders_list_table").children().length == 0 && $scope.readyFlag) {
            setTimeout(function () {
                $scope.showListOfDocs($scope.tableData.columns, $scope.tableData.data);
            }, 50);
        }

    }, 100)

    angular.element(document).ready(function () {
        $scope.getDocList();

        $scope.getOrdersList();
    });
    $scope.getDocument = function (id) {

        $http({
            url: urlGetDocument,
            method: "POST",
            data: { 'id': id }
        }).success(function (doc) {
            $scope.Doc = JSON.parse(JSON.parse(JSON.stringify(doc)));
            $scope.Id = $scope.Doc.Id;
            return $scope.Doc;
        });
    };
    $scope.execute = function () {
        $scope.isRowClicked = true;
    }
    $scope.getId = function (id) {
        $scope.Id = id;
        $http({
            url: urlSetId,
            method: "POST",
            data: { 'id': id }
        });
    };
    $scope.exportDocument = function () {
        $http({
            url: "",
            method: "POST",
            data: { 'id': $scope.Id }
        }).success(function (response) {
            window.location = "/Home/ExportDocument?id=" + $scope.Id;

        });
    }
    $scope.importDocument = function () {
        $scope.info = document.getElementById("file").files[0];
        $http({
            url: urlImportDocument,
            method: "POST",
            data: { 'data': $scope.info }
        }).success(function (response) {

        });

    }

    $scope.showOpenField = function () {
        $scope.showOpen = true;
    }

    setInterval(function () {
        $http({
            url: urlGetOrdersList,
            method: "GET"
        }).success(function (list) {
            $scope.OrdersList = list;
            $scope.tableData = parseToBootstrapTableData();
            refreshTable($scope.tableData.data);
        });
    }, 10000)

});

