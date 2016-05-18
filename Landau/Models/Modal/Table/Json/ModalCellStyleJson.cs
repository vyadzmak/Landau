using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSandbox.Models.Modal.Table.Json
{
    public class ModalCellStyleJson
    {
        public int fontSize { get; set; }
        public string fontStyle { get; set; }
        public string fontFamily { get; set; }
        public string align { get; set; }
        public string fontColor { get; set; }
        public string backgroundColor { get; set; }
        public string linkColor { get; set; }

        public ModalCellStyleJson(int fontSize, string fontStyle, string fontfamily, string align, string linkColor, string backgroundColor, string fontColor)
        {
            try
            {
                this.fontSize = fontSize;
                this.fontStyle = fontStyle;
                this.fontFamily = fontFamily;
                this.align = align;
                this.linkColor = linkColor;
                this.backgroundColor = backgroundColor;
                this.fontColor = fontColor;
            }
            catch (Exception exception)
            {
                
            }
        }

        public ModalCellStyleJson()
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
