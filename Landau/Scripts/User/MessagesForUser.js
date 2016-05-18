usersApp.controller("MessagesCtr", function($scope, $http,$interval, messagesFactory) {

    function messageForUser() {
     
        $scope.Messages = [];

        messagesFactory.GetMessages().then(function(d) {
            $scope.Messages = d.data;
            $scope.showmessages = 0;
            $('#showredmessage').show();
            $('#showredchevron').show();
            if (d.data.length > 0) {
                $scope.showmessages = 1;
            }
           
        });
    }

    messageForUser();
    $interval(messageForUser, 5000);


  
            //    $scope.showdvLoading = false;


       // });
    //});
});
usersApp.factory("messagesFactory", function ($http) {
    var fac = {};


    fac.GetMessages = function () {

        return $http(
        {
            url: "Documents/GetMessagesForUser",
            method: "GET"

        });
    };
   

    return fac;
});
