var Car = function (car) {
    'use strict';

    var self = this;

    self.isBest = false;
    self.paramGroups = [],

    self.brands = car.brands,
    self.models = car.models,
    self.versions = car.versions,
    self.modifies = car.modifies,
    self.params = car.params,
    self.selectedBrand = car.selectedBrand;
    self.selectedModel = car.selectedModel;
    self.selectedVersion = car.selectedVersion;
    self.selectedModify = car.selectedModify;
    self.imageUrl = car.imageUrl;
};