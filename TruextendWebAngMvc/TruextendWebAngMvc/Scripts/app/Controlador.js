var Controlador = angular.module('Controlador', []);
Controlador.controller("Controlador", [
    '$scope',
    'Servicios',
    function ($scope, Servicios) {
        $scope.Students=Servicios.GetStudents();
        //console.log($scope.Students);
    }
]);