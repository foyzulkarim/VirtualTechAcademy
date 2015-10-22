/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />
var App;
(function (App) {
    "use strict"; // OOP mental context
    var Config = (function () {
        function Config($routeProvider) {
            console.log('I am in config constructor.');
            $routeProvider.when('/', {
                templateUrl: 'partials/home/home.tpl.html'
            });
        }
        return Config;
    })();
    App.Config = Config;
    var HomeController = (function () {
        function HomeController() {
            console.log('I am in home controller constructor.');
        }
        HomeController.prototype.clickme = function () {
            alert('i m clicked. ');
        };
        return HomeController;
    })();
    App.HomeController = HomeController;
    // angular mental context
    angular.module('app', ['ngRoute']);
    Config.$inject = ['$routeProvider'];
    angular.module('app').config(Config);
    angular.module('app').controller('HomeController', HomeController);
})(App || (App = {}));
