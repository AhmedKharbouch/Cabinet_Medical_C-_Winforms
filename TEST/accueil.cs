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
    public partial class accueil : UserControl
    {
        public accueil()
        {
            InitializeComponent();
        }
        public void refr()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=gestion_hopital;Integrated Security=True");
            con.Open();
            int nbligne=0,nbligne1 = 0;
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(cin_pat) FROM PATIENT", con);
            cmd1.ExecuteNonQuery();

            nbligne = Convert.ToInt16(cmd1.ExecuteScalar());

           gunaLabel2.Text = nbligne.ToString();
            
            
            DateTime DateAndTime = new DateTime(2022,4,6);
            gunaLabel3.Text =DateTime.Now.ToString("dd/MM/yyyy");
            int nbligne2 = 0;
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(id_CONSULTATION) FROM CONSULTATION ", con);
            cmd2.ExecuteNonQuery();
            nbligne2 = Convert.ToInt16(cmd2.ExecuteScalar());
            gunaLabel5.Text= nbligne2.ToString();
            con.Close();

        }
        private void accueil_Load(object sender, EventArgs e)
        {
            gunaLabel1.BorderStyle = BorderStyle.FixedSingle;

            refr();
            
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
