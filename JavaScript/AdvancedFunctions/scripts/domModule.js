/*    01. Create a module for working with DOM. The module should have the following functionality
        Add DOM element to parent element given by selector
        Remove element from the DOM  by given selector
        Attach event to given selector by given event type and event hander
        Add elements to buffer, which appends them to the DOM when their count for some selector becomes 100
        The buffer contains elements for each selector it gets
        Get elements by CSS selector
        The module should reveal only the methods.*/

var domModule = function () {

    /**
    * Appends a child element to a parent by given selector.
    */
    var appendChild = function (childType, selector) {
        // More info @: https://developer.mozilla.org/en-US/docs/DOM/Node.appendChild
        document.querySelector(selector).appendChild(childType);
    }

    /**
    * Removes a child element by given selector.
    */
    var removeChild = function (parent, selector) {
        // More info @: https://developer.mozilla.org/en-US/docs/DOM/Node.removeChild
        var elementSelector = parent + " " + selector;
        var childs = document.querySelectorAll(elementSelector);

        for (var i = 0; i < childs.length; i++) {
            childs[i].parentNode.removeChild(childs[i]);
        }
    }

    /**
    * Attaches an event of an element by given element selector, event type and event handler.
    */
    var addHandler = function (selector, type, handler) {
        // More info @: https://developer.mozilla.org/en-US/docs/DOM/EventTarget.addEventListener
        var elements = document.querySelectorAll(selector);
        var useCapture = false;
        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(type, handler, useCapture);
        }
    }

    var buffer = [];
    var BUFFER_MAX_SIZE = 5;

    /**
    * Flushes the buffer by appending all elements from the buffer to their parents.
    */
    var flushBuffer = function () {
        for (var i = 0; i < buffer.length; i++) {
            var parent = buffer[i].parent;
            var element = buffer[i].element;
            parent.appendChild(element);
        }
        buffer = [];
    }

    /**
    * Appends element to a buffer by given parent selector and element.
    */
    var appendToBuffer = function (selector, element) {
        var parent = document.querySelector(selector);
        buffer.push({ parent: parent, element: element });

        if (buffer.length === BUFFER_MAX_SIZE) {
            flushBuffer();
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    }
}();