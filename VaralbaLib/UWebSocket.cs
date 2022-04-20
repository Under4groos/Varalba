using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using WebSocketSharp;

namespace VaralbaLib
{

    public enum SocketStatusType
    {
        OPEN,
        CLOSED,
    }

    public class UWebSocket
    {
        List<string> messages_ = new List<string>();

        WebSocket webSocket;
        public string WebSocketHost
        { get; set; } = "ws://77.246.158.191/app10"; // "ws://localhost:2332";

        public SocketStatusType StatusWebSocket
        {
            get; private set;
        } = SocketStatusType.CLOSED;


        public Action<string> NewMessage;


        public void Close()
        {
            webSocket.Close();
            webSocket.CloseAsync();
            webSocket = null;
        }

        public void Init()
        {

            new Thread(() => 
            {
                int timesleep = 0;


                webSocket = new WebSocket(WebSocketHost);

                webSocket.OnMessage += (sender, e) =>
                {
                    if (NewMessage != null)
                        NewMessage(e.Data);
                };
                webSocket.OnClose += (o, e) =>
                {
                    StatusWebSocket = SocketStatusType.CLOSED;

                    while (true)
                    {


                        if (DateTime.Now.TimeOfDay.Seconds > timesleep)
                        {

                            webSocket.Connect();

                            if (StatusWebSocket == SocketStatusType.OPEN)
                                break;

                            timesleep = DateTime.Now.TimeOfDay.Seconds + 1;
                        }

                    }



                };
                webSocket.OnOpen += (o, e) =>
                {
                    StatusWebSocket = SocketStatusType.OPEN;
                    foreach (var item in messages_)
                    {
                        SendMessage(item, false);
                    }
                    messages_.Clear();
                };
                webSocket.Connect();


            }).Start();

 


        }
        public void SendMessage(string mes , bool b = true)
        {
            if (StatusWebSocket == SocketStatusType.OPEN && webSocket != null)
            {

                Dictionary<string, string> localizedWelcomeLabels = new Dictionary<string, string>();

                localizedWelcomeLabels.Add("Name", User.Name);
                localizedWelcomeLabels.Add("Message", mes);
                localizedWelcomeLabels.Add("AvatarImage", User.LinkAvatarImage);
                string json_data_ = JsonConvert.SerializeObject(localizedWelcomeLabels);

                webSocket.Send(json_data_);
            }
            else
            {
                if(b)
                    messages_.Add(mes);
            }
        }

    }
}
