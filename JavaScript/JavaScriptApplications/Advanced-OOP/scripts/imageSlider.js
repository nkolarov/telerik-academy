// Represents an Button
var Image = {
    init: function (title, smallUrl, bigUrl) {
        this.title = title;
        this.smallUrl = smallUrl;
        this.bigUrl = bigUrl;
    }
}

// Represents a Button
var Button = {
    init: function (id, title) {
        this.id = id;
        this.title = title;
    }
};

// Represents a Slider
var Slider = {
    init: function (parentSelector, images) {
        this.container = document.getElementById(parentSelector);
        this.images = images;
        this.slideWrapper = document.createElement("div");
        this.slideWrapper.id = 'slide-wrapper';
        this.slideWrapper.style.width = 1000 + 'px';
        this.nav = document.createElement("div");
        this.nav.id = 'nav';
    },
    render: function () {
        this.generateButton(this.prevButton, this.previousImage);
        this.generateButton(this.nextButton, this.nextImage);
        this.renderImages();
    },
    nextImage: function () {
        var slide = document.getElementById("slider-images");
        var position = parseInt(slide.style.left, 10);
        var currentPos = -(parseInt(slide.style.width, 10) - 216);
        if (position > currentPos) {
            position = position - 108;
            slide.style.left = position + "px";
        }
    },
    previousImage: function () {
        var slide = document.getElementById("slider-images");
        var position = parseInt(slide.style.left, 10);
        if (position < 0) {
            position = position + 108;
            slide.style.left = position + "px";
        }
    },
    renderImages: function () {
        var imageHolder = document.createElement("div");
        imageHolder.id = 'image-holder';

        var bigImage = document.createElement("img");
        bigImage.src = this.images[0].bigUrl;
        imageHolder.appendChild(bigImage);
        this.container.appendChild(imageHolder);

        var imageSliderHolder = document.createElement("div");
        imageSliderHolder.style.left = 0;
        imageSliderHolder.id = 'slider-images';
        var width = 0;
        for (var i = 0; i < this.images.length; i++) {
            var image = document.createElement("img");
            image.src = this.images[i].smallUrl;
            image.title = this.images[i].imgTitle;
            image.data = this.images[i].bigUrl;
            image.onclick = function (ev) {
                bigImage.src = this.data;
                imageHolder.innerText = '';
                imageHolder.appendChild(bigImage);
            };
            width += 300;
            imageSliderHolder.style.width = width + "px";
            imageSliderHolder.appendChild(image);
        }
        this.slideWrapper.appendChild(imageSliderHolder);
        this.nav.appendChild(this.slideWrapper);
        this.container.appendChild(this.nav);
    },
    prevButton: function (id, title) {
        this.prevButton = Object.create(Button);
        this.prevButton.init(id, title);
    },
    nextButton: function (id, title) {
        this.nextButton = Object.create(Button);
        this.nextButton.init(id, title);
    },
    generateButton: function (obj, func) {
        var btn = document.createElement("button");
        btn.id = obj.id;
        btn.textContent = obj.title;
        btn.style.cursor = 'pointer';
        this.nav.appendChild(btn);
        btn.onclick = func;
    },
};