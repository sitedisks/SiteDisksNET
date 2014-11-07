(function () {

    'use strict'; // strict mode js
    app.config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {


        $stateProvider

          .state('app', {
              url: "/app",
              abstract: true,
              templateUrl: "templates/menu.html",
              controller: 'AppCtrl'
          })

          .state('app.search', {
              url: "/search",
              views: {
                  'menuContent': {
                      templateUrl: "templates/search.html"
                  }
              }
          })

          .state('app.browse', {
              url: "/browse",
              views: {
                  'menuContent': {
                      templateUrl: "templates/browse.html"
                  }
              }
          });
         
        // if none of the above states are matched, use this as the fallback
        $urlRouterProvider.otherwise('/app/playlists');
    }

})();
