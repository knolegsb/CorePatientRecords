var patientRecordsApp = angular.module('patientRecordsApp', []);
patientRecordsApp.controller('patientController', function ($scope) {
    $scope.lastName = 'Smith';
    $scope.firstName = 'John';
    $scope.socialSecurityNumber = '123450001';
});