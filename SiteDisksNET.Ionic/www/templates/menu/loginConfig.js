loginModule.config(function ($stateProvider) {
    $stateProvider
         .state('app', {
             url: "/app",
             abstract: true,
             templateUrl: "templates/menu/menu.html",
             controller: 'LoginCtrl'
         });
})