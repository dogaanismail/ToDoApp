

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
                $scope.model.TotalUsers = result.data.TotalUsers;
                $scope.model.TotalTasks = result.data.TotalTasks;
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

        //GetAllEmployee
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
                console.log(obj);
                obj.Password = "1233345";
                obj.Id = "12244325";
                userService.createUser( obj).then(function (result) {
                        if (result.data.success === 1) {
                            $scope.flgMessage = true;
                            $scope.message = result.data.message;
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
            else {
                userService.updateUser(obj).then(function (result) {
                    if (result.data.success === 1) {
                        $scope.flgMessage = true;
                        $scope.message = result.data.message;
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
            params = {
                id: obj.Id
            }
            userService.deleteUser(obj).then(function (result) {
                if (result.data.success === 1) {
                    $scope.flgMessage = true;
                    $scope.message = result.data.message;
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