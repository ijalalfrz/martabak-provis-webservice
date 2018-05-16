using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartabakProvis.Helper
{
  

    public class PushNotif : Hub
    {
        public void SendToAll(object data)
        {
            Clients.All.SendAsync("orderNotif", data);
        }
    }
}
