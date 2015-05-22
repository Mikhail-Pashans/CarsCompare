var carsCompareApp = angular.module('carsCompareApp');

carsCompareApp.controller('modalInstancesCtrl', function modalInstancesCtrl($scope, $modalInstance, conf, brands, dataService) {
    'use strict';

    $scope.brands = brands;
    $scope.models = null;
    $scope.versions = null;
    $scope.modifies = null;
    $scope.selectedBrand = null;
    $scope.selectedModel = null;
    $scope.selectedVersion = null;
    $scope.selectedModify = null;
    $scope.isModelsDisabled = true;
    $scope.isVersionsDisabled = true;
    $scope.isModifiesDisabled = true;

    //$scope.$watch('selectedBrand', function (newValue, oldValue) {
    //    if (newValue !== null) {
    //        if (newValue !== oldValue) {
    //            conf.url = '/Home/GetModelsByBrandId';
    //            conf.params = {
    //                'brandId': $scope.selectedBrand
    //            };
    //            var promiseObj = dataService.getData(conf);
    //            promiseObj.then(function (response) {
    //                $scope.models = response.models;
    //            });
    //        }
    //        $scope.isModelsDisabled = false;
    //    } else {
    //        $scope.isModelsDisabled = true;
    //    }
    //});

    $scope.getModels = function() {
        if ($scope.selectedBrand !== null) {
            conf.url = '/Home/GetModelsByBrandId';
            conf.params = {
                'brandId': $scope.selectedBrand
            };
            var promiseObj = dataService.getData(conf);
            promiseObj.then(function (response) {
                $scope.models = response.models;
                $scope.isModelsDisabled = false;
            });
        }
        $scope.isModelsDisabled = true;
    };

    //$scope.$watch('selectedModel', function (newValue, oldValue) {
    //    if (newValue !== null) {
    //        if (newValue !== oldValue) {
    //            conf.url = '/Home/GetVersionsByModelId';
    //            conf.params = {
    //                'modelId': $scope.selectedModel
    //            };
    //            var promiseObj = dataService.getData(conf);
    //            promiseObj.then(function (response) {
    //                $scope.versions = response.versions;
    //            });
    //        }
    //        $scope.isVersionsDisabled = false;
    //    } else {
    //        $scope.isVersionsDisabled = true;
    //    }
    //});

    $scope.getVersions = function () {
        if ($scope.selectedBrand !== null || $scope.selectedModel !== null) {
            conf.url = '/Home/GetVersionsByModelId';
            conf.params = {
                'modelId': $scope.selectedModel
            };
            var promiseObj = dataService.getData(conf);
            promiseObj.then(function (response) {
                $scope.versions = response.versions;
                $scope.isVersionsDisabled = false;
            });
        }
        $scope.isVersionsDisabled = true;
    };

    //$scope.$watch('selectedVersion', function (newValue, oldValue) {
    //    if (newValue !== null) {
    //        if (newValue !== oldValue) {
    //            conf.url = '/Home/GetModifiesByModelIdAndVersionId';
    //            conf.params = {
    //                'modelId': $scope.selectedModel,
    //                'versionId': $scope.selectedVersion
    //            };
    //            var promiseObj = dataService.getData(conf);
    //            promiseObj.then(function (response) {
    //                $scope.modifies = response.modifies;
    //            });
    //        }
    //        $scope.isModifiesDisabled = false;
    //    } else {
    //        $scope.isModifiesDisabled = true;
    //    }
    //});

    $scope.getModifies = function () {
        if ($scope.selectedBrand !== null || $scope.selectedModel !== null || $scope.selectedVersion !== null) {
            conf.url = '/Home/GetModifiesByModelIdAndVersionId';
            conf.params = {
                'modelId': $scope.selectedModel,
                'versionId': $scope.selectedVersion
            };
            var promiseObj = dataService.getData(conf);
            promiseObj.then(function (response) {
                $scope.modifies = response.modifies;
                $scope.isModifiesDisabled = false;
            });
        }
        $scope.isModifiesDisabled = true;
    };

    $scope.ok = function () {
        $modalInstance.close($scope.selectedModify);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
})