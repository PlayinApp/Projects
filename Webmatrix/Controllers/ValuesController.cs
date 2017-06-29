using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Web.Http;

namespace Webmatrix.Controllers
{
    
    public class ValuesController : ApiController
    {
        private readonly ManualResetEvent allDone = new ManualResetEvent(false);
        private Socket m_Listener;
        private bool m_Listening;
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        [Route("v1/starttread")]
        [HttpPost]
        public String starttread ()
        {

            // eventInfo.Add(results);

            var myThreadDelegate = new ThreadStart(Listen);
            var myThread = new Thread(myThreadDelegate);
            myThread.Start();

            return "tread started";
           
            
                
        }
        [Route("v1/stoptread")]
        [HttpPost]
        public String stoptread()
        {

            // eventInfo.Add(results);


            m_Listening = false;
            allDone.Set();
            return "tread stoped";



        }

        private void Listen()
        {

            // IPAddress ip = IPAddress.Parse("192.168.0.104");
            var localEndPoint = new IPEndPoint(IPAddress.Any, 5222);

            // Create a TCP/IP socket.
            m_Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                m_Listener.Bind(localEndPoint);
                m_Listener.Listen(10);

                m_Listening = true;

                while (m_Listening)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    m_Listener.BeginAccept(AcceptCallback, null);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();
            // Get the socket that handles the client request.
            var sock = m_Listener.EndAccept(ar);

            var con = new XmppSeverConnection(sock);
        }





    }
}
