$('document').ready(function () {
    var allFolders = [];
    var allFiles = [];

    // Prototypical OOP Extend Methods
    if (!Object.create) {
        Object.create = function (obj) {
            function f() {
            };
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

    // HTML escape method
    var escapeHTML = function (html) {
        var escaped = html;
        var findReplace = [[/&/g, "&amp;"], [/</g, "&lt;"], [/>/g, "&gt;"], [/"/g, "&quot;"]]
        for (var item in findReplace)
            escaped = escaped.replace(findReplace[item][0], findReplace[item][1]);
        return escaped;
    }

    // File repository control
    var FileRepositoryControl = (function () {
        // File Repository Variable (Singleton)
        var fileRepo;

        // File repository
        var FileRepository = {
            init: function (selector) {
                this.fileRepoContainer = $("#file-repo-container").addClass('current-folder');
                this.folders = [];
                this.files = [];
                that = this;

                this.fileRepoContainer.dblclick(function (e) {
                    if ($(e.target).hasClass('folder-element')) {
                        $('.current-folder').removeClass('current-folder');
                        $('.parent-folder').removeClass('parent-folder');
                        $(e.target).addClass('current-folder');
                        var el = e.target;
                        while (el.parentNode != document.getElementById('file-repo-container')) {
                            $(el.parentNode).addClass('parent-folder');
                            el = el.parentNode;
                        }
                        that.render();
                    }
                    else if ($(e.target.parentNode).hasClass('folder-element') &&
                             !$(e.target.parentNode).hasClass('current-folder')) {
                        $('.current-folder').removeClass('current-folder');
                        $(e.target.parentNode).addClass('current-folder');
                        var el = e.target.parentNode;
                        while (el.parentNode != document.getElementById('file-repo-container')) {
                            $(el.parentNode).addClass('parent-folder');
                            el = el.parentNode;
                        }
                        that.render();
                    }
                });
            },
            render: function () {
                this.fileRepoContainer.empty();
                for (var i = 0; i < this.folders.length; i++) {
                    this.fileRepoContainer.append(this.folders[i].render());
                }
                for (var i = 0; i < this.files.length; i++) {
                    this.fileRepoContainer.append(this.files[i].render());
                }
            },
            addFolder: function (folder) {
                this.folders.push(folder);
                this.render();
            },
            addFile: function (file) {
                this.files.push(file);
                this.render();
            },
            getFileRepositoryData: function () {
                var serializedData = {};

                // Serialize files
                if (this.files.length > 0) {
                    var serializedFiles = [];
                    for (var i = 0; i < this.files.length; i += 1) {
                        var serializedFile = this.files[i].serialize();
                        serializedFiles.push(serializedFile);
                    }
                    serializedData.files = serializedFiles;
                }

                // Serialize folders
                if (this.folders.length > 0) {
                    var serializedFolders = [];
                    for (var i = 0; i < this.folders.length; i += 1) {
                        var serializedFolder = this.folders[i].serialize();
                        serializedFolders.push(serializedFolder);
                    }
                    serializedData.folders = serializedFolders;
                }

                return serializedData;
            }
        };

        // Folder
        var Folder = {
            init: function (title) {
                this.folder = $('<div></div>').addClass('folder-element');
                this.title = escapeHTML(title);
                this.folders = [];
                this.files = [];
            },
            render: function () {
                this.folder.empty();
                if (this.folder.hasClass('parent-folder')) {
                    for (var i = 0; i < this.folders.length; i++) {
                        if (this.folders[i].folder.hasClass('current-folder') ||
                            this.folders[i].folder.hasClass('parent-folder')) {
                            this.folder.append(this.folders[i].render());
                        }
                    }
                }
                else if (!this.folder.hasClass('current-folder')) {
                    this.folder.append('<p>' + this.title + '</p>');
                }
                else {
                    for (var i = 0; i < this.folders.length; i++) {
                        this.folder.append(this.folders[i].render());
                    }
                    for (var i = 0; i < this.files.length; i++) {
                        this.folder.append(this.files[i].render());
                    }
                }
                return this.folder;
            },
            addFolder: function (folder) {
                this.folders.push(folder);
                this.render();
            },
            addFile: function (file) {
                this.files.push(file);
                this.render();
            },
            serialize: function () {
                var serializedFolderData = {
                    title: this.title
                };

                // Serialize files
                if (this.files.length > 0) {
                    var serializedFiles = [];
                    for (var i = 0; i < this.files.length; i += 1) {
                        var serializedFile = this.files[i].serialize();
                        serializedFiles.push(serializedFile);
                    }
                    serializedFolderData.files = serializedFiles;
                }

                // Serialize folders
                if (this.folders.length > 0) {
                    var serializedFolders = [];
                    for (var i = 0; i < this.folders.length; i += 1) {
                        var serializedFolder = this.folders[i].serialize();
                        serializedFolders.push(serializedFolder);
                    }
                    serializedFolderData.folders = serializedFolders;
                }

                return serializedFolderData;
            }
        };

        // File
        var File = {
            init: function (params) {
                this.file = $('<div></div>').addClass('file-element');
                this.params = params;
                this.title = params.title;
                this.size = params.size;
                this.url = params.url;
                this.objectType = params.objectType;
            },
            render: function () {
                this.file.empty();
                return this.file.append('<p>' + this.title + '</p>');
            },
            serialize: function () {
                var serializedFile = {}
                for (var prop in this.params) {
                    if (prop != 'extend') {
                        serializedFile[prop] = this.params[prop];
                    }
                }

                return serializedFile;
            }
        };

        //Text File
        var FileText = File.extend({
            init: function (params) {
                if (!params.objectType) {
                    params.objectType = 'Text';
                }
                File.init.call(this, params);
                this.charset = params.charset;
                this.file.addClass('file-text');
            }
        });

        // Multimedia File
        var FileMultimedia = File.extend({
            init: function (params) {
                if (!params.objectType) {
                    params.objectType = 'Multimedia';
                }
                File.init.call(this, params);
                this.length = params.length;
                this.file.addClass('file-multimedia');
            }
        });

        // PDF file
        var FilePDF = FileText.extend({
            init: function (params) {
                if (!params.objectType) {
                    params.objectType = 'PDF';
                }
                FileText.init.call(this, params);
                this.numberOfPages = params.numberOfPages;
                this.file.addClass('file-pdf');
            }
        });

        // Word file
        var FileWord = FileText.extend({
            init: function (params) {
                if (!params.objectType) {
                    params.objectType = 'Word';
                }
                FileText.init.call(this, params);
                this.wordCount = params.wordCount;
                this.file.addClass('file-word');
            }
        });

        // Excel file
        var FileExcel = FileText.extend({
            init: function (params) {
                if (!params.objectType) {
                    params.objectType = 'Excel';
                }
                FileText.init.call(this, params);
                this.rows = params.rows;
                this.cols = params.cols;
                this.file.addClass('file-excel');
            }
        });

        // Audio file
        var FileAudio = FileMultimedia.extend({
            init: function (params) {
                if (!params.objectType) {
                    params.objectType = 'Audio';
                }
                FileMultimedia.init.call(this, params);
                this.sampleRate = params.sampleRate;
                this.file.addClass('file-audio');
            }
        });

        // Video file
        var FileVideo = FileMultimedia.extend({
            init: function (params) {
                if (!params.objectType) {
                    params.objectType = 'Video';
                }
                FileMultimedia.init.call(this, params);
                this.frameRate = params.frameRate;
                this.file.addClass('file-video');
            }
        });

        return {
            getFileRepo: function (selector) {
                if (typeof fileRepo == 'undefined') {
                    fileRepo = Object.create(FileRepository);
                    fileRepo.init(selector);
                }
                return fileRepo;
            },
            createFolder: function (title) {
                var folder = Object.create(Folder);
                folder.init(title);
                return folder;
            },
            createFile: function (type, params) {
                var file;
                switch (type) {
                    case 'PDF': {
                        file = Object.create(FilePDF);
                        break;
                    }
                    case 'Word': {
                        file = Object.create(FileWord);
                        break;
                    }
                    case 'Excel': {
                        file = Object.create(FileExcel);
                        break;
                    }
                    case 'Audio': {
                        file = Object.create(FileAudio);
                        break;
                    }
                    case 'Video': {
                        file = Object.create(FileVideo);
                        break;
                    }
                }
                file.init(params);
                return file;
            }
        }
    })();

    var repo = FileRepositoryControl.getFileRepo("#file-repo-container");
    allFolders.push(repo);

    $('#save-to-repository').click(function () {
        var fileGaleryData = repo.getFileRepositoryData();
        console.log(fileGaleryData);
        fileGalleryRepository.save("fileGallery", fileGaleryData);
    });

    $('#load-from-repository').click(function () {
        var fileGaleryData = fileGalleryRepository.load("fileGallery");
        buildFileGallery(fileGaleryData);
    });

    $('#back-button').click(function () {
        var currentFolder = $('.current-folder');
        if (!currentFolder.is('#file-repo-container')) {
            $('.current-folder').removeClass('current-folder');
            $('.parent-folder').removeClass('parent-folder');
            currentFolder.parent().addClass('current-folder');
            var el = currentFolder.parent();
            while (!el.is('#file-repo-container')) {
                el.parent().addClass('parent-folder');
                el = el.parent();
            }
            that.render();
        }
    });

    $('#create-folder-button').click(function () {
        $('#create-folder-dialog').css('display', 'block');
        $('#create-file-dialog').css('display', 'none');
        folderSelectUpdate('#create-folder-select');
    });

    $('#create-folder-submit').click(function (e) {
        e.preventDefault();
        var selected = $('#create-folder-select').val();
        var title = $('#folder-title-input').val();
        var folder = FileRepositoryControl.createFolder(title);
        allFolders[selected].addFolder(folder);
        allFolders.push(folder);
        folder.folder.data('index', allFolders.length - 1);
        $('#create-folder-dialog').css('display', 'none');
        $('#folder-title-input').val('');
    });

    $('#create-folder-cancel').click(function (e) {
        e.preventDefault();
        $('#create-folder-dialog').css('display', 'none');
    });

    $('#create-file-button').click(function () {
        $('#create-file-type').change();
        $('#create-file-dialog').css('display', 'block');
        $('#create-folder-dialog').css('display', 'none');
        folderSelectUpdate('#create-file-select');
    });

    $('#create-file-submit').click(function (e) {
        e.preventDefault();
        var selected = $('#create-file-select').val();
        var type = $('#create-file-type').val();
        var params = {};
        params.title = $('#file-title-input').val();
        params.size = $('#file-size-input').val();
        params.url = $('#file-url-input').val();
        switch (type) {
            case 'PDF': {
                params.charset = $('#file-charset-input').val();
                params.numberOfPages = $('#file-numOfPages-input').val();
                break;
            }
            case 'Word': {
                params.charset = $('#file-charset-input').val();
                params.wordCount = $('#file-wordCount-input').val();
                break;
            }
            case 'Excel': {
                params.charset = $('#file-charset-input').val();
                params.rows = $('#file-rows-input').val();
                params.cols = $('#file-cols-input').val();
                break;
            }
            case 'Audio': {
                params.length = $('#file-length-input').val();
                params.sampleRate = $('#file-sampleRate-input').val();
                break;
            }
            case 'Video': {
                params.length = $('#file-length-input').val();
                params.frameRate = $('#file-frameRate-input').val();
                break;
            }
        }
        var file = FileRepositoryControl.createFile(type, params);
        allFolders[selected].addFile(file);
        allFiles.push(file);
        file.file.data('index', allFiles.length - 1);
        $('#create-file-dialog').css('display', 'none');
        $('#file-title-input').val('');
        $('#file-size-input').val('');
        $('#file-url-input').val('');
    });

    $('#create-file-cancel').click(function (e) {
        e.preventDefault();
        $('#create-file-dialog').css('display', 'none');
    });

    $('#create-file-type').change(function () {
        var type = $('#create-file-type').val();
        var specifics = $('#create-file-specifics');
        var contents = '';
        switch (type) {
            case 'PDF': {
                contents = '<label for="file-charset-input">Charset:</label>\
                            <input type="text" name="charset" id="file-charset-input" /><br />\
                            <label for="file-numOfPages-input">Number of pages:</label>\
                            <input type="text" name="numOfPages" id="file-numOfPages-input" /><br />';
                break;
            }
            case 'Word': {
                contents = '<label for="file-charset-input">Charset:</label>\
                            <input type="text" name="charset" id="file-charset-input" /><br />\
                            <label for="file-wordCount-input">Word count:</label>\
                            <input type="text" name="wordCount" id="file-wordCount-input" /><br />';
                break;
            }
            case 'Excel': {
                contents = '<label for="file-charset-input">Charset:</label>\
                            <input type="text" name="charset" id="file-charset-input" /><br />\
                            <label for="file-rows-input">Rows:</label>\
                            <input type="text" name="rows" id="file-rows-input" /><br />\
                            <label for="file-cols-input">Cols:</label>\
                            <input type="text" name="cols" id="file-cols-input" /><br />';
                break;
            }
            case 'Audio': {
                contents = '<label for="file-length-input">Length:</label>\
                            <input type="text" name="length" id="file-length-input" /><br />\
                            <label for="file-sampleRate-input">Sample Rate:</label>\
                            <input type="text" name="sampleRate" id="file-sampleRate-input" /><br />';
                break;
            }
            case 'Video': {
                contents = '<label for="file-length-input">Length:</label>\
                            <input type="text" name="length" id="file-length-input" /><br />\
                            <label for="file-frameRate-input">Frame Rate:</label>\
                            <input type="text" name="frameRate" id="file-frameRate-input" /><br />';
                break;
            }
        }

        specifics.html(contents);
    });

    function folderSelectUpdate(selector) {
        var root = FileRepositoryControl.getFileRepo();
        var select = $(selector);
        var options = getNestedFolders(root, 0);
        select.html(options);
    }

    function getNestedFolders(root, level) {
        if (root == FileRepositoryControl.getFileRepo()) {
            result = '<option value="' + allFolders.indexOf(root) + '">' + Array(level).join('-') + 'Root</option>\n';
        }
        else {
            result = '<option value="' + allFolders.indexOf(root) + '">' + Array(level).join('-') + root.title + '</option>\n';
        }
        for (var i = 0; i < root.folders.length; i++) {
            result += getNestedFolders(root.folders[i], level + 1);
        }
        return result;
    }

    //function selectFileHandler(e) {
    //    var infoBox = $('#file-repo-info');
    //    var content = '';
    //    var selected = allFiles[$(e.currentTarget).data('index')];
    //    content = '<h4>' + selected.title + '</h4><ul>';
    //    for (var prop in selected) {
    //        content += '<li>' + prop + ': ' + selected[prop] + '</li>';
    //    }
    //    content += '</ul>';
    //    infoBox.html(content);
    //}

    //function selectFolderHandler(e) {
    //    var infoBox = $('#file-repo-info');
    //    var content = '';
    //    var selected = allFolders[$(e.currentTarget).data('index')];
    //    content = '<h4>' + selected.title + '</h4><ul>';
    //    for (var prop in selected) {
    //        content += '<li>' + prop + ': ' + selected[prop] + '</li>';
    //    }
    //    content += '</ul>';
    //    infoBox.html(content);
    //}

    function buildFileGallery(fileGalleryData) {
        if (fileGalleryData) {
            if (fileGalleryData.files) {
                for (var i = 0; i < fileGalleryData.files.length; i++) {
                    var fileType = fileGalleryData.files[i].objectType;
                    var params = {};
                    for (var prop in fileGalleryData.files[i]) {
                        if (prop != 'extend') {
                            params[prop] = fileGalleryData.files[i][prop];
                        }
                    }
                    var file = FileRepositoryControl.createFile(fileType, params);
                    repo.addFile(file);
                    allFiles.push(file);
                    file.file.data('index', allFiles.length - 1);
                }
            }

            if (fileGalleryData.folders) {
                for (var i = 0; i < fileGalleryData.folders.length; i++) {
                    if (fileGalleryData.folders[i]) {
                        var folder = buildFolder(fileGalleryData.folders[i]);
                        repo.addFolder(folder);
                    }
                }
            }
        }
    }

    function buildFolder(data) {
        var title = data.title;
        var folder = FileRepositoryControl.createFolder(title);
        if (data.files) {
            addFiles(folder, data.files);
        }
        if (data.folders) {
            for (var i = 0; i < data.folders.length; i++) {
                if (data.folders[i]) {
                    var subFolder = buildFolder(data.folders[i]);
                    folder.addFolder(subFolder);
                }
            }
        }
        allFolders.push(folder);
        folder.folder.data('index', allFolders.length - 1);
        return folder;
    }

    function addFiles(folder, files) {
        for (var i = 0; i < files.length; i++) {
            var fileType = files[i].objectType;
            var params = {};
            for (var prop in files[i]) {
                if (prop != 'extend') {
                    params[prop] = files[i][prop];
                }
            }
            var file = FileRepositoryControl.createFile(fileType, params);
            folder.addFile(file);
            allFiles.push(file);
            file.file.data('index', allFiles.length - 1);
        }
    }
});