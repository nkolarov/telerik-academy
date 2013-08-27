/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="Vegetables.js" />

WinJS.Namespace.defineWithParent(Vegetables, "DirectlyEatable", {
    Tomato: WinJS.Class.derive(Vegetables.Vegetable, function (radius) {
        var color = "red";
        var isDirectlyEatable = true;
        Vegetables.Vegetable.call(this, color, isDirectlyEatable);
        this.radius = radius;
    })
});
