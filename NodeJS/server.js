

const WebSocketServer = require('ws');
const wss = new WebSocketServer.Server({ port: 2332 })
clients = []
wss.on("connection", ws => {
    console.log("new client connected");
    clients.push(ws);
    ws.on("message", event => {

         
        var json_ = JSON.parse(event);
        var string_mes = json_.Name + ": " + json_.Message;
        console.log(string_mes);
        clients.forEach(client => client.send(JSON.stringify(json_ )));
       
        

    });
    ws.on("close", () => {
        console.log("the client has connected");
    });
    ws.onerror = function () {
        console.log("Some Error occurred")
    }
});
console.log("The WebSocket server is running on port 8080");









// const WebSocket = require('ws');
// const fs = require('fs');

// const wsServer = new WebSocket.Server({ port: 2332 });
// wsServer.on('connection', onConnect);

// clients = []

 

// function onConnect(wsClient) {
//     clients.push(wsClient);
//     console.log('New user');
//     wsClient.send('Hello');
//     wsClient.on('message', function (message) {
//          //console.log(JSON.stringify(message) );

//         //var response = JSON.parse(message);
//         console.log(message.data);
      
//     });
//     wsClient.on('close', function () {
//         console.log('User has been disconnected');
//     });
// }

// console.log('Server has been started on port 2332 ');