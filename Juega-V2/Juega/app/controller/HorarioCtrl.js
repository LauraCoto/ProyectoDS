angular.module('CanchasController', []).controller('HorarioCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.Cancha = {};
    $scope.Accion = 'nuevo';
    $scope.MostrarControles = false;
    $scope.MostrarError = {};
    $scope.MostrarAlerta = {};
    $scope.MostrarInfo = {};
    $scope.Mensaje = {};


    $scope.Init = function (value) {
        $scope.IdCancha = value

        var url = '/Canchas/ObtenerHorarios/' + value;

        $http.get(url, $scope.Registro)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;
                $scope.Cancha = data.data;

                //if (data.Error == 'N' && data.Alerta == 'N')
                //{
                //    if ($scope.Accion == 'nuevo')
                //        $scope.ListaRegistros.push(data.data);

                //    $scope.Limpiar();
                //    return;
                //}
            })
            .error(function (data) {
                $scope.Mensaje = data;
                $scope.MostrarError = 'S';
                $scope.MostrarAlerta = 'N'
                $scope.MostrarInfo = 'N'
            });

    };


    $scope.MostrarHorarios = function () {

        $scope.Cancha.FechaClonar = document.getElementById("t1").value; 
        $scope.Cancha.FechaClonar = $scope.Cancha.FechaClonar.replace("/", "-");
        $scope.Cancha.FechaClonar = $scope.Cancha.FechaClonar.replace("/", "-");
        $scope.Cancha.FechaClonar = $scope.Cancha.FechaClonar.replace("/", "-");

        var url = '/Canchas/HorarioFecha/' + $scope.IdCancha + '=' + $scope.Cancha.FechaClonar;

        $http.get(url, $scope.Registro)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;
                $scope.HorarioXDia = data.data;

                //if (data.Error == 'N' && data.Alerta == 'N')
                //{
                //    if ($scope.Accion == 'nuevo')
                //        $scope.ListaRegistros.push(data.data);

                //    $scope.Limpiar();
                //    return;
                //}
            })
            .error(function (data) {
                $scope.Mensaje = data;
                $scope.MostrarError = 'S';
                $scope.MostrarAlerta = 'N'
                $scope.MostrarInfo = 'N'
            });
    }

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
}



]);