angular.module('PerfilController', []).controller('PerfilCtrl', ['$scope', '$http', function ($scope, $http) {


    $scope.Usuario = {};

    $http.get('/Perfil/UsuarioLogin').success(function (data)
    {
        $scope.Usuario = data.data;
    });

    $scope.Guardar = function () {
        var url = '/Perfil/Editar_Perfil';

        $http.post(url, Usuario)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;
                $scope.Usuario = data.data;

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