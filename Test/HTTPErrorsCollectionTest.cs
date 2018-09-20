//  <copyright file="HTTPErrorsCollectionTest.cs" company="NIP">
//  Copyright © 2018. All rights reserved.
//  </copyright>
//  <author>Volodymyr Lysyshyn</author>
//  <date>09/20/2018 11:47:21 PM </date>
//  <summary>Class representing a collection of http errors test</summary>

using System;
using System.IO;
using HttpError;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HttpError.Tests
{
    /// <summary>
    /// HTTPErrors collection test.
    /// </summary>
    [TestClass]
    public class HTTPErrorsCollectionTest
    {
        /// <summary>
        /// Reads the text from file test.
        /// </summary>
        [TestMethod]
        public void ReadTextFromFileTest()
        {
            HTTPErrorsCollection httpErrorsCollection = new HTTPErrorsCollection();
            try
            {
                httpErrorsCollection.ReadTextFromFile("File54.txt");
            }
            catch (FileNotFoundException e)
            {
                Assert.AreEqual(e.Message, "There is no such file.");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        /// <summary>
        /// Reads the log of errors from file test.
        /// </summary>
        [TestMethod]
        public void ReadLogOfErrorsFromFileTest()
        {
            HTTPErrorsCollection httpErrorsCollection = new HTTPErrorsCollection();
            try
            {
                httpErrorsCollection.ReadLogOfErrorsFromFile("File54.txt");
            }
            catch (FileNotFoundException e)
            {
                Assert.AreEqual(e.Message, "There is no such file.");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        /// <summary>
        /// Httperrors getter test.
        /// </summary>
        [TestMethod]
        public void HttpErrorsGetterTest()
        {
            var one = new HTTPError(402, DateTime.Now);
            var two = new HTTPError(403, DateTime.Now);
            var three = new HTTPError(404, DateTime.Now);

            var collection = new HTTPErrorsCollection();
            collection.Add(one);
            collection.Add(two);
            collection.Add(three);

            Assert.IsTrue(collection.HttpErrors.Count > 0);
            Assert.IsTrue(collection[0].Code == 402);
        }

        /// <summary>
        /// Httperrors remove test.
        /// </summary>
        [TestMethod]
        public void HttpErrorsRemoveTest()
        {
            var one = new HTTPError(402, DateTime.Now);
            var two = new HTTPError(403, DateTime.Now);
            var three = new HTTPError(404, DateTime.Now);

            var collection = new HTTPErrorsCollection();
            collection.Add(one);
            collection.Add(two);
            collection.Add(three);
            collection.Remove(one);
            Assert.IsTrue(collection.HttpErrors.Count == 2);
            collection.RemoveAt(1);
            Assert.IsTrue(collection[0].Code == 403);
        }

        /// <summary>
        /// Httperror collection clear test.
        /// </summary>
        [TestMethod]
        public void HttpErrorCollectionClearTest()
        {
            var one = new HTTPError(402, DateTime.Now);
            var two = new HTTPError(403, DateTime.Now);
            var three = new HTTPError(404, DateTime.Now);

            var collection = new HTTPErrorsCollection();
            collection.Add(one);
            collection.Add(two);
            collection.Add(three);
            collection.Clear();
            Assert.IsTrue(collection.HttpErrors.Count == 0);
        }

        /// <summary>
        /// Https the error collection contains test.
        /// </summary>
        [TestMethod]
        public void HttpErrorCollectionContainsTest()
        {
            var one = new HTTPError(402, DateTime.Now);

            var collection = new HTTPErrorsCollection();
            collection.Add(one);
            Assert.IsTrue(collection.HttpErrors.Contains(one));
        }
    }
}
