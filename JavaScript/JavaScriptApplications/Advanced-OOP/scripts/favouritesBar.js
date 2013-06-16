// Represents a url.
var Url = Class.create({
    init: function (title, link) {
        this.title = title;
        this.link = link;
    }
});

// Represents a folder.
var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    }
});

// Represents a side bar.
var FavoriteSitesBar = Class.create({
    init: function (urls, folders) {
        this.urls = urls;
        this.folders = folders;
    },
    render: function (parent) {
        // TODO: Beautify when you have some free time.
    }
});