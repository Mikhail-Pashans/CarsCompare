app.controller("compareCtrl", function ($scope, $http) {
    $http.get('/Home/GetData')
        .success(function(response) {
            $scope.brands = response.brands;
            $scope.models = response.models;
            $scope.versions = response.versions;
            $scope.modifies = response.modifies;
            $scope.params = response.params;
            $scope.paramNames = response.paramNames;
            $scope.paramGroups = response.paramGroups;
        });
});