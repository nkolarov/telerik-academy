/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="Vegetables.js" />

WinJS.Namespace.define("Mixins", {
    Mushroom: {
        grow: function (water) {
            if (this.radius) {
                this.radius = this.radius * water / 100;
            } else if (this.length) {
                this.length = this.length * water / 100;
            }
        }
    }
});