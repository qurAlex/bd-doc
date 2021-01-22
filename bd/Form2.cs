using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bd
{
    public partial class list : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Students.mdb";
        private OleDbConnection myConnection;
        public void refresh()
        {
            string query = "SELECT * FROM table_uch";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
                listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            reader.Close();
        }
        public void clText()
        {
            text_first.Clear();
            text_fater.Clear();
            text_group.Clear();
            text_last.Clear();
            text_s.Clear();
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker3.Value = DateTime.Today;
            spec.Clear();
            checkBox1.Checked = false;
        }
        
        
        public list()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            start star = (start)Application.OpenForms["start"];
            star.Show();
            this.Hide();
        }

        private void list_FormClosed(object sender, FormClosedEventArgs e)
        {
            start star = (start)Application.OpenForms["start"];
            star.Show();
            myConnection.Close();
            
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (text_last.Text.Length > 0 && text_first.Text.Length > 0 && text_group.Text.Length > 0 && text_group.Text.Length > 0 && text_s.Text.Length > 0)
            {
                string s = "";
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command = new OleDbCommand("INSERT INTO `table_uch`(`Фамилия`, `Имя`, `Отчество`, `группа`,`дата рождения`," +
                    "`дата поступления`,`дата выпуска`,`специальность`,`пол`,`гос-обеспечение`) VALUES (@FIO,@NAME,@P,@GR,@DR,@ST,@FIN,@sP,@S,@B)", myConnection);
                command.Parameters.Add("@FIO", OleDbType.VarChar).Value = text_last.Text;
                command.Parameters.Add("@NAME", OleDbType.VarChar).Value = text_first.Text;
                command.Parameters.Add("@P", OleDbType.VarChar).Value = text_fater.Text;
                command.Parameters.Add("@GR", OleDbType.VarChar).Value = text_group.Text;
                command.Parameters.Add("@DR", OleDbType.Date).Value = dateTimePicker1.Value;
                command.Parameters.Add("@ST", OleDbType.Date).Value = dateTimePicker2.Value;
                command.Parameters.Add("@FIN", OleDbType.Date).Value = dateTimePicker3.Value;
                for (int i = 0; i < spec.Lines.Length; i++)
                    s += spec.Lines[i] + " ";
                command.Parameters.Add("@sP", OleDbType.VarChar).Value = s;
                command.Parameters.Add("@S", OleDbType.VarChar).Value = text_s.Text;
                command.Parameters.Add("@B", OleDbType.Boolean).Value = checkBox1.Checked;
                adapter.SelectCommand = command;
                adapter.SelectCommand.ExecuteNonQuery();
                clText();
                refresh();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            refresh();
            clText();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0) MessageBox.Show("выберите данные");
            else for(int i=0;i<listBox1.SelectedItems.Count;i++)
            {
                string str = listBox1.SelectedItems[i].ToString();
                string[] masStr = str.Split(' ');
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command = new OleDbCommand("DELETE* FROM `table_uch` WHERE `Фамилия`=@uL AND `Имя`=@uN AND `Отчество`=@uP AND `группа`=@uGR", myConnection);
                command.Parameters.Add("@uL", OleDbType.VarChar).Value = masStr[0];
                command.Parameters.Add("@uN", OleDbType.VarChar).Value = masStr[1];
                command.Parameters.Add("@uP", OleDbType.VarChar).Value = masStr[2];
                command.Parameters.Add("@uGR", OleDbType.VarChar).Value = masStr[3];
                adapter.SelectCommand = command;
                adapter.SelectCommand.ExecuteNonQuery();
                clText();
            }refresh();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            bool[] i = new bool[4] { false,false,false,false};
            if (text_fater.Text.Length > 0 || text_first.Text.Length > 0 || text_group.Text.Length > 0 || text_last.Text.Length > 0)
            {
                OleDbCommand command = new OleDbCommand();
                string query = "SELECT * FROM table_uch WHERE ";
                if (text_last.Text.Length > 0)
                {
                    query += "`Фамилия`Like '"+text_last.Text+"%' ";
                    command = new OleDbCommand(query, myConnection);
                    i[0] = true;
                }
                if (text_first.Text.Length > 0)
                {
                    if (i[0]) query += "AND ";
                    query += "`Имя`Like '"+text_first.Text+"%' ";
                    command = new OleDbCommand(query, myConnection);
                    i[1] = true;
                }
                if (text_fater.Text.Length > 0)
                {
                    if (i[1]||i[0]) query += "AND ";
                    query += "`Отчество`Like '"+text_fater.Text+"%' ";
                    command = new OleDbCommand(query, myConnection);
                    i[2] = true;
                }
                if (text_group.Text.Length > 0)
                {
                    if (i[2]||i[1]||i[0]) query += "AND ";
                    query += "`группа`Like '"+text_group.Text+"%'";
                    command = new OleDbCommand(query, myConnection);
                    i[3] = true;
                }
                OleDbDataReader reader = command.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                    listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4] + "");
                reader.Close();
            }
            else
            {
                MessageBox.Show("поиск только по ФИО и группе");
                clText();
            }
                }

        private void button_more_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0) MessageBox.Show("выберите учащегося(-юся)");
            else for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                string str = listBox1.SelectedItems[i].ToString();
                string[] masStr = str.Split(' ');
                string query = "SELECT * FROM table_uch WHERE `Фамилия`=@uL AND `Имя`=@uN AND `Отчество`=@uP AND `группа`=@uGR";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.Parameters.Add("@uL", OleDbType.VarChar).Value = masStr[0];
                command.Parameters.Add("@uN", OleDbType.VarChar).Value = masStr[1];
                command.Parameters.Add("@uP", OleDbType.VarChar).Value = masStr[2];
                command.Parameters.Add("@uGR", OleDbType.VarChar).Value = masStr[3];
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                string gos = "";
                if (Convert.ToBoolean(reader[10].ToString())) gos = "обеспечение"; else gos = "нет обеспечения";
                MessageBox.Show(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() +
                        " " + reader[5].ToString().Split()[0] + " " + reader[6].ToString().Split()[0] + " " + reader[7].ToString().Split()[0] + " " + reader[8] + " " + reader[9].ToString() + " " + gos);
                reader.Close();
            }
        }

        private void list_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void text_last_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
