angular.module('Perfil_UsuarioController', []).controller('Perfil_UsuarioCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.Usuario = {};
  
    //$http.get('/Perfil_Usuario/Obtener_Perfil').success(function (data)
    //{
    //    $scope.Usuario = data.data;

    //});


    $http.get('/Perfil_Usuario/Index').success(function (data) {
        $scope.Usuario = data.data;

    });

   




}



]);