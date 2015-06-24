(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("importResource",
                ["$resource",
                "appSettings",
                importResource])

    function importResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/ImportResults/:id");
    }
}());