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
        bool drag = false;
        Point start_point = new Point(0, 0);

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

        private void gunaPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void gunaPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);

            }
        }



        private void gunaPanel2_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
           
        }
    }
}
