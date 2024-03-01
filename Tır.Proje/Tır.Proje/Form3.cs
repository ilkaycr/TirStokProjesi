using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Tır.Proje
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Server = .\\SQLEXPRESS;Database = TırProje;Integrated Security =True");
        SqlCommand cmd = new SqlCommand();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("Insert into tblAraclar (Plaka,marka,model,yil,renk,km,durumu,fiyat) values(@Plaka,@marka,@model,@yil,@renk,@km,@durumu,@fiyat)",con);

            cmd.Parameters.AddWithValue("@Plaka",  textBox1.Text);
            cmd.Parameters.AddWithValue("@marka", comboBox1.Text);
            cmd.Parameters.AddWithValue("@model", comboBox2.Text);
            cmd.Parameters.AddWithValue("@yil",    textBox2.Text);
            cmd.Parameters.AddWithValue("@renk",   textBox3.Text);
            cmd.Parameters.AddWithValue("@km",     textBox4.Text);
            cmd.Parameters.AddWithValue("@durumu",comboBox3.Text);
            cmd.Parameters.AddWithValue("@fiyat",  textBox5.Text);

            if (con.State == ConnectionState.Closed)
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Items.Clear();

            MessageBox.Show("Kayıt işlemi başarılı");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                
                if (comboBox1.SelectedIndex == 0)
                {
                    comboBox2.Items.Clear();

                    comboBox2.Items.Add("Actros 1842 LS 4X2");
                    comboBox2.Items.Add("Actros 1851 LS 4X2");

                }

                else if (comboBox1.SelectedIndex == 1)
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("V8");
                    comboBox2.Items.Add("R 540 Dynamic");
                    comboBox2.Items.Add("540 S Dream");
                }

                else if (comboBox1.SelectedIndex == 2)
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("Volvo FH16");
                    comboBox2.Items.Add("Volvo FMX");
                }

                else if (comboBox1.SelectedIndex == 3)
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("Premium");
                    comboBox2.Items.Add("T");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
