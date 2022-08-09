"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${message}`;
});

connection.start().then(function () {　　//SignalR接続時に、ルームへ参加する処理
    document.getElementById("sendButton").disabled = false;

    var roomName = document.getElementById("roomName").value;
    connection.invoke("AddToGroup", roomName).catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {　//ルームごとにメッセージを送信する
    var roomName = document.getElementById("roomName").value;
    var user = ""
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessageToGroup", roomName, user,message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
    document.getElementById("messageInput").value = "";
});