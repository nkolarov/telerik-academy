if (!Object.create) {
    Object.create = function (obj) {
        function f() { };
        f.prototype = obj;
        return new f();
    };
}

if (!Object.prototype.extend) {
    Object.prototype.extend = function (properties) {
        function f() { };
        f.prototype = Object.create(this);
        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        f.prototype._super = this;
        return new f();
    };
}

var iconsEnumeration = {
    pdfIcon: "/icons/pdfIcon.jpg",
    wordIcon: "/icons/wordIcon.jpg",
    audioIcon: "/icons/audioIcon.jpg",
    videoIcon: "/icons/videoIcon.jpg",
};

var File = {
    init: function (title, size, icon, url) {
        this.title = title;
        this.size = size;
        this.icon = icon;
        this.url = url;
    }
};

var FilePDF = File.extend({
    init: function (title, size, url) {
        File.init.call(this, title, size, iconsEnumeration.pdfIcon, url);
    }
});

var FileWORD = File.extend({
    init: function (title, size, url) {
        File.init.call(this, title, size, iconsEnumeration.wordIcon, url);
    }
});

var FileAudio = File.extend({
    init: function (title, size, url) {
        File.init.call(this, title, size, iconsEnumeration.audioIcon, url);
    }
});

var FileVideo = File.extend({
    init: function (title, size, url) {
        File.init.call(this, title, size, iconsEnumeration.videoIcon, url);
    }
});