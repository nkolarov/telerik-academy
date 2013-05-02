/* 02. Create a module that works with moving div elements. Implement functionality for:
Add new moving div element to the DOM.
The module should generate random background, font and border colors for the div element.
All the div elements are with the same width and height.
The movements of the div elements can be either circular or rectangular.
The elements should be moving all the time.
*/
var movingShapes = new function () {
    var SPEED = 100;

    /**
    * Updates all elements position at given interval.
    */
    var x = setInterval(function () {
        updateEllipsePosition();
        updateRectanglePosition()
    }, SPEED);

    /**
    * Appends a new DIV element to the given parent element.
    */
    function add(shape, selector) {
        var parent = document.querySelector(selector);
        var currentElement = document.createElement("div");
        setRandomDivStyle(currentElement, shape);
        setElementStartPosition(currentElement, shape);
        parent.appendChild(currentElement);
    }

    /**
    * Generates a radnom integer number in range [min,max].
    */
    function generateRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    /**
    * Generates a random rgb color.
    * Example: rgb(255,255,255)
    */
    function generateRandomRGBColor() {
        var red = generateRandomInt(0, 255);
        var green = generateRandomInt(0, 255);
        var blue = generateRandomInt(0, 255);

        return "rgb(" + red + "," + green + "," + blue + ")"; 
    }

    /**
    * Updates the position of all elements with class ellipse.
    */
    function updateEllipsePosition() {
        var ANGLE_STEP = 5;
        var elements = document.querySelectorAll(".ellipse");
        for (var i = 0; i < elements.length; i++) {
            node = elements[i];
            node.currentAngle += ANGLE_STEP;
            var newPosition = getEllipsePosition(node);
            setElementStyles(node, newPosition);
        }
    }

    /**
    * Updates the position of all elements with class rectangle.
    */
    function updateRectanglePosition() {
        var MOMENT_STEP = 5;
        var elements = document.querySelectorAll(".rectangle");
        for (var i = 0; i < elements.length; i++) {
            node = elements[i];
            node.currentMoment += MOMENT_STEP;
            var newPosition = getRectangularPosition(node);
            setElementStyles(node, newPosition);
        }
    }
  
    /**
    * Sets top and left atribute for absolutely positionned elements.
    */
    function setElementStyles(node, newPosition) {
        var positionX = newPosition.positionX;
        node.style.left = positionX + "px";
        var positionY = newPosition.positionY;
        node.style.top = positionY + "px";
    }

    /**
    * Calculates current position in 2D Euclidean plane by given ellipse parameters.
    * See more info @: http://www.mathopenref.com/coordparamellipse.html
    */
    function getEllipsePosition(node) {
        var ELLIPSE_X = 150;
        var ELLIPSE_Y = 40;
        var centerX = node.centerX;
        var centerY = node.centerY
        if (node.currentAngle >= 360) {
            node.currentAngle = 0;
        }
        var currentAngle = node.currentAngle;

        return {
            positionX: parseInt(centerX + ELLIPSE_X * Math.cos(convertDegreesToRadians(currentAngle))),
            positionY: parseInt(centerY + ELLIPSE_Y * Math.sin(convertDegreesToRadians(currentAngle))),
        }
    }

    /**
    * Describes rectangular element movement. Calculates current position in 2D Euclidean plane by  given moment.
    * Max moment = 2*HEIGHT + 2*WIDTH;
    */
    function getRectangularPosition(node) {
        var WIDTH = 200;
        var HEIGHT = 150;

        var startX = node.centerX;
        var startY = node.centerY;

        var currentX;
        var currentY;

        var direction = "";
        if (node.currentMoment > (2 * HEIGHT + 2 * WIDTH)) {
            node.currentMoment = 0;
        }
        var currentMoment = node.currentMoment;

        if (currentMoment < WIDTH) {
            direction = "right";
        }
        else if (currentMoment < WIDTH + HEIGHT) {
            direction = "down";
        }
        else if (currentMoment < 2 * WIDTH + HEIGHT) {
            direction = "left";
        }
        else {
            direction = "up";
        }

        switch (direction) {
            case "right":
                currentX = currentMoment;
                currentY = 0;
                break;
            case "down":
                currentX = WIDTH;
                currentY = currentMoment - WIDTH;
                break;
            case "left":
                currentY = HEIGHT;
                currentX = WIDTH - (currentMoment - HEIGHT - WIDTH);
                break;
            case "up":
                currentX = 0;
                currentY = HEIGHT - (currentMoment - 2 * WIDTH - HEIGHT);
        }

        return { positionX: startX + currentX, positionY: startY + currentY }
    }

    /**
    * Converts degrees to radians.
    */
    function convertDegreesToRadians(degrees) {
        return degrees * Math.PI / 180;
    }

    /**
    * Sets radnom font and color styles for given node.
    */
    function setRandomDivStyle(node, shape) {
        var MIN_FONT_SIZE = 10;
        var MAX_FONT_SIZE = 20;

        // Set node styles with random values.
        var nodeContent = "Just " + shape;
        node.innerHTML = nodeContent;

        var backgroungColor = generateRandomRGBColor();
        node.style.background = backgroungColor;
        var borderColor = generateRandomRGBColor();
        node.style.borderColor = borderColor;

        var fontSize = generateRandomInt(MIN_FONT_SIZE, MAX_FONT_SIZE);
        node.style.fontSize = fontSize + "px";
        var fontColor = generateRandomRGBColor();
        node.style.color = fontColor;

        var divCSSClass = "moving-div"; // If you insist to change the class you must also update the CSS.
        node.classList.add(divCSSClass);
        node.classList.add(shape);
    }
    
    /**
    * Calulates and sets element start position.
    */
    function setElementStartPosition(node, shape) {
        var MAX_WINDOW_HEIGHT = screen.height - 500;
        var MAX_WINDOW_WIDTH = screen.width - 500;
        var WINDOW_PADDING = 20;
        node.centerX = generateRandomInt(WINDOW_PADDING, MAX_WINDOW_WIDTH - WINDOW_PADDING);
        node.centerY = generateRandomInt(WINDOW_PADDING, MAX_WINDOW_HEIGHT - WINDOW_PADDING);
        node.currentAngle = 0;
        node.currentMoment = 0;

        var startPosition = {};
        switch (shape) {
            case "ellipse":
                startPosition = getEllipsePosition(node);
                break;
            case "rectangle":
                startPosition = getRectangularPosition(node);
                break;
        }

        node.style.left = startPosition.positionX + "px";
        node.style.top = startPosition.positionY + "px";
    }

    return {
        add: add,
    }
}();