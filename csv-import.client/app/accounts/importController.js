(function () {
    "use strict";

    angular
        .module("accountManagement")
        .controller("ImportController",
                    ["importResource","$scope",
                        ImportController]);

    function ImportController(importResource, $scope) {
        importResource.query(function (data) {
            $scope.imports = data;
        });

    }
}());