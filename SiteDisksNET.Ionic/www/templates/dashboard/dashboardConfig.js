dashboardModule.config(function ($stateProvider) {
    $stateProvider
     .state('app.dashboard', {
         url: "/dashboard",
         views: {
             'menuContent': {
                 templateUrl: "templates/dashboard/dashboard.html"
             }
         }
     })
})