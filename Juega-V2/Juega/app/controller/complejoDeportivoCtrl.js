angular.module('ComplejoDeportivoController', []).controller('complejoDeportivoCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.ListaRegistros = {};
    $scope.Registro = {};
    $scope.Accion = 'nuevo';
    $scope.MostrarControles = false;
    $scope.IniciarSesion = {};


    $scope.Limpiar = function () {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = false;
    };

    $scope.cargar = function () {
      var info =  $http.get('/ComplejoDeportivo/GetAll');
        alert(info);
    };

    $scope.NuevoRegistro = function ()
    {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = true;
    };

    $scope.EditarRegistro = function (registroEditar) {
        $scope.Registro = registroEditar;
        $scope.Accion = 'editar';
        $scope.MostrarControles = true;
    }

    $http.get('/ComplejoDeportivo/GetAll').success(function (data) {
        if (data == "-1") {
            $scope.IniciarSesion = 'S';
            return;
        }
        else {
            $scope.ListaCanchas = data;
            $scope.IniciarSesion = 'N';
        }
    });


    $scope.Guardar = function ()
    {
        if ($scope.Accion == 'nuevo') {
            $http.post('/ComplejoDeportivo/Create', $scope.Registro).success(function (data) {
                $scope.ListaRegistros.push(data);
            });
        }

        if ($scope.Accion == 'editar') {
            $http.post('/ComplejoDeportivo/Update', $scope.Registro).success(function (data) {
                // $scope.ListaCarreras.push(data);
            });
        }
         
        $scope.Limpiar();
    }


    $scope.EliminarRegistro = function (registroEliminar) {
        var response = $http({
            method: "post",
            url: "/ComplejoDeportivo/Delete",
            params: { id: JSON.stringify(registroEliminar.IdComplejoDeportivo) }
        });

        var indice = $scope.ListaRegistros.indexOf(registroEliminar);

        $scope.ListaRegistros.splice(indice, 1);

    }


}

]);