
//Javascript to manage answer selection

//Private variables
var divArray = new Array();
var checkArray = new Array();
var exDivArray = new Array();

var status = 0;
var count = 0;

//Function called on body load which finds div, checkboxes and excelusive checkboxes from the page
function init() {
    //initialize all the Arrays
    divArray = ["divAns1", "divAns2", "divAns3", "divAns4"];
    checkArray = ["check1", "check2", "check3", "check4"];
    exDivArray = ["divAns3"];

    //set count to number of exclusive checkbox count and status to 0 that means unchecked
    count = exDivArray.length;
    status = 0;
}

//click event handler if checkbox is clicked
function cbClicked() {
    status = 1;
    changeColor();
}

//click event hanlder for exclusive divisions
function divClickedOnlyThis(id) {

    //set selected to the clicked division
    var checkClicked;
    for (var i = 0; i < divArray.length; i++) {
        if (divArray[i] == id) {
            checkClicked = document.getElementById(String(checkArray[i]));
            if (status == 1)
                status = 0;
            else checkClicked.checked = !checkClicked.checked;
        }
    }

    //change the counter
    if (checkClicked.checked) {
        count--;
    }
    else {
        count++;
    }

    //uncheck non-exclusive answers
    for (var i = 0; i < divArray.length; i++) {

        var checkID = document.getElementById(String(checkArray[i]));
        //check if current div is exclusive,,,if no then set it unselected
        if (checkClicked.checked == true && divArray[i] != id) {
            var flag = 0;
            for (var j = 0; j < exDivArray.length; j++) {
                if (divArray[i] == exDivArray[j]) {
                    flag = 1;
                    break;
                }
            }
            if (flag == 0) {
                checkID.checked = false;
            }
        }
    }
    //call method to set the background color of div
    changeColor();
}

//click event handler for non-exclusive divisions
function divClicked(id) {

    //find the current clicked division
    for (var i = 0; i < divArray.length; i++) {
        if (divArray[i] == id) {
            var checkID = document.getElementById(String(checkArray[i]));
            //Check if any exclusive option is selected or not
            //If no then select the current one
            if (count == exDivArray.length) {
                if (status == 1)
                    status = 0;
                else checkID.checked = !checkID.checked;
            }
            else {
                checkID.checked = false;
            }
        }
    }
    //call the method to change the background color of selected div
    changeColor();
}

//method to change background color of selected divs
function changeColor() {
    //traverse through the array and check if they are selected or not

    for (var i = 0; i < divArray.length; i++) {
        var checkID = document.getElementById(checkArray[i]);
        var divID = document.getElementById(divArray[i]);
        //check the status
        //if selected , then set background color
        if (checkID.checked)
            divID.style.backgroundColor = '#6699FF';
        else
            divID.style.backgroundColor = '#f2f2f2';
    }
}