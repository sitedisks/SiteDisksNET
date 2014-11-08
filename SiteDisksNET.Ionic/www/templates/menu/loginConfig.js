loginModule.config(function ($stateProvider) {
    $stateProvider
         .state('app', {
             url: "/alpha",
             abstract: true, // abstract give the /app as root
             templateUrl: "templates/menu/menu.html",
             controller: 'LoginCtrl'
         });
})