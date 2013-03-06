using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Polakken
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
           
        }

        private void GUI_Load(object sender, EventArgs e)
        {

            // Graf:

            crtView.ChartAreas.Add("tempOversikt");
            crtView.ChartAreas["tempOversikt"].AxisX.Minimum = 0;
            crtView.ChartAreas["tempOversikt"].AxisX.Maximum = 20;
            crtView.ChartAreas["tempOversikt"].AxisX.Interval = 1;
            crtView.ChartAreas["tempOversikt"].AxisY.Minimum = -30;
            crtView.ChartAreas["tempOversikt"].AxisY.Interval = 10;
            crtView.ChartAreas["tempOversikt"].BackColor = Color.Transparent;
            crtView.ChartAreas["tempOversikt"].AxisX.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.ForeColor = Color.GreenYellow;
            
            
            
            crtView.Series.Add("Pakistan");
            crtView.Series.Add("India");

            crtView.Series["Pakistan"].Color = Color.LawnGreen;
            crtView.Series["India"].Color = Color.Red;

            crtView.Series["Pakistan"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["India"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["Pakistan"].BorderWidth = 2;
            crtView.Series["India"].BorderWidth = 2;
            
                

            crtView.Series["Pakistan"].Points.AddXY(0, 0);
            crtView.Series["India"].Points.AddXY(0, 0);

            crtView.Series["Pakistan"].Points.AddXY(1, 4);
            crtView.Series["India"].Points.AddXY(1, 9);

            crtView.Series["Pakistan"].Points.AddXY(12, -10);
            crtView.Series["India"].Points.AddXY(12, 20);

            crtView.Series["Pakistan"].Points.AddXY(13, 5);
            crtView.Series["India"].Points.AddXY(13, 15);

            crtView.Series["Pakistan"].Points.AddXY(15, -100);
            crtView.Series["India"].Points.AddXY(15, -34);

            crtView.Series["Pakistan"].Points.AddXY(16, -50);
            crtView.Series["India"].Points.AddXY(16, -10);


            txtCurrent.AppendText("42" + "°C");
            txtCurrentTime.AppendText("06.03.2013" + " " + "13:37");

            string hello = "666";
            string world = "06.03.2013";
            string c = "°C";
            string t = "13:37";
            txtMax.AppendText(hello + c);
            txtMin.AppendText(hello + c);
            txtMaxTime.AppendText(world + " " + t);
            txtMinTime.AppendText(world + " " + t);
            
            

            
        }

        private void tabOversikt_Click(object sender, EventArgs e)
        {

        }

       

        private void btnLukk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
     
    }
    public partial class CTabControl : System.Windows.Forms.TabControl
    {

        public CTabControl()
        {

            this.ItemSize = new Size(90, 30);

            this.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.DrawItem += new DrawItemEventHandler(this.RepaintControls);

            this.Invalidate();

        }



        private void RepaintControls(object sender, DrawItemEventArgs e)
        {

            Font font;

            Brush back_brush;

            Brush fore_brush;

            Rectangle bounds = e.Bounds;

            this.TabPages[e.Index].BackColor = Color.Blue;

            if (e.Index == this.SelectedIndex)
            {

                font = new Font(e.Font, e.Font.Style);

                back_brush = new SolidBrush(Color.DimGray);

                fore_brush = new SolidBrush(Color.White);

                bounds = new Rectangle(bounds.X + (this.Padding.X / 2), bounds.Y + this.Padding.Y, bounds.Width - this.Padding.X, bounds.Height - (this.Padding.Y * 2));

            }

            else
            {

                font = new Font(e.Font, e.Font.Style & ~FontStyle.Bold);

                back_brush = new SolidBrush(this.TabPages[e.Index].BackColor);

                fore_brush = new SolidBrush(this.TabPages[e.Index].ForeColor);

            }

            string tab_name = this.TabPages[e.Index].Text;

            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;

            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.FillRectangle(back_brush, bounds);

            e.Graphics.DrawString(tab_name, font, fore_brush, bounds, sf);

            Brush background_brush = new SolidBrush(Color.DodgerBlue);

            Rectangle LastTabRect = this.GetTabRect(this.TabPages.Count - 1);

            Rectangle rect = new Rectangle();

            rect.Location = new Point(LastTabRect.Right + this.Left, this.Top);

            rect.Size = new Size(this.Right - rect.Left, LastTabRect.Height);

            e.Graphics.FillRectangle(background_brush, rect);

            background_brush.Dispose();

            sf.Dispose();

            back_brush.Dispose();

            fore_brush.Dispose();

            font.Dispose();

        }

    }
}
