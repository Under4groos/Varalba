
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
console.log("The WebSocket server is running.");
