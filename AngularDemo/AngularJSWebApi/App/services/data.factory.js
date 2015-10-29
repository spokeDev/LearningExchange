(function () {
    'use strict';

    angular
        .module('demoApp')
        .factory('dataService', ['$http', '$q', function ($http, $q) {

            // interface
            var service = {
                getCitations: getCitations,
                getCitation: getCitation,
                updateCitation: updateCitation,
                addCitation: addCitation
            };
            return service;

            // implementation
            function getCitations() {
                var def = $q.defer();

                $http.get("/api/CitationQ")
                    .success(function (data) {
                        def.resolve(data);
                    })
                    .error(function () {
                        def.reject("failed to get data");
                    });
                return def.promise;

            };

            function getCitation(citationID) {
                var def = $q.defer();
                $http.get("/api/CitationQ/" + citationID)
                    .success(function (data) {
                        def.resolve(data);
                    })
                    .error(function () {
                        def.reject("failed to get data");
                    });
                return def.promise;

            };

            function getCitations(dataObj) {
                var def = $q.defer();

                $http.post("/api/CitationQ", dataObj)
                    .success(function (data) {
                        def.resolve(data);
                    })
                    .error(function () {
                        def.reject("Failed to get data");
                    });
                return def.promise;
            }

            function updateCitation(dataObj) {
                var def = $q.defer();

                $http.put("/api/citation", dataObj)
                    .success(function (data) {
                        def.resolve(data);
                    })
                    .error(function () {
                        def.reject("Failed to update citation");
                    });
                return def.promise;
            }

            function addCitation(dataObj) {
                var def = $q.defer();

                $http.post("/api/citation", dataObj)
                    .success(function (data) {
                        def.resolve(data);
                    })
                    .error(function () {
                        def.reject("Failed to add citation");
                    });
                return def.promise;
            }



        }]);


})();