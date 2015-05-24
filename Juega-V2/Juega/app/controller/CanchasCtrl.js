angular.module('CanchasController', []).controller('CanchasCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.ListaCanchas = {};
    $scope.Registro = {};
    $scope.Accion = 'nuevo';
    $scope.MostrarControles = false;

    $scope.IniciarSesion = {};

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
           

        if (data == "-1") { 
            $scope.IniciarSesion = 'S';
            return;
        }
        else
        {
            $scope.ListaCanchas = data;
            $scope.IniciarSesion = 'N';
        }
    });


    $scope.Guardar = function () {
        if ($scope.Accion == 'nuevo') {
            $http.post('/Canchas/Create', $scope.Registro).success(function (data) {
                $scope.ListaCanchas.push(data);
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

        var indice = $scope.ListaCanchas.indexOf(registroEliminar);

        $scope.ListaCanchas.splice(indice, 1);

    }


}

]);