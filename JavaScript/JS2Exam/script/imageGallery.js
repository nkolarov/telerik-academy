var controls = (function () {
    function Gallery(selector) {
        var that = this;
        var images = [];
        var albums = [];
        var galeryItem = document.querySelector(selector);
        var mainAlbum = document.createElement("ul");

        attachEventHandler(galeryItem, "click",
                           function (ev) {
                               if (!ev) {
                                   ev = window.event;
                               }
                               if (ev.stopPropagation)
                                   ev.stopPropagation();
                               if (ev.preventDefault)
                                   ev.preventDefault();

                               var clickedItem = ev.target;

                               /*Task 7*/
                               if (clickedItem instanceof HTMLImageElement) {
                                   var largerImage = document.getElementById("larger-image");
                                   
                                   // Click again to close.
                                   if (largerImage.style.display != "block") {
                                       largerImage.style.display = "block";
                                   }
                                   else {
                                       largerImage.style.display = "none";
                                   }

                                   var fc = largerImage.firstChild;

                                   while (fc) {
                                       largerImage.removeChild(fc);
                                       fc = largerImage.firstChild;
                                   }

                                   var clonedTitle = clickedItem.previousElementSibling.cloneNode(true);
                                   var clonedImage = clickedItem.cloneNode(true);
                                   clonedImage.width = 2 * clonedImage.width;
                                   clonedImage.height = 2 * clonedImage.height;
                                   largerImage.appendChild(clonedTitle);
                                   largerImage.appendChild(clonedImage);
                                   
                                   return;
                               }

                               /*Task 3*/
                               if (!(clickedItem instanceof HTMLAnchorElement)) {
                                   return;
                               }

                               var subElement = clickedItem.nextElementSibling;

                               if (subElement instanceof HTMLImageElement) {
                                   return;
                               }

                               while (subElement) {
                                   var sublistDisplay = "";
                                   if (!subElement) {
                                       return;
                                   }
                                   if (subElement.style.display === "none") {
                                       subElement.style.display = "";
                                   }
                                   else {
                                       subElement.style.display = "none";
                                   }
                                   subElement = subElement.nextElementSibling;
                               }
                           }, false);

        this.addImage = function (title, src) {
            var newImage = new Image(title, src);
            images.push(newImage);
        };

        this.addAlbum = function (title, src) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);

            return newAlbum;
        };

        this.render = function () {
            for (var i = 0; i < images.length; i++) {
                mainAlbum.appendChild(images[i].render());
            }

            for (var i = 0; i < albums.length; i++) {
                mainAlbum.appendChild(albums[i].render());
            }
            galeryItem.appendChild(mainAlbum);
        }

        this.getImageGalleryData = function () {
            var thisItem = {};

            // Seriallize Images
            if (images.length > 0) {
                var serializedImages = [];
                for (var i = 0; i < images.length; i += 1) {
                    var serItem = images[i].serialize();
                    serializedImages.push(serItem);
                }
                thisItem.images = serializedImages;
            }

            // Seriallize Albums
            if (albums.length > 0) {
                var serializedAlbums = [];
                for (var i = 0; i < albums.length; i += 1) {
                    var serItem = albums[i].serialize();
                    serializedAlbums.push(serItem);
                }
                thisItem.albums = serializedAlbums;
            }

            return thisItem;
        }
    };

    function Image(title, src) {
        var escapedTitle = title.escape();
        var escapedSrc = src.escape();

        this.render = function () {
            var imageNode = document.createElement("li");
            imageNode.innerHTML = "<a href='#' >" + escapedTitle + "</a>";
            imageNode.innerHTML += "<img src=\"" + escapedSrc + "\" alt = \"" + escapedTitle + "\"/>";
            imageNode.className += "image";
            return imageNode;
        };

        this.serialize = function () {
            var thisItem = {
                title: escapedTitle,
                src: escapedSrc
            };

            return thisItem;
        }
    }

    function Album(title) {
        var that = this;
        var escapedTitle = title.escape();
        var images = [];
        var albums = [];
        var that = this;

        this.addImage = function (title, src) {
            var newImage = new Image(title, src);
            images.push(newImage);
        };

        this.addAlbum = function (title, src) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);

            return newAlbum;
        };

        this.render = function () {
            var fragment = document.createDocumentFragment();
            var imageNode = document.createElement("li");
            imageNode.innerHTML = "<a href='#' >" + escapedTitle + "</a><br/>";
            var albumNode = document.createElement("ul");
            albumNode.style.display = "none";

            if (images.length > 0) {
                for (var i = 0; i < images.length; i++) {
                    albumNode.appendChild(images[i].render());
                }
            }

            if (albums.length > 0) {
                for (var j = 0; j < albums.length; j++) {
                    albumNode.appendChild(albums[j].render());
                }
            }
            imageNode.appendChild(albumNode);
            fragment.appendChild(imageNode);
            return fragment;
        }

        this.serialize = function () {
            var thisItem = {
                title: escapedTitle
            };

            // Seriallize Images
            if (images.length > 0) {
                var serializedImages = [];
                for (var i = 0; i < images.length; i += 1) {
                    var serItem = images[i].serialize();
                    serializedImages.push(serItem);
                }
                thisItem.images = serializedImages;
            }

            // Seriallize Albums
            if (albums.length > 0) {
                var serializedAlbums = [];
                for (var i = 0; i < albums.length; i += 1) {
                    var serItem = albums[i].serialize();
                    serializedAlbums.push(serItem);
                }
                thisItem.albums = serializedAlbums;
            }

            return thisItem;
        }
    }

    return {
        getImageGallery: function (selector) {
            return new Gallery(selector);
        },
        buildImageGallery: function (selector, imageGalleryData) {
            var gallery = this.getImageGallery(selector);

            if (imageGalleryData) {
                addToGallery(gallery, imageGalleryData);
            }

            function addImageToGallery(parent, images) {
                // Add images
                if (images) {
                    for (var i = 0; i < images.length; i++) {
                        parent.addImage(images[i].title, images[i].src);
                    }
                }
            }

            function addToGallery(parent, imageGalleryData) {
                // Add images
                if (imageGalleryData.images) {
                    addImageToGallery(parent, imageGalleryData.images)
                }
                //function addAlbum(title) {

                // Add Albums Recursively
                if (imageGalleryData.albums) {
                    var albums = imageGalleryData.albums;
                    for (var i = 0; i < albums.length; i++) {
                        var newParent = parent.addAlbum(albums[i].title);
                        if (albums[i].images && !albums[i].albums) {
                            addImageToGallery(newParent, albums[i].images);
                        }
                        if (albums[i].albums) {
                            addToGallery(newParent, albums[i]);
                        }
                    }
                }
            }
            return gallery;
        }
    }
}());