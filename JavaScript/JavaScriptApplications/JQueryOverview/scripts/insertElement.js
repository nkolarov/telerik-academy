/* 02. Using jQuery implement functionality to insert a DOM element before or after another element. */
(function ($) {
    // Attach events handlers.
    $("#addFirst").on("click", function () {
        var content = $("#elementData").val();
        $("#list").prepend($("<li>" + content + "</li>"));
    });
    $("#addLast").on("click", function () {
        var content = $("#elementData").val();
        $("#list").append($("<li>" + content + "</li>"));
    });
    
}(jQuery)
);