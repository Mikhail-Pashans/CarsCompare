var carsCompareApp = angular.module('carsCompareControllers');

carsCompareApp.controller('compareCtrl',
    [
        '$scope', '$modal', '$log', 'dataService',
        function compareCtrl($scope, $modal, $log, dataService) {
            'use strict';

            var config = {
                method: 'GET',
                url: '',
                params: {},
                cache: false,
                timeout: 15000
            };

            angular.extend(config, {
                url: '/Home/GetParamGroupsWithParamNames'
            });
            var promiseObject = dataService.getData(config);
            promiseObject.then(function (response) {
                $scope.paramGroups = response.paramGroups.map(function (item) {
                    return new ParamGroup(item);
                });
            });

            $scope.cars = [];

            $scope.addCar = function () {
                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: 'ClientTemplates/modalInstanceTemplate.html',
                    controller: 'modalInstancesCtrl',
                    resolve: {
                        config: function () {
                            return config;
                        },
                        car: function() {
                            return null;
                        }
                    }
                });

                modalInstance.result.then(function (car) {
                    $scope.cars.push(car);
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.clearCars = function () {
                $scope.cars = [];
            };

            $scope.changeCar = function (index) {
                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: 'ClientTemplates/modalInstanceTemplate.html',
                    controller: 'modalInstancesCtrl',
                    resolve: {
                        config: function () {
                            return config;
                        },
                        car: function () {
                            return $scope.cars[index];
                        }
                    }
                });

                modalInstance.result.then(function (car) {
                    $scope.cars.splice(index, 1, car);
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.removeCar = function (index) {
                $scope.cars.splice(index, 1);
            };
        }
    ]);