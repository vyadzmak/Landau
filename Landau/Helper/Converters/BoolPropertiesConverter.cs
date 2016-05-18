using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.Models.XModels;

namespace Landau.Helper
{
    public class BoolPropertiesConverter
    {
        #region fields
        private string UnderlineState = "underline";

        private string OverlineState = "overline";

        private string StrikeState = "line-through";
        #endregion

        public string GetState(XCell cell)
        {
            try
            {
                if (cell.Style.DecorLine == UnderlineState)
                {
                    return UnderlineState;
                }

                if (cell.Style.DecorLine == OverlineState)
                {
                    return OverlineState;
                }

                if (cell.Style.DecorLine == StrikeState)
                {
                    return StrikeState;
                }

                return null;

            }
            catch (Exception exception)
            {
                return null;
            }
        }

    }
}