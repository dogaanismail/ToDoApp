angular.module('todoController')
    .service('dashboardService', ['$http', function ($http) {

        var urlBase = "https://localhost:44387/api/dashboard/";

        this.getData = function () {
            return $http.get(urlBase + "getdata");
        };

    }]);