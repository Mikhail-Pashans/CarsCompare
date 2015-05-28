var carsCompareApp = angular.module('carsCompareControllers');

carsCompareApp.controller('modalInstancesCtrl',
    [
        '$scope', '$modalInstance', 'dataService', 'config', 'car',
        function modalInstancesCtrl($scope, $modalInstance, dataService, config, car) {
            'use strict';

            $scope.brands = [];
            $scope.models = [];
            $scope.versions = [];
            $scope.modifies = [];

            $scope.params = !!car ? car.params : [];
            $scope.brand = {
                selected: !!car ? car.brand : null
            };
            $scope.model = {
                selected: !!car ? car.model : null
            };
            $scope.version = {
                selected: !!car ? car.version : null
            };
            $scope.modify = {
                selected: !!car ? car.modify : null
            };

            $scope.isModelsDisabled = function () {
                return !$scope.brand.selected || !$scope.brands.length;
            };
            $scope.isVersionsDisabled = function () {
                return !$scope.brand.selected || !$scope.model.selected || !$scope.versions.length;
            };
            $scope.isModifiesDisabled = function () {
                return !$scope.brand.selected || !$scope.model.selected || !$scope.version.selected || !$scope.modifies.length;
            };
            $scope.isOKButtonDisabled = function () {
                return !$scope.brand.selected || !$scope.model.selected || !$scope.version.selected || !$scope.modify.selected || !$scope.params.length;
            };

            var firstUpload = true;

            angular.extend(config, {
                url: '../brands.json'//'/Home/GetBrands'
            });
            var brandsPromise = dataService.getData(config);
            brandsPromise.then(function (response) {
                $scope.brands = response.brands.map(function (item) {
                    return new Brand(item);
                });
            });

            $scope.$watch('brand.selected', function (newValue) {
                if (!!car && firstUpload) {
                    return;
                }
                if (!!newValue) {
                    angular.extend(config, {
                        url: '../models.json'//'/Home/GetModelsByBrandId',
                        //params: {
                        //    brandId: !!$scope.brand.selected ? $scope.brand.selected.id : 0
                        //}
                    });
                    var modelsPromise = dataService.getData(config);
                    modelsPromise.then(function (response) {
                        $scope.models = response.models.map(function (item) {
                            return new Model(item);
                        });
                    });
                }
                $scope.model = {};
                $scope.version = {};
                $scope.modify = {};
                $scope.models = [];
                $scope.versions = [];
                $scope.modifies = [];
                $scope.params = [];
            });

            $scope.$watch('model.selected', function (newValue) {
                if (!!car && firstUpload) {
                    return;
                }
                if (!!newValue) {
                    angular.extend(config, {
                        url: '../versions.json'//'/Home/GetVersionsByModelId',
                        //params: {
                        //    modelId: !!$scope.model.selected ? $scope.model.selected.id : 0
                        //}
                    });
                    var vearsionsPromise = dataService.getData(config);
                    vearsionsPromise.then(function (response) {
                        $scope.versions = response.versions.map(function (item) {
                            return new Version(item);
                        });
                    });
                }
                $scope.version = {};
                $scope.modify = {};
                $scope.versions = [];
                $scope.modifies = [];
                $scope.params = [];
            });

            $scope.$watch('version.selected', function (newValue) {
                if (!!car && firstUpload) {
                    return;
                }
                if (!!newValue) {
                    angular.extend(config, {
                        url: '../modifies.json'//'/Home/GetModifiesByModelIdAndVersionId',
                        //params: {
                        //    modelId: !!$scope.model.selected ? $scope.model.selected.id : 0,
                        //    versionId: !!$scope.version.selected ? $scope.version.selected.id : 0
                        //}
                    });
                    var modifiesPromise = dataService.getData(config);
                    modifiesPromise.then(function (response) {
                        $scope.modifies = response.modifies.map(function (item) {
                            return new Modify(item);
                        });
                    });
                }
                $scope.modify = {};
                $scope.modifies = [];
                $scope.params = [];
            });

            $scope.$watch('modify.selected', function (newValue) {
                if (!!car && firstUpload) {
                    firstUpload = false;
                    return;
                }
                if (!!newValue) {
                    angular.extend(config, {
                        url: '../params.json'//'/Home/GetParamsByModifyId',
                        //params: {
                        //    modifyId: !!$scope.modify.selected ? $scope.modify.selected.id : 0
                        //}
                    });
                    var paramsPromise = dataService.getData(config);
                    paramsPromise.then(function (response) {
                        $scope.params = response.params.map(function (item) {
                            return new Param(item);
                        });

                        var paramName = new ParamName({
                            id: 0,
                            name: '',
                            units: ''
                        });
                        var param = new Param({
                            id: 0,
                            value: '—',
                            paramName: paramName
                        });

                        $scope.params.splice(0, 0, param);
                    });
                }
                $scope.params = [];
            });

            $scope.ok = function () {
                var car = new Car({
                    brand: $scope.brand.selected,
                    model: $scope.model.selected,
                    version: $scope.version.selected,
                    modify: $scope.modify.selected,
                    params: $scope.params
                });

                $modalInstance.close(car);
            };

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        }
    ]);