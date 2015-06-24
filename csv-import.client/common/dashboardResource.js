(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("dashboardResource",
            ["$http",
             "appSettings",
             dashboardResource])

    function dashboardResource($http, appSettings) {
        var uploadFile = function (data) {
            return $http.post(appSettings.serverPath + 'api/files', JSON.stringify(data))
        };

        return {
            uploadFile: uploadFile
        };
    };
}());