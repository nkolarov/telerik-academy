var DomLogger = WinJS.Class.define(function DomLoggerCtor(element, name) {
    var self = this;
    self.element = element;
    name = name || "Logger";

    element.className += " dom-logger";

    self.logContainer = document.createElement("div");
    self.titleContainer = document.createElement("h3");

    self.element.appendChild(self.titleContainer);
    self.element.appendChild(self.logContainer);

    self.titleContainer.innerText = name;
}, {
    log: function log(text, overwrite) {
        var paragraph = document.createElement("p");
        paragraph.innerText = text;

        if (overwrite) {
            this.logContainer.innerHTML = "";
        }

        this.logContainer.appendChild(paragraph);
    }
})