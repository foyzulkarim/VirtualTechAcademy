module App {
    // OOP mental context
    class Config {
        constructor() {
            console.log('I am in config constructor.');
        }
    }

    export class HomeController {
        constructor() {
            console.log('I am in home controller constructor.');            
        }

        clickme(): void {
            console.log('I am in home controller click me method.');                        
        }
    }


    // angular mental context
    angular.module('app', []);
    angular.module('app').config(Config);
    angular.module('app').controller('HomeController', HomeController);
}