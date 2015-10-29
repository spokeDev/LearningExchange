(function () {

    'use strict;'
    angular
        .module('demoApp')  // Getter
        .controller('CitationsController', CitationsController);

    CitationsController.$inject = ['$state', 'dataService'];

    function CitationsController($state, dataService) {

        var vm = this;

        vm.message = "";

        vm.citationSearchViewModel = {
            CitationNumber: "",
            FirstName: "",
            LastName: "",
            MiddleName: "",
            }

        var onSearchComplete = function (response) {
            vm.citations = response;
        };

        var onError = function (response) {
            vm.message = "Error getting citations";
        };

        getCitations();

        function getCitations() {
            dataService.getCitations().then(onSearchComplete, onError);
        };

        vm.search = search;
        function search() {
            dataService.getCitations(vm.citationSearchViewModel).then(onSearchComplete, onError);
        };
        

        vm.addCitation = addCitation;
        function addCitation(citationNumber) {
            vm.message = citationNumber;
            $state.go('addCitation', { citationNumber: citationNumber });
        };

        vm.editCitation = editCitation;
        function editCitation(citationID) {
            vm.message = citationID;
            $state.go('editCitation', { citationID: citationID });
        };


    };

})();