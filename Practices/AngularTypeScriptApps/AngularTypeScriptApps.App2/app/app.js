var App;
(function (App) {
    // OOP mental context
    var Config = (function () {
        function Config() {
            console.log('I am in config constructor.');
        }
        return Config;
    })();
    var HomeController = (function () {
        function HomeController() {
            console.log('I am in home controller constructor.');
        }
        HomeController.prototype.clickme = function () {
            console.log('I am in home controller click me method.');
        };
        return HomeController;
    })();
    App.HomeController = HomeController;
    // angular mental context
    angular.module('app', []);
    angular.module('app').config(Config);
    angular.module('app').controller('HomeController', HomeController);
})(App || (App = {}));
//# sourceMappingURL=app.js.map