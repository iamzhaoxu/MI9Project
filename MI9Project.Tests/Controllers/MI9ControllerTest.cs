﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MI9Project;
using MI9Project.Controllers;
using MI9Project.Controllers.API;
using System.Net;
using System.IO;
using MI9Project.Models;
using Newtonsoft.Json;
using MI9Project.Tests.Models;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace MI9Project.Tests.Controllers
{
    [TestClass]
    public class MI9ControllerTest
    {
        #region Private Fileds

        private string _endPoint;
        private string _contentType;
        private string _method;

        private readonly string NoExceptioinShouldBeExpected = "No exceptioin should be thrown.";
        private readonly string ExceptionShouldBeExpected = "Exceptioin should not be thown before this step.";

        #endregion

        #region Constructor

        public MI9ControllerTest()
        {
            _endPoint = "http://mi9xuz.azurewebsites.net:80/";
            _contentType = "application/json";
            _method = "Post";
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void TestNormralJSONReqeust()
        {
            try
            {
                MI9JSONResponse actualResponse = JsonConvert.DeserializeObject<MI9JSONResponse>(GetActualResponse(TestSrc.MI9Request));
                MI9JSONResponse expectedResponse = JsonConvert.DeserializeObject<MI9JSONResponse>(TestSrc.MI9Reponse);
                Assert.AreEqual(actualResponse.Response.Count, expectedResponse.Response.Count);
                for (int i = 0; i < actualResponse.Response.Count; i++)
                {
                    Assert.AreEqual(actualResponse.Response[i].Image, expectedResponse.Response[i].Image);
                    Assert.AreEqual(actualResponse.Response[i].Slug, expectedResponse.Response[i].Slug);
                    Assert.AreEqual(actualResponse.Response[i].Title, expectedResponse.Response[i].Title);
                }
            }
            catch
            {
                Assert.Fail(NoExceptioinShouldBeExpected);
            }
        }

        /// <summary>
        /// Test a json request with illegal format.
        /// </summary>
        [TestMethod]
        public void TestJSONForIllegalFormat()
        {
            try
            {
                GetActualResponse(TestSrc.MI9BadRequestForInvalidFormatJSON);
                Assert.Fail(ExceptionShouldBeExpected);
            }
            catch (WebException ex)
            {
                CheckWebException(ex);
            }
            catch
            {
                Assert.Fail(NoExceptioinShouldBeExpected);
            }
        }

        /// <summary>
        /// Test a json request with legal formart but invliad against the json schema
        /// </summary>
        [TestMethod]
        public void TestJSONReqeustForInvalidAgainstSchema()
        {
            try
            {
                GetActualResponse(TestSrc.MI9BadRequestForIncompitableJSON);
                Assert.Fail(ExceptionShouldBeExpected);
            }
            catch (WebException ex)
            {
                CheckWebException(ex);
            }
            catch
            {
                Assert.Fail(NoExceptioinShouldBeExpected);
            }
        }

        #endregion

        #region Helpers

        private void CheckWebException(WebException ex)
        {
            Assert.IsNotNull(ex.Response);
            Assert.IsTrue(ex.Response is HttpWebResponse);
            Assert.AreEqual((ex.Response as HttpWebResponse).StatusCode, HttpStatusCode.BadRequest);
            Stream stream = ex.Response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string result = sr.ReadToEnd();
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            ErrorMessage actualError = JsonConvert.DeserializeObject<ErrorMessage>(result);
            ErrorMessage expectedError = JsonConvert.DeserializeObject<ErrorMessage>(TestSrc.Error);
            Assert.AreEqual(actualError.Error, expectedError.Error);
        }

        private string GetActualResponse(string requestJson)
        {
            HttpWebRequest reqeust = (HttpWebRequest)WebRequest.Create(new Uri(_endPoint));
            reqeust.ContentType = _contentType;
            reqeust.Method = _method;

            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(requestJson);
            reqeust.ContentLength = bytes.Length;
            using (Stream requestStream = reqeust.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)reqeust.GetResponse();
            using (Stream reponseStream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(reponseStream);
                return sr.ReadToEnd();
            }
        }

        #endregion
    }
}
