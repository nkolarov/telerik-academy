/// <reference path="Vegetables.js" />
/// <reference path="Tomato.js" />
/// <reference path="Cucumber.js" />
/// <reference path="MushromMixin.js" />

WinJS.Namespace.defineWithParent(Vegetables, "GMOs", {
    TomatoGmo: WinJS.Class.mix(Vegetables.DirectlyEatable.Tomato, Mixins.Mushroom),
    CucumberGmo: WinJS.Class.mix(Vegetables.NotDirectlyEatable.Cucumber, Mixins.Mushroom)
});