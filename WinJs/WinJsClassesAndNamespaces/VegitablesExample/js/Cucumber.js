/// <reference path="Vegetables.js" />

WinJS.Namespace.defineWithParent(Vegetables, "NotDirectlyEatable", {
    Cucumber: WinJS.Class.derive(Vegetables.Vegetable, function (length) {
        var color = "green";
        var isDirectlyEatable = false;
        Vegetables.Vegetable.call(this, color, isDirectlyEatable);
        this.length = length;
    })
});