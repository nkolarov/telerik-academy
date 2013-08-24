/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
    var ListView = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }

            this.itemsSource = itemsSource;
        },
        render: function (template) {
            var list = document.createElement("ul");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var listItem = document.createElement("li");
                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                list.appendChild(listItem);
            }

            return list.outerHTML;
        }
    });

    var TableView = Class.create({
        init: function (itemsSource, options) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }

            if (options.cols) {
                if (options.cols <= 0) {
                    throw "The number of columns must be a positive integer!";
                }

                this.cols = options.cols;
                this.rows = itemsSource.length / options.cols;
            } else if (options.rows) {
                if (options.rows <= 0) {
                    throw "The number of rows must be a positive integer!";
                }

                this.rows = options.rows;
                this.cols = itemsSource.length / options.rows;

                // 13 items -> 2 rows 7 columns
                if (itemsSource.length % this.rows > 0) {
                    this.cols++;
                }
            }

            this.itemsSource = itemsSource;
        },
        render: function (template) {
            var tableRoot = document.createElement("table");
            var tableBody = document.createElement("tbody");
            var fragment = document.createDocumentFragment();

            var tr = document.createElement("tr");

            for (var i = 0; i < this.itemsSource.length; i++) {
                if (i % this.cols == 0 && i != 0) {
                    tableBody.appendChild(tr);
                    tr = document.createElement("tr");
                }

                if (i == this.itemsSource.length - 1) {
                    tableBody.appendChild(tr);
                }

                var td = document.createElement("td");
                var item = this.itemsSource[i];
                td.innerHTML = template(item);
                tr.appendChild(td);
            }

            tableBody.appendChild(fragment);
            tableRoot.appendChild(tableBody);

            return tableRoot.outerHTML;
        }
    });

    c.getListView = function (itemsSource) {
        return new ListView(itemsSource);
    }

    c.getTableView = function (itemsSource, options) {
        return new TableView(itemsSource, options);
    }

}(controls || {}));