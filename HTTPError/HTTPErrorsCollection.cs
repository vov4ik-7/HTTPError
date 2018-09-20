//  <copyright file="HTTPErrorsCollection.cs" company="NIP">
//  Copyright © 2018. All rights reserved.
//  </copyright>
//  <author>Vasyl Salabay</author>
//  <date>09/14/2018 11:39:58 PM </date>
//  <summary>Class representing a collection of http errors</summary>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpError
{
    /// <summary>
    /// Represents classs for HTTPError collection
    /// </summary>
    public class HTTPErrorsCollection
    {
        /// <summary>
        /// List of HTTP errors
        /// </summary>
        private List<HTTPError> httpErrors;

        /// <summary>
        /// Initializes a new instance of the <see cref="HTTPErrorsCollection"/> class
        /// </summary>
        public HTTPErrorsCollection()
        {
            this.httpErrors = new List<HTTPError>();
        }

        /// <summary>
        /// Gets variable httpErrors
        /// </summary>
        public IList<HTTPError> HttpErrors
        {
            get
            {
                List<HTTPError> errors = (from e in this.httpErrors
                                          orderby e.Date descending
                                          select e).ToList<HTTPError>();
                return errors;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:httpError.HTTPErrorsCollection"/> at the specified index.
        /// </summary>
        /// <param name="index">Index of error you want to get</param>
        /// <returns>Error by your index</returns>
        public HTTPError this[int index]
        {
            get
            {
                return this.httpErrors[index];
            }
        }

        /// <summary>
        /// Adds new HTTP error to the list 
        /// </summary>
        /// <param name="error">Error you want to add</param>
        public void Add(HTTPError error)
        {
            if (!this.httpErrors.Contains(error))
            {
                this.httpErrors.Add(error);
            }
        }

        /// <summary>
        /// Removes  specified HTTP error from the list
        /// </summary>
        /// <param name="error">Error you want to remove</param>
        /// <returns>Error that was removed</returns>
        public bool Remove(HTTPError error)
        {
            if (this.httpErrors.Contains(error))
            {
                return this.httpErrors.Remove(error);
            }

            return false;
        }

        /// <summary>
        /// Checks if list contains specified HTTP error
        /// </summary>
        /// <param name="error">An error whose presence will be checked</param>
        /// <returns> <see langword="true"/> if the error is on the list, <see langword="false"/> otherwise</returns>
        public bool Contains(HTTPError error)
        {
            return this.httpErrors.Contains(error);
        }

        /// <summary>
        /// Removes specified HTTP error chosen by index
        /// </summary>
        /// <param name="index">Index of error you want do remove</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.httpErrors.Count)
            {
                throw new ArgumentOutOfRangeException("index", $"Index must be in range [0 ; {this.httpErrors.Count - 1}].");
            }

            this.httpErrors.Remove(this.httpErrors[index]);
        }

        /// <summary>
        /// Clears list of HTTP errors
        /// </summary>
        public void Clear()
        {
            this.httpErrors.Clear();
        }

        /// <summary>
        /// Represents instance in string format
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            string[] str = new string[this.httpErrors.Count];
            for (int i = 0; i < this.httpErrors.Count; i++)
            {
                str[i] = this.httpErrors[i].ToString();
            }

            return string.Join("\n", str);
        }

        /// <summary>
        /// Reads list of HTTP errors from file
        /// </summary>
        /// <param name="path">Path to file with list of errors</param>
        /// <exception cref="System.IO.IOException">Throw when an incorrect file path is specified</exception>
        public void ReadLogOfErrorsFromFile(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists == false)
            {
                throw new FileNotFoundException("There is no such file.");
            }

            using (var streamReader = new StreamReader(path))
            {
                char[] separators = { ' ', '#' };
                while (!streamReader.EndOfStream)
                {
                    var str = streamReader.ReadLine();
                    var strs = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    var date = strs[1];
                    var time = strs[2];
                    var code = strs[0];
                    this.httpErrors.Add(new HTTPError(int.Parse(code), DateTime.Parse($"{date} {time}")));
                }
            }
        }

        /// <summary>
        /// Reads text from file
        /// </summary>
        /// <param name="path">Path to file with text which contains code of errors</param>
        /// <returns>Pair of text from file and changed text</returns>
        /// <exception cref="System.IO.IOException">Throw when an incorrect file path is specified</exception>
        public MyTextPair ReadTextFromFile(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists == false)
            {
                throw new FileNotFoundException("There is no such file.");
            }

            using (var streamReader = new StreamReader(path))
            {
                var str = streamReader.ReadToEnd();
                char[] separators = { ' ', '-', '.', '(', ')', ',', ':', '\n', '\t', '?', '!', ';' };
                this.httpErrors = (from t in str.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                   where t.StartsWith("#")
                                   select new HTTPError(int.Parse(t.Substring(1)), DateTime.Now)).ToList<HTTPError>();
                var newStr = new StringBuilder(str);
                foreach (var httpError in this.httpErrors)
                {
                    newStr.Replace(httpError.Code.ToString(), $"['{HTTPError.GetDescriptionOf(httpError.Code)}', {httpError.Date.ToString(CultureInfo.CurrentCulture)}]");
                }

                return new MyTextPair(str, newStr.ToString());
            }
        }
    }
}
