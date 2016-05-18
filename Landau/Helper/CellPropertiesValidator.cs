using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Landau.Helper
{
    /// <summary>
    /// The class, that prevents the insertion of wrong values to the cell properties
    /// </summary>
    public static class CellPropertiesValidator
    {
        #region fields
        public enum Styles : int { Normal = 0, Italic = 1, Oblique = 2, Initial = 3, Inherit = 4 };

        public static string[] StylesStrings = { "normal", "italic", "oblique", "initial", "inherit" };

        public enum Weights : int {
            Normal = 0, Bold = 1, Bolder = 2, Lighter = 3, 
        OneHundred = 4, TwoHundred = 5, ThreeHundred = 6, FourHundred = 7, 
            FiveHundred = 8, SixHundred = 9,  SevenHundred = 10, EightHundred = 11, NineHundred = 12};

        public static string[] WeightsStrings =  {"normal", "bold", "bolder", "lighter", "100", "200", "300", "400", 
        "500", "600",  "700", "800", "900"};

        public static int FontSizeDefault = 10;

        public static int WidthDefault = 80;

        public static int HeightDefault = 20;

        public static int RotateDefault = 90;

        public static int AnotherRotateDefault = 270;

        #endregion

        #region validate methods

        public static int BorderWidthValidator(int? toCheck)
        {
            try
            {
                if (toCheck == null)
                {
                    return 1;
                }
                else
                {
                    return (int)toCheck;
                }
            }
            catch (Exception exception)
            {
                return 1;
            }
        }
        public static int FontSizeValidate(int? toCheck)
        {
            try
            {
                if (toCheck > 6 && toCheck < 72)
                {
                    return (int)toCheck;
                }
                else return FontSizeDefault;
            }
            catch (Exception exception)
            {
                return FontSizeDefault;
            }
        }

        public static string FontWeightValidate(string toCheck)
        {
            try
            {
                if (toCheck == "Bold") { return "bold"; } else { if (toCheck == "Regular" || toCheck == "") { return "normal"; } }
                foreach (var item in WeightsStrings)
                {
                    if (toCheck == item)
                    {
                        return toCheck;
                    }
                }
                return WeightsStrings[(int)Weights.Normal];
            }

            catch (Exception Exception)
            {
                return WeightsStrings[(int)Weights.Normal];
            }
        }

        public static string FontStyleValidate(string toCheck)
        {
            try
            {
                foreach (var item in StylesStrings)
                {
                    if (toCheck == item)
                    {
                        return toCheck;
                    }
                }
                return StylesStrings[(int)Styles.Normal];
            }

            catch (Exception exception)
            {
                return StylesStrings[(int)Styles.Normal];
            }
        }

        public static int CellRotationValidate(int toCheck)
        {
            try
            {
                if (toCheck == RotateDefault || toCheck == AnotherRotateDefault)
                {
                    return toCheck;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        public static int CellHeightValidate(int? toCheck)
        {
            try
            {
                if (toCheck == null)
                {
                    return HeightDefault;
                }
                else return (int)toCheck;
            }
            catch (Exception exception)
            {
                return HeightDefault;
            }
                
        }

        public static int CellWidthValidate(int? toCheck)
        {
            try
            {
                if (toCheck == null)
                {
                    return WidthDefault;
                }
                else return (int)toCheck;
            }
            catch (Exception exception)
            {
                return WidthDefault;
            }

        }

        public static string ColorValidate(Color? toCheck)
        {
            try
            {
                Color color = (Color)toCheck;
                if (toCheck != null)
                {
                    // forming the hex representative of color in string
                    return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
                }
                else return null;
            }
            catch(Exception exeption)
            {
                return null;
            }
        }

        public static bool IsValueFormula(string toCheck)
        {
            try
            {
                if (toCheck != null)
                {
                    // by checking the "=" sign in value we realize, if the value of the cell is
                    // formula, or not
                    if (toCheck.IndexOf("=") != -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else return false;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public static string DecoreLineValidate(string o, string u, string s)
        {
            try
            {
                if (o != null)
                {
                    return o;
                }

                if (u != null)
                {
                    return u;
                }

                if (s != null)
                {
                    return s;
                }

                return "";
            }
            catch (Exception exception)
            {
                return "";
            }
        }

        #endregion
    }
}