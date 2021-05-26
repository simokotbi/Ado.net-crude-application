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
using System.Data.SqlClient;

namespace connecter2
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string checkbox="";
        static string connectionstring="Data Source=.;Initial Catalog=voitures;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            afficher();
        }
        public void afficher()
        {
            dt = new DataTable();
          
            using(SqlConnection con=new SqlConnection(connectionstring))
            {
                SqlCommand cmd1 = new SqlCommand("select*from voiture", con);
                con.Open();
                dr = cmd1.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { checkbox = checkBox1.Text; }
            else if (checkBox2.Checked) { checkbox = checkBox2.Text; }
            if (checkBox3.Checked) { checkbox = checkBox3.Text; }
            else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked) { checkbox = "mixefiuel"; }
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd2 = new SqlCommand("insert into voiture values("+int.Parse(textBox1.Text)+",'"+textBox2.Text+"','"+textBox3.Text+"','"+dateTimePicker1.Value+"','"+checkbox+"')",con);
                con.Open();
                cmd2.ExecuteNonQuery();
            }afficher();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("voulez vous vraiment quiter", "Fermeture", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes) { 
            this.Close();
            }else { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(SqlConnection con3=new SqlConnection(connectionstring))
            {
                SqlCommand cmd3 = new SqlCommand("update voiture set nom='"+textBox2.Text+"',marque='"+textBox3.Text+"',model='"+dateTimePicker1.Value+"',carburan='"+checkbox+"'where id="+int.Parse(textBox1.Text),con3);
                con3.Open();
                cmd3.ExecuteNonQuery();
            }afficher();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using(SqlConnection con=new SqlConnection(connectionstring))
            {
                SqlCommand cmd4 = new SqlCommand("delete from voiture where id="+int.Parse(textBox1.Text),con);
                con.Open();
                cmd4.ExecuteNonQuery();
            }afficher();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
