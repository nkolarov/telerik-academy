// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    var app = WinJS.Application;
    app.onactivated = function (args) {
        console = new DomLogger(document.getElementById("output"));
        var sampleTomato = new Vegetables.DirectlyEatable.Tomato(20);
        var sampleCucumber = new Vegetables.NotDirectlyEatable.Cucumber(15);

        console.log("Tomato data:");
        console.log(sampleTomato.description);
        console.log("Cucumber data:");
        console.log(sampleCucumber.description);

        var tomatoGMO = new Vegetables.GMOs.TomatoGmo(10);
        console.log("Tomato GMO: " + tomatoGMO.description + " Initial size: " + tomatoGMO.radius);
        tomatoGMO.grow(1000);
        console.log("Size after givving 1000ml water: " + tomatoGMO.radius);

        var cucumberGMO = new Vegetables.GMOs.CucumberGmo(50);
        console.log("Cucumber GMO: " + cucumberGMO.description + " Initial size: " + cucumberGMO.length);
        cucumberGMO.grow(1000);
        console.log("Size after givving 1000ml water: " + cucumberGMO.length);
    }; 
    app.start();
})();
