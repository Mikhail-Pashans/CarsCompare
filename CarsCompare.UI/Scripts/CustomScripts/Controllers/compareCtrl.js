var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.controller('compareCtrl', function compareCtrl($scope, $modal, $log, dataService) {
    'use strict';

    var conf = {
        method: 'GET',
        url: '/Home/GetBrands',
        timeout: 15000
    };

    var promiseObj = dataService.getData(conf);
    promiseObj.then(function (response) {
        $scope.brands = response.brands;
    });

    $scope.open = function () {
        var modalInstance = $modal.open({
            animation: false,
            templateUrl: 'ClientTemplates/modalInstanceTemplate.html',
            controller: 'modalInstancesCtrl',
            resolve: {
                conf: function () {
                    return conf;
                },
                brands: function () {
                    return $scope.brands;
                }
            }
        });

        modalInstance.result.then(function (selectedModifyId) {
            $scope.selectedModifyId = selectedModifyId;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
})