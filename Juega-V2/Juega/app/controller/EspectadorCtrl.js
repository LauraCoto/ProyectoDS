angular.module('EspectadorController', []).controller('EspectadorCtrl', ['$scope', '$http', function ($scope, $http) {
     

    $http.get('/Espectador/GetAll_Complejos').success(function (data) {

        if (data.Error == 'S')
        {
            $scope.ListaComplejos = {};
        }
        else
        {
            $scope.ListaComplejos = data.data;
        }
    });

    $http.get('/Espectador/GetAll_Canchas').success(function (data) {

        if (data.Error == 'S') {
            $scope.ListaCanchas = {};
        }
        else {
            $scope.ListaCanchas = data.data;
        }
    });


    $http.get('/Espectador/GetAll_Equipos').success(function (data) {

        if (data.Error == 'S') {
            $scope.ListaEquipos = {};
        }
        else {
            $scope.ListaEquipos = data.data;
        }
    });


    $http.get('/Espectador/GetAll_Jugadores').success(function (data) {

        if (data.Error == 'S') {
            $scope.ListaJugadores = {};
        }
        else {
            $scope.ListaJugadores = data.data;
        }
    });

}



]);