using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TEST
{
    public partial class signup : Form
    {
        bool mouseDown;
        private Point offset;

        public signup()
        {
            InitializeComponent();
        }

        private void gunaTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void gunaTextBox1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void gunaPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            gunaPanel3.Width = 256;
            gunaPanel3.Location = new Point(352, 319);
            gunaPanel3.BackColor = Color.CornflowerBlue;
            /**********************************/
            gunaPanel2.Width = 63;
            gunaPanel2.Location= new Point(445,230);
            gunaPanel2.BackColor = Color.YellowGreen;
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {
            gunaPanel2.Width = 288;
            gunaPanel2.Location = new Point(331, 229);
            gunaPanel2.BackColor = Color.CornflowerBlue;
            /****************************************/
            gunaPanel3.Width = 63;
            gunaPanel3.Location = new Point(450, 319);
            gunaPanel3.BackColor = Color.YellowGreen;
        }

        private void gunaTextBox1_Leave(object sender, EventArgs e)
        {
            gunaPanel2.Width = 288;
            gunaPanel2.Location = new Point(331, 229);
            gunaPanel2.BackColor = Color.CornflowerBlue;
        }

        private void gunaTextBox2_Leave(object sender, EventArgs e)
        {
            gunaPanel3.Width = 256;
            gunaPanel3.Location = new Point(352, 319);
            gunaPanel3.BackColor = Color.CornflowerBlue;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            int nbligne = 0;
            if (gunaTextBox2.Text.Length == 0 && gunaTextBox2.Text.Length == 0)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=gestion_hopital;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(cin_med) FROM MEDECIN where cin_med = '" + "bw53" + "' AND nom_med = '" + "ahmed" + "'  ", con);
                cmd.ExecuteNonQuery();
                nbligne = Convert.ToInt16(cmd.ExecuteScalar());

                if (nbligne==0)
                {
                gunaTextBox1.Clear();
                gunaTextBox2.Clear();
                gunaTextBox3.Clear();
                MessageBox.Show("information incorrect");
                }
                else
                {
                    Form1 Form1 = new Form1();
                    Form1.Show();
                    this.Hide();
                }

                con.Close();


            }
            else
            {
                MessageBox.Show("textbox vide");
            }
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

        private void gunaLabel5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }

        }
    }
}
