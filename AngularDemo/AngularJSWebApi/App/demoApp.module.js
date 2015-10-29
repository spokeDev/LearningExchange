(function () {
    'use strict';

    var demoApp = angular.module('demoApp', ['ngAnimate', 'ui.router'

    ])  //  Setter, items in [] are other modules demoApp module depends on

    .config(['$stateProvider', '$urlRouterProvider',
    function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/citations")

        $stateProvider
            .state('citations', {
                url: '/citations',
                templateUrl: "app/citation/Citations.html",
                controller: "CitationsController as vm"
            })
            .state('editCitation', {
                url: '/citationEdit/:citationID',
                templateUrl: "app/citation/citationEdit.html",
                controller: "CitationEditController as vm"
            })
            .state('addCitation', {
                url: '/citationAdd/:citationNumber',
                templateUrl: "app/citation/citationAdd.html",
                controller: "CitationAddController as vm"
            })
    }
    ]);
})();
