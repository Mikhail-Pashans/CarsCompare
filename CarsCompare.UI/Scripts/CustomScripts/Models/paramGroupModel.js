var ParamGroup = function (paramGroup) {
    'use strict';

    var self = this;

    self.isExpanded = false;

    self.id = paramGroup.id;
    self.name = paramGroup.name;
    self.paramNames = paramGroup.paramNames.map(function (item) {
        return new ParamName(item);
    });    
};