(function () {

    'use strict;'
    angular
        .module('demoApp')  // Getter
        .controller('CitationEditController', CitationEditController);

    CitationEditController.$inject = ['$stateParams', 'dataService'];

    function CitationEditController($stateParams, dataService) {

        var vm = this;

        vm.message = ""
        vm.citationID = $stateParams.citationID;

        var onSearchComplete = function (response) {
            vm.citation = response;

            //vm.LastName = vm.citation.Driver.LastName;
            //vm.FirstName = vm.citation.Driver.FirstName;
            //vm.CitationNumber = vm.citation.CitationNumber;
            //vm.Fine = vm.citation.Fine;
        }

        var onError = function (response) {
            vm.message = "Error getting citation.";
        }

        getCitation();

        function getCitation() {
            dataService.getCitation(vm.citationID).then(onSearchComplete, onError);
        }


        vm.save = function () {
            dataService.updateCitation(vm.citation);
            vm.message = "success";
        }

        vm.cancel = function () {
            getCitation();
        }


    };

})();