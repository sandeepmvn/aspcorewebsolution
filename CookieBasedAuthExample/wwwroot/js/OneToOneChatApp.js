var connection = new signalR.HubConnectionBuilder().withUrl("/ChatHub").build();
var userName = "";

//invoke methods from server

connection.on("NewUserRegistred", function (message,lstUsers) {
    alert(message);
    console.log(lstUsers);
    var lst = document.getElementById("lstUsers");
    $("#lstUsers").html("");
    debugger;
    for (var user in lstUsers) {
        if (lstUsers[user] !== userName) {
            var option = document.createElement("option");
            option.text = lstUsers[user];
            lst.options.add(option);
        }
    }
});


connection.on("ReceiveMessage", function (fromuser, message) {
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



//inovke method from client to server

function registerUser(user) {
    userName = user;
    connection.invoke("RegisterAsync", user).then(function () {
        document.getElementById("btnRegister").disabled=true
        alert("Registered Succesfully");

    }).catch(function (err) {
        return console.error(err.toString());
    });
}


function sendMessage(message, touser) {
    connection.invoke("SendMessageTo", userName, touser, message).then(function () {
        alert("Message has sent")

    }).catch(function (err) {
        return console.error(err.toString());
    });
}
