using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using MI9Project.Models;
using Newtonsoft.Json;

namespace MI9Project.Controllers.API
{
    public class MI9Controller : ApiController
    {
        #region Public Fields

        public readonly static string JSONContentType = "application/json";

        #endregion

        #region Web APIs
        /// <summary>
        /// This is the interface which will be called to filter the playlod list.
        /// </summary>
        /// <returns>return a HttpResponseMessage message</returns>
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Filter()
        {
            HttpResponseMessage response = null;
            MI9JSONRequest mi9JSONReqeust = null;
            try
            {
                mi9JSONReqeust =  MI9JSONRequest.GetInstance(HttpContext.Current.Request);
            }
            catch
            {
                // If any execption were catached from the GetInstance method, we would consider this is bad reqesut and then
                // return error meesage
                HttpError myCustomError = new HttpError() { { ErrorRes.Error, ErrorRes.BadRequestMessage } };          
                response = Request.CreateResponse(HttpStatusCode.BadRequest,  myCustomError);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(JSONContentType);
                return response;
            }

            // We need to find out which paryload has drm as true and episode count value is larger than 0.
            // Create the reponse objects to store image, slug and title of these payloads.
            MI9JSONResponse mi9JSONResponse = new MI9JSONResponse();
            foreach (MI9JSONRequest.MI9Payload payload in mi9JSONReqeust.Payload.Where(p => p.Drm && p.EpisodeCount > 0))
            {
                mi9JSONResponse.AddResponse(payload.Image.ShowImage, payload.Slug, payload.Title);
            }
            response = Request.CreateResponse(HttpStatusCode.OK);
            // Desrailize the response object as JSON string and set it back to client side.
            response.Content = new StringContent(JsonConvert.SerializeObject(mi9JSONResponse));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(JSONContentType);
            return response;
        }

        #endregion
    }
}