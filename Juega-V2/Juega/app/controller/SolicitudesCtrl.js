angular.module('SolicitudesController', []).controller('SolicitudesCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.ListaRegistros = {};
    $scope.Registro = {};
    $scope.Accion = 'nuevo';
    $scope.MostrarControles = false;
    $scope.MostrarError = {};
    $scope.MostrarAlerta = {};
    $scope.MostrarInfo = {};
    $scope.Mensaje = {};

    $scope.Limpiar = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = false;
        $scope.MostrarAlerta = 'N';
        $scope.MostrarInfo = 'N';
    };

    $scope.NuevoRegistro = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = true;
        $scope.MostrarAlerta = 'N';
        $scope.MostrarInfo = 'N';
    };

    $scope.EditarRegistro = function (registroEditar) {
        $scope.Registro = registroEditar;
        $scope.Accion = 'editar';
        $scope.MostrarControles = true;
    }



    $http.get('/Solicitudes/GetAll').success(function (data) {
        $scope.Mensaje = data.Mensaje;
        $scope.MostrarAlerta = data.Alerta;
        $scope.MostrarInfo = data.Info;
        $scope.MostrarError = data.Error;
         
        if (data.Error == 'S')
            $scope.ListaRegistros = {};
        else
            $scope.ListaRegistros = data.data;

    });

    $scope.Aceptar = function () {
        $http.post('/Solicitudes/Aceptar_AdminCanchas', $scope.Registro)
        .success(function (data) {
            $scope.MostrarError = data.Error;
            $scope.MostrarAlerta = data.Alerta;
            $scope.MostrarInfo = data.Info;
            $scope.Mensaje = data.Mensaje;

            if (data.Error == 'N' && data.Alerta == 'N') {
                var indice = $scope.ListaRegistros.indexOf($scope.Registro);
                $scope.ListaRegistros.splice(indice, 1);
                $scope.Limpiar();
                return;
            }
        })
        .error(function (data) {
            $scope.Mensaje = data;
            $scope.MostrarError = 'S';
            $scope.MostrarAlerta = 'N'
            $scope.MostrarInfo = 'N'
        });

    }

    $scope.Rechazar = function () {
        $http.post('/Solicitudes/Rechazar_AdminCanchas', $scope.Registro)
        .success(function (data) {
            $scope.MostrarError = data.Error;
            $scope.MostrarAlerta = data.Alerta;
            $scope.MostrarInfo = data.Info;
            $scope.Mensaje = data.Mensaje;

            if (data.Error == 'N' && data.Alerta == 'N') {
                var indice = $scope.ListaRegistros.indexOf($scope.Registro);
                $scope.ListaRegistros.splice(indice, 1);
                $scope.Limpiar();
                return;
            }
        })
        .error(function (data) {
            $scope.Mensaje = data;
            $scope.MostrarError = 'S';
            $scope.MostrarAlerta = 'N'
            $scope.MostrarInfo = 'N'
        });

    } 
}



]);