using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xceed.Words.NET;
using System.IO;
using System.Diagnostics;

namespace bd
{
    public partial class refe : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Students.mdb";
        private OleDbConnection myConnection;
        public void refresh()
        {
            string query = "SELECT * FROM table_uch order by `Фамилия`";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            
            while (reader.Read())
                if (reader[9].ToString()[0] == 'м') 
                listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            reader.Close();
        }
        public refe()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            StreamReader reader = new StreamReader("num.txt");
            numericUpDown1.Value = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            refresh();
        }

        private void refer_Load(object sender, EventArgs e)
        {

        }
        
        private void refe_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter writer = new StreamWriter("num.txt");
            writer.WriteLine(numericUpDown1.Value);
            writer.Close();
            start star = (start)Application.OpenForms["start"];
            star.Show();
            myConnection.Close();
        }


      

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                string str = listBox1.SelectedItem.ToString();
                string[] masStr = str.Split(' ');
                string query = "SELECT * FROM table_uch WHERE `Фамилия`=@uL AND `Имя`=@uN AND `Отчество`=@uP AND `группа`=@uGR";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.Parameters.Add("@uL", OleDbType.VarChar).Value = masStr[0];
                command.Parameters.Add("@uN", OleDbType.VarChar).Value = masStr[1];
                command.Parameters.Add("@uP", OleDbType.VarChar).Value = masStr[2];
                command.Parameters.Add("@uGR", OleDbType.VarChar).Value = masStr[3];
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                MessageBox.Show(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() +
                    " " + reader[5].ToString().Split()[0] + " " + reader[6].ToString().Split()[0] + " " + reader[7].ToString().Split()[0] + " " + reader[8] + " " + reader[9].ToString());
                reader.Close();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                string[] mass = new string[9];
                string str = listBox1.SelectedItem.ToString();
                string[] masStr = str.Split(' ');
                string query = "SELECT * FROM table_uch WHERE `Фамилия`=@uL AND `Имя`=@uN AND `Отчество`=@uP AND `группа`=@uGR";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.Parameters.Add("@uL", OleDbType.VarChar).Value = masStr[0];
                command.Parameters.Add("@uN", OleDbType.VarChar).Value = masStr[1];
                command.Parameters.Add("@uP", OleDbType.VarChar).Value = masStr[2];
                command.Parameters.Add("@uGR", OleDbType.VarChar).Value = masStr[3];
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                mass[0] = reader[1].ToString();
                mass[1] = reader[2].ToString();
                mass[2] = reader[3].ToString();
                mass[3] = reader[4].ToString();
                mass[4] = reader[5].ToString().Split()[0];
                mass[5] = reader[6].ToString().Split()[0];
                mass[6] = reader[7].ToString().Split()[0];
                mass[7] = reader[8].ToString();
                mass[8] = reader[9].ToString();
                reader.Close();

                string pathDocument = AppDomain.CurrentDomain.BaseDirectory + (mass[0] + " " + mass[3] + ".docx");
                DocX document = DocX.Create(pathDocument);
                
                document.MarginTop = 56.7f;
                document.MarginLeft = 85;
                document.MarginRight = 42.52f;
                document.MarginBottom = 56.7f;
                Paragraph par1 =
                document.InsertParagraph("СПРАВКА").
                         Font("Times New Roman").
                         FontSize(15);
                par1.SetLineSpacing(new LineSpacingType(), 1f);
                par1.Alignment = Alignment.center;
                par1.AppendLine("О том, что гражданин является обучающимся").
                    Font("Times New Roman").
                    FontSize(15);
                par1.AppendLine(DateTime.Now.ToString().Split()[0] + " № " + numericUpDown1.Value.ToString()).
                    Font("Times New Roman").
                    FontSize(15);


                string s = "";
                if (mass[8].ToString()[0] == 'м') s = "он"; else s = "она";
                int now = Convert.ToInt32(DateTime.Now.ToString().Split()[0][8] + "" + DateTime.Now.ToString().Split()[0][9]);
                if (DateTime.Now.Month > 7) now++;
                int start = Convert.ToInt32(mass[5].ToString().Split()[0][8] + "" + mass[5].ToString().Split()[0][9]);
                Paragraph par2 = document.InsertParagraph(Convert.ToChar(09) + "Выдана " + mass[0] + " " + mass[1] + " " + mass[2] + ", " + mass[4] + " года рождения, в том что " + s + " с " + mass[5] +
                    " действительно является обучающимся учреждения образования «Молодечненский государственный колледж» учебной группы " + mass[3] + ", "
                    + (now - start + "") + " курса, по специальности: «" + mass[7] + "».").
                    Font("Times New Roman").
                    FontSize(15).
                    SpacingBefore(8);
                par2.Alignment = Alignment.both;
                par2.SetLineSpacing(new LineSpacingType(), 1f);

                Paragraph par =
                document.InsertParagraph("Форма получения образования – дневная.").
                    Font("Times New Roman").
                    FontSize(15);
                par.Alignment = Alignment.left;
                par.IndentationBefore = 1.25f;
                par.SetLineSpacing(new LineSpacingType(), 1f);

                par.AppendLine("Получает первое профессионально техническое образование.").
                    Font("Times New Roman").
                    FontSize(15);

                par.AppendLine("Обучение продлится до " + mass[6] + " г.").
                    Font("Times New Roman").
                    FontSize(15);

                par.AppendLine("Справка действительна 6 месяцев.").
                    Font("Times New Roman").
                    FontSize(15);

                document.InsertParagraph("Директор колледжа " + Convert.ToChar(09) + "" + Convert.ToChar(09) + "" +
                    Convert.ToChar(09) + "" + Convert.ToChar(09) + "" + Convert.ToChar(09) + "" +
                    Convert.ToChar(09) + "" + Convert.ToChar(09) + "" + "Д.Л. Богдан").
                    Font("Times New Roman").
                    FontSize(15).
                    SpacingBefore(8);

                document.Save();
                numericUpDown1.Value++;
                bool i = false;
                StreamReader reader1 = new StreamReader("patch.txt");
                string patch = reader1.ReadLine();
                bool b = Directory.Exists(patch);
                if (!b) { Directory.CreateDirectory(patch); MessageBox.Show("путь к файлу: " + patch); }
                try { File.Move((mass[0] + " " + mass[3] + ".docx"), @"" + patch + "" + mass[0] + " " + mass[3] + ".docx"); }
                catch { File.Delete(mass[0] + " " + mass[3] + ".docx"); numericUpDown1.Value--; i = true; }
                if (!i) MessageBox.Show("имя документа: " + mass[0] + " " + mass[3] + ".docx");
                Process.Start("explorer.exe", "/select," + @"" + patch + "" + mass[0] + " " + mass[3] + ".docx");
            }
            else MessageBox.Show("выберите учащегося");
        }

        private void text_last_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_uch WHERE `Фамилия` Like '" + text_last.Text + "%' order by `Фамилия`";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                if (reader[9].ToString()[0] == 'м') listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            }
            reader.Close();
            if (text_last.Text.Length == 0) refresh();
        }

        private void text_first_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_uch WHERE `Имя` Like '" + text_first.Text + "%' order by `Фамилия`";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                if (reader[9].ToString()[0] == 'м') listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            }
            reader.Close();
            if (text_first.Text.Length == 0) refresh();
        }

        private void text_fater_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_uch WHERE `Отчество` Like '" + text_fater.Text + "%' order by `Фамилия`";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read()) {
                if (reader[9].ToString()[0] == 'м') listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            } reader.Close();
            if (text_fater.Text.Length == 0) refresh();
        }

        private void text_group_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_uch WHERE `группа` Like '" + text_group.Text + "%' order by `группа`";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                if (reader[9].ToString()[0] == 'м') listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            } reader.Close();
            if (text_group.Text.Length == 0) refresh();
        }
    }
}
