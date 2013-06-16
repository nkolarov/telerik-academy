/*
01. Create a slider control using jQuery
The slider can have many slides
Only one slide is visible at a time
Each slide contains HTML code
i.e. it can contain images, forms, divs, headers, links, etc…
Implement functionality for changing the visible slide after 5 seconds
Create buttons for next and previous slide
*/
(function ($) {
    var interval = 2000;
    var slideInterval;
    var sliderElementsClass = "slider-element";
    var sliderElementsSelector = "." + sliderElementsClass;
    var currentElementClass = "current";
    var currentElementSelector = "." + currentElementClass;

    // Attach events handlers.
    $("#autoSlideButton").on("click", function () {
        slide();
    });
    $("#previousButton").on("click", function () {
        previousSliderElement();
    });
    $("#nextButton").on("click", function () {
        nextSliderElement();
    });
                
    // Slides all elements containing class sliderElementsClass starting from the element that have class currentElementClass.
    function slide() {
        clearInterval(slideInterval);
        var current = $(currentElementSelector);
        current.fadeOut(interval, function () {
            $(this).css('display', 'none');
        }
        );
        slideInterval = setInterval(function () {
            var current = $(currentElementSelector);
            var next = current.next();
            if (!next.hasClass(sliderElementsClass)) {
                next = $(sliderElementsSelector).first();
            }
            current.removeClass(currentElementClass);
            next.addClass(currentElementClass);
            next.show();
            next.fadeOut(interval, function () {
                $(this).css('display', 'none');
            });
        }, interval)
    };
            
    // Hides the current element and shows the next one with class sliderElementsClass
    function nextSliderElement() {
        clearInterval(slideInterval);
        var current = $(currentElementSelector);
        var next = current.next();
        if (!next.hasClass(sliderElementsClass)) {
            next = $(sliderElementsSelector).first();
        }
                    
        current.removeClass(currentElementClass);
        current.css('display', 'none');
        next.addClass(currentElementClass);
        next.show();
    }
            
    // Hides the current element and shows the previous one with class sliderElementsClass
    function previousSliderElement() {
        clearInterval(slideInterval);
        var current = $(currentElementSelector);
        var previous = current.prev();
        if (!previous.hasClass(sliderElementsClass)) {
            previous = $(sliderElementsSelector).last();
        }
            
        current.removeClass(currentElementClass);
        current.css('display', 'none');
        previous.addClass(currentElementClass);
        previous.show();
    }
}(jQuery)
);