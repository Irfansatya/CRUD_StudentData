using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CrudDaftarSiswa
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            comboBox1.Items.Add("RPL");
            comboBox1.Items.Add("TKJ");
            comboBox1.Items.Add("TJA");

            comboBox3.Items.Add("Laki-Laki");
            comboBox3.Items.Add("Perempuan");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "server=127.0.0.1;database=datasiswa;uid=root;pwd=";
            string query = "INSERT INTO data_kelas11(nis, nama, jurusan, kelas, tempat_tgllahir, jenis_kelamin, alamat)VALUES('"+ this.textBox1.Text + "','"+ this.textBox2.Text + "','"+ this.comboBox1.Text + "','"+ this.comboBox2.Text + "','"+ this.textBox3.Text + "','"+ this.comboBox3.Text + "','"+ this.richTextBox1.Text + "')";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data Telah Disimpan!");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = "server=127.0.0.1;database=datasiswa;uid=root;pwd=";
            string query = "UPDATE data_kelas11 SET nis='" + this.textBox1.Text + "', nama='" + this.textBox2.Text + "', jurusan='" + this.comboBox1.Text + "', kelas='" + this.comboBox2.Text + "', tempat_tgllahir='" + this.textBox3.Text + "', alamat='" + this.richTextBox1.Text + "' WHERE id_siswa='" + this.textBox4.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data Berhasil Diubah!");
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connection = "server=127.0.0.1;database=datasiswa;uid=root;pwd=";
            string query = "SELECT * FROM data_kelas11";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hapus semua item dalam ComboBox 2
            comboBox2.Items.Clear();

            // Tentukan item ComboBox 2 berdasarkan pilihan ComboBox 1
            if (comboBox1.SelectedItem.ToString() == "RPL")
            {
                comboBox2.Items.Add("XI RPL 1");
                comboBox2.Items.Add("XI RPL 2");
                comboBox2.Items.Add("XI RPL 3");
                comboBox2.Items.Add("XI RPL 4");
                comboBox2.Items.Add("XI RPL 5");
                comboBox2.Items.Add("XI RPL 6");
                comboBox2.Items.Add("XI RPL 7");
            }
            else if (comboBox1.SelectedItem.ToString() == "TKJ")
            {
                comboBox2.Items.Add("XI TKJ 1");
                comboBox2.Items.Add("XI TKJ 2");
                comboBox2.Items.Add("XI TKJ 3");
            }
            else if (comboBox1.SelectedItem.ToString() == "TJA")
            {
                comboBox2.Items.Add("XI TJA 1");
                comboBox2.Items.Add("XI TJA 2");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection = "server=127.0.0.1;database=datasiswa;uid=root;pwd=";
            string query = "DELETE FROM data_kelas11 WHERE id_siswa='" + this.textBox4.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data Telah Dihapus!");
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            comboBox3.Text = "";
            richTextBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = row.Cells["id_siswa"].Value.ToString();
                textBox1.Text = row.Cells["nis"].Value.ToString();
                textBox2.Text = row.Cells["nama"].Value.ToString();
                comboBox1.Text = row.Cells["jurusan"].Value.ToString();
                comboBox2.Text = row.Cells["kelas"].Value.ToString();
                textBox3.Text = row.Cells["tempat_tgllahir"].Value.ToString();
                comboBox3.Text = row.Cells["jenis_kelamin"].Value.ToString();
                richTextBox1.Text = row.Cells["alamat"].Value.ToString();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
