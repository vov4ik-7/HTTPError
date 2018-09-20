//  <copyright file="Program.cs" company="NIP">
//  Copyright © 2018. All rights reserved.
//  </copyright>
//  <author>Volodymyr Lysyshyn</author>
//  <date>09/13/2018 07:27:48 PM </date>
//  <summary>Class representing a main method</summary>

using System;
using System.IO;

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:FileMustHaveHeader", Justification = "Reviewed.")]

namespace HttpError
{
    /// <summary>
    /// Main class.
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            HTTPErrorsCollection logErrors = new HTTPErrorsCollection();
            try
            {
                logErrors.ReadLogOfErrorsFromFile(@"Files/File1.txt");
                Console.WriteLine(logErrors);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Console.WriteLine();

            HTTPErrorsCollection fromFile = new HTTPErrorsCollection();
            try
            {
                MyTextPair text = fromFile.ReadTextFromFile(@"Files/File2.txt");
                Console.WriteLine($"Text from file:\n{text.OldText}\nChanged text:\n{text.NewText}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Logger.AddLog(400, DateTime.Now);
            Logger.AddLog(400, DateTime.Now);
            Logger.AddLog(401, DateTime.Now);
            Logger.AddLog(401, DateTime.Now);
            Logger.AddLog(403, DateTime.Now);
            Console.WriteLine();

            HttpRequestEmulator.MakeRequest();

            var q = Logger.GetLog;
            foreach (var elem in q)
            {
                Console.WriteLine($"{elem.Key}\n");
                elem.Value.ForEach(delegate(DateTime date)
                {
                    Console.WriteLine($"\t{date}");
                });
            }
        }
    }
}
