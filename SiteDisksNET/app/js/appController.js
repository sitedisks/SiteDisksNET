var sitetaskapp = angular.module('sitetask', ['ui.bootstrap']);

sitetaskapp.controller('sitetaskCtrl', function ($scope,  $modal,  $http) {

    $scope.message = "Hello World";
    $scope.tasks = [];
  
    $scope.IssueTrack = function (task) {
    
        $scope.taskId = task.Id;
        $http.get('/api/issues?id=' + $scope.taskId).success(function (data, status) {
            $scope.issues = data;
        });
    }

    $scope.IsDone = function (done) {
        if (done)
            return "Done";
        else
            return "Process";
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
            // refresh the table
            $http.get('/api/issues?id=' + $scope.taskId).success(function (data, status) {
                $scope.issues = data;
            });

        });
    }

    $http.get('/api/tasks').success(function (data, status) {
        $scope.tasks = data;
    });
});