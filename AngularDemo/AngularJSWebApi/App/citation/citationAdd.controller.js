(function () {

    'use strict;'
    angular
        .module('demoApp')  // Getter
        .controller('CitationAddController', CitationAddController);

    CitationAddController.$inject = ['$stateParams', 'dataService'];

    function CitationAddController($stateParams, dataService) {

        var vm = this;

        vm.message = "";

        vm.citation = 
        {
            "CitationNumber": "",
            "Driver": { "LastName": "", "FirstName": "" },
            "Speed": "",
            "SpeedZone": "",
            "Fine": ""
        };


        var onSaveComplete = function (response) {
            vm.message = "success";
        }

        var onError = function (response) {
            vm.message = "Error saving citation";
        };

        vm.save = function () {
            dataService.addCitation(vm.citation).then(onSaveComplete, onError);
        }



    };

})();