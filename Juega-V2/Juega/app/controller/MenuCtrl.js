angular.module('MenuController', []).controller('MenuCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.ListaRegistros = {};
    $scope.ListaMenu = {};
    $scope.ListaRoles = {};
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


    $http.get('/Menu/GetAll').success(function (data) {
        $scope.Mensaje = data.Mensaje;
        $scope.MostrarAlerta = data.Alerta;
        $scope.MostrarInfo = data.Info;
        $scope.MostrarError = data.Error;
         
        if (data.Error == 'S') {
            $scope.ListaRegistros = {};
            $scope.ListaMenu = {};
        }
        else {
            $scope.ListaRegistros = data.data;
            $scope.ListaMenu = data.data;
        }

    });
     
    $http.get('/Roles/GetAllRoles').success(function (data) {
        $scope.Mensaje = data.Mensaje;
        $scope.MostrarAlerta = data.Alerta;
        $scope.MostrarInfo = data.Info;
        $scope.MostrarError = data.Error;

        if (data.Error == 'S')  
            $scope.ListaRoles = {}; 
        else
            $scope.ListaRoles = data.data;

    });



    $scope.Guardar = function () {
        var url = $scope.Accion == 'nuevo' ? '/Menu/Create' : '/Menu/update';

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


    $scope.EliminarRegistro = function (registroEliminar) {
        $http.post('/Menu/Delete', registroEliminar)
        .success(function (data) {
            $scope.MostrarError = data.Error;
            $scope.MostrarAlerta = data.Alerta;
            $scope.MostrarInfo = data.Info;
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
            $scope.MostrarInfo = 'N'
        });

    }

}



]);