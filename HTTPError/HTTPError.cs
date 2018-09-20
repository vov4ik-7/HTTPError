//  <copyright file="HTTPError.cs" company="NIP">
//  Copyright © 2018. All rights reserved.
//  </copyright>
//  <author>Vasyl Salabay</author>
//  <date>09/15/2018 05:09:42 PM </date>
//  <summary>Class representing a http error</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HttpError
{
    /// <summary>
    /// Represents class for HTTP error
    /// </summary>
    public class HTTPError : IComparable
    {
        private int code;
        private string description;
        private DateTime date;
        private static SortedList<int, string> listOfErrors;

        /// <summary>
        /// Static constructor for initialization static list of errors
        /// </summary>
        static HTTPError()
        {
            listOfErrors = new SortedList<int, string>();
            listOfErrors.Add(400, "Bad Request");
            listOfErrors.Add(401, "Unauthorized");
            listOfErrors.Add(403, "Forbidden");
            listOfErrors.Add(402, "Payment Required");
            listOfErrors.Add(404, "Not Found");
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:HttpError.HTTPError"/> class
        /// </summary>
        public HTTPError()
        {
            this.code = 0;
            this.description = "ERROR";
            this.date = new DateTime();

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:HttpError.HTTPError"/> class with specified code and date
        /// </summary>
        /// <param name="code"></param>
        /// <param name="date"></param>
        public HTTPError(int code, DateTime date)
        {
            this.code = code;
            if (listOfErrors.TryGetValue(this.code, out this.description) == false)
            {
                this.description = "This error haven`t description yet.";
            }
            this.date = date;
        }

        /// <summary>
        /// Gets variable code
        /// </summary>
        /// <value>The code</value>
        public int Code
        {
            get
            {
                return code;
            }
            private set
            {
                code = value;
            }
        }
        /// <summary>
        /// Gets variable description
        /// </summary>
        /// <value>The description</value>
        public string Description
        {
            get
            {
                return description;
            }
            private set
            {
                description = value;
            }
        }
        /// <summary>
        /// Gets and sets variable date
        /// </summary>
        public DateTime Date
        {
            get
            {
                return date;
            }
            private set
            {
                date = value;
            }
        }

        /// <summary>
        /// Gets description of error by its code
        /// </summary>
        /// <param name="key">Key (Error's code)</param>
        /// <returns>String of description of error</returns>
        public static string GetDescriptionOf(int key)
        {
            string str;
            if (listOfErrors.TryGetValue(key, out str) == false)
            {
                str = "This error haven`t description yet.";
            }
            return str;
        }
        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:HttpError.HTTPError"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:HttpError.HTTPError"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="T:HttpError.HTTPError"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return code == (obj as HTTPError).Code && description.CompareTo((obj as HTTPError).description) == 0 ? true : false;
        }
        /// <summary>
        /// Compares instance to <see cref="object"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>1 0 -1</returns>
        public int CompareTo(object obj)
        {
            if (!(obj is HTTPError)) // perevirka ce is
            {
                throw new Exception("об`єкт не є HTTPEror!");
            }
            int result = 0;
            if (this.Equals(obj))
            {
                result = 0;
            }
            else
            {
                if (code > (obj as HTTPError).code)
                {
                    result = -1;
                }
                else
                {
                    if (code < (obj as HTTPError).code)
                    {
                        result = 1;
                    }
                    else
                    {
                        if (!date.Equals((obj as HTTPError).date))
                        {
                            throw new Exception("exception with different throws!");
                        }



                        throw new Exception("Неоднозначний код помилки"); // два дескрипшини не спывпали
                    }

                }

            }
            return result;
        }
        /// <summary>
        /// Returns a string that represents the current instance
        /// </summary>
        /// <returns>A <see cref="T:System.String"/></returns>
        public override string ToString()
        {
            return string.Format($"CODE: {this.code} DESCRIPTION: {this.description} DATE: {this.date}");
        }
        // jepa
        public void Read(string s)
        {
            // string s = sr.ReadLine();
            string[] arr = s.Split('|');
            int.TryParse(arr[0], out code);
            description = arr[1];
            string[] arrDate = arr[2].Split('.');

            date = new DateTime(int.Parse(arrDate[0]), int.Parse(arrDate[1]), int.Parse(arrDate[2]));

        }
        /// <summary>
        /// Serves as a hash function for a <see cref="T:HttpError.HTTPError"/> object 
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }
}

