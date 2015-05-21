app.controller("compareCtrl", function ($scope, $http) {
    $http.post('/Home/GetData')
        .success(function(response) {
            $scope.response = response;            
        });
});