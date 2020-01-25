

//Dashboard Controller
app.controller('DashboardCtrl', ['$scope', 'dashboardService',
    function ($scope, dashboardService) {

        //Initialize data
        $scope.init = function () {

            $scope.model = {
                TotalUsers: 0,
                TotalTasks: 0,
            };

            dashboardService.getData().then(function (result) {
                console.log(result);
                $scope.model.TotalUsers = result.data.TotalUsers;
                $scope.model.TotalTasks = result.data.TotalTasks;
            });
        };

        $scope.init();

    }]);