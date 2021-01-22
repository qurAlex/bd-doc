namespace bd
{
    partial class list
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.insert = new System.Windows.Forms.Button();
            this.text_last = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.text_first = new System.Windows.Forms.TextBox();
            this.text_fater = new System.Windows.Forms.TextBox();
            this.text_group = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.text_s = new System.Windows.Forms.TextBox();
            this.button_more = new System.Windows.Forms.Button();
            this.spec = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(412, 436);
            this.listBox1.TabIndex = 0;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(687, 308);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(86, 23);
            this.insert.TabIndex = 1;
            this.insert.Text = "добавить";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // text_last
            // 
            this.text_last.Location = new System.Drawing.Point(544, 39);
            this.text_last.Name = "text_last";
            this.text_last.Size = new System.Drawing.Size(229, 22);
            this.text_last.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "группа";
            // 
            // text_first
            // 
            this.text_first.Location = new System.Drawing.Point(544, 67);
            this.text_first.Name = "text_first";
            this.text_first.Size = new System.Drawing.Size(229, 22);
            this.text_first.TabIndex = 7;
            // 
            // text_fater
            // 
            this.text_fater.Location = new System.Drawing.Point(544, 95);
            this.text_fater.Name = "text_fater";
            this.text_fater.Size = new System.Drawing.Size(229, 22);
            this.text_fater.TabIndex = 8;
            // 
            // text_group
            // 
            this.text_group.Location = new System.Drawing.Point(544, 123);
            this.text_group.Name = "text_group";
            this.text_group.Size = new System.Drawing.Size(103, 22);
            this.text_group.TabIndex = 9;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(437, 409);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(336, 29);
            this.delete.TabIndex = 10;
            this.delete.Text = "удалить выбранные данные";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(437, 364);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(336, 29);
            this.search.TabIndex = 11;
            this.search.Text = "поиск по введенным данным";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(434, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "дата рождения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "дата поступления";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(433, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "дата выпуска";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(431, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "специальность";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(573, 151);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(573, 179);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(573, 207);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker3.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(673, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "пол";
            // 
            // text_s
            // 
            this.text_s.Location = new System.Drawing.Point(721, 123);
            this.text_s.Name = "text_s";
            this.text_s.Size = new System.Drawing.Size(52, 22);
            this.text_s.TabIndex = 24;
            // 
            // button_more
            // 
            this.button_more.Location = new System.Drawing.Point(434, 3);
            this.button_more.Name = "button_more";
            this.button_more.Size = new System.Drawing.Size(239, 30);
            this.button_more.TabIndex = 25;
            this.button_more.Text = "подробно о выбранном";
            this.button_more.UseVisualStyleBackColor = true;
            this.button_more.Click += new System.EventHandler(this.button_more_Click);
            // 
            // spec
            // 
            this.spec.Location = new System.Drawing.Point(544, 235);
            this.spec.Multiline = true;
            this.spec.Name = "spec";
            this.spec.Size = new System.Drawing.Size(229, 67);
            this.spec.TabIndex = 26;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(437, 310);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(143, 21);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "ГосОбеспечение";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.spec);
            this.Controls.Add(this.button_more);
            this.Controls.Add(this.text_s);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.search);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.text_group);
            this.Controls.Add(this.text_fater);
            this.Controls.Add(this.text_first);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_last);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.listBox1);
            this.Name = "list";
            this.Text = "Список";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.list_FormClosed);
            this.Load += new System.EventHandler(this.list_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.TextBox text_last;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_first;
        private System.Windows.Forms.TextBox text_fater;
        private System.Windows.Forms.TextBox text_group;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_s;
        private System.Windows.Forms.Button button_more;
        private System.Windows.Forms.TextBox spec;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}