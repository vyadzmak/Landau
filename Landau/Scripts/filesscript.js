
function UploadProgress(evt) {
    if (evt.lengthComputable) {
        var percentComplete = Math.round(evt.loaded * 100 / evt.total);
        $("#uploading").text(percentComplete + "% ");
        
    }
}

function UploadFailed(evt) {
    alert("There was an error attempting to upload the file.");
}

function UploadCanceled(evt) {
    alert("The upload has been canceled by the user or the browser dropped the connection.");
}



    usersApp.controller("FileCtr", function($scope, contactFactory) {
        $(document).ready(function() {
            document.getElementById("spanDescription").hidden = false;
            $(window).load(function () {

                $('#dvLoading').fadeOut(2000);


            });
        });
       

        function uploadComplete() {

            $scope.Contact = [];
            contactFactory.GetImage().then(function(d) {
                $scope.Contact = d.data;

            }, function() {
                alert("Warning!!!");
            });

        }

        function pageiantion() {
            $scope.itemsPerPage = 5;
            $scope.currentPage = 0;

            $scope.range = function() {

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
            $scope.pageCount = function() {

                return Math.ceil($scope.filteredContact.length / $scope.itemsPerPage) - 1;
            };

            $scope.prevPage = function() {
                if ($scope.currentPage > 0) {
                    $scope.currentPage--;
                }
            };

            $scope.prevPageDisabled = function() {
                return $scope.currentPage === 0 ? "disabled" : "";
            };


            $scope.nextPage = function() {
                if ($scope.currentPage < $scope.pageCount()) {
                    $scope.currentPage++;
                }
            };

            $scope.nextPageDisabled = function() {
                return $scope.currentPage === $scope.pageCount() ? "disabled" : "";
            };

            $scope.setPage = function(n) {
                $scope.currentPage = n;
            };
        }

        $scope.$watch("query", function() {

            $scope.currentPage = 0;
        });
        $scope.$watch("selectedformat", function() {

            $scope.currentPage = 0;
        });


        //$.when($scope.LoadFileData).done(function () {
        //    console.log("Motheer");
        //    uploadComplete();
        //});


        $scope.LoadFileData = function() {
            if ($scope.value.$invalid) {
                console.log("In");
                $scope.submitted = false;
                
            } else {
                console.log("InIn");
                var formdata = new FormData(); //FormData object
                var fileInput = document.getElementById("etlfileToUpload");
                for (i = 0; i < fileInput.files.length; i++) {

                    console.log(fileInput.files.length);
                    formdata.append("files", fileInput.files[i]);
                    formdata.append("description", $scope.Description);
                }
                var xhr = new XMLHttpRequest();
                xhr.upload.addEventListener("progress", function(evt) { UploadProgress(evt); }, false);
                xhr.addEventListener("load", function() { uploadComplete(); }, false);
                xhr.addEventListener("error", function(evt) { UploadFailed(evt); }, false);
                xhr.addEventListener("abort", function(evt) { UploadCanceled(evt); }, false);
                xhr.open("POST", "Documents/Upload");
                xhr.send(formdata);
                $scope.showLink = false;

                return false;
            }
        };
        $scope.Contact = [];
        contactFactory.GetImage().then(function(d) {
            $scope.Contact = d.data;
            pageiantion();

        }, function() {
            alert("Warning!!!");
        });
        $scope.TypeDocument = [];
        contactFactory.GetTypeDocument().then(function(d) {
            $scope.TypeDocument = d.data;


        }, function() {
            alert("Warning!!!");
        });

        $scope.showDescription = function() {
           
            var fileInput = document.getElementById("etlfileToUpload");
           
            if (fileInput.files.length > 0) {
                $scope.showLink = true;
                $scope.Description = [];
            } else {
                $scope.showLink = false;
            }
           

        };
        pageiantion();

        $scope.sortField = undefined;
        $scope.reverse = false;
        $scope.sort = function(fieldName) {

            if ($scope.sortField === fieldName) {

                $scope.reverse = !$scope.reverse;

            } else {

                $scope.sortField = fieldName;
                $scope.reverse = false;
            }
        };
        $scope.isSortUp = function(fieldName) {
            return $scope.sortField === fieldName && !$scope.reverse;
        };
        $scope.isSortDown = function(fieldName) {
            return $scope.sortField === fieldName && $scope.reverse;
        };
    })
    .filter("offset", function() {
        return function(input, start) {

            return input.slice(start);
        };
    })
    .factory("contactFactory", function($http) {
        var fac = {};


        fac.GetImage = function() {
            return $http(
            {
                url: "Documents/Get",
                method: "GET"

            });
        };
        fac.GetTypeDocument = function() {
            return $http(
            {
                url: "Documents/GetDocumentType",
                method: "GET"

            });
        };
        return fac;
    });