angular.module('todoController')
    .service('userService', ['$http', function ($http) {

        var urlBase = 'https://localhost:44387/api/users/'; 

        this.getUsers = function () {
            return $http.get(urlBase + "getusers");
        };

        this.getUserById = function (id) {
            return $http.get(urlBase + "getuser" + '/' + id);
        };

        this.createUser = function (obj) {
            return $http.post(urlBase + "createuser", obj);
        };

        this.updateUser = function (obj) {
            return $http.post(urlBase + "updateuser" + '/' , obj);
        };

        this.deleteUser = function (id) {
            return $http.delete(urlBase + "deleteUser" + '/' + id);
        };

    }]);