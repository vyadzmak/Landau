using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSandbox.Models.Modal.Table
{
    public class XModalCellStyle
    {
        public int FontSize { get; set; }
        public string FontStyle { get; set; }
        public string FontFamily { get; set; }
        public string Align { get; set; }
        public string FontColor { get; set; }
        public string BackgroundColor { get; set; }
        public string LinkColor { get; set; }

        public XModalCellStyle(int fontSize, string fontStyle, string fontFamily, string align, string linkColor, string backgroundColor, string fontColor)
        {
            try
            {
                FontSize = fontSize;
                FontStyle = fontStyle;
                FontFamily = fontFamily;
                Align = align;
                LinkColor = linkColor;
                BackgroundColor = backgroundColor;
                FontColor = fontColor;
            }
            catch (Exception exception)
            {
                
            }
        }

        public XModalCellStyle()
        {
            try
            {

            }
            catch (Exception exception)
            {
                
            }
        }
    }
}
