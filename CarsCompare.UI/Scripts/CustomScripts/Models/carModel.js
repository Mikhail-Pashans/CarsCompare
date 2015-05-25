var Car = function (car) {
    'use strict';

    var self = this;

    self.brand = !!car ? car.brand : null;
    self.model = !!car ? car.model : null;
    self.version = !!car ? car.version : null;
    self.modify = !!car ? car.modify : null;
    self.params = !!car ? car.params : [];
};