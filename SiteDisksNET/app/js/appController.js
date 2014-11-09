var sitetaskapp = angular.module('sitetask', ['ui.bootstrap']);

sitetaskapp.controller('sitetaskCtrl', function ($scope,  $modal,  $http) {

    $scope.message = "Hello World";
    $scope.tasks = [];
  
    $scope.IssueTrack = function (task) {
        $scope.issues = task.Issues;
        $scope.taskId = task.Id;
    }

    $scope.openIssueModel = function (issue) {
     
        var issueModel = $modal.open({
            templateUrl: 'templates/issueModel.html',
            controller: 'IssueModelCtrl',
            resolve: {
                issue: function () {
                    return issue;
                },
                taskId: function () {
                    return $scope.taskId;
                }
            }
        });

        issueModel.result.then(function () {
            //Save the Issue 
        });
    }

    $http.get('/api/tasks').success(function (data, sataus) {
        $scope.tasks = data;
    });
});