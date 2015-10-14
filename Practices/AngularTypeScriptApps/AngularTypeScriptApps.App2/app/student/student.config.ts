module App {
    export class StudentConfig {
        constructor($routeProvider : ng.route.IRouteProvider) {
            $routeProvider
                .when('/student-list', {
                    templateUrl: 'views/student/student-list/student-list.tpl.html',
                    controller: 'StudentListController',
                    controllerAs: 'vm'
                });

        }
    }

    StudentConfig.$inject = ['$routeProvider'];
    angular.module('app').config(StudentConfig);    
}