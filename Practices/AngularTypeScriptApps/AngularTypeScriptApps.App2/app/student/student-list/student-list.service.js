var App;
(function (App) {
    var StudentListService = (function () {
        function StudentListService($q) {
            this.qService = $q;
        }
        StudentListService.prototype.get = function () {
            var self = this;
            var deffered = self.qService.defer();
            var data = [
                { Id: 1, Name: "Student One", Phone: "01911831901", Address: "address 1", },
                { Id: 2, Name: "Student Two", Phone: "01911831902", Address: "address 2", },
                { Id: 3, Name: "Student Three", Phone: "01911831903", Address: "address 3", },
                { Id: 4, Name: "Student Four", Phone: "01911831904", Address: "address 4", },
                { Id: 5, Name: "Student Five", Phone: "01911831905", Address: "address 5", },
                { Id: 6, Name: "Student Six", Phone: "01911831906", Address: "address 6", }
            ];
            deffered.resolve(data);
            return deffered.promise;
        };
        return StudentListService;
    })();
    App.StudentListService = StudentListService;
    StudentListService.$inject = ['$q'];
    angular.module('app').service('StudentListService', StudentListService);
})(App || (App = {}));
