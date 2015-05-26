angular.module('CanchasController', []).controller('CanchasCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.ListaRegistros = {};
    $scope.Registro = {};
    $scope.Accion = 'nuevo';
    $scope.MostrarControles = false;

    $scope.MostrarError = {};

    $scope.Limpiar = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = false;
    };

    $scope.NuevoRegistro = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = true;
    };

    $scope.EditarRegistro = function (registroEditar) {
        $scope.Registro = registroEditar;
        $scope.Accion = 'editar';
        $scope.MostrarControles = true;
    }

    $http.get('/Canchas/GetAll').success(function (data) {
         
        $scope.Mensaje = data.Mensaje;

        //alert("Error:" + data.Error + " Data:" + data.Info + " Mensaje:" + data.Mensaje);

        if (data.Error == true) {
            $scope.ListaRegistros = {};
            $scope.MostrarError = 'S';
            return;
        }
        else {
            $scope.ListaRegistros = data.Info;
            $scope.MostrarError = 'N';
        }
    });


    $scope.Guardar = function () {
        if ($scope.Accion == 'nuevo') {
            $http.post('/Canchas/Create', $scope.Registro).success(function (data) {
                $scope.ListaRegistros.push(data);
            });
        }

        if ($scope.Accion == 'editar') {
            $http.post('/Canchas/Update', $scope.Registro).success(function (data) {
                // $scope.ListaCanchas.push(data);
            });
        }

        $scope.Limpiar();
    }


    $scope.EliminarRegistro = function (registroEliminar) {
        var response = $http({
            method: "post",
            url: "/Canchas/Delete",
            params: { id: JSON.stringify(registroEliminar.IdCancha) }
        });

        var indice = $scope.ListaRegistros.indexOf(registroEliminar);

        $scope.ListaRegistros.splice(indice, 1);

    }


}

]);