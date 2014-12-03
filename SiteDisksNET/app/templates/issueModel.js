sitetaskapp.controller('IssueModelCtrl', function ($scope, $modalInstance, $http, issue, taskId) {
 
    $scope.issue = issue;
    $scope.taskId = taskId;

    $scope.save = function () {

        if ($scope.issue.TaskId == null)
            $scope.issue.TaskId = $scope.taskId;
        
        $http.post('/api/issues', $scope.issue).success(function (data, status) {

            //$scope.issue = data;
           
            toastr.success('Save Success!');
            $modalInstance.close();
        });
    }

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    }

})