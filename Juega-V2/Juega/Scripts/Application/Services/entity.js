"use strict";
(function () {
    angular.module("application")
           .factory("entityService", ["akFileUploaderService", function (akFileUploaderService) {
               var saveTutorial = function (tutorial) {
                   return akFileUploaderService.saveModel(tutorial, "/Perfil/Editar_Perfil");
               };
               return {
                   saveTutorial: saveTutorial
               };
           }]);
})();