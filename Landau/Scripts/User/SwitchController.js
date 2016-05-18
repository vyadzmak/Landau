usersApp.controller("switchController", function ($scope) {
    $scope.showdvLoading = true;
    $scope.showAnalyticsLabel = false;
    $scope.User1Flag = true;
    $scope.User2Flag = false;
    $scope.User3Flag = false;
    $scope.RequestModeFlag = false;

    $scope.PartialsStates = [true,  // 0 - Request table
                             false, // 1 - Area chart
                             false, // 2 - Responsive timeline
                             false, // 3 - Notification table
                             false, // 4 - Donut chart
                             false, // 5 - Chat
                             false, // 6 - Documents table
                             false, // 7 - Sheets
                             false,  // 8 - Order table for user
                             false  // 9 - New order form
    ];

    $scope.switchModes = function (id) {
        var s = JSON.parse(id);
        switch (s) {
            case 0: $scope.User3Flag = true;
                $scope.User1Flag = false;
                $scope.User2Flag = false;
                $scope.RequestModeFlag = false;
                $scope.switchPartials(4);
                break;

            case 1: $scope.User2Flag = true;
                $scope.User1Flag = false;
                $scope.User3Flag = false;
                $scope.RequestModeFlag = false;
                $scope.switchPartials(2);
                break;
            case 2:

                $scope.User1Flag = true;
                $scope.User2Flag = false;
                $scope.User3Flag = false;
                $scope.RequestModeFlag = false;
                $scope.switchPartials(0);
                break;
            case 3: $scope.RequestModeFlag = true;
                $scope.User2Flag = false;
                $scope.User3Flag = false;
                $scope.switchPartials(6);
                break;
        }
    };
    switchName = function () {
        $scope.UserName = names[$scope.UserId];
    }

    $scope.switchPartials = function (partialId) {
        $scope.showAnalyticsLabel = false;
        for (var i = 0; i < $scope.PartialsStates.length; i++) {
            $scope.PartialsStates[i] = false;
        }

        var fileCtr = angular.element(document.getElementById("content_cover")).scope();

        var op = angular.element(document.getElementById("operations_content")).scope();
        if (op) {
            op.readyFlag = false;
        }

        $("#sheet-markup").remove();

        if (partialId == 7) {
            $scope.appendSheetsMarkup();
            $scope.showAnalyticsLabel = true;
        }

        $scope.PartialsStates[partialId] = true;

        //if (partialId == 6) {
        //    setTimeout(function () { fileCtr.readyFlag = true; }, 2000);
        //}

        setTimeout(function () {
            for (var i = 0; i <= 14; i++) {
                $("#side" + i).attr("style", "");
            }
        }, 100);
    }

    $scope.appendSheetsMarkup = function () {
        $("#sheet-markup").remove();

        var svDiv = document.getElementById("sv");
        var sheetMarkup = document.createElement("div");

        sheetMarkup.setAttribute("id", "sheet-markup");
        sheetMarkup.style.position = "absolute";
        sheetMarkup.style.width = "100%";
        sheetMarkup.style.height = "100%";
        sheetMarkup.style.marginTop = "-52px"

        svDiv.appendChild(sheetMarkup);
    }

    $scope.isSwitchedOn = function (id) {
        return $scope.PartialsStates[id];
    }

    angular.element(document).ready(function() {
        $scope.switchModes(mode);
        $scope.showdvLoading = false;
    });
    

});