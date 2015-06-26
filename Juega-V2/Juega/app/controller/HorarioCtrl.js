
angular.module('CanchasController', []).controller('HorarioCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.Accion = 'nuevo';
    $scope.MostrarError = {};
    $scope.MostrarAlerta = {};
    $scope.MostrarInfo = {};
    $scope.Mensaje = {};

    $http.get('/Canchas/ObtenerEstados').success(function (data) {

        $scope.ListaEstados = data.data;

    });

    $scope.EstablecerId = function (value) {
        $scope.IdCancha = value
    }

    $scope.Init = function (value) {
        $scope.IdCancha = value

        var url = '/Canchas/ObtenerHorariosXCancha/' + value;

        $http.get(url, $scope.Registro)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;
                $scope.Horarios = data.data;

            })
            .error(function (data) {
                $scope.Mensaje = data;
                $scope.MostrarError = 'S';
                $scope.MostrarAlerta = 'N'
                $scope.MostrarInfo = 'N'
                $scope.CancelarClonado();
                $scope.Mensaje = data;
            });

    };

    $scope.MostrarHorarios = function () {

        var fechaClonar = document.getElementById("t1").value.trim();

        if (fechaClonar == "") {
            $scope.Mensaje = 'Debe seleccionar la fecha que desea clonar.';
            $scope.MostrarMsjValidarClonar = 'S';
            return;
        }

        $scope.MostrarMsjValidarClonar = 'N';

        fechaClonar = fechaClonar.replace("/", "-");
        fechaClonar = fechaClonar.replace("/", "-");
        fechaClonar = fechaClonar.replace("/", "-");

        var url = '/Canchas/ObtenerHorarioXFecha/' + $scope.IdCancha + '=' + fechaClonar;


        $http.get(url, $scope.Registro)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;
                $scope.HorarioXDia = data.data;
                $scope.CancelarClonado();
                $scope.Mensaje = data.Mensaje;
            })
            .error(function (data) {
                $scope.Mensaje = data;
                $scope.MostrarError = 'S';
                $scope.MostrarAlerta = 'N'
                $scope.MostrarInfo = 'N'
                $scope.CancelarClonado();
                $scope.Mensaje = data.Mensaje;
            });
    }

    $scope.CancelarClonado = function () {
        $scope.MostrarMsjValidarClonarRango = 'N';
        $scope.MostrarMsjValidarClonar = 'N';
        $scope.MostrarConfirmacionClonar = 'N';
        $scope.Mensaje = '';
    }

    $scope.ClonarHorario = function (clonar) {
        $scope.MostrarMsjValidarClonarRango = 'N';
        $scope.MostrarMsjValidarClonar = 'N';
        $scope.MostrarConfirmacionClonar = 'N';
        $scope.Mensaje = '';

        if (document.getElementById("t1").value.trim() == "") {

            $scope.Mensaje = 'Debe seleccionar la fecha que desea clonar.';
            $scope.MostrarMsjValidarClonar = 'S';
            return;
        }

        if ($scope.HorarioXDia == null || $scope.HorarioXDia.Count <= 0) {
            $scope.Mensaje = 'Debe consultar el detalle de horarios a clonar.';
            $scope.MostrarMsjValidarClonar = 'S';
            return;
        }

        if (document.getElementById("tr1").value.trim() == "") {

            $scope.Mensaje = 'Debe seleccionar la fecha de inicio.';
            $scope.MostrarMsjValidarClonarRango = 'S';
            return;
        }

        if (document.getElementById("tr2").value.trim() == "") {

            $scope.Mensaje = 'Debe seleccionar la fecha fin.';
            $scope.MostrarMsjValidarClonarRango = 'S';
            return;
        }

        if (clonar == true) {
            var FechaClonar = document.getElementById("t1").value;
            FechaClonar = FechaClonar.replace("/", "-");
            FechaClonar = FechaClonar.replace("/", "-");
            FechaClonar = FechaClonar.replace("/", "-");

            var FechaDesde = document.getElementById("tr1").value;
            FechaDesde = FechaDesde.replace("/", "-");
            FechaDesde = FechaDesde.replace("/", "-");
            FechaDesde = FechaDesde.replace("/", "-");

            var FechaHasta = document.getElementById("tr2").value;
            FechaHasta = FechaHasta.replace("/", "-");
            FechaHasta = FechaHasta.replace("/", "-");
            FechaHasta = FechaHasta.replace("/", "-");

            var url = '/Canchas/ClonarFecha/' + $scope.IdCancha + ',' + FechaClonar + ',' + FechaDesde + ',' + FechaHasta;
             
            $http.get(url, $scope.Registro)
                .success(function (data) {
                    $scope.MostrarError = data.Error;
                    $scope.MostrarAlerta = data.Alerta;
                    $scope.MostrarInfo = data.Info;
                    $scope.Mensaje = data.Mensaje;
                    //$scope.HorarioXDia = data.data;
                    $scope.CancelarClonado();
                    $scope.Mensaje = data.Mensaje;
                })
                .error(function (data) {
                    $scope.Mensaje = data;
                    $scope.MostrarError = 'S';
                    $scope.MostrarAlerta = 'N'
                    $scope.MostrarInfo = 'N'
                    $scope.CancelarClonado();
                    $scope.Mensaje = data.Mensaje;
                });
        }
        else {
            $scope.MostrarConfirmacionClonar = 'S';
        }
    }


    $scope.EditarHorario = function (IdHorario_Dia) {
        $scope.MostrarDetalle = 'S';

        var url = '/Canchas/ObtenerHorarioXId/' + IdHorario_Dia;


        $http.get(url, $scope.Registro)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;
                $scope.DetalleHorasXDia = data.data.ListaHoras;
            })
            .error(function (data) {
                $scope.Mensaje = data;
                $scope.MostrarError = 'S';
                $scope.MostrarAlerta = 'N'
                $scope.MostrarInfo = 'N'
            });
    }

    $scope.NuevoRegistro = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = true;
        $scope.MostrarAlerta = 'N';
        $scope.MostrarInfo = 'N';
    };

    $scope.EditarRegistro = function (registroEditar) {

        $scope.MostrarControles = true;
        $scope.Registro = registroEditar;

        document.getElementById("tpDesde").value = registroEditar.HoraDesde;
        document.getElementById("tpHasta").value = registroEditar.HoraHasta;
        document.getElementById("spinPrecio").value = registroEditar.nPrecio;

    
        $scope.Accion = 'editar';
        $scope.MostrarControles = true;
    

    }
}

]);

