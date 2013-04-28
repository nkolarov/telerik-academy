function OnButtonClick(event) {
    var browserName = window.navigator.appName;
    if (browserName === "Mozilla") {
        alert("Your Browser is Mozilla!");
    }
    else {
        alert("Your Browser is NOT Mozilla!");
    }
}