/* 03. Create a module to work with the console object.Implement functionality for:
Writing a line to the console 
Writing a line to the console using a format
Writing to the console should call toString() to each element
Writing errors and warnings to the console with and without format
*/

var specialConsole = (function () {
    /**
    * Checks if the function is invoked with more than one parameter (there are placeholders).
    */
    function hasPlaceholders(args) {
        if (args.length > 1) {
            return true;
        }
    }

    /**
    * Replaces all placeholders in a string.
    * The string is the first element of args Array followed by placeholders data.
    */
    function replacePlaceholders(args) {
        var placeholderData = [];
        var resultString = args[0];

        for (var i = 0; i < args.length - 1; i++) {
            placeholderData[i] = args[i + 1];
        }

        for (var j = 0; j < placeholderData.length; j++) {
            var token = "\\{" + j + "\\}";
            var regex = new RegExp(token, "g");
            resultString = resultString.replace(regex, placeholderData[j]);
        }

        return resultString;
    }

    /**
    * Checks for placeholders. Replaces them and returns human readable message.
    */
    function prepareMessage(args) {
        var message = "";

        if (hasPlaceholders(args)) {
            message = replacePlaceholders(args);
        }
        else {
            message = args[0];
        }

        return message;
    }

    /**
    * Writes a message to a new console line.
    */
    function writeLine() {
        var message = prepareMessage(arguments);
        console.log(message);
    }

    /**
    * Writes an error message to the console.
    */
    function writeError() {
        var message = prepareMessage(arguments);
        console.error(message);
    }

    /**
    * Writes a warning message to the console.
    */
    function writeWarning() {
        var message = prepareMessage(arguments);
        console.warn(message);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
})();