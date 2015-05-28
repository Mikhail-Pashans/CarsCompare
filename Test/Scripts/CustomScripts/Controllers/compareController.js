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
                url: '../paramGroups.json'//'/Home/GetParamGroupsWithParamNames'
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
                    templateUrl: '../ClientTemplates/modalInstanceTemplate.html',
                    controller: 'modalInstancesCtrl',
                    resolve: {
                        config: function () {
                            return config;
                        },
                        car: function () {
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

            $scope.removeCar = function (index) {
                $scope.cars.splice(index, 1)
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

            $scope.paramGroups =
            [
                {
                    "id": 0,
                    "name": "Общие",
                    "paramNames": [
                        { "id": 1, "name": "Цена", "units": "$" },
                        { "id": 2, "name": "Год", "units": "", best: true }
                    ]
                },
                {
                    "id": 1,
                    "name": "Кузов",
                    "paramNames": [
                        { "id": 1, "name": "Тип кузова", "units": "" },
                        { "id": 2, "name": "Количество дверей", "units": "" },
                        { "id": 3, "name": "Количество мест", "units": "" },
                        { "id": 4, "name": "Ширина", "units": "мм" },
                        { "id": 5, "name": "Длина", "units": "мм" },
                        { "id": 6, "name": "Высота", "units": "мм" },
                        { "id": 7, "name": "Колесная база", "units": "мм" },
                        { "id": 8, "name": "Дорожный просвет", "units": "мм" },
                        { "id": 24, "name": "Колея передняя", "units": "мм", best: true },
                        { "id": 25, "name": "Объем багажника минимальный", "units": "л" },
                        { "id": 26, "name": "Объем багажника максимальный", "units": "л" },
                        { "id": 27, "name": "Колея задняя", "units": "мм" },
                        { "id": 56, "name": "Ширина с зеркалами", "units": "мм" }
                    ]
                },
                {
                    "id": 2,
                    "name": "Двигатель",
                    "paramNames": [
                        { "id": 9, "name": "Тип двигателя", "units": "" },
                        { "id": 10, "name": "Объем двигателя", "units": "см3" },
                        { "id": 11, "name": "Мощность", "units": "л.с." },
                        { "id": 12, "name": "Газораспределительный механизм", "units": "" },
                        { "id": 13, "name": "Расположение цилиндров", "units": "" },
                        { "id": 14, "name": "Количество цилиндров", "units": "" },
                        { "id": 15, "name": "Топливо", "units": "" },
                        { "id": 20, "name": "При оборотах", "units": "" },
                        { "id": 21, "name": "Крутящий момент", "units": "н*м" },
                        { "id": 22, "name": "Степень сжатия", "units": "" },
                        { "id": 23, "name": "Количество клапанов на цилиндр", "units": "" },
                        { "id": 28, "name": "Система питания", "units": "" },
                        { "id": 29, "name": "Наличие турбонаддува", "units": "" },
                        { "id": 30, "name": "Диаметр цилиндра", "units": "мм" },
                        { "id": 31, "name": "Ход поршня", "units": "мм" },
                        { "id": 51, "name": "Модель двигателя", "units": "", best: true },
                        { "id": 52, "name": "Мощность электромотора", "units": "л.с." },
                        { "id": 55, "name": "Совокупная мощность", "units": "л.с." },
                        { "id": 57, "name": "Расположение двигателя", "units": "" }
                    ]
                },
                {
                    "id": 3,
                    "name": "Трансмиссия",
                    "paramNames": [
                        { "id": 16, "name": "Тип КПП", "units": "" },
                        { "id": 17, "name": "Кол-во передач", "units": "" },
                        { "id": 18, "name": "Кол-во передач (мех коробка)", "units": "" },
                        { "id": 19, "name": "Привод", "units": "" },
                        { "id": 34, "name": "Кол-во передач (автомат коробка)", "units": "", best: true },
                        { "id": 42, "name": "Передаточное отношение главной пары", "units": "" }
                    ]
                },
                {
                    "id": 4,
                    "name": "Подвеска",
                    "paramNames": [
                        { "id": 32, "name": "Тип передней подвески", "units": "" },
                        { "id": 33, "name": "Тип задней подвески", "units": "" }
                    ]
                },
                {
                    "id": 5,
                    "name": "Тормозная система",
                    "paramNames": [
                        { "id": 35, "name": "Передние тормоза", "units": "" },
                        { "id": 36, "name": "Задние тормоза", "units": "", best: true }
                    ]
                },
                {
                    "id": 6,
                    "name": "Рулевое управление",
                    "paramNames": [
                        { "id": 37, "name": "Тип рулевого управления", "units": "" },
                        { "id": 49, "name": "Диаметр разворота", "units": "м" }
                    ]
                },
                {
                    "id": 7,
                    "name": "Эксплуатационные показатели",
                    "paramNames": [
                        { "id": 38, "name": "Допустимая полная масса", "units": "кг" },
                        { "id": 39, "name": "Объем топливного бака", "units": "л" },
                        { "id": 40, "name": "Размер шин", "units": "" },
                        { "id": 41, "name": "Размер дисков", "units": "" },
                        { "id": 43, "name": "Максимальная скорость", "units": "км/час" },
                        { "id": 44, "name": "Время разгона (0-100 км/ч)", "units": "с" },
                        { "id": 45, "name": "Расход топлива в городе на 100 км", "units": "л", best: true },
                        { "id": 46, "name": "Расход топлива на шоссе на 100 км", "units": "л", best: true },
                        { "id": 47, "name": "Расход топлива в смешанном цикле на 100 км", "units": "л" },
                        { "id": 48, "name": "Снаряженная масса автомобиля", "units": "кг" },
                        { "id": 50, "name": "Экологический стандарт", "units": "" },
                        { "id": 53, "name": "Запас хода", "units": "" },
                        { "id": 54, "name": "Полная зарядка", "units": "" }
                    ]
                }
            ];
            
            //небольше четырех
            $scope.cars = [
                {
                    "id": 0,
                    "name": "Aston Martin DB9 Coupe",
                    "image": "http://images.drive3.ru/models.large.main.images/4400/000/000/000/dca/88ce56ff7ad262d4-main.jpg",
                    "groups": $scope.paramGroups,
                    
                },
                {
                    "id": 1,
                    "name": "Maserati Quattroporte",
                    "image": "http://images.drive3.ru/models.large.main.images/0000/000/000/000/460/48d17f8ab473dc9f-main.jpg",
                    "groups": $scope.paramGroups
                },
                {
                    "id": 2,
                    "name": "Hyundai Genesis",
                    "image": "http://images.drive3.ru/models.large.main.images/0000/000/000/000/3d1/48d1fd2f236eeab7-main.jpg",
                    "groups": $scope.paramGroups,
                    "best": true
                },
                {
                    "id": 3,
                    "name": "Jaguar XJ",
                    "image": "http://images.drive3.ru/models.large.main.images/4400/000/000/000/bed/88ce71390c0de93c-main.jpg",
                    "groups": $scope.paramGroups
                }
            ];

        }
    ]);