angular.module('MenuController', []).controller('PageMenuCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.ListaRegistros = {};  

    $http.get('/Menu/GetMenu').success(function (data) {

        if (data.Error == 'S')
        {
            $scope.ListaMenu = {};
        }
        else
        {
            $scope.ListaMenu = data.data;
        }

    }); 

}



]);