var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.controller('compareCtrl', ['$scope', '$modal', '$log',
    function compareCtrl($scope, $modal, $log) {
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
                animation: true,
                templateUrl: 'ClientTemplates/modalInstanceTemplate.html',
                controller: 'modalInstancesCtrl',
                resolve: {
                    config: function () {
                        return config;
                    }
                }
            });

            modalInstance.result.then(function (result) {
                $scope.result = result;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        }
    }
])