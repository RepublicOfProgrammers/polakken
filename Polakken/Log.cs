using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Polakken
{
    public partial class Log : Form
    {
        
        int Mover;
        int MoveX;
        int MoveY;
        public string msgbxms;
        public static string ourPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        string file = ourPath + @"\bin\Files\";
        public Log()
        {
            InitializeComponent();
            tmrUpdateText.Start();
        }
         
             private void btnLukk_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

             private void btnMove1_MouseDown(object sender, MouseEventArgs e)
             {
                 Mover = 1;
                 MoveX = e.X;
                 MoveY = e.Y;
             }

             private void btnMove1_MouseUp(object sender, MouseEventArgs e)
             {
                 Mover = 0;
             }

             private void btnMove1_MouseMove(object sender, MouseEventArgs e)
             {
                 if (Mover == 1)
                 {
                     this.SetDesktopLocation(MousePosition.X - MoveX, MousePosition.Y - MoveY);
                 }
             }

             private void tmrUpdateText_Tick(object sender, EventArgs e)
             {
                 txtRead.Text = Logger.msgbxms;

             }

         


            

            


        
    }
}
