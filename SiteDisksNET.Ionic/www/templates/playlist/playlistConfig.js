playlistModule.config(function ($stateProvider) {

    $stateProvider
         .state('app.playlists', {
             url: "/playlists",
             views: {
                 'menuContent': {
                     templateUrl: "templates/playlist/playlists.html",
                     controller: 'PlaylistsCtrl'
                 }
             }
         })
          .state('app.single', {
              url: "/playlists/:playlistId",
              views: {
                  'menuContent': {
                      templateUrl: "templates/playlist/playlist.html",
                      controller: 'PlaylistCtrl'
                  }
              }
          });
})