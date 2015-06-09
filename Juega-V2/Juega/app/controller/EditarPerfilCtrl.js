angular.module('PerfilController', []).controller('EditarPerfilCtrl', ['$scope', '$http', function ($scope, $http)
{

    $scope.Usuario = {};
    $scope.Accion = 'nuevo';
    $scope.MostrarControles = false;
    $scope.MostrarError = {};
    $scope.MostrarAlerta = {};
    $scope.MostrarInfo = {};
    $scope.Mensaje = {};

    $scope.EditarRegistro = function (registroEditar)
    {
        $scope.Registro = registroEditar;
        $scope.Accion = 'editar';
        $scope.MostrarControles = true;
    }

    $scope.Limpiar = function ()
    {
        $scope.Registro = {};
        $scope.Accion = 'nuevo';
        $scope.MostrarControles = false;
        $scope.MostrarAlerta = 'N';
        $scope.MostrarInfo = 'N';
    };

    $http.get('/Perfil/Editar_Perfil').success(function (data)
    {
        $scope.Mensaje = data.Mensaje;
        $scope.MostrarAlerta = data.Alerta;
        $scope.MostrarInfo = data.Info;
        $scope.MostrarError = data.Error;

        if (data.Error == 'S')
            $scope.Usuario = {};
        else
            $scope.Usuario = data.data;

    });

    $scope.Guardar = function ()
    {
        var url = $scope.Accion == 'editar' ? '/Perfil/Editar_Perfil' : '/Perfil/update';

        $http.post(url, $scope.Registro)
            .success(function (data)
            {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;

            })

            .error(function (data)
            {
                $scope.Mensaje = data;
                $scope.MostrarError = 'S';
                $scope.MostrarAlerta = 'N'
                $scope.MostrarInfo = 'N'
            });
    }
}



]);