/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular-resource.d.ts" />
var App;
(function (App) {
    var StudentListService = (function () {
        function StudentListService($q, $http) {
            this.qService = $q;
            this.config = {
                headers: {
                    "someheader": "somevalue"
                }
            };
            this.httpService = $http;
        }
        StudentListService.prototype.get = function () {
            var self = this;
            var deffered = self.qService.defer();
            self.httpService.get('/api/values', this.config).then(function (result) {
                if (result.status === 200) {
                    deffered.resolve(result.data);
                }
                else {
                    deffered.reject(result);
                }
            }, function (error) {
                deffered.reject(error);
            });
            return deffered.promise;
        };
        return StudentListService;
    })();
    App.StudentListService = StudentListService;
    StudentListService.$inject = ['$q', '$http'];
    angular.module('app').service('StudentListService', StudentListService);
})(App || (App = {}));
