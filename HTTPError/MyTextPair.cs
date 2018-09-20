//  <copyright file="MyTextPair.cs" company="NIP">
//  Copyright © 2018. All rights reserved.
//  </copyright>
//  <author>Volodymyr Lysyshyn</author>
//  <date>09/17/2018 04:10:13 PM </date>
//  <summary>Class representing a pair of two string values</summary>

using System;

namespace HttpError
{
    /// <summary>
    /// Represent a pair of two string values.
    /// </summary>
    public struct MyTextPair
    {
        /// <summary>
        /// The old text.
        /// </summary>
        private string oldText;

        /// <summary>
        /// The new text.
        /// </summary>
        private string newText;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:HttpError.MyTextPair"/> struct.
        /// </summary>
        /// <param name="oldText">Old text.</param>
        /// <param name="newText">New text.</param>
        public MyTextPair(string oldText, string newText)
        {
            this.oldText = oldText;
            this.newText = newText;
        }

        /// <summary>
        /// Gets the old text.
        /// </summary>
        /// <value>The old text.</value>
        public string OldText
        {
            get
            {
                return this.oldText;
            }
        }

        /// <summary>
        /// Gets the new text.
        /// </summary>
        /// <value>The new text.</value>
        public string NewText
        {
            get
            {
                return this.newText;
            }
        }
    }
}