var App;
(function (App) {
    var StudentListController = (function () {
        function StudentListController(studentListService) {
            this.studentListService = studentListService;
            this.students = [];
            this.heading = 'test';
            this.getPosts();
        }
        StudentListController.prototype.getPosts = function () {
            var self = this;
            self.studentListService.get().then(function (result) {
                self.students = result;
                self.heading += ' ' + self.students.length;
            });
        };
        return StudentListController;
    })();
    App.StudentListController = StudentListController;
    StudentListController.$inject = ['StudentListService'];
    angular.module('app').controller('StudentListController', StudentListController);
})(App || (App = {}));
