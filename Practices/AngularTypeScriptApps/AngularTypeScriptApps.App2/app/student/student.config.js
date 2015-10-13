var App;
(function (App) {
    var StudentConfig = (function () {
        function StudentConfig($routeProvider) {
            $routeProvider
                .when('/student-list', {
                templateUrl: 'views/student/student-list/student-list.tpl.html',
                controller: 'StudentListController'
            })
                .when('/student-manage', {
                templateUrl: 'views/student/student-manage/student-manage.tpl.html',
                controller: 'StudentManageController'
            });
        }
        return StudentConfig;
    })();
    App.StudentConfig = StudentConfig;
    StudentConfig.$inject = ['$routeProvider'];
    angular.module('app').config(StudentConfig);
})(App || (App = {}));
//# sourceMappingURL=student.config.js.map