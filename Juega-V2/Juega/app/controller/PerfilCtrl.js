angular.module('PerfilController', []).controller('PerfilCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.Cargando = 'S';

    $http.get('/Perfil/UsuarioLogin').success(function (data) {
        $scope.Mensaje = data.Mensaje;
        $scope.MostrarAlerta = data.Alerta;
        $scope.MostrarInfo = data.Info;
        $scope.MostrarError = data.Error;
        $scope.Cargando = 'N';
        if (data.Error == 'S')
            $scope.Usuario = {};
        else
            $scope.Usuario = data.data;
    });


    $scope.AgregarFoto = function () {
        var f = document.getElementById('file').files[0],
            r = new FileReader();
        r.onloadend = function (e) {
            var data = e.target.result;
            //send you binary data via $http or $resource or do anything else with it
            $scope.Usuario.FotoPrincipal_Stream = data;
        }
        r.readAsBinaryString(f);
    }

    $scope.uploadFile = function (files) {
        var fd = new FormData();
        //Take the first selected file
        fd.append("file", files[0]);

        $scope.Usuario.Foto = fd;
       // $scope.Usuario.Attachment = fd;
        alert("Foto preparada");
        //$http.post(uploadUrl, fd,
        //{
        //    withCredentials: true,
        //    headers: { 'Content-Type': undefined },
        //    transformRequest: angular.identity
        //}).success(function (data) {
        //    alert("Subido");
        //}
        //).error(function (data) {
        //    alert("Error");
        //});

    };

    $scope.onFileSelect = function ($files)
    {
        //$files: an array of files selected, each file has name, size, and type.
        alert("Foto subida");
        $scope.Usuario.Foto = $files;
     

        //for (var i = 0; i < $files.length; i++)
        //{
        //    var $file = $files[i];
        //    $scope.Usuario.Attachment = $file;


           
        //    //$upload.upload({
        //    //    url: '/Perfil/Editar_Perfil',
        //    //    file: $file,
        //    //    progress: function (e) { }
        //    //}).then(function (data, status, headers, config)
        //    //{
        //    //    // file is uploaded successfully
        //    //    console.log(data);
        //    //});
        //}
    }

    $scope.Guardar = function () {
        var url = '/Perfil/Editar_Perfil';

        $http.post(url, $scope.Usuario)
            .success(function (data) {
                $scope.MostrarError = data.Error;
                $scope.MostrarAlerta = data.Alerta;
                $scope.MostrarInfo = data.Info;
                $scope.Mensaje = data.Mensaje;

                if (data.Error == 'N' && data.Alerta == 'N') {
                    $scope.Usuario = data.data;
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