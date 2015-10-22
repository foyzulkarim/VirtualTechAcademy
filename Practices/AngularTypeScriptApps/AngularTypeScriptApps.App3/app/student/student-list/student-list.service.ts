/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular-resource.d.ts" />


module App {
    export class StudentListService {
        private qService: angular.IQService;
        private httpService: angular.IHttpService;
        private config: angular.IRequestShortcutConfig;

        constructor($q: ng.IQService, $http: ng.IHttpService) {
            this.qService = $q;
            this.config = {
                headers: {
                    "someheader": "somevalue"
                }
            };
            this.httpService = $http;
        }

        get(): ng.IPromise<Object[]> {
            var self = this;
            var deffered = self.qService.defer();            
            self.httpService.get('/api/values',this.config).then((result: any): void => {
                if (result.status === 200) {
                    deffered.resolve(result.data);
                } else {
                    deffered.reject(result);
                }
            }, error => {
                deffered.reject(error);
            });

            return deffered.promise;
        }
    }

    StudentListService.$inject = ['$q', '$http'];
    angular.module('app').service('StudentListService', StudentListService);
}