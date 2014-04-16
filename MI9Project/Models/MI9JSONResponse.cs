using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MI9Project.Models
{
    public class MI9JSONResponse
    {
        #region Public Properties

        public List<MI9Response> Response { get; set; }

        #endregion

        #region Constructor

        public MI9JSONResponse()
        {
            Response = new List<MI9Response>();
        }

        #endregion

        #region Classes

        public class MI9Response
        {
            public string Image { get; set; }
            public string Slug { get; set; }
            public string Title { get; set; }
        }

        #endregion

        #region Helpers

        public void AddResponse(string image, string slug, string title)
        {
            MI9Response response = new MI9Response();
            response.Image = image;
            response.Slug = slug;
            response.Title = title;
            Response.Add(response);
        }

        #endregion
    }
}