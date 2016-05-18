


angular.module('RegistrationApp', [])
    .controller('RegistrationCtr', function ($scope, $http) {
        $(document).ready(function () {
            document.getElementById("spanSecondName").hidden = false;
            document.getElementById("spanFirstName").hidden = false;
            document.getElementById("spanLastName").hidden = false;
            document.getElementById("spanRegistrationNumber").hidden = false;
            document.getElementById("spanPhoneNumber").hidden = false;
            document.getElementById("spanPasswordValidation").hidden = false;
            document.getElementById("spanConPasswordValidation").hidden = false;
            document.getElementById("spanNameOrganisation").hidden = false;
            document.getElementById("spanEmail").hidden = false;
          //  $('#layoutfooter').show();

            $("#FormRegistrSubmit").submit(function() {
                $('#dvLoading').show();
                $('#mask').show();
                if ($scope.value.$invalid) {

                    $scope.submitted = false;
                    $('#mask').hide();
                    $('#dvLoading').fadeOut(1000);
                } else {

                    $http.get("Account/CheckEmail?email=" + $scope.user.Email).success(function(data) {
                        $http.post("Account/CheckPassword", $scope.user).success(function(passworddata) {


                            console.log(passworddata);

                            if (data === 'False' || passworddata === 'False') {
                                console.log("234");
                                if (data === 'False') {
                                    $scope.showLink = true;
                                    $scope.submitted = false;
                                    $scope.checkemail = "Пользователь с данным Email уже зарегистрирован!!!";
                                    $('#mask').hide();
                                    $('#dvLoading').fadeOut(1000);
                                }
                                if (passworddata === 'False') {
                                    $scope.showPassword = true;
                                    $scope.submitted = false;
                                    $scope.checkpassword = "Пароли не совпадают!!!";
                                    $('#mask').hide();
                                    $('#dvLoading').fadeOut(1000);
                                }

                            } else {
                                console.log("Ok");
                                $http.post('Account/Register', $scope.user).success(function(data) {
                                    console.log("123111");
                                    //document.getElementById("myBtn").disabled = true;
                                    //$scope.showseccess = true;
                                    //$scope.uploading = "Регистрация прошла успешно!!!";
                                    //$('#dvLoading').fadeOut(1000);
                                    if (data === 'True') {
                                        console.log("123111");
                                        window.location.href = 'Cabinet/Cabinet';
                                    }
                                    if (data === 'False') {
                                        $scope.register = "Регистрация не удалась";
                                        $scope.showLink = true;
                                        $('#mask').hide();
                                        $('#dvLoading').fadeOut(1000);
                                    }
                                }).error(function(data) {
                                   // alert("Warning!!!");
                                    $('#mask').hide();
                                    $('#dvLoading').fadeOut(1000);

                                });
                            }

                        }).error(function(data) {
                          //  alert("Warning!!!");
                            $('#mask').hide();
                            $('#dvLoading').fadeOut(1000);
                        });

                    }).error(function(data) {
                       // alert("Warning!!!");
                        $('#mask').hide();
                        $('#dvLoading').fadeOut(1000);
                    });

                }

            });
        });
        $scope.changepassword = function () {
            $scope.showPassword = false;
        }
        $scope.changeemail = function () {
            $scope.showLink = false;
        }



    })

.controller('LoginCtr', function ($scope, $http) {
    $(document).ready(function () {
        document.getElementById("spanlogin").hidden = false;
        document.getElementById("spanpassword").hidden = false;


        console.log("123");
        //$scope.submit = function () {
        //    console.log(123);
        //    if ($scope.LoginForm.$valid)
        //        alert('send to server: ' + $scope.number);
        //}


        $("#FormLoginSubmit").submit(function () {

            $('#mask').show();
            if ($scope.LoginForm.$invalid) {

                $scope.submitted = false;
                $('#dvLoading').show();
                $('#mask').hide();
                $('#dvLoading').fadeOut(1000);
            } else {
                $('#dvLoading').show();
                $http.post("Account/Login", $scope.user).success(function (data) {

                    if (data === 'True') {

                        window.location.href = 'Cabinet/Cabinet';
                    }
                    if (data === 'False') {
                        $scope.submitted = false;
                        $scope.auto = "Авторизация не удалась";
                        $scope.showLink = true;
                        $('#mask').hide();
                        $('#dvLoading').fadeOut(1000);
                    }
                });
            }
        });






    });




});








