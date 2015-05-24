var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.controller('modalInstancesCtrl', ['$scope', '$modalInstance', 'dataService', 'config',
    function modalInstancesCtrl($scope, $modalInstance, dataService, config) {
        'use strict';

        $scope.brands = null;
        $scope.models = null;
        $scope.versions = null;
        $scope.modifies = null;

        $scope.selectedBrand = null;
        $scope.selectedModel = null;
        $scope.selectedVersion = null;
        $scope.selectedModify = null;

        $scope.isModelsDisabled = function () {
            return $scope.selectedBrand === null;
        };
        $scope.isVersionsDisabled = function () {
            return $scope.selectedBrand === null || $scope.selectedModel === null;
        };
        $scope.isModifiesDisabled = function () {
            return $scope.selectedBrand === null || $scope.selectedModel === null || $scope.selectedVersion === null;
        };

        angular.extend(config, {
            url: '/Home/GetBrands'
        });
        var brandsPromise = dataService.getData(config);
        brandsPromise.then(function (response) {
            $scope.brands = response.brands;
        });

        $scope.$watch('selectedBrand', function (newValue) {
            if (newValue !== null) {
                angular.extend(config, {
                    url: '/Home/GetModelsByBrandId',
                    params: {
                        brandId: $scope.selectedBrand.id
                    }
                });
                var modelsPromise = dataService.getData(config);
                modelsPromise.then(function (response) {
                    $scope.models = response.models;
                });
            }
            $scope.selectedModel = null;
            $scope.selectedVersion = null;
            $scope.selectedModify = null;
        });

        $scope.$watch('selectedModel', function (newValue) {
            if (newValue !== null) {
                angular.extend(config, {
                    url: '/Home/GetVersionsByModelId',
                    params: {
                        modelId: $scope.selectedModel.id
                    }
                });
                var vearsionsPromise = dataService.getData(config);
                vearsionsPromise.then(function (response) {
                    $scope.versions = response.versions;
                });
            }
            $scope.selectedVersion = null;
            $scope.selectedModify = null;
        });

        $scope.$watch('selectedVersion', function (newValue) {
            if (newValue !== null) {
                angular.extend(config, {
                    url: '/Home/GetModifiesByModelIdAndVersionId',
                    params: {
                        modelId: $scope.selectedModel.id,
                        versionId: $scope.selectedVersion.id
                    }
                });
                var modifiesPromise = dataService.getData(config);
                modifiesPromise.then(function (response) {
                    $scope.modifies = response.modifies;
                });
            }
            $scope.selectedModify = null;
        });

        $scope.ok = function () {
            var result = {
                brand: $scope.selectedBrand,
                model: $scope.selectedModel,
                version: $scope.selectedVersion,
                modify: $scope.selectedModify
            };

            $modalInstance.close(result);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }
])