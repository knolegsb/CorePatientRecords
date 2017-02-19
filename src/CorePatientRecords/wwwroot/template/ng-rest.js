(function () {
    'use strict';
    var prApp = angular.module('patientRecordsApp', []);
})();

(function () {
    'use strict';

    var pService = 'patientFactory';

    angular.module('patientRecordsApp').factory(pService, ['$http', patientFactory]);

    function patientFactory($http) {
        function getPatientsFromApi() {
            return $http.get('http://localhost:23799/api/Patient');
        }

        var patientService = {
            getPatientsFromApi: getPatientsFromApi
        };
        return patientService;
    }
})();

(function () {
    'use strict';
    var pController = 'patientController';

    angular.module('patientRecordsApp').controller(pController, ['$scope', 'patientFactory', patientController]);

    function patientController($scope, patientFactory) {
        $scope.patients = [];

        patientFactory.getPatientsFromApi().success(function (patientData) {
            $scope.patients = patientData;
            console.log("Data obtained successfully.");
        }).error(function (error) {
            console.log("An error has occured.");
        });
    }
})();