"use strict";

document.addEventListener("DOMContentLoaded", init);

function init(e) {
    const employeeDOM = document.getElementById("employeeList");

    $.getJSON("Employee/GetEmployees", function (data) {
        $.each(data, function (i, employee) {
            // Create new list-attribute for each employee
            const newAttribute = document.createElement("a");
            newAttribute.setAttribute("class", "list-group-item");
            newAttribute.innerHTML = employee.name;
            employeeDOM.appendChild(newAttribute);
        });
    });
}