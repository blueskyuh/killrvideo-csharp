﻿define(["knockout", "jquery", "text!./tour.tmpl.html", "./main-tour", "lib/knockout-extenders", "lib/knockout-popover", "bootstrap"], function (ko, $, htmlString, mainTour) {
    function tourViewModel(params) {
        var self = this;

        // An array of tour step definitions (normalized with some default properties if not set)
        var steps = $.map(mainTour.steps, function(step) {
            var stepWithDefaults = $.extend({
                showNextButton: true,
                showPreviousButton: true,
                callToAction: null,
                contentClass: null
            }, step);

            if (step.onShow) {
                stepWithDefaults.onShow = $.proxy(step.onShow, stepWithDefaults, self);
            }

            if (step.onHide) {
                stepWithDefaults.onHide = $.proxy(step.onHide, stepWithDefaults, self);
            }

            return stepWithDefaults;
        });

        // A unique identifier for the tour
        self.tourId = mainTour.tourId;

        // The index of the current step
        self.currentStepIndex = ko.observable(0).extend({ persist: self.tourId + ".index" });

        // Whether or not we're on the correct page for the current step
        self.onCorrectPage = ko.pureComputed(function () {
            var idx = self.currentStepIndex();
            var step = steps[idx];

            // See if we're on the correct page for the step, possibly by running a RegEx
            return (typeof step.page === "string")
                ? step.page === window.location.pathname.toLowerCase()
                : step.page.test(window.location.pathname.toLowerCase());
        });

        // The step object for the current step
        self.currentStep = ko.pureComputed(function () {
            var rightPage = self.onCorrectPage();
            if (!rightPage) return null;

            // See if the step has a promsie to be fulfilled first
            var step = steps[self.currentStepIndex()];
            if (!step.beforeShowPromise) return step;

            return step.beforeShowPromise().then(function() { return step; });
        }).extend({ async: null });

        // Go to next step
        self.next = function () {
            var curIdx = self.currentStepIndex();
            if (curIdx < steps.length - 1) {
                self.currentStepIndex(curIdx + 1);
            }
        };

        // Go to previous step
        self.previous = function () {
            var curIdx = self.currentStepIndex();
            if (curIdx > 0) {
                // Set current step state
                var newIdx = curIdx - 1;
                self.currentStepIndex(newIdx);

                // Do back button navigation if necessary
                if (steps[curIdx].page !== steps[newIdx].page) {
                    window.history.back();
                }
            }
        };

        // Whether or not the tour is enabled
        self.enabled = ko.observable(true).extend({ persist: self.tourId + ".enabled" });

        // Disable the tour
        self.disable = function () {
            self.enabled(false);
        };

        // Restart the tour from the beginning
        self.restart = function () {
            self.currentStepIndex(0);
            self.enabled(true);

            if (window.location.pathname !== "/") {
                window.location.href = "/"; // TODO: Logout?
            }
        };

        // The last correct page for the user was on
        self.resumeUrl = ko.observable("").extend({ persist: self.tourId + ".resumeUrl" });

        // Resume the tour from where you left off
        self.resume = function () {
            self.enabled(true);

            var resumeUrl = self.resumeUrl();
            if (window.location.href !== resumeUrl) {
                window.location.href = self.resumeUrl();
            }
        };

        // If we're not on the correct page when the model is initially loaded, disable the tour
        if (self.onCorrectPage() === false) {
            self.enabled(false);
        } else if (self.enabled() === true) {
            // If we're on the correct page and enabled, save the URL so the tour can be resumed
            self.resumeUrl(window.location.href);
        }
    }

    // Return KO component definition
    return { viewModel: tourViewModel, template: htmlString };
});