//usersApp.directive('page', function () {
//    return {
//        restrict: 'E',
//        replace: true,
//        template: function (tElement, tAttrs) {
//            var isClickable = angular.isDefined(tAttrs.isClickable) && eval(tAttrs.isClickable) === true ? true : false;

//            var clickAttr = isClickable ? 'ng-click="onHandleClick()"' : '';

//            return '<div ' + clickAttr + ' ng-transclude></div>';
//        },
//        transclude: true,
//        link: function (scope, element, attrs) {
//            scope.onHandleClick = function () {
//                console.log('onHandleClick');
//            };
//        }
//    };
//});

usersApp.controller("OrderCtr", function ($scope, $http, $compile) {

    $scope.testArr = [{ id: 1, name: "Александр" }, { id: 2, name: "Алексей" }, { id: 3, name: "Андрей" }, { id: 4, name: "Афанасий" }];

    $scope.currentPage = 0;

    $scope.range = function () {

        var rangeSize = Math.ceil($scope.filteredOrder.length / $scope.itemsPerPage);
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

        return Math.ceil($scope.filteredOrder.length / $scope.itemsPerPage) - 1;
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

    $scope.makeAction = function (id, name) {
        alert("Id: " + id + "; Name: " + name);
    }

    $scope.log = function(docId) {
        $.ajax({
            type: "POST",
            url: urlReportLog,
            data: {
                'docId': docId
            }
        }).success(function(logs) {
            createModalWindow("<div id=\"log_table_jacket\"><div>",
                "Логи по документу №" + docId);

            var tableStr = "<table id=\"log-table\" class=\"table table-bordered table-striped\" style=\"margin-left: 9%; width: 80%;\">" +
                "<thead><tr><th width=\"5%\">#</th><th width=\"30%\">Дата</th><th width=\"65%\">Содержание</th>" +
                "</tr></thead><tbody></tbody></table>";

            $("#log_table_jacket").append($.parseHTML(tableStr));

            for (var key = 0; key < logs.length; key++) {
                $("#log-table").children("tbody").append("<tr id=\"popover\" data-content=\"" + logs[key].FullDescription + "\" " +
                    "title=\"Полное описание\" id=\"log-row" +
                    key + "\"  class=\"with-full-description " + logs[key].Type + "\">" +
                    "<th>" + (key + 1) + "</th><th>" + logs[key].Date +
                    "</th><th>" + logs[key].Message + "</th><th class=\"full-descr\" style=\"display: none\">" + logs[key].FullDescription + "</th></tr>");
            }

            $("tr[id=popover]").popover({ placement: "bottom", trigger: "hover" });

        });
    }

    $scope.openMod = function (id) {
        //var buy_body = document.createElement("div");
        //var btn = document.createElement("button");
        //btn.setAttribute("class", "btn btn-default");
        //btn.style.alignSelf = "center";
        //btn.innerText = "Make action";
        //btn.setAttribute("onclick", "alert(\"Закуп\");");
        //buy_body.appendChild(btn);


        $.ajax({
            type: "POST",
            url: "/HtmlForms/GetHtmlForm/",
            data: { 'id': id }
        }).then(function (result) {

            if (result == "") {
                createModalWindow(empty, "Закуп"); return 0;
            }

            createModalWindow("<div id=\"table_jacket\"></div>", "Закуп");

            $scope.additionToTable = $compile(result);

            $("#table_jacket").html(
                $compile(result)($scope)
                );
            //var tableJacket = document.getElementById("table_jacket");
            //tableJacket.appendChild($scope.additionToTable);
        })

        
    };


})