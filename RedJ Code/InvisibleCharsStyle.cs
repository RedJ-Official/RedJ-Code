using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastColoredTextBoxNS;

namespace RedJ_Code
{
    public class InvisibleCharsStyle : Style
    {
        Pen pen;

        public InvisibleCharsStyle(Pen pen)
        {
            this.pen = pen;
        }

        public override void Draw(Graphics gr, Point position, FastColoredTextBoxNS.Range range)
        {
            var tb = range.tb;
            using (Brush brush = new SolidBrush(pen.Color))
                foreach (var place in range)
                {
                    switch (tb[place].c)
                    {
                        case ' ':
                            var point = tb.PlaceToPoint(place);
                            point.Offset(tb.CharWidth / -4, 0);
                            //point.Offset(tb.CharWidth / 2, tb.CharHeight / 2);
                            //gr.DrawLine(pen, point.X, point.Y, point.X + 1, point.Y);
                            gr.DrawString("·", tb.Font, brush, point);
                            break;
                    }

                    if (tb[place.iLine].Count - 1 == place.iChar)
                    {
                        var point = tb.PlaceToPoint(place);
                        point.Offset(tb.CharWidth, 0);
                        gr.DrawString("¶", tb.Font, brush, point);
                    }
                }
        }
    }
}
