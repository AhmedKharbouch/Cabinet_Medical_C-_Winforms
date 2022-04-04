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
    public partial class medicament : UserControl
    {
        public medicament()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=gestion_hopital;Integrated Security=True");
        public void refr()
        {
            con.Close();
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select nom_medoc from MEDICAMENT ", con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            gunaDataGridView1.DataSource = dtbl;
            con.Close();
        }
        private void medicament_Load(object sender, EventArgs e)
        {
            refr();
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

        }
        int selectedRow;
        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = gunaDataGridView1.Rows[selectedRow];
                gunaTextBox1.Text = row.Cells[0].Value.ToString();
            }
            
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            con.Open();

            int nbligne = 0;
            if (gunaTextBox1.Text.Length != 0 )
            {

                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(nom_medoc) FROM MEDICAMENT WHERE nom_medoc = '" + gunaTextBox1.Text + "'", con);
                cmd1.ExecuteNonQuery();

                nbligne = Convert.ToInt16(cmd1.ExecuteScalar());

                if (nbligne == 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO MEDICAMENT (nom_medoc) VALUES ('" + gunaTextBox1.Text + "')", con);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("inserer avec succes");
                    gunaTextBox1.Clear();
                    


                }
                else
                {
                    MessageBox.Show("medicament existant");
                    gunaTextBox1.Clear();
                    
                };

                refr();
                con.Close();
            }
            else
            {
                MessageBox.Show("textbox vide");
            }
        }

        private void gunaButton2_Click_1(object sender, EventArgs e)
        {
            if (gunaTextBox1.Text.Length != 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM MEDICAMENT where nom_medoc = '" + gunaTextBox1.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("suppression avec succes");
                refr();
                gunaTextBox1.Clear();
                con.Close();

            }
            else
            {
                MessageBox.Show("textbox vide");
            }
        }
    }
}
