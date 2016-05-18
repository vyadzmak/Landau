

angular.module("SendEmail", [])
    .controller("SendEmailCtr", function($scope, $http,contactFactory) {

        $scope.init = function (model) {

            $scope.model = model;
            $scope.DocumentId = model["DocumentId"];
            $scope.Comments = [];
            contactFactory.GetComments(model["DocumentId"]).then(function (d) {
                $scope.Comments = d.data;
                document.getElementById("spanMessage").hidden = false;
                document.getElementById("spantextarea").hidden = false;

            }, function () {
                alert("Warning!!!");
            });



        }

        $scope.SendMessage = function() {
            if ($scope.getUser === undefined) {
                $scope.getUser = 0;
            }
            $http.post("SendtoEmail", { userModel: $scope.model, message: $scope.Message, getUser: $scope.getUser }).success(function () {
               
                $scope.Comments = [];
                contactFactory.GetComments($scope.DocumentId).then(function (d) {
                    $scope.Comments = d.data;

                }, function () {
                    alert("Warning!!!");
                });

            }).error(function(data) {
                alert("Warning!!!");
            });


        };
        $scope.showComment= function(getuser) {
            $scope.showLink = true;
            $scope.getUser = getuser;
            console.log($scope.getUser);
        }

    })

 .factory("contactFactory", function ($http) {
     var fac = {};
     
     fac.GetComments = function(documentid) {
   return $http.get("Documents/GetComment?id="+documentid);

         //};
     }
    return fac;
 });
 