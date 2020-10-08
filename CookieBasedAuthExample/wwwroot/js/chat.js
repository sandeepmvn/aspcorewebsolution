
//connection  object has to created

var connection = new signalR.HubConnectionBuilder().withUrl("/ChatHub").build();

//server invoke methods (//server to client)
connection.on("ReceiveMessage", function (fromuser, message) {
    //alert("Method invoked");
   // debugger;
    //var encodedMsg = "Message from:" + fromuser + "<br/>" + message;
    ////$("#messagesList").append("<li>" + data + "</li>");
    //var li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);

    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = fromuser + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);

});

//connection opened
connection.start().then(function () {
    alert("Connection has opened");
}).catch(function (err) {
    return console.error(err.toString());
});



//client to server
function SendMessage(user, message) {
    connection.invoke("SendMessages", user, message).catch(function (err) {
        return console.error(err.toString());
    });
}






