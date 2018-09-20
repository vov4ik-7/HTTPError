//  <copyright file="HttpRequestEmulator.cs" company="NIP">
//  Copyright © 2018. All rights reserved.
//  </copyright>
//  <author>Oleh Petryk</author>
//  <date>09/17/2018 08:51:34 PM </date>
//  <summary>Class representing a http request emulator</summary>

using System;

namespace HttpError
{
    /// <summary>
    /// Class emulating Http Request 
    /// </summary>
    public static class HttpRequestEmulator
    {
        /// <summary>
        /// Make a fake request and get a random Http Error
        /// </summary>
        public static void MakeRequest()
        {
            var code = new Random().Next(400, 404);
            Console.WriteLine(new HTTPError(code, DateTime.Now));
            Logger.AddLog(code, DateTime.Now);
        }
    }
}