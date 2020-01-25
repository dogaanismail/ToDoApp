
                                                /* --------------------------           ANGULARJS CONTROLLERS ------------------------------------------------ */


//Dashboard Controller
app.controller('DashboardCtrl', ['$scope', 'dashboardService',
    function ($scope, dashboardService) {

        //Initialize data
        $scope.init = function () {

            $scope.model = {
                TotalUsers: 0,
                TotalTasks: 0,
            };

            $scope.getDashboardData();
        };

        $scope.getDashboardData = function () {
            dashboardService.getData().then(function (result) {
                $scope.model.TotalUsers = result.data.TotalUsers;
                $scope.model.TotalTasks = result.data.TotalTasks;
            });
        };

        $scope.init();
    }]);


//Task Contr0ller
app.controller('TaskCtrl', ['$scope', 'taskService',
    function ($scope, taskService) {

        //Initialize data
        $scope.init = function () {

            $scope.model = {
                TaskId: 0,
                TaskName: '',
                TaskTitle: '',
                TaskDescription: '',
                Deadline: null,
                CreatedDate: null
            };

            $scope.message = "";
            //for display message of user   
            $scope.flgMessage = false;
            $scope.getTasks();        
        };

        //hide message
        $scope.hideMessage = function () {
            //make message flg false for hide message
            $scope.flgMessage = false;
            $("#message").removeClass("alert alert-success").removeClass("alert alert-danger");
            $("#icon").removeClass("fa-check").removeClass("fa-ban");

            $scope.flgMessage1 = false;
            $("#message1").removeClass("alert alert-success").removeClass("alert alert-danger");
            $("#icon1").removeClass("fa-check").removeClass("fa-ban");
        };

        $scope.getTasks = function () {
            taskService.getTasks().then(function (result) {
                $scope.lstTasks = result.data;
                console.log(result);
            });
        };

        //Reset data
        $scope.reset = function () {
            $scope.model = {
                TaskId: 0,
                TaskName: '',
                TaskTitle: '',
                TaskDescription: '',
                Deadline: null,
                CreatedDate: null
            };
        };

        //Create Task
        $scope.createTask = function (obj) {
            $scope.hideMessage();

            taskService.createTask(obj).then(function (result) {
                if (result.data === 200) {
                    $scope.flgMessage = true;
                    $scope.message = "Task has been created successfully !";
                    $("#message").addClass("alert alert-success");
                    $("#icon").addClass("glyphicon glyphicon-ok");
                    $scope.getTasks();
                    $scope.reset();
                }
                else {
                    $scope.flgMessage = true;
                    $scope.message = result.data.message;
                    $("#message").addClass("alert alert-danger");
                    $("#icon").addClass("glyphicon glyphicon-warning-sign");
                }
            });
        };

        //Update Task
        $scope.updateTask = function (obj) {
            $scope.hideMessage();

            taskService.updateTask(obj).then(function (result) {
                if (result.data === 200) {
                    $scope.flgMessage = true;
                    $scope.message = "Task has been updated successfully !";
                    $("#message").addClass("alert alert-success");
                    $("#icon").addClass("glyphicon glyphicon-ok");
                    $scope.getTasks();
                    $scope.reset();
                }
                else {
                    $scope.flgMessage = true;
                    $scope.message = result.data.message;
                    $("#message").addClass("alert alert-danger");
                    $("#icon").addClass("glyphicon glyphicon-warning-sign");
                }
            });
        };

        //Delete Task
        $scope.deleteTask = function (obj) {
            $scope.hideMessage();

            taskService.deleteTask(obj).then(function (result) {
                if (result.data === 200) {
                    $scope.flgMessage = true;
                    $scope.message = "Task has been deleted successfully !";
                    $("#message").addClass("alert alert-success");
                    $("#icon").addClass("glyphicon glyphicon-ok");
                    $scope.getTasks();
                    $scope.reset();
                }
                else {
                    $scope.flgMessage = true;
                    $scope.message = result.data.message;
                    $("#message").addClass("alert alert-danger");
                    $("#icon").addClass("glyphicon glyphicon-warning-sign");
                }
            });
        };

        $scope.init();
    }]);


//Application User Controller
app.controller('UserCtrl', ['$scope', 'userService',
    function ($scope, userService) {
        //Initialize data
        $scope.init = function () {
            $scope.model = {
                Id: '',
                Email: '',
                UserName: '',
            };

            //for user Detail
            $scope.flgUserDetail = false;

            //for user list
            $scope.flgTable = true;

            //for display message of user   
            $scope.flgMessage = false;

            $scope.flgUser = true;
            $scope.showCreate = false;
            $scope.showEdit = false;

            //for showing message
            $scope.flgMessage1 = false;
            $scope.message = "";
            $scope.message1 = "";

            $scope.UserState = "";
            $scope.getAllUser();
            //$scope.getAllRoles();
        };

        //hide message
        $scope.hideMessage = function () {
            //make message flg false for hide message
            $scope.flgMessage = false;
            $("#message").removeClass("alert alert-success").removeClass("alert alert-danger");
            $("#icon").removeClass("fa-check").removeClass("fa-ban");

            $scope.flgMessage1 = false;
            $("#message1").removeClass("alert alert-success").removeClass("alert alert-danger");
            $("#icon1").removeClass("fa-check").removeClass("fa-ban");
        };

        //GetAllUsers
        $scope.getAllUser = function () {
            var table = $("#userTable").DataTable();
            table.clear();
            table.destroy();
            userService.getUsers()
                .then(function (result) {
                    $scope.lstUsers = result.data;

                    setTimeout(function () {
                        $('#userTable').DataTable({
                            "aoColumnDefs": [{
                                "bSortable": false,
                                "aTargets": [-1]
                            }],
                            "paging": true,
                            "lengthChange": true,
                            "searching": true,
                            "ordering": true,
                            "info": true,
                            "autoWidth": false
                        });
                    }, 500);

                });

        };

        //Open user form
        $scope.addUser = function () {
            //make table flg false for display message
            $scope.flgTable = false;
            $scope.showCreate = true;
            $scope.showEdit = false;
            $scope.UserState = "> Add an user";
        };

        //Edit Users
        $scope.editUser = function (obj) {
            $scope.model.Id = obj.Id;
            $scope.model.Email = obj.Email;
            $scope.model.UserName = obj.UserName;
            $scope.flgTable = false;
            $scope.showCreate = false;
            $scope.showEdit = true;
            $scope.UserState = "> Update an user";
        };

        //Create/update Usesr
        $scope.createUser = function (obj) {
            $scope.hideMessage();

            if ($scope.showCreate === true) {
                //Check password and confirm password is same
                if (obj.Password !== obj.CPassword) {
                    $scope.flgMessage = true;
                    $scope.message = "Password and Confirm Password must be same.";
                    $("#message").addClass("alert alert-danger");
                    $("#icon").addClass("glyphicon glyphicon-warning-sign");
                }
                else {
                    userService.createUser(obj).then(function (result) {
                        console.log(result);
                        if (result.data === 200) {
                            $scope.flgMessage = true;
                            $scope.message = "User has been created successfully !";
                            $("#message").addClass("alert alert-success");
                            $("#icon").addClass("glyphicon glyphicon-ok");
                            $scope.getAllUser();
                            $scope.reset();
                        }
                        else {
                            $scope.flgMessage = true;
                            $scope.message = result.data.message;
                            $("#message").addClass("alert alert-danger");
                            $("#icon").addClass("glyphicon glyphicon-warning-sign ");
                        }
                    });
                }
            }
            else {
                userService.updateUser(obj).then(function (result) {
                    if (result.data === 200) {
                        $scope.flgMessage = true;
                        $scope.message = "User has been updated successfully !";
                        $("#message").addClass("alert alert-success");
                        $("#icon").addClass("glyphicon glyphicon-ok");
                        $scope.getAllUser();
                        $scope.reset();
                    }
                    else {
                        $scope.flgMessage = true;
                        $scope.message = result.data.message;
                        $("#message").addClass("alert alert-danger");
                        $("#icon").addClass("glyphicon glyphicon-warning-sign ");
                    }
                });
            }

        };

        //Delete User
        $scope.deleteUser = function (obj) {
            $scope.hideMessage();

            userService.deleteUser(obj).then(function (result) {
                if (result.data === 200) {
                    $scope.flgMessage = true;
                    $scope.message = "User has been deleted successfully !";
                    $("#message").addClass("alert alert-success");
                    $("#icon").addClass("glyphicon glyphicon-ok");
                    $scope.getAllUser();
                    $scope.reset();
                }
                else {
                    $scope.flgMessage = true;
                    $scope.message = result.data.message;
                    $("#message").addClass("alert alert-danger");
                    $("#icon").addClass("glyphicon glyphicon-warning-sign");
                }
            });
        };

        //Get all roles
        //$scope.getAllRoles = function () {
        //    roleService.getRoles()
        //        .then(function (result) {
        //            $scope.lstRoles = result.data;
        //        });
        //};

        function formatDate(d) {
            date = new Date(d);
            var dd = date.getDate();
            var mm = date.getMonth() + 1;
            var yyyy = date.getFullYear();
            if (dd < 10) { dd = '0' + dd }
            if (mm < 10) { mm = '0' + mm };
            return d = yyyy + '-' + mm + '-' + dd;
        }

        //Reset data
        $scope.reset = function () {
            $scope.flgTable = true;
            $scope.flgUserDetail = false;
            $scope.flgUser = true;
            $scope.model = {
                Id: '',
                Email: '',
                UserName: '',
                Password: '',
            };
            $("#liTab_2").removeClass("active");
            $("#tab_2").removeClass("active");
            $("#liTab_1").addClass("active");
            $("#tab_1").addClass("active");
        };
        $scope.init();
    }]);