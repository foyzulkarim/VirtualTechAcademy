var App;
(function (App) {
    var StudentListController = (function () {
        function StudentListController(studentListService) {
            this.studentListService = studentListService;
            this.getPosts();
        }
        StudentListController.prototype.successCallback = function (result) {
            return null;
        };
        StudentListController.prototype.getPosts = function () {
            this.studentListService.get().then(this.successCallback);
        };
        return StudentListController;
    })();
    App.StudentListController = StudentListController;
    StudentListController.$inject = ['StudentListService'];
    angular.module('app').controller('StudentListController', StudentListController);
})(App || (App = {}));
//# sourceMappingURL=student-list.controller.js.map