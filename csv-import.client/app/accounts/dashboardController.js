(function () {
    "use strict";

    angular
        .module("accountManagement")
        .controller("DashboardController",
                    ["importResource", "$scope", "dashboardResource",
                    DashboardController]);

    function DashboardController(importResource, $scope, dashboardResource) {
        $scope.title = "Dashboard";
        $scope.state = "Upload a File"

        getLastImportData();

        $scope.upload = function () {
            $scope.state = "Uploading data this may take a while..."
            dashboardResource.uploadFile($scope.fileContent)
            .success(function (response) {
                $scope.state = "Upload a File";
                getLastImportData();
                $scope.loaded = 'animated bounce'
            });

        };

        function getLastImportData() {
            importResource.query({ last: true }, function (data) {
                if (data.length > 0) {
                    $scope.lastImport = data[0];
                    $scope.message = "Data from last import";
                }
                else {
                    $scope.lastImport = {}
                    $scope.message = "No imports yet";
                }
            });
        };

    }

}());