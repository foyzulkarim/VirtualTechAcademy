module App {
    export class StudentListController {
        students: Object[];
        heading: string;             
        studentListService: StudentListService;

        constructor(studentListService: App.StudentListService) {
            this.studentListService = studentListService;
            this.students = [];
            this.heading = 'test';
            this.getPosts();
        }

        getPosts(): void {
            var self = this;
            self.studentListService.get().then((result: Object[]): void => {
                self.students = result;
                self.heading += ' ' + self.students.length;
            });
        }
    }

    StudentListController.$inject = ['StudentListService'];
    angular.module('app').controller('StudentListController', StudentListController);
}