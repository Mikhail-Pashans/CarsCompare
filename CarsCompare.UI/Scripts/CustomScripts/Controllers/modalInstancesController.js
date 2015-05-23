var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.controller('modalInstancesCtrl', function modalInstancesCtrl($scope, $modalInstance, config, dataService) {
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
                    brandId: $scope.selectedBrand
                }
            });
            var modelsPromise = dataService.getData(config);
            modelsPromise.then(function (response) {
                $scope.models = response.models;
            });
        } else {
            $scope.selectedModel = null;
            $scope.selectedVersion = null;
            $scope.selectedModify = null;
        }
    });

    $scope.$watch('selectedModel', function (newValue) {
        if (newValue !== null) {
            angular.extend(config, {
                url: '/Home/GetVersionsByModelId',
                params: {
                    modelId: $scope.selectedModel
                }
            });
            var vearsionsPromise = dataService.getData(config);
            vearsionsPromise.then(function (response) {
                $scope.versions = response.versions;
            });
        } else {
            $scope.selectedVersion = null;
            $scope.selectedModify = null;
        }
    });

    $scope.$watch('selectedVersion', function (newValue) {
        if (newValue !== null) {
            angular.extend(config, {
                url: '/Home/GetModifiesByModelIdAndVersionId',
                params: {
                    modelId: $scope.selectedModel,
                    versionId: $scope.selectedVersion
                }
            });
            var modifiesPromise = dataService.getData(config);
            modifiesPromise.then(function (response) {
                $scope.modifies = response.modifies;
            });
        } else {
            $scope.selectedModify = null;
        }
    });

    $scope.ok = function () {
        var result = {
            brandId: $scope.selectedBrand,
            modelId: $scope.selectedModel,
            versionId: $scope.selectedVersion,
            modifyId: $scope.selectedModify
        };

        $modalInstance.close(result);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
})