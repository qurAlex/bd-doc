using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Xceed.Words.NET;
using System.IO;

namespace bd
{
    public partial class refe1 : Form
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
                    listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            reader.Close();
        }
        public void clText()
        {
            text_fater.Clear();
            text_first.Clear();
            text_group.Clear();
            text_last.Clear();
        }
        
        public refe1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            StreamReader reader = new StreamReader("num.txt");
            numericUpDown1.Value = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0) for (int i = 0; i < listBox1.SelectedItems.Count; i++)
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
                    MessageBox.Show(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() +
                        " " + reader[5].ToString().Split()[0] + " " + reader[6].ToString().Split()[0] + " " + reader[7].ToString().Split()[0] + " " + reader[8] + " " + reader[9].ToString());
                    reader.Close();
                }
            else MessageBox.Show("выберите данные");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
                if (listBox1.SelectedItems.Count > 1)
                {
                    string name = "" + numericUpDown1.Value.ToString() + "-" + (numericUpDown1.Value + listBox1.SelectedItems.Count);
                    if (text_group.Text.Length > 0 && text_fater.Text.Length == 0 && text_first.Text.Length == 0 && text_last.Text.Length == 0) name += " " + text_group.Text;
                    string pathDocument = AppDomain.CurrentDomain.BaseDirectory + (name + ".docx");
                    DocX document = DocX.Create(pathDocument);
                    document.MarginTop = 56.7f;
                    document.MarginLeft = 85;
                    document.MarginRight = 42.52f;
                    document.MarginBottom = 56.7f;
                    for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                    {
                        string[] mass = new string[10];
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
                        mass[0] = reader[1].ToString();
                        mass[1] = reader[2].ToString();
                        mass[2] = reader[3].ToString();
                        mass[3] = reader[4].ToString();

                        mass[5] = reader[6].ToString().Split()[0];
                        mass[6] = reader[7].ToString().Split()[0];
                        mass[7] = reader[8].ToString();
                        mass[8] = reader[9].ToString();
                        mass[9] = reader[10].ToString();
                        reader.Close();

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
                        Paragraph par2 = document.InsertParagraph(Convert.ToChar(09) + "Выдана " + mass[0] + " " + mass[1] + " " + mass[2] + ", в том что " + s + " с " + mass[5] +
                            " действительно является обучающимся учреждения образования «Молодечненский государственный колледж» учебной группы № " + mass[3] + ", "
                            + (now - start + "") + " курса, по специальности: «" + mass[7] + "».").
                            Font("Times New Roman").
                            FontSize(15).
                            SpacingBefore(8);
                        par2.Alignment = Alignment.both;
                        par2.SetLineSpacing(new LineSpacingType(), 1f);

                        Paragraph par3 = document.InsertParagraph(Convert.ToChar(09) + "Форма получения образования – дневная.").
                            Font("Times New Roman").
                            FontSize(15);
                        par3.Alignment = Alignment.left;
                        par3.SetLineSpacing(new LineSpacingType(), 1f);

                        string p = "";
                        if (Convert.ToBoolean(mass[9])) p = "четырехразовое питание и находится на государственном обеспечении с " + mass[5].ToString().Split()[0];
                        else p = "одноразовое питание и не находится на государственном обеспечении";
                        Paragraph par4 = document.InsertParagraph(Convert.ToChar(09) + "Получает " + p + ". Стипендия не выплачивается.").
                            Font("Times New Roman").
                            FontSize(15);
                        par4.SetLineSpacing(new LineSpacingType(), 1f);

                        Paragraph par =
                        document.InsertParagraph("Получает первое профессионально техническое образование.").
                            Font("Times New Roman").
                            FontSize(15);
                        par.Alignment = Alignment.left;
                        par.IndentationBefore = 1.25f;
                        par.SetLineSpacing(new LineSpacingType(), 1f);

                        par.AppendLine("Срок окончания учреждения образования " + mass[6] + " г.").
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
                        if (i % 2 == 0)
                        {
                            document.InsertParagraph().FontSize(43);
                            document.InsertParagraph().FontSize(43);
                            /// document.InsertParagraph().FontSize(40);
                        }
                        else
                            document.InsertSectionPageBreak();
                        document.Save();
                        numericUpDown1.Value++;
                    }
                    StreamReader reader1 = new StreamReader("patch1.txt");
                    string patch = reader1.ReadLine();
                    bool i1 = false;
                    bool b = Directory.Exists(patch);
                    if (!b) { Directory.CreateDirectory(patch); }
                    MessageBox.Show("имя файла: " + name + ".docx");
                    try { File.Move((name + ".docx"), @"" + patch + "" + name + ".docx"); }
                    catch {  File.Delete(@"" + patch + "" + name + ".docx"); numericUpDown1.Value -= listBox1.SelectedItems.Count; i1 = true; }
                    if(i1) File.Move((name + ".docx"), @"" + patch + "" + name + ".docx");
                    Process.Start("explorer.exe", "/select," + @"" + patch + "" +name + ".docx");
                    
                }
                else
                {
                    string[] mass = new string[10];
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

                    mass[5] = reader[6].ToString().Split()[0];
                    mass[6] = reader[7].ToString().Split()[0];
                    mass[7] = reader[8].ToString();
                    mass[8] = reader[9].ToString();
                    mass[9] = reader[10].ToString();
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
                    Paragraph par2 = document.InsertParagraph(Convert.ToChar(09) + "Выдана " + mass[0] + " " + mass[1] + " " + mass[2] + ", в том что " + s + " с " + mass[5] +
                        " действительно является обучающимся учреждения образования «Молодечненский государственный колледж» учебной группы № " + mass[3] + ", "
                        + (now - start + "") + " курса, по специальности: «" + mass[7] + "».").
                        Font("Times New Roman").
                        FontSize(15).
                        SpacingBefore(8);
                    par2.Alignment = Alignment.both;
                    par2.SetLineSpacing(new LineSpacingType(), 1f);

                    Paragraph par3 = document.InsertParagraph(Convert.ToChar(09) + "Форма получения образования – дневная.").
                        Font("Times New Roman").
                        FontSize(15);
                    par3.Alignment = Alignment.left;
                    par3.SetLineSpacing(new LineSpacingType(), 1f);

                    string p = "";
                    if (Convert.ToBoolean(mass[9])) p = "четырезразовое питание и находится на государственном обеспечении с" + mass[5].ToString().Split()[0];
                    else p = "одноразовое питание и не находится на государственном обеспечении";
                    Paragraph par4 = document.InsertParagraph(Convert.ToChar(09) + "Получает " + p + ". Стипендия не выплачивается.").
                        Font("Times New Roman").
                        FontSize(15);
                    par4.SetLineSpacing(new LineSpacingType(), 1f);

                    Paragraph par =
                    document.InsertParagraph("Получает первое профессионально техническое образование.").
                        Font("Times New Roman").
                        FontSize(15);
                    par.Alignment = Alignment.left;
                    par.IndentationBefore = 1.25f;
                    par.SetLineSpacing(new LineSpacingType(), 1f);

                    par.AppendLine("Срок окончания учреждения образования " + mass[6] + " г.").
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
                    StreamReader reader1 = new StreamReader("patch1.txt");
                    string patch = reader1.ReadLine();
                    bool b=Directory.Exists(patch);
                    if (!b) { Directory.CreateDirectory(patch); }
                    try { File.Move((mass[0] + " " + mass[3] + ".docx"), @"" + patch + "" + mass[0] + " " + mass[3] + ".docx"); }
                    catch {  File.Delete(@""+patch+""+mass[0] + " " + mass[3] + ".docx"); numericUpDown1.Value--; i = true; }
                    if (i) File.Move((mass[0] + " " + mass[3] + ".docx"), @"" + patch + "" + mass[0] + " " + mass[3] + ".docx");
                    if (!i) {MessageBox.Show("имя документа: " + mass[0] + " " + mass[3] + ".docx"); }
                    Process.Start("explorer.exe", "/select," + @"" + patch + "" + mass[0] + " " + mass[3] + ".docx");
                }
            else MessageBox.Show("выберите учащегося");
        }

        private void refe1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter writer = new StreamWriter("num.txt");
            writer.WriteLine(numericUpDown1.Value);
            writer.Close();
            start star = (start)Application.OpenForms["start"];
            star.Show();
            myConnection.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            refresh();
            clText();
        }

        private void text_last_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_uch WHERE `Фамилия` Like '"+text_last.Text+"%' order by `Фамилия`";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
                listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            reader.Close();
        }

        private void text_first_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_uch WHERE `Имя` Like '" + text_first.Text + "%' order by `Фамилия`";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
                listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            reader.Close();
        }

        private void text_fater_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_uch WHERE `Отчество` Like '" + text_fater.Text + "%' order by `Фамилия`";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
                listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            reader.Close();
        }

        private void text_group_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_uch WHERE `группа` Like '" + text_group.Text + "%' order by `группа`";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
                listBox1.Items.Add(reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString());
            reader.Close();
        }
    }
}
