"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

////Disable the send button until connection is established.
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    var li = document.createElement("p");
//    document.getElementById("messagesList").appendChild(li);
//    // We can assign user-supplied strings to an element's textContent because it
//    // is not interpreted as markup. If you're assigning in any other way, you
//    // should be aware of possible script injection concerns.
//    li.textContent = `${message}`;
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});
var enterGroup = document.getElementById("enterGroup");
var sendMessageForm = document.getElementById("sendMessageForm");
var leaveGroup = document.getElementById("leaveGroup");

if (localStorage.getItem("user")) {
    enterGroup.parentElement.parentElement.parentElement.classList.add("d-none");
    sendMessageForm.parentElement.parentElement.classList.remove("d-none");
}


enterGroup.addEventListener("submit", function (ev) {
    ev.preventDefault();
    let user = {
        userName: document.getElementById("userName").value,
        group: document.getElementById("group").value
    };
    localStorage.setItem("user", JSON.stringify(user));
    hiddenArea();
})

leaveGroup.addEventListener("click", function () {
    localStorage.removeItem("user");
    enterGroup.parentElement.parentElement.parentElement.classList.remove("d-none");
    sendMessageForm.parentElement.parentElement.classList.add("d-none");
})

sendMessageForm.addEventListener("submit", function (ev) {
    ev.preventDefault();
    var message = document.querySelector("textarea").value;
    if (message == "") {
        document.getElementById("validation").innerHTML = "Textarea is null";
    }
    else {
        let user = JSON.parse(localStorage.getItem("user"));
        const d = new Date();
        let hour = (d.getHours());
        let minute = (d.getMinutes());
        let second = (d.getSeconds());
        let li = `<li class="list-group-item">
                    <b>${user.userName}</b>
                    <p>${message}</p>
                    <span class="text-muted d-flex justify-content-end">${hour}:${minute}:${second}</span>
                </li>`
        document.getElementById("appendMessage").innerHTML += li;
        document.querySelector("textarea").value = "";
    }
})
//function getTime() {
//    const d = new Date();
//    let hour = (d.getHours());
//    let minute = (d.getMinutes());
//    let second = (d.getSeconds());
//    return hour, minute, second;
//}

function hiddenArea() {
    enterGroup.parentElement.parentElement.parentElement.classList.add("d-none");
    sendMessageForm.parentElement.parentElement.classList.remove("d-none");
}
