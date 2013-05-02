/* 02. Create a module that works with moving div elements. Implement functionality for:
Add new moving div element to the DOM.
The module should generate random background, font and border colors for the div element.
All the div elements are with the same width and height.
The movements of the div elements can be either circular or rectangular.
The elements should be moving all the time.
*/
var movingShapes = new function () {
    var SPEED = 100;

    var x = setInterval(function () {
        updateEllipsePosition();
        updateRectanglePosition()
    }, SPEED);

    function add(shape, selector) {
        var parent = document.querySelector(selector);
        var currentElement = document.createElement("div");
        setRandomDivStyle(currentElement, shape);
        parent.appendChild(currentElement);
    }

    function generateRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function generateRandomRGBColor() {
        var red = generateRandomInt(0, 255);
        var green = generateRandomInt(0, 255);
        var blue = generateRandomInt(0, 255);

        return "rgb(" + red + "," + green + "," + blue + ")"; // Example: rgb(255,255,255)
    }

    function updateEllipsePosition() {
        var MOMENT_STEP = 5;
        var elements = document.querySelectorAll(".ellipse");
        for (var i = 0; i < elements.length; i++) {
            node = elements[i];
            node.currentAngle += MOMENT_STEP;
            var newPosition = getEllipsePosition(node);
            setElementStyles(node, newPosition);
        }
    }

    function updateRectanglePosition() {
        var ANGLE_STEP = 5;
        var elements = document.querySelectorAll(".rectangle");
        for (var i = 0; i < elements.length; i++) {
            node = elements[i];
            node.currentAngle += ANGLE_STEP;
            var newPosition = getRectangularPosition(node);
            setElementStyles(node, newPosition);
        }
    }
  
    function setElementStyles(node, newPosition) {
        var positionX = newPosition.positionX;
        node.style.left = positionX + "px";
        var positionY = newPosition.positionY;
        node.style.top = positionY + "px";
    }

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

    function getRectangularPosition(node) {
        var WIDTH = 200;
        var HEIGHT = 150;

        var startX = node.centerX;
        var startY = node.centerY;

        var currentX;
        var currentY;

        var direction = "";
        if (node.currentAngle > (2 * HEIGHT + 2 * WIDTH)) {
            node.currentAngle = 0;
        }
        var moment = node.currentAngle;

        if (moment < WIDTH) {
            direction = "right";
        }
        else if (moment < WIDTH + HEIGHT) {
            direction = "down";
        }
        else if (moment < 2 * WIDTH + HEIGHT) {
            direction = "left";
        }
        else {
            direction = "up";
        }

        switch (direction) {
            case "right":
                currentX = moment;
                currentY = 0;
                break;
            case "down":
                currentX = WIDTH;
                currentY = moment - WIDTH;
                break;
            case "left":
                currentY = HEIGHT;
                currentX = WIDTH - (moment - HEIGHT - WIDTH);
                break;
            case "up":
                currentX = 0;
                currentY = HEIGHT - (moment - 2 * WIDTH - HEIGHT);
        }

        return { positionX: startX + currentX, positionY: startY + currentY }
    }

    function convertDegreesToRadians(degrees) {
        return degrees * Math.PI / 180;
    }

    function setRandomDivStyle(node, shape) {
        var MAX_WINDOW_HEIGHT = screen.height - 500;
        var MAX_WINDOW_WIDTH = screen.width - 500;
        var WINDOW_PADDING = 20;
        var MIN_FONT_SIZE = 10;
        var MAX_FONT_SIZE = 20;
        var nodeContent = "Just " + shape;
        var divCSSClass = "moving-div"; // If you insist to change the class you must also update the CSS.

        // Set node styles with random values.
        var backgroungColor = generateRandomRGBColor();
        node.style.background = backgroungColor;

        var fontSize = generateRandomInt(MIN_FONT_SIZE, MAX_FONT_SIZE);
        node.style.fontSize = fontSize + "px";

        var fontColor = generateRandomRGBColor();
        node.style.color = fontColor;

        var borderColor = generateRandomRGBColor();
        node.style.borderColor = borderColor;

        node.innerHTML = nodeContent;

        node.classList.add(divCSSClass);
        node.classList.add(shape);

        // Custom properties needed for rotation
        node.centerX = generateRandomInt(WINDOW_PADDING, MAX_WINDOW_WIDTH - WINDOW_PADDING);
        node.centerY = generateRandomInt(WINDOW_PADDING, MAX_WINDOW_HEIGHT - WINDOW_PADDING);
        node.currentAngle = 0;
        node.moment = 0;

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