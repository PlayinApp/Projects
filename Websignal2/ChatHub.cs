using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace Websignal2
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        static HashSet<string> CurrentConnections = new HashSet<string>();

        public override Task OnConnected()
        {
            var id = Context.ConnectionId;
            CurrentConnections.Add(id);

            return base.OnConnected();
        }

        //public override System.Threading.Tasks.Task OnDisconnected()
        //{
        //    var connection = CurrentConnections.FirstOrDefault(x => x == Context.ConnectionId);

        //    if (connection != null)
        //    {
        //        CurrentConnections.Remove(connection);
        //    }

        //    return base.OnDisconnected();
        //}


        //return list of all active connections
        public List<string> GetAllActiveConnections()
        {
            return CurrentConnections.ToList();
        }

    }
}