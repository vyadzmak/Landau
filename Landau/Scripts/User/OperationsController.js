usersApp.controller("OperationsController", function ($scope, $http, $interval, $rootScope, contactFactory) {
    
    $scope.getAllOrders = function () {
        $.ajax({
            url: urlGetAllOrders,
            method: "POST",
        }).then(function (result) {

            if (result == "") {
                createModalWindow(empty, "Консолидация"); return 0;
            }

            var orders = JSON.parse(result);
            createModalWindow("<button class=\"btn btn-default\" id=\"select_orders\" type=\"button\">Выбранные отчёты</button><table id=\"orders_table\" class=\"table table-bordered\"><tbody id=\"order_table_body\">" +
            "</tbody></table>", "Консолидация");

            var columns = new Array();
            columns.push({ 'checkbox': true, 'field': "state" });
            columns.push({ 'field': "Наименование", 'title': "Наименование" });

            var data = new Array();

            for (key in orders) {
                data.push({ "Id": orders[key].Id, "Index": parseInt(key) + 1, "Наименование": orders[key].Name });
            }

            $("#orders_table").bootstrapTable({
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

            $("#select_orders").click(function () {
                var selectedRows = $("#orders_table").bootstrapTable('getSelections');
                alert(JSON.stringify(selectedRows));
            })

        })
    }

});