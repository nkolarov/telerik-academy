/*
02. Create a TODO list with the following UI controls
- Form input for new Item
- Button for adding the new Item
- Button for deleting some item
- Show and Hide Button
*/

var addButton = document.getElementById("add");
var removeButton = document.getElementById("remove");
var hideButton = document.getElementById("hide");
var showButton = document.getElementById("show");

/*
* Prepares a new checkbox element.
*/
function initializeToDoTask(currentTask) {
    var check = document.createElement("input");
    check.type = "checkbox";
    check.name = "checkbox";

    // http://stackoverflow.com/questions/6293588/how-to-create-an-html-checkbox-with-a-clickable-label
    var task = document.createElement("label");
    task.style.display = "block";
    task.appendChild(check);
    task.appendChild(document.createTextNode(currentTask));

    return task;
}

/*
* Adds a new task to the list.
*/
function addTask() {
    var currentTask = document.getElementById("task");
    var currentTaskValue = currentTask.value;
    var list = document.getElementById("list");

    if (currentTaskValue == "" || currentTaskValue == null) {
        alert("Please Enter a Task!");
        return;
    }

    var currentToDoTask = initializeToDoTask(currentTaskValue);
    list.appendChild(currentToDoTask);

    // Clear task input element.
    currentTask.value = "";
}

/*
* Removes all selected tasks.
*/
function removeSelectedTasks() {
    var selectedCheckboxes = document.querySelectorAll("input[type=checkbox]:checked");

    for (var i = 0; i < selectedCheckboxes.length; i++) {
        var currentTask = selectedCheckboxes[i];
        var currentTaskLabel = currentTask.parentNode;
        if (currentTaskLabel.style.display == "block") {
            currentTaskLabel.parentNode.removeChild(currentTaskLabel);
        }
    }
}

/*
* Hides all selected tasks.
*/
function hideSelectedTasks() {
    var selectedCheckboxes = document.querySelectorAll("input[type=checkbox]:checked");

    for (var i = 0; i < selectedCheckboxes.length; i++) {
        selectedCheckboxes[i].parentNode.style.display = "none";
    }
}

/*
* Shows all selected tasks.
*/
function showHiddenTasks() {
    var checkboxes = document.querySelectorAll("input[type=checkbox]");

    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].parentNode.style.display == "none") {
            checkboxes[i].parentNode.style.display = "block";
        }

    }
}

addButton.addEventListener("click", addTask, false);
removeButton.addEventListener("click", removeSelectedTasks, false);
hideButton.addEventListener("click", hideSelectedTasks, false);
showButton.addEventListener("click", showHiddenTasks, false);