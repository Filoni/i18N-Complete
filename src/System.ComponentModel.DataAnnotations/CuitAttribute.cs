﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>A localized version of the CuitAttribute</summary>
    /// <created author="laurentiu.macovei" date="Fri, 24 Feb 2012 15:53:38 GMT"/>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CuitAttribute
        : DataTypeAttribute
    {
        private static Regex _regex = new Regex(@"^[0-9]{2}-?[0-9]{8}-?[0-9]$");

        /// <summary>Gets the Regex</summary>
        /// <created author="laurentiu.macovei" date="Fri, 24 Feb 2012 15:53:39 GMT"/>
        public string Regex
        {
            get
            {
                return _regex.ToString();
            }
        }

        /// <summary>Creates a new instance of CuitAttribute</summary>
        /// <created author="laurentiu.macovei" date="Fri, 24 Feb 2012 15:53:39 GMT"/>
        public CuitAttribute()
            : this("The {0} field is not a valid CUIT number.")
        {

        }
        /// <summary>Creates a new instance of CuitAttribute</summary>
        /// <param name="errorMessage"></param>
        /// <created author="laurentiu.macovei" date="Fri, 24 Feb 2012 15:53:39 GMT"/>
        public CuitAttribute(string errorMessage)
            : base("cuit")
        {
            this.ErrorMessage = errorMessage;
        }

        /// <summary>Applies formatting to an error message, based on the data field where the error occurred.</summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>The localized formatted error message</returns>
        /// <created author="laurentiu.macovei" date="Fri, 24 Feb 2012 15:53:40 GMT"/>
        public override string FormatErrorMessage(string name)
        {
            return CultureInfo.CurrentCulture.Format(this.ErrorMessage, name);
        }

        /// <summary>Determines whether the specified value of the object is valid.</summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        /// <created author="laurentiu.macovei" date="Fri, 24 Feb 2012 15:53:40 GMT"/>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var valueAsString = value as string;
            return valueAsString != null && _regex.Match(valueAsString).Length > 0;
        }
    }
}
