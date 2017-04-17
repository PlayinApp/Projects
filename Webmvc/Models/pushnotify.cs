using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Webmvc.Models
{
    public class FCMPushNotification
    {
        public bool Successful
        {
            get;
            set;
        }

        public string Response
        {
            get;
            set;
        }
        public Exception Error
        {
            get;
            set;
        }

        public FCMPushNotification SendNotification(string _title, string _message, string _topic)
        {
            FCMPushNotification result = new FCMPushNotification();
            try
            {

                string FCM_SERVER_API = "AAAAA5GDoDk:APA91bFBrwNOo-FPN1uRnnfIvh1WqdAFl92dy9R76uC50BnmCoHqifP9zHXDq8Vu98hq25orN5wLSbW2HpJt8-jsiY6nfthJVOkoMcns7pj18o0YbgAPzglQo8wRq2N2jgHpzQ38FC9h";
                string FCM_SENDER_ID= "15326224441";

                result.Successful = true;
                result.Error = null;
                // var value = message;
                var requestUri = "https://fcm.googleapis.com/fcm/send";

                WebRequest webRequest = WebRequest.Create(requestUri);
                webRequest.Method = "POST";
                webRequest.Headers.Add(string.Format("Authorization: key={0}", FCM_SERVER_API));
                webRequest.Headers.Add(string.Format("Sender: id={0}", FCM_SENDER_ID));
                webRequest.ContentType = "application/json";

                var data = new
                {
                    // to = YOUR_FCM_DEVICE_ID, // Uncoment this if you want to test for single device
                     to = "cZUfb1WNSZU:APA91bFscuBAvbLALPQjIOMjj1wzjU0QGcfljoe2Wq45aXjF_aMo6FS_RVX_huaqfF-QoXVg1CA4rOzz9OfY9skkTpppo11tKQUFF41_BbaKQXsGE-lVv5JR4QMJnA6G2y5KlVDPUO0G", // this is for topic 
                   

                    notification = new
                    {

                        title = _title,
                        body = _message,
                        sound = true,
                        image = "http://api.androidhive.info/images/minion.jpg",
                        color= "#228B22"


                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                webRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse webResponse = webRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = webResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                result.Response = sResponseFromServer;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }
            return result;
        }
    }






}