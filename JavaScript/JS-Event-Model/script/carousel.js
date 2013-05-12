/* 01. Create a Simple JS Carousel with N images and two arrows for image control */
var carousel = function () {
    var images = [];
    var imageIndex = 0;

    /*
    * Represents an enumeration for avaiable image directions.
    */
    var imageDirection = Object.freeze({
        "LEFT": 0,
        "RIGHT": 1
    });

    /*
    * Adds an image by given relative path to a parent element defined with parent selector.
    */
    function addImage(parentSlector, relativePathToImage) {
        var parent = document.querySelector(parentSlector);
        var image = document.createElement("img");

        image.setAttribute("src",relativePathToImage);
        parent.appendChild(image);
        images.push(image);
        // Hide all but first image
        if (images.length - 1 > 0) {
            hideImage(images.length - 1);
        }
    }

    /*
    * Checks if imageIndex is out of the permitted range and corrects it if needed.
    */
    function correctImageIndex() {
        if (imageIndex < 0) {
            imageIndex = images.length - 1;
        }
        else if (imageIndex > images.length - 1) {
            imageIndex = 0;
        }
    }

    /*
    * Hides an image by given index.
    */
    function hideImage(index) {
        images[index].style.display = "none";
    }

    /*
    * Shows an image by given index.
    */
    function showImage(index) {
        images[index].style.display = "";
    }

    /*
    * Shows next image according to the passed direction.
    */
    function showNextImage(direction) {
        hideImage(imageIndex);
        switch (direction) {
            case imageDirection.LEFT:
                imageIndex--;
                break;
            case imageDirection.RIGHT:
                imageIndex++;
                break;
            default:
                throw new Error("Unknown Direction!");
        }
        correctImageIndex();
        showImage(imageIndex);
    }

    return {
        addImage: addImage,
        showNextImage: showNextImage,
        imageDirection: imageDirection
    }
}();