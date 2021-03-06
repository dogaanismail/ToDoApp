﻿angular.module('todoController')
    .service('taskService', ['$http', function ($http) {

        var urlBase = 'https://localhost:44387/api/tasks/';

        this.getTasks = function () {
            return $http.get(urlBase + "gettasks");
        };

        this.getTaskById = function (id) {
            return $http.get(urlBase + "gettaskbyid" + '/' + id);
        };

        this.createTask = function (obj) {
            return $http.post(urlBase + "createtask" + '/', obj);
        };

        this.updateTask = function (obj) {
            return $http.post(urlBase + "updatetask" + '/', obj);
        };

        this.deleteTask = function (obj) {
            return $http.post(urlBase + "deletetask" + '/', obj);
        };

        this.checkTasks = function () {
            return $http.get(urlBase + "checktasks");
        };

    }]);