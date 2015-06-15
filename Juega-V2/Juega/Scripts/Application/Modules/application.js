﻿"use strict";
(function () {
    angular.module("application", ["ngRoute", "akFileUploader"])
           .config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
               $routeProvider.when("/", { 
                   controller:"homeCtrl"
               });
               $locationProvider.html5Mode({
                   enabled: true,
                   requireBase: false
               });
           }]);
})();
