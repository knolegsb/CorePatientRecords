var patientRecordsApp = angular.module('patientRecordsApp', []);

patientRecordsApp.factory('patientFactory', function () {
    function getPatientLastName() {
        return 'Smith';
    }

    function getPatientFirstName() {
        return 'John';
    }

    function getPatientSsn() {
        return '123450001';
    }

    var patientService = {
        getPatientLastName: getPatientLastName,
        getPatientFirstName: getPatientFirstName,
        getPatientSsn: getPatientSsn
    };

    return patientService;
});

patientRecordsApp.controller('patientController', function ($scope, patientFactory) {
    $scope.lastName = patientFactory.getPatientLastName();
    $scope.firstName = patientFactory.getPatientFirstName();
    $scope.socialSecurityNumber = patientFactory.getPatientSsn();
});