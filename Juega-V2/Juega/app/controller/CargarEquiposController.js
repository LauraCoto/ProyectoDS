angular.module('CargarEquiposController', [])
.controller('CargarEquiposCtrl', ['$scope','$http', function($scope,$http){

    $scope.ListaRegistros = {};
    $scope.Registro = {};
    $scope.Accion = 'nuevo';
    $scope.MostrarControles = true;
    $scope.MostrarError = {};
    $scope.MostrarAlerta = {};
    $scope.MostrarInfo = {};
    $scope.Mensaje = {};
    $scope.Equipo = null;

    $scope.msg = function (msg) { alert(msg); };

    $http.get('/Usuario_Solicitud_Equipo/GetAll').success(function (data) {

        $scope.Mensaje = data.Mensaje;
        $scope.MostrarAlerta = data.Alerta;
        $scope.Info = data.Info;
        $scope.MostrarError = data.Error;

        if (data.Error == 'S')
            $scope.ListaRegistros = {};
        else {
            if (data.mensaje == '0')
                alert('No hay equipo que mostrar');
            $scope.ListaRegistros = data.data;
           
        }
    });


    $scope.MostrarUnirse= function ()
    {
        $scope.MostrarControles = true;
    }

    $scope.enviarSolicitud = function (equipo) {

        var response = $http({
            method: "post",
            url: '/Usuario_Solicitud_Equipo/enviarSolicitud',
            params: { id: JSON.stringify(equipo.IdEquipo) }
        }).success(function (data) {
            alert(data.Mensaje);
        }).error(function (data) { alert(data.Mensaje); });

    };


}]);