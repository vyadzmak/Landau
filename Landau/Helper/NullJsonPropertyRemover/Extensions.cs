using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace Landau.Helper
{
    public static class Extensions
    {
        /// <summary>
        /// Check wheather the string is empty or null (Extention Method)
        /// </summary>
        /// <param name="str">The string to be checked</param>
        /// <returns>Returns true if string is NULL or String.Empty, otherwise false</returns>
        public static bool IsEmptyOrNull(this string str)
        {
            if (str == null || str == string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes Json null objects from the serialized string and return a new string(Extention Method)
        /// </summary>
        /// <param name="str">The String to be checked</param>
        /// <returns>Returns the new processed string or NULL if null or empty string passed</returns>
        public static string RemoveJsonNulls(this string str)
        {
            if (!str.IsEmptyOrNull())
            {
                Regex regex = new Regex(Landau.Helper.UtilityRegexp.JsonNullRegEx);
                string data = regex.Replace(str, string.Empty);
                regex = new Regex(Landau.Helper.UtilityRegexp.JsonNullArrayRegEx);
                return regex.Replace(data, "[]");
            }
            return null;
        }

        /// <summary>
        /// Serializes an objct to a Json string using Javascript Serializer and removes Json null objects if opted (Extention Method)
        /// </summary>
        /// <param name="arg">Object to serialize</param>
        /// <param name="checknull">Set to true if you want remove null Json objects from serialized string, otherwise false(default)</param>
        /// <returns>The serialized Json as string, if check null was set true then null Json strings are removed</returns>        
        public static string SerializeToJson(this object arg, bool checknull = false)
        {
            JavaScriptSerializer sr = new JavaScriptSerializer();
            if (checknull)
            {
                return sr.Serialize(arg).RemoveJsonNulls();
            }
            return sr.Serialize(arg);
        }
        
    }
}