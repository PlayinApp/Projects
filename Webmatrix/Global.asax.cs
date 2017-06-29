using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Webmatrix
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        private readonly ManualResetEvent allDone = new ManualResetEvent(false);
        private Socket m_Listener;
        private bool m_Listening;
        protected void Application_Start()
        {

            //var myThreadDelegate = new ThreadStart(Listen);
            //var myThread = new Thread(myThreadDelegate);
            //myThread.Start();


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



          
        }

        //private void Listen()
        //{

        //   // IPAddress ip = IPAddress.Parse("192.168.0.104");
        //    var localEndPoint = new IPEndPoint(IPAddress.Any,5222);

        //    // Create a TCP/IP socket.
        //    m_Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        //    // Bind the socket to the local endpoint and listen for incoming connections.
        //    try
        //    {
        //        m_Listener.Bind(localEndPoint);
        //        m_Listener.Listen(10);

        //        m_Listening = true;

        //        while (m_Listening)
        //        {
        //            // Set the event to nonsignaled state.
        //            allDone.Reset();

        //            // Start an asynchronous socket to listen for connections.
        //            Console.WriteLine("Waiting for a connection...");
        //            m_Listener.BeginAccept(AcceptCallback, null);

        //            // Wait until a connection is made before continuing.
        //            allDone.WaitOne();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //}

        //public void AcceptCallback(IAsyncResult ar)
        //{
        //    // Signal the main thread to continue.
        //    allDone.Set();
        //    // Get the socket that handles the client request.
        //    var sock = m_Listener.EndAccept(ar);

        //    var con = new XmppSeverConnection(sock);
        //}
    }
    }

