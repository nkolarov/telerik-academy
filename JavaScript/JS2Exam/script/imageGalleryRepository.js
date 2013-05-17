var imageGalleryRepository = (function () {
    return {
        save: function (title, data) {
            // IE8 
            function setObject (key, obj) {
                localStorage.setItem(key, JSON.stringify(obj));
            }
            setObject(title, data);
        },
        load: function (title) {
            // IE8 
            function getObject (key) {
                return JSON.parse(localStorage.getItem(key));
            }
            return getObject(title);
        }
    }
}());