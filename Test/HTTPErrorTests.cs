//  <copyright file="HTTPErrorTests.cs" company="NIP">
//  Copyright © 2018. All rights reserved.
//  </copyright>
//  <author>Volodymyr Lysyshyn</author>
//  <date>09/20/2018 11:44:25 PM </date>
//  <summary>Class representing a http error tests</summary>

using System;
using HttpError;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HttpError.Tests
{
    /// <summary>
    /// HTTPError tests.
    /// </summary>
    [TestClass]
    public class HTTPErrorTests
    {
        /// <summary>
        /// HTTPError code test.
        /// </summary>
        [TestMethod]
        public void HTTPErrorCodeTest()
        {
            var d = DateTime.Now;
            HTTPError kek = new HTTPError(404, d);

            Assert.AreEqual(404, kek.Code);
        }

        /// <summary>
        /// HTTPEsrror date test.
        /// </summary>
        [TestMethod]
        public void HTTPErrorDateTest()
        {
            var d = DateTime.Now;
            HTTPError kek = new HTTPError(404, d);

            Assert.AreEqual(d, kek.Date);
        }

        /// <summary>
        /// HTTPEsrror description test.
        /// </summary>
        [TestMethod]
        public void HTTPErrorDescriptionTest()
        {
            HTTPError kek = new HTTPError();
            Assert.AreEqual(kek.Description, "ERROR");

            HTTPError lol = new HTTPError(404, DateTime.Now);
            Assert.AreEqual(lol.Description, "Not Found");
        }

        /// <summary>
        /// HTTPError get description of test.
        /// </summary>
        [TestMethod]
        public void HTTPErrorGetDescriptionOfTest()
        {
            Assert.AreEqual(HTTPError.GetDescriptionOf(400), "Bad Request");
            Assert.AreEqual(HTTPError.GetDescriptionOf(401), "Unauthorized");
            Assert.AreEqual(HTTPError.GetDescriptionOf(403), "Forbidden");
            Assert.AreEqual(HTTPError.GetDescriptionOf(402), "Payment Required");
            Assert.AreEqual(HTTPError.GetDescriptionOf(404), "Not Found");
        }

        /// <summary>
        /// HTTPEsrror equals test.
        /// </summary>
        [TestMethod]
        public void HTTPErrorEqualsTest()
        {
            var d = DateTime.Now;
            HTTPError kek = new HTTPError(401, d);
            HTTPError lol = new HTTPError(401, d);

            HTTPError yo = new HTTPError(403, d);
            HTTPError ye = new HTTPError(403, d);

            HTTPError kekez = new HTTPError(404, d);
            HTTPError lolez = new HTTPError(404, d);
            if (kek.Equals(lol) && yo.Equals(ye) && kekez.Equals(lolez))
            {
                return;
            }
        }

        /// <summary>
        /// HTTPError compare to test.
        /// </summary>
        [TestMethod]
        public void HTTPErrorCompareToTest()
        {
            var d = DateTime.Now;
            HTTPError kek = new HTTPError(401, d);
            try
            {
                kek.CompareTo(12);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "об`єкт не є HTTPEror!");
            }

            HTTPError lol = new HTTPError(401, d);
            HTTPError lolez = new HTTPError(403, d);
            if (kek.CompareTo(lol) == 0 && kek.CompareTo(lolez) == 1)
            {
                return;
            }
        }
    }
}
