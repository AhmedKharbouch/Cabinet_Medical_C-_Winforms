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
    public partial class consultation : UserControl
    {
        public consultation()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=gestion_hopital;Integrated Security=True");
        public void refr()
        {
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select id_MEDECIN, nom_med from MEDECIN ", con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            gunaDataGridView1.DataSource = dtbl;
        }
        public void refr1()
        {
            con.Close();
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select id_PATIENT, nom_pat from PATIENT", con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            gunaDataGridView2.DataSource = dtbl;
            con.Close();
        }
        public void refr2()
        {
            con.Close();
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select id_CONSULTATION, prix_cons, date_cons, id_PATIENT, id_MEDECIN nom_pat from CONSULTATION", con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            gunaDataGridView3.DataSource = dtbl;
            con.Close();
        }
        private void gunaTextBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void consultation_Load(object sender, EventArgs e)
        {
            refr();
            refr1();
            refr2();
            gunaTextBox3.Enabled = false;
            gunaTextBox2.Enabled = false;
            gunaTextBox4.Visible= false;

        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

          
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("date impossible");
                gunaTextBox1.Clear();
                gunaTextBox2.Clear();
                gunaTextBox3.Clear();
            }
            else if(gunaTextBox1.Text.Length == 0 && gunaTextBox2.Text.Length == 0 && gunaTextBox3.Text.Length == 0)
            {
                MessageBox.Show("les textbox sont vide");
                gunaTextBox1.Clear();
                gunaTextBox2.Clear();
                gunaTextBox3.Clear();
            }
            else
            {
                con.Open();
                
                SqlCommand cmd = new SqlCommand(" INSERT INTO CONSULTATION (prix_cons,date_cons,id_PATIENT,id_MEDECIN) VALUES('" + gunaTextBox1.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy HH:MM:ss") + "','" + gunaTextBox3.Text + "','" + gunaTextBox2.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Inssertion avec succes");
                gunaTextBox1.Clear();
                gunaTextBox2.Clear();
                gunaTextBox3.Clear();
                dateTimePicker1.Value = DateTime.Now;
                con.Close();


            }
            refr2();

        }
        int selectedRow;
        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (selectedRow >= 0) { 
            DataGridViewRow row = gunaDataGridView1.Rows[selectedRow];
            gunaTextBox2.Text = row.Cells[0].Value.ToString();
            }
        }
        
        int selectedRow1;
        private void gunaDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow1 = e.RowIndex;
            if (selectedRow1 >= 0)
            {
                DataGridViewRow row = gunaDataGridView2.Rows[selectedRow1];
                gunaTextBox3.Text = row.Cells[0].Value.ToString();
            }
        }
        int selectedRow2;
        private void gunaDataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gunaButton1.Enabled = false;
            selectedRow2 = e.RowIndex;
            if (selectedRow2 >= 0)
            {
                DataGridViewRow row = gunaDataGridView3.Rows[selectedRow2];
                gunaTextBox4.Text = row.Cells[0].Value.ToString();
                gunaTextBox1.Text = row.Cells[1].Value.ToString();
                gunaTextBox2.Text = row.Cells[4].Value.ToString();
                gunaTextBox3.Text = row.Cells[3].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells[2].Value);
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
           con.Open();
            SqlCommand cmd = new SqlCommand(" UPDATE CONSULTATION SET prix_cons = '" + gunaTextBox1.Text + "' , date_cons = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy HH:MM:ss") + "'  WHERE  id_CONSULTATION = '" + gunaTextBox4.Text + "' ", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("modification avec succes");
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            gunaTextBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
            gunaButton1.Enabled = true;
            refr2();
            con.Close();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
           con.Open();
            SqlCommand cmd = new SqlCommand(" DELETE CONSULTATION WHERE id_CONSULTATION = '" + gunaTextBox4.Text + "' ", con);
            int i = cmd.ExecuteNonQuery();
            MessageBox.Show("suppression avec succes");
            gunaTextBox1.Clear();
            gunaTextBox2.Clear();
            gunaTextBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
            gunaButton1.Enabled = true;

            refr();
            refr1();
            refr2();
            con.Close();
        }

       
    }
}
