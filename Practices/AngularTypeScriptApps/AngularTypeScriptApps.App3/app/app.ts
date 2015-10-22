/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />

module App {
    "use strict"; // OOP mental context
    export class Config {
        constructor($routeProvider : ng.route.IRouteProvider) {
            console.log('I am in config constructor.');
            $routeProvider.when('/', {
                templateUrl:'partials/home/home.tpl.html'
            });
        }
    }

    export class HomeController {
        constructor() {
            console.log('I am in home controller constructor.');            
        }

        clickme(): void {
            alert('i m clicked. ');
        }
    }


    // angular mental context
    angular.module('app', ['ngRoute']);

    Config.$inject = ['$routeProvider'];
    angular.module('app').config(Config);
    angular.module('app').controller('HomeController', HomeController);
}