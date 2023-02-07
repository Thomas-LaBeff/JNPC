"use strict";

/* Set the date disoplayed in the calendar */
var thisDay = new Date("July 4, 2022");

document.getElementById("calendar").innerHTML = "Testing";

function test() {
    document.getElementById("calendar").innerHTML = createCalendar(thisDay);
}


/* Function to generate the calendar table */
function createCalendar(calDate)
{
    var calendarHTML = "<table id='calendar_table'>";
    calendarHTML += calCaption(calDate);
    calendarHTML += "</table>";
    return calendarHTML;
}

function calCaption(calDate)
{
    // monthName array contains the list of month names
    var monthName = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    var thisMonth = calDate.getMonth();
    var thisYear = calDate.getFullYear();
    return "<caption>" + monthName[thisMonth] + " " + thisYear + "</caption>";
}
