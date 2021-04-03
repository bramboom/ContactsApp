
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
//переименовать класс по типу Backgrounddatetimepicker
namespace ContactsAppUI
{
    //https://stackoverflow.com/questions/33436162/why-datetimepicker-backcolor-disable-manual-typing
    public class myDateTimePicker:DateTimePicker
    {
        public myDateTimePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Rectangle dropDownRectangle = new Rectangle(ClientRectangle.Width - 20, 0, 20, 20);
            Brush bkgBrush;
            ComboBoxState visualState;
            if (this.Enabled)
            {
                bkgBrush = new SolidBrush(Color.DimGray);
                visualState = ComboBoxState.Normal;
            }
            else
            {
                bkgBrush = new SolidBrush(Color.DimGray);
                visualState = ComboBoxState.Disabled;
            }
            g.FillRectangle(bkgBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            if (this.Enabled)
            {
                bkgBrush = new SolidBrush(this.BackColor);
                visualState = ComboBoxState.Normal;
            }
            else
            {
                bkgBrush = new SolidBrush(this.BackColor);
                visualState = ComboBoxState.Disabled;
            }
            g.FillRectangle(bkgBrush, 1, 1, ClientRectangle.Width-22, ClientRectangle.Height-2);
            g.DrawString(this.Text, this.Font, Brushes.Black, 0, 2);
            ComboBoxRenderer.DrawDropDownButton(g, dropDownRectangle, visualState);

            g.Dispose();
            bkgBrush.Dispose();
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }
    }
}
