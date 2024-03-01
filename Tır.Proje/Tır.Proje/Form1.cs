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
    public partial class Form1 : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection("Server = .\\SQLEXPRESS; Database = TırProje; Integrated Security = True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "Select * From Kullanici_bilgi where kullanici_adi = @adi and sifre = @sifresi";
                SqlParameter p1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter p2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Başarıyla Giriş Yapıldı");
                    Form2 frm2 = new Form2();
                    frm2.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }
            catch
            {
                MessageBox.Show("Hatalı giriş yapıldı");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
