﻿require(["knockout", "jquery", "app/common", "app/shared/header"], function (ko, $) {
    // Bind the main content area when DOM is ready
    $(function () {
        ko.applyBindings({}, $("#body-content").get(0));
    });
});