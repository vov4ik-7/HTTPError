//  <copyright file="Logger.cs" company="NIP">
//  Copyright © 2018. All rights reserved.
//  </copyright>
//  <author>Danylo Monets</author>
//  <author>Volodymyr Lysyshyn</author>
//  <date>09/17/2018 06:40:03 PM </date>
//  <summary>Class representing a http errors logger</summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpError
{
    /// <summary>
    /// Represents static class Logger
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// The const path to log file.
        /// </summary>
        private const string PATH = "log.txt";

        /// <summary>
        /// Static list of error's code and list of dates
        /// </summary>
        private static SortedList<int, List<DateTime>> log;

        /// <summary>
        /// Initializes static members of the <see cref="Logger"/> class
        /// </summary>
        static Logger()
        {
            log = new SortedList<int, List<DateTime>>();
        }

        /// <summary>
        /// Gets variable log
        /// </summary>
        public static SortedList<int, List<DateTime>> Log
        {
            get
            {
                return log;
            }
        }

        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <value>The log.</value>
        public static SortedList<int, List<DateTime>> GetLog
        {
            get
            {
                var l = new SortedList<int, List<DateTime>>(log.ToDictionary(q => q.Key, r => r.Value));
                return l;
            }
        }

        /// <summary>
        /// Adds pair of key and time to log
        /// </summary>
        /// <param name="key">Error to add</param>
        /// <param name="time">The time when the error occurred</param>
        public static void AddLog(int key, DateTime time)
        {
            if (log.Keys.Contains(key))
            {
                int index = log.Keys.IndexOf(key);
                log.Values[index].Add(time);
            }
            else
            {
                List<DateTime> buffer = new List<DateTime>() { time };
                log.Add(key, buffer);
            }

            MakeALog(PATH);
        }

        /// <summary>
        /// Loads log in file
        /// </summary>
        /// <param name="filename">Path to file</param>
        private static void MakeALog(string filename)
        {
            string[] strArr = new string[log.Keys.Count];
            List<List<string>> str = new List<List<string>>();

            for (int i = 0; i < log.Keys.Count; ++i)
            {
                str.Add(new List<string>());
                str[i].Add($"#{log.Keys[i]}");
                for (int j = 0; j < log.Values[i].Count; ++j)
                {
                    str[i].Add($"\t{log.Values[i][j].ToString()}");
                }

                str[i].Add("\n");
                strArr[i] = string.Join("\n", str[i].ToArray());
            }

            string result = string.Join("\n", strArr);

            File.WriteAllText(filename, result);
        }
    }
}
