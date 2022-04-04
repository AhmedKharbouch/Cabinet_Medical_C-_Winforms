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
    public partial class medecin : UserControl
    {
        public medecin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=gestion_hopital;Integrated Security=True");
        public void refr()
        {
            con.Close();
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select id_MEDECIN, nom_med, cin_med, tel_med from MEDECIN ", con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            gunaDataGridView1.DataSource = dtbl;
            con.Close();
        }
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            con.Open();

            int nbligne = 0;
            if (gunaTextBox2.Text.Length != 0 && gunaTextBox2.Text.Length != 0 && gunaTextBox2.Text.Length != 0)
            {

                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(cin_med) FROM MEDECIN WHERE cin_med = '" + gunaTextBox2.Text + "'", con);
                cmd1.ExecuteNonQuery();

                nbligne = Convert.ToInt16(cmd1.ExecuteScalar());

                if (nbligne == 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO MEDECIN (cin_med,nom_med,tel_med) VALUES ('" + gunaTextBox2.Text + "','" + gunaTextBox1.Text + "','" + gunaTextBox3.Text + "')", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("inserer avec succes");
                    gunaTextBox1.Clear();
                    gunaTextBox2.Clear();
                    gunaTextBox3.Clear();


                }
                else
                {
                    MessageBox.Show("medecin existant");
                    gunaTextBox1.Clear();
                    gunaTextBox2.Clear();
                    gunaTextBox3.Clear();
                };

                refr();
                con.Close();
            }
            else
            {
                MessageBox.Show("textbox vide");
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if (gunaTextBox2.Text.Length != 0 && gunaTextBox2.Text.Length != 0 && gunaTextBox2.Text.Length != 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE MEDECIN SET nom_med = '" + gunaTextBox1.Text + "' ,tel_med = '" + gunaTextBox3.Text + "' where cin_med = '" + gunaTextBox2.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("modification avec succes");
                refr();
                gunaTextBox1.Clear();
                gunaTextBox2.Clear();
                gunaTextBox3.Clear();
                gunaTextBox2.Enabled = true;
                gunaButton1.Enabled = true;
                con.Close();
            }
            else
            {
                MessageBox.Show("textbox vide");
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (gunaTextBox2.Text.Length != 0 && gunaTextBox2.Text.Length != 0 && gunaTextBox2.Text.Length != 0)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("DELETE FROM CONSULTATION where id_MEDECIN = '" + gunaTextBox0.Text + "'", con);
                int t = cmd1.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("DELETE FROM MEDECIN where cin_med = '" + gunaTextBox2.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("suppression avec succes");
                refr();
                gunaTextBox1.Clear();
                gunaTextBox2.Clear();
                gunaTextBox3.Clear();
                gunaTextBox2.Enabled = true;
                gunaButton1.Enabled = true;
                con.Close();
            }
            else
            {
                MessageBox.Show("textbox vide");
            }
        }

        private void gunaTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        int selectedRow;
        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(selectedRow >= 0) {
            DataGridViewRow row = gunaDataGridView1.Rows[selectedRow];
            gunaTextBox0.Text = row.Cells[0].Value.ToString();
            gunaTextBox1.Text = row.Cells[1].Value.ToString();
            gunaTextBox2.Text = row.Cells[2].Value.ToString();
            gunaTextBox3.Text = row.Cells[3].Value.ToString();
            gunaTextBox2.Enabled = false;
            gunaButton1.Enabled = false; 
            }
        }

        private void medecin_Load(object sender, EventArgs e)
        {
            gunaTextBox0.Visible = false;
            refr();
        }

        private void gunaTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
