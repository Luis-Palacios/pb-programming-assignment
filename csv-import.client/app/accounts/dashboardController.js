(function () {
    "use strict";

    angular
        .module("accountManagement")
        .controller("DashboardController",
                    ["importResource", "$scope", "$http",
                    DashboardController]);

    function DashboardController(importResource, $scope, $http) {
        $scope.title = "Dashboard";
        importResource.query({ last: true }, function (data) {
            if (data.length > 0) {
                $scope.lastImport = data[0];
                $scope.message = "Data from last import";
            }
            else {
                $scope.lastImport = {}
                $scope.message = "No imports yet";
            }
        })

        $scope.upload = function () {
            
            var data = [];
            for (var i = 0; i < 100000; i++) {
                data.push($scope.fileContent[i]);
            }
            $http.post('http://localhost:23730/api/files', data)
            .success(function (response) {
                console.log(response);
            });
           
        };
    }

}());