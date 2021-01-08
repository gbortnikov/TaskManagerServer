using SuperSocket.SocketBase;
using System;
using SuperWebSocket;

namespace Ws
{
    class WebSocket
    {
        private static WebSocketServer wsServer = new WebSocketServer();
        /// <summary>
        /// Инициализация websocket
        /// </summary>

        public void WSInit(int port)
        {
            wsServer.Setup(port);
            wsServer.NewSessionConnected += WsServer_NewSessionConnected;
            wsServer.NewMessageReceived += WsServer_NewMessageReceived;
            wsServer.NewDataReceived += WsServer_NewDataReceived;
            wsServer.SessionClosed += WsServer_SessionClosed;
            wsServer.Start();
            Console.WriteLine("Server is run " + port);
        }

        private void WsServer_SessionClosed(WebSocketSession session, CloseReason value)
        {
            Console.WriteLine("SessionClosed");
        }

        private void WsServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            Console.WriteLine("NewDataReceived" + wsServer.SessionCount);
        }


        private void WsServer_NewMessageReceived(WebSocketSession session, string value)
        {
            Console.WriteLine("NewMessageReceived: " + value + "\tfrom:" + session.SocketSession.RemoteEndPoint.Address);

            ProcessingResponsesWS processingResponses = new ProcessingResponsesWS(value);       //обработка сообщения 
            session.Send(processingResponses.AnswerBD);                                         // отправка ответа клиенту
        }

        private void WsServer_NewSessionConnected(WebSocketSession session)
        {
            Console.WriteLine("NewSessionConnected");
        }
    }
}
