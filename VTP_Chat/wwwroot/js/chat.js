"use strict";

//const { data } = require("jquery");

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

var enterGroup = document.getElementById("enterGroup");
var sendMessageForm = document.getElementById("sendMessageForm");
var leaveGroup = document.getElementById("leaveGroup");
var clearMessages = document.getElementById("clearMessages");

connection.on("ReceiveMessage", function (user, message) {
    const d = new Date();
    let hour = (d.getHours());
    let minute = (d.getMinutes());
    let second = (d.getSeconds());
    let li = `<li class="list-group-item">
                    <b>${user}</b>
                    <p>${message}</p>
                <span class="text-muted d-flex justify-content-end">${hour}:${minute}:${second}</span>
                </li>`
    document.getElementById("appendMessage").innerHTML += li;
});

connection.start().then(function () {
    if (localStorage.getItem("user")) {
        enterGroup.parentElement.parentElement.parentElement.classList.add("d-none");
        sendMessageForm.parentElement.parentElement.classList.remove("d-none");
        let user = JSON.parse(localStorage.getItem("user"));
        connection.invoke("AddGroupAsync", user.group);
    }
}).catch(function (err) {
    return console.error(err.toString());
});

enterGroup.addEventListener("submit", function (ev) {
    //ev.preventDefault();
    let user = {
        userName: document.getElementById("userName").value,
        group: document.getElementById("group").value
    };
    localStorage.setItem("user", JSON.stringify(user));
    connection.invoke("AddGroupAsync", user.group);
    /*connection.invoke("CurrentMessages", user.group);*/
    //var num = document.getElementById("group").value;
    hiddenArea();
})



clearMessages.addEventListener("submit", function (ev) {
    ev.preventDefault();
    //console.log("s")
    let user = JSON.parse(localStorage.getItem("user"));
    connection.invoke("Clear", user.group);
    location.reload();
})

leaveGroup.addEventListener("click", function () {
    let user = JSON.parse(localStorage.getItem("user"));
    localStorage.removeItem("user");
    enterGroup.parentElement.parentElement.parentElement.classList.remove("d-none");
    sendMessageForm.parentElement.parentElement.classList.add("d-none");
    connection.invoke("RemoveGroupAsync", user.group);
})

sendMessageForm.addEventListener("submit", function (ev) {
    ev.preventDefault();
    var message = document.querySelector("textarea").value;
    if (message == "") {
        document.getElementById("validation").innerHTML = "Textarea is null";
    }
    else {
        var message = document.querySelector("textarea").value;
        let user = JSON.parse(localStorage.getItem("user"));
        connection.invoke("SendMessage", user.userName, user.group, message)
        document.getElementById("validation").innerHTML = "";
        document.querySelector("textarea").value = "";
    }
})

function hiddenArea() {
    enterGroup.parentElement.parentElement.parentElement.classList.add("d-none");
    sendMessageForm.parentElement.parentElement.classList.remove("d-none");
}

//$(document).ready(function () {
//    $(document).on("submit", "#enterGroup", function (ev) {
//        ev.preventDefault();
//        var number = $("#group :selected").val();
//        $.ajax({
//            url: "/Home/Index",
//            data: {
//                num: number
//            },
//            type: "GET",
//            success: function (result) {
//                alert("yes")
//            }
//        })
//    })
//})