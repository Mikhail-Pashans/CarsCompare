var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.controller('modalInstancesCtrl', ['$scope', '$modalInstance', 'dataService', 'config',
    function modalInstancesCtrl($scope, $modalInstance, dataService, config) {
        'use strict';

        $scope.brands = null;
        $scope.models = null;
        $scope.versions = null;
        $scope.modifies = null;
        $scope.params = null;

        $scope.selectedBrand = null;
        $scope.selectedModel = null;
        $scope.selectedVersion = null;
        $scope.selectedModify = null;

        $scope.isModelsDisabled = function () {
            return $scope.selectedBrand === null || $scope.brands === null;
        };
        $scope.isVersionsDisabled = function () {
            return $scope.selectedBrand === null || $scope.selectedModel === null || $scope.versions === null;
        };
        $scope.isModifiesDisabled = function () {
            return $scope.selectedBrand === null || $scope.selectedModel === null || $scope.selectedVersion === null || $scope.modifies === null;
        };
        $scope.isOKButtonDisabled = function () {
            return $scope.selectedBrand === null || $scope.selectedModel === null || $scope.selectedVersion === null || $scope.params === null;
        };

        angular.extend(config, {
            url: '/Home/GetBrands'
        });
        var brandsPromise = dataService.getData(config);
        brandsPromise.then(function (response) {
            $scope.brands = response.brands.map(function (item) {
                return new Brand(item);
            });
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
                    $scope.models = response.models.map(function (item) {
                        return new Model(item);
                    });
                });
            }
            $scope.selectedModel = null;
            $scope.selectedVersion = null;
            $scope.selectedModify = null;
            $scope.models = null;
            $scope.versions = null;
            $scope.modifies = null;
            $scope.params = null;
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
                    $scope.versions = response.versions.map(function (item) {
                        return new Version(item);
                    });
                });
            }
            $scope.selectedVersion = null;
            $scope.selectedModify = null;
            $scope.versions = null;
            $scope.modifies = null;
            $scope.params = null;
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
                    $scope.modifies = response.modifies.map(function (item) {
                        return new Modify(item);
                    });
                });
            }
            $scope.selectedModify = null;
            $scope.modifies = null;
            $scope.params = null;
        });

        $scope.$watch('selectedModify', function (newValue) {
            if (newValue !== null) {
                angular.extend(config, {
                    url: '/Home/GetParamsByModifyId',
                    params: {
                        modifyId: $scope.selectedModify.id
                    }
                });
                var paramsPromise = dataService.getData(config);
                paramsPromise.then(function (response) {
                    $scope.params = response.params.map(function (item) {
                        return new Param(item);
                    });
                });
            }
            $scope.params = null;
        });

        $scope.ok = function () {
            var car = new Car($scope.selectedBrand, $scope.selectedModel, $scope.selectedVersion, $scope.selectedModify, $scope.params);

            $modalInstance.close(car);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }
])