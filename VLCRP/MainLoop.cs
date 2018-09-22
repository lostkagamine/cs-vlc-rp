using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using DiscordRPC;
using DiscordRPC.Message;
using DiscordRPC.RPC;

namespace VLCRP
{
    class MainLoop
    {
        private bool running;
        private static DiscordRpcClient client;
        private RichPresence presence;

        public void Execute()
        {
            // todo do things
            Console.CancelKeyPress += new ConsoleCancelEventHandler(CtrlC);
            running = true;
            client = new DiscordRpcClient("410474255810035712", null, true, -1); // bind to 1st available pipe
            client.OnReady += RPCReady;

            Assets assets = new Assets()
            {
                LargeImageKey = "cone",
                LargeImageText = "VLC media player"
            };

            presence = new RichPresence()
            {
                State = "In C#",
                Details = "Test",
                Assets = assets
            };

            client.SetPresence(presence);
            client.Initialize();

            while (running && client != null)
            {
                client.Invoke();
                Thread.Sleep(15000); // sleep for 15s
            }
        }

        protected void CtrlC(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Quitting...");
            client.Dispose();
            running = false;
        }

        protected void RPCReady(object sender, ReadyMessage msg)
        {
            Console.WriteLine("Ready!");
        }
    }
}
