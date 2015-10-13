module App {
    export class StudentListController {
        data: Object[];
        studentListService: StudentListService;
        constructor(studentListService: App.StudentListService) {
            this.studentListService = studentListService;
            this.getPosts();
        }

        
        successCallback(result: Object[]): Object {
            return null;
        }

        getPosts(): void {
                
            this.studentListService.get().then(this.successCallback);
        }
    }

    StudentListController.$inject = ['StudentListService'];
    angular.module('app').controller('StudentListController', StudentListController);
}