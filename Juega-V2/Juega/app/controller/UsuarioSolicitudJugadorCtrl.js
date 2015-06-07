angular.module('UsuarioSolicitudJugadorController', []).controller('UsuarioSolicitudJugadorCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.ListaRegistros = {};
    $scope.Registro = {};

    $scope.ListaEquipo = {};

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

    $http.get('/UsuarioSolicitudJugador/GetAllUsuarioEquipo').success(function (data) {
        $scope.Mensaje = data.Mensaje;
        $scope.MostrarAlerta = data.Alerta;
        $scope.MostrarInfo = data.Info;
        $scope.MostrarError = data.Error;

        //if (data.Error == 'S')
        //    $scope.ListaRegistros = {};
        //else
            $scope.ListaRegistros = data.data;

    });

    //$http.get('/UsuarioSolicitudJugador/GetAllEquipos').success(function (data) {
    //    $scope.Mensaje = data.Mensaje;
    //    $scope.MostrarAlerta = data.Alerta;
    //    $scope.MostrarInfo = data.Info;
    //    $scope.MostrarError = data.Error;

    //    if (data.Error == 'S')
    //        $scope.ListaRoles = {};
    //    else
    //        $scope.ListaRoles = data.data;

    //});

    //$http.get('/UsuarioSolicitudJugador/GetAll').success(function (data) {
    //    $scope.Mensaje = data.Mensaje;
    //    $scope.MostrarAlerta = data.Alerta;
    //    $scope.MostrarInfo = data.Info;
    //    $scope.MostrarError = data.Error;

    //    //alert("Error:" + data.Error + " Alerta:" + data.Alerta + " Mensaje:" + data.Mensaje + " Data:" + data.data);

    //    if (data.Error == 'S')
    //        $scope.ListaRegistros = {};
    //    else
    //        $scope.ListaRegistros = data.data;

    //});



    //Obtengo la lista de equipos
    //$http.get('/UsuarioSolicitudJugador/GetAllEquipo').success(function (data) {

    //    $scope.ListaEquipo = data.data;

    //});


    $scope.Guardar = function () {
        var url = $scope.Accion == 'nuevo' ? '/UsuarioSolicitudJugador/Create' : '/UsuarioSolicitudJugador/update';

        $http.post(url, $scope.Registro)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;

                // alert("Error:" + data.Error + " Alerta:" + data.Alerta + " Mensaje:" + data.Mensaje + " Data:" + data.data);

                if (data.Error == 'N' && data.Alerta == 'N') {

                    if ($scope.Accion == 'nuevo')
                        $scope.ListaRegistros.push(data.data);

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

    $scope.Aceptar = function (RegistroAceptar) {
        var url = '/UsuarioSolicitudJugador/Aceptado'
        $http.post(url, RegistroAceptar)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;

                // alert("Error:" + data.Error + " Alerta:" + data.Alerta + " Mensaje:" + data.Mensaje + " Data:" + data.data);

                if (data.Error == 'N' && data.Alerta == 'N') {

                    var indice = $scope.ListaRegistros.indexOf(RegistroAceptar);
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


    $scope.Rechazar = function (registrorechazar) {
        var url = '/UsuarioSolicitudJugador/Rechazado'
        $http.post(url, registrorechazar)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;

                // alert("Error:" + data.Error + " Alerta:" + data.Alerta + " Mensaje:" + data.Mensaje + " Data:" + data.data);

                if (data.Error == 'N' && data.Alerta == 'N') {

                    var indice = $scope.ListaRegistros.indexOf(registrorechazar);
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