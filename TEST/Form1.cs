using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class Form1 : Form
    {

        bool mouseDown;
        private Point offset;
        public Form1()
        {
            InitializeComponent();
          


        }


        private void gunaLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            accueil1.Visible = true;
            patient1.Visible = false;
            medicament1.Visible = false;
            medecin1.Visible = false;
            consultation1.Visible = false;

        }
        private void medecin1_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            accueil1.Refresh();
            accueil1.Visible = true;
            patient1.Visible = false;
            medicament1.Visible = false;
            medecin1.Visible = false;
            consultation1.Visible = false;
            accueil1.refr();

        }

        private void gunaButton2_Click_1(object sender, EventArgs e)
        {
            patient1.Visible = true;
            medecin1.Visible = false;
            medicament1.Visible = false;
            accueil1.Visible = false;
            consultation1.Visible = false;

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            patient1.Visible = false;
            medecin1.Visible = true;
            medicament1.Visible = false;
            accueil1.Visible = false;
            consultation1.Visible = false;
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            patient1.Visible = false;
            medecin1.Visible = false;
            medicament1.Visible = true;
            accueil1.Visible = false;
            consultation1.Visible = false;
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            consultation1.refr();
            consultation1.refr1();
            consultation1.refr2();
            consultation1.Visible = true;
            
        }

      

       
        private void mouseDown_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void mouseDown_Event1(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }
        private void mouseMove_Event1(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }
        private void mouseUp_Event1(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if(WindowState== FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }


        }
    }
}
