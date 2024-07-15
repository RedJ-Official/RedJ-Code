using System.Drawing;
using System.Windows.Forms;

namespace RedJ_Code
{
    internal class ImprovedToolStripSystemRenderer : ToolStripSystemRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled && (e.Item.Selected || e.Item.Pressed))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0xFF, 0x00, 0x77, 0xDD)), new Rectangle(Point.Empty, e.Item.Size));
            }
            else
            {
                base.OnRenderItemBackground(e);
            }
        }
    }
}
