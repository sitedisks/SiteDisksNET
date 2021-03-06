﻿(function () {

    'use strict'; // strict mode js
    app.config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider

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
          })

        .state('app.me', {
            url: "/me",
            views: {
                'menuContent': {
                    templateUrl: "templates/me.html"
                }
            }
        });

        // if none of the above states are matched, use this as the fallback
        //$urlRouterProvider.otherwise('/app/playlists');
        $urlRouterProvider.otherwise('/alpha/dashboard');
    }

})();
