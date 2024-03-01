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

    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Server = .\\SQLEXPRESS;Database = TırProje;Integrated Security =True");
        SqlCommand cmd = new SqlCommand();
        DataSet dataset = new DataSet();
        

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void listeleme()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();


            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT ID,Plaka,marka,model,yil,renk,km,durumu,fiyat From tblAraclar", con);


            dataAdapter.Fill(dataset, "tblAraclar");
            dataGridView1.DataSource = dataset.Tables["tblAraclar"];

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();


            cmd = new SqlCommand("UPDATE tblAraclar set Plaka=@PPlaka, marka = @mrk,model=@mdl,yil=@yyil,renk=@rrenk,km=@kkm,durumu=@drm,fiyat=@fyt Where ID=@ID", con);

            cmd.Parameters.AddWithValue("@ID", textBox6.Text);
            cmd.Parameters.AddWithValue("@PPlaka", textBox1.Text);
            cmd.Parameters.AddWithValue("@mrk", comboBox1.Text);
            cmd.Parameters.AddWithValue("@mdl", comboBox2.Text);
            cmd.Parameters.AddWithValue("@yyil", textBox2.Text);
            cmd.Parameters.AddWithValue("@rrenk", textBox3.Text);
            cmd.Parameters.AddWithValue("@kkm", textBox4.Text);
            cmd.Parameters.AddWithValue("@drm", comboBox3.Text);
            cmd.Parameters.AddWithValue("@fyt", textBox5.Text);
            
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Güncelleme Gerçekleştirildi");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            DialogResult a = MessageBox.Show(" Silmek İstediğinizden Emin Misiniz ?","Silme", MessageBoxButtons.YesNo);
            
            if (a == DialogResult.Yes)
            {
                cmd = new SqlCommand("DELETE FROM tblAraclar WHERE ID=@ID", con);

                cmd.Parameters.AddWithValue("@ID", textBox6.Text);

                cmd.ExecuteNonQuery();
            } 
            else
            {
                MessageBox.Show("Silme İşlemi Gerçekleştirilmedi", "Silme");
            }

            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
