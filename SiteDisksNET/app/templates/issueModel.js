sitetaskapp.controller('IssueModelCtrl', function ($scope, $modalInstance, $http, issue) {
 
    $scope.issue = issue;
    $scope.save = function () {
        $http.post('/api/tasks', $scope.issue).success(function (data, sataus) {


            $scope.issue = data;
        });
    }

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    }

})