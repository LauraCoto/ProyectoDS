angular.module('CanchasController', []).controller('CanchasCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.ListaRegistros = {};
    $scope.Registro = {};
    $scope.Accion = 'nuevo';
    $scope.MostrarControles = false;
    $scope.MostrarError = {};
    $scope.MostrarAlerta = {};
    $scope.Mensaje = {};

    $scope.Limpiar = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = false;
        $scope.MostrarAlerta = 'N';
    };

    $scope.NuevoRegistro = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = true;
        $scope.MostrarAlerta = 'N';
    };

    $scope.EditarRegistro = function (registroEditar) {
        $scope.Registro = registroEditar;
        $scope.Accion = 'editar';
        $scope.MostrarControles = true;
    }

    $http.get('/Canchas/GetAll').success(function (data) {
        $scope.Mensaje = data.Mensaje;
        $scope.MostrarAlerta = data.Alerta;
        $scope.MostrarError = data.Error;

        //alert("Error:" + data.Error + " Alerta:" + data.Alerta + " Mensaje:" + data.Mensaje + " Data:" + data.Info);

        if (data.Error == 'S')
            $scope.ListaRegistros = {};
        else
            $scope.ListaRegistros = data.Info;

    });


    $scope.Guardar = function () {
        var url = $scope.Accion == 'nuevo' ? '/Canchas/Create' : '/Canchas/update';

        $http.post(url, $scope.Registro)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.Mensaje = data.Mensaje;

                // alert("Error:" + data.Error + " Alerta:" + data.Alerta + " Mensaje:" + data.Mensaje + " Data:" + data.Info);

                if (data.Error == 'N' && data.Alerta == 'N') {
                    // alert("Entro Aqui");

                    if ($scope.Accion == 'nuevo')
                        $scope.ListaRegistros.push(data.Info);

                    $scope.Limpiar();
                    return;
                }
            })
            .error(function (data) {
                $scope.Mensaje = data;
                $scope.MostrarError = 'S';
                $scope.MostrarAlerta = 'N'
            });
    }


    $scope.EliminarRegistro = function (registroEliminar) {
        $http.post('/Canchas/Delete', registroEliminar)
        .success(function (data) {
            $scope.MostrarError = data.Error;
            $scope.MostrarAlerta = data.Alerta;
            $scope.Mensaje = data.Mensaje;

            if (data.Error == 'N' && data.Alerta == 'N') {
                var indice = $scope.ListaRegistros.indexOf(registroEliminar);
                $scope.ListaRegistros.splice(indice, 1);
                $scope.Limpiar();
                return;
            }
        })
        .error(function (data) {
            $scope.Mensaje = data;
            $scope.MostrarError = 'S';
            $scope.MostrarAlerta = 'N'
        });

    }

}



]);