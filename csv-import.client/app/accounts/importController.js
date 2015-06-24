(function () {
    "use strict";

    angular
        .module("accountManagement")
        .controller("ImportController",
                    ["importResource",
                        ImportController]);

    function ImportController(importResource) {
        var vm = this;

        importResource.query(function (data) {
            vm.imports = data;
        });

    }
}());