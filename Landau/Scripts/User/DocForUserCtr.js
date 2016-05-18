usersApp.controller("DocForUserCtr", function ($scope) {

    function pageiantionforuser() {

        $scope.currentPage = 0;

        $scope.rangeUser = function () {

            var rangeSize = Math.ceil($scope.filteredDocUser.length / $scope.itemsPerPage);
            var ret = [];
            var start;
            start = $scope.currentPage;

            if (start > $scope.pageCountUser() - rangeSize) {
                start = $scope.pageCountUser() - rangeSize + 1;

            }

            for (var i = start; i < start + rangeSize; i++) {

                ret.push(i);
            }
            return ret;
        };
        $scope.pageCountUser = function () {

            return Math.ceil($scope.filteredDocUser.length / $scope.itemsPerPage) - 1;
        };

        $scope.prevPageUser = function () {
            if ($scope.currentPage > 0) {
                $scope.currentPage--;
            }
        };

        $scope.prevPageDisabledUser = function () {
            return $scope.currentPage === 0 ? "disabled" : "";
        };


        $scope.nextPageUser = function () {
            if ($scope.currentPage < $scope.pageCountUser()) {
                $scope.currentPage++;
            }
        };

        $scope.nextPageDisabledUser = function () {
            return $scope.currentPage === $scope.pageCountUser() ? "disabled" : "";
        };

        $scope.setPageUser = function (n) {
            $scope.currentPage = n;
        };
    }

    pageiantionforuser();

    

})

                .filter("offset", function () {
                    return function (input, start) {

                        return input.slice(start);
                    };
                })








