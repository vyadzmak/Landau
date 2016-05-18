function transactions(transactionsInfo) {
    $(function () {
        var excludedData = new Array();
        var columns = new Array();
        columns.push({ 'field': 'state', 'checkbox': true });

        for (var k = 0; k < transactionsInfo[0].length; k++) {
            columns.push({ 'field': transactionsInfo[0][k][0], 'title': transactionsInfo[0][k][0] });
        }

        var data = new Array();
        for (var i = 0; i < transactionsInfo.length; i++) {

            var objNew = new Object();

            for (var j = 0; j < transactionsInfo[i].length; j++) {

                objNew[transactionsInfo[i][j][0]] = transactionsInfo[i][j][1];
                objNew['Категория'] = transactionsInfo[i][j][2];

            }

            data.push(objNew);
        }

        $(".category-select-option").change(function () {
            var clickedCategory = $(this).val();
            var dataCopy = new Array();

            for (var keyData in data) {
                dataCopy.push(data[keyData]);
            }
           

            dataCopy = refreshDataList(clickedCategory, dataCopy)

            $('#move-table').bootstrapTable('load', dataCopy);
        });

        function refreshDataList(clickedCategory, dataArr) {
            var dataArrNew = new Array();

            for (var key in dataArr) {
                if (dataArr[key]['Категория'] == clickedCategory) {
                    dataArrNew.push(dataArr[key]);
                }
            }

            return dataArrNew;
        }

        $('#move-table').bootstrapTable({
            data: data,
            height: 400,
            striped: true,
            pagination: true,
            pageSize: 50,
            pageList: [10, 25, 50, 100, 200],
            search: true,
            showColumns: true,
            showRefresh: false,
            minimumCountColumns: 2,
            columns: columns
         }).on('check.bs.table', function (e, row) {
            console.log('Event: check.bs.table, data: ' + JSON.stringify(row));
         });


        });
};