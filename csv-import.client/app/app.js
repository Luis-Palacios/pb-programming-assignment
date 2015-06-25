(function () {
    "use strict";

    var app = angular.module("accountManagement",
                            ["common.services", "ngRoute"]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/",
            {
                templateUrl: "app/accounts/dashboard.html",
                controller: "DashboardController"
            })
            .when("/imports",
            {
                templateUrl: "app/accounts/importsListView.html",
                controller: "ImportController"
            })
            .otherwise({ redirectTo:"/"});
    });

    app.directive('fileReader', function () {
        return {
            scope: {
                fileReader: "="
            },
            link: function (scope, element) {
                $(element).on('change', function (changeEvent) {
                    var files = changeEvent.target.files;
                    if (files.length) {
                        var r = new FileReader();
                        r.onload = function (e) {
                            var contents = e.target.result;
                            var objectFormat = csvJSON(contents);
                            scope.$apply(function () {
                                scope.fileReader = objectFormat;
                            });
                        };
                        
                        r.readAsText(files[0]);
                    }
                });
            }
        };
    });

    //var csv is the CSV file with headers
    function csvJSON(csv) {

        var lines = csv.split("\n");

        var result = [];

        var headers = lines[0].split(",");
        for (var i = 1; i < lines.length; i++) {
            if (lines[i].trim() == '')
                continue;
            var obj = {};
            var currentline = lines[i].split(",");
            for (var j = 0; j < headers.length; j++) {
                obj[headers[j].trim()] = (currentline[j]) ? currentline[j].trim():'';
            }
           
            result.push(obj);

        }
        return result; 
    }

}());