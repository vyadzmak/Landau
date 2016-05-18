angular.module('ionicApp', ['ionic'])

// All this does is allow the message
// to be sent when you tap return
.directive('input', function ($timeout) {
    
    return {
        restrict: 'E',
        scope: {
            'returnClose': '=',
            'onReturn': '&',
            'onFocus': '&',
            'onBlur': '&'
        },
        link: function (scope, element, attr) {
            element.bind('focus', function (e) {
                if (scope.onFocus) {
                    $timeout(function () {
                        scope.onFocus();
                    });
                }
            });
            element.bind('blur', function (e) {
                if (scope.onBlur) {
                    $timeout(function () {
                        scope.onBlur();
                    });
                }
            });
            element.bind('keydown', function (e) {
                if (e.which == 13) {
                    if (scope.returnClose) element[0].blur();
                    if (scope.onReturn) {
                        $timeout(function () {
                            scope.onReturn();
                        });
                    }
                }
            });
        }
    }
})


.controller('Messages', function($scope, $timeout,$interval, $ionicScrollDelegate, contactFactory, $http) {
 
    function commentsforuser() {
     
        contactFactory.GetComments($scope.DocumentId).then(function (d) {
                $scope.messages = d.data;
                //   $scope.showOnParentShow = true;
                $('#dvLoading').hide();
             

            });
        }


            $scope.init = function(model) {
               // $('#dvLoading').show();
                $scope.model = model;

                $scope.myId = sessionUserId;
                $scope.DocumentId = model["DocumentId"];
             
                commentsforuser();

           
            }
      
            $scope.hideTime = true;

            $('#back').show();
            $('#ion-content').show();
            $('#footer').show();
          
           $interval(commentsforuser, 5000);
            var isIOS = ionic.Platform.isWebView() && ionic.Platform.isIOS();

            $scope.sendMessage = function() {
              
                if ($scope.getUser === undefined) {
                    $scope.getUser = 0;
                }
                var d = new Date();
                d = d.toLocaleTimeString().replace(/:\d+ /, ' ');

                $scope.messages.push({
                    SendUserId: sessionUserId,
                    Data: $scope.data.message,
                    Date: d,
                    SendUser: sessionName,

                });
              

                $http.post("Documents/SendtoEmail", { userModel: $scope.model, message: $scope.data.message }).success(function() {


               
                });
                delete $scope.data.message;
                $ionicScrollDelegate.scrollBottom(true);

            };


            $scope.inputUp = function() {
                if (isIOS) $scope.data.keyboardHeight = 216;
                $timeout(function() {
                    $ionicScrollDelegate.scrollBottom(true);
                }, 300);

            };

            $scope.inputDown = function() {
                if (isIOS) $scope.data.keyboardHeight = 0;
                $ionicScrollDelegate.resize();
            };

            $scope.closeKeyboard = function() {
                // cordova.plugins.Keyboard.close();
            };


            $scope.data = {};

            $scope.messages = [];

        
    })
.factory("contactFactory", function ($http) {

    var fac = {};
   
    fac.GetComments = function(documentid) {
        return $http.get("Documents/GetComment?id="+documentid);

        //};
    }
    return fac;
});
 