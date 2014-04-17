using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace MI9Project.Models
{
    public class MI9JSONRequest
    {
        #region Public Properties

        public List<MI9Payload> Payload { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int TotalRecords { get; set; }

        #endregion

        #region Classes

        public class MI9Image
        {
            public string ShowImage { get; set; }
        }

        public class MI9NextEpisode
        {
            public object Channel { get; set; }
            public string ChannelLogo { get; set; }
            public object Date { get; set; }
            public string Html { get; set; }
            public string Url { get; set; }
        }

        public class MI9Season
        {
            public string Slug { get; set; }
        }

        public class MI9Payload
        {
            public string Country { get; set; }
            public string Description { get; set; }
            public bool Drm { get; set; }
            public int EpisodeCount { get; set; }
            public string Genre { get; set; }
            public MI9Image Image { get; set; }
            public string Language { get; set; }
            public MI9NextEpisode NextEpisode { get; set; }
            public string PrimaryColour { get; set; }
            public List<MI9Season> Seasons { get; set; }
            public string Slug { get; set; }
            public string Title { get; set; }
            public string TvChannel { get; set; }
        }

        /// <summary>
        /// Create a MI9JSONRequest object based on the JSON from the http reqeust.
        /// </summary>
        /// <param name="request">A HttpRequest object</param>
        /// <returns>A MI9JSONRequest object</returns>
        public static MI9JSONRequest GetInstance(HttpRequest request)
        {
            string reqeustJsone = null;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                reqeustJsone = reader.ReadToEnd();
            }
            //Check JSON string against the json schema.
            JsonSchema schema = JsonSchema.Parse(JSONSchemaRes.PayloadSchema);
            JObject reqeust = JObject.Parse(reqeustJsone);
            // request json at least have the element "payload";
            if (reqeust.IsValid(schema))
            {
                // Desralize the JSON string to MI9JSONRequest object. If JSON is invalid or not compatiable with the test case, it should throw an exception.
                MI9JSONRequest instance = JsonConvert.DeserializeObject<MI9JSONRequest>(reqeustJsone);
                if (instance.Payload == null) throw new Exception(ErrorRes.BadRequestMessage);
                return instance;
            }
            else
            {
                throw new Exception(ErrorRes.BadRequestMessage);
            }
        }

        #endregion
    }
}