/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular-resource.d.ts" />


module App {
    export class StudentListService {
        private qService: ng.IQService;
        private httpService: ng.IHttpService;

        constructor($q: ng.IQService, $http: ng.IHttpService) {
            this.qService = $q;             
            this.httpService = $http;
        }

        get(): ng.IPromise<Object[]> {
            var self = this;
            var deffered = self.qService.defer();

            self.httpService.get('/api/values').then((result: any): void => {
                if (result.status === 200) {
                    deffered.resolve(result.data);
                } else {
                    deffered.reject(result);
                }
            }, error => {
                deffered.reject(error);
            });

            //var data = [
            //    { Id: 1, Name: "Student One", Phone: "01911831901", Address: "address 1", },
            //    { Id: 2, Name: "Student Two", Phone: "01911831902", Address: "address 2", },
            //    { Id: 3, Name: "Student Three", Phone: "01911831903", Address: "address 3", },
            //    { Id: 4, Name: "Student Four", Phone: "01911831904", Address: "address 4", },
            //    { Id: 5, Name: "Student Five", Phone: "01911831905", Address: "address 5", },
            //    { Id: 6, Name: "Student Six", Phone: "01911831906", Address: "address 6", }
            //];
            //deffered.resolve(data);
            return deffered.promise;
        }
    }

    StudentListService.$inject = ['$q','$http'];
    angular.module('app').service('StudentListService', StudentListService);
}