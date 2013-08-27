/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("Vegetables", {
    Vegetable: WinJS.Class.define(
        function (color, isDirecltyEatable) {
            this.color = color;
            this.isDirectlyEatable = isDirecltyEatable;
        },{
            description: {
                get: function () {
                    return "Vegetable; Color: " + this.color + "; Eaten directly: " + (this.isDirectlyEatable === true ? "Yes" : "No") + " .";
                }
            }
        }
    )
});