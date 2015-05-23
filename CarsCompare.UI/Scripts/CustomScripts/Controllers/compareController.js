var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.controller('compareCtrl', function compareCtrl($scope, $modal, $log, dataService) {
    'use strict';

    var config = {
        method: 'GET',
        url: '',
        params: {},
        cache: true,
        timeout: 15000
    };

    $scope.cars = [];

    $scope.open = function () {
        var modalInstance = $modal.open({
            animation: false,
            templateUrl: 'ClientTemplates/modalInstanceTemplate.html',
            controller: 'modalInstancesCtrl',
            resolve: {
                config: function () {
                    return config;
                }
            }
        });

        modalInstance.result.then(function (result) {
            $scope.selectedModifyId = result.modifyId;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };
})