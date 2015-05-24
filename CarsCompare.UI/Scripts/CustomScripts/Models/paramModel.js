var Param = function (param) {
    'use strict';

    var self = this;

    self.id = param.id;
    self.value = param.value;
    self.paramName = new ParamName(param.paramName);
};