using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class jsonController : ApiController
    {
        [HttpGet]
        public JObject JObjectOutputTest()
        {

            var jsonObject = new JObject();

            // you can explicitly add values here using class interface
            jsonObject.Add("Message", DateTime.Now);

            // or cast to dynamic to dynamically add/read properties    dynamic album = jsonObject;
            dynamic album = jsonObject;

          //  album.AlbumName = "Output";
            

            album.Output = new JArray() as dynamic;

            dynamic song = new JObject();
            song.SongName = "Dirty Deeds Done Dirt Cheap";
            song.SongLength = "4:11";
            album.Output.Add(song);

            song = new JObject();
            song.SongName = "Love at First Feel";
            song.SongLength = "3:10";
            album.Output.Add(song);



            return album;

        }



    }
}
