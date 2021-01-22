namespace bd
{
    partial class refe1
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.text_group = new System.Windows.Forms.TextBox();
            this.text_fater = new System.Windows.Forms.TextBox();
            this.text_first = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.text_last = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(482, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "справка №";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(579, 366);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(82, 22);
            this.numericUpDown1.TabIndex = 34;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(482, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 28);
            this.button3.TabIndex = 33;
            this.button3.Text = "подробно о выбранном";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // text_group
            // 
            this.text_group.Location = new System.Drawing.Point(558, 130);
            this.text_group.Name = "text_group";
            this.text_group.Size = new System.Drawing.Size(103, 22);
            this.text_group.TabIndex = 31;
            this.text_group.TextChanged += new System.EventHandler(this.text_group_TextChanged);
            // 
            // text_fater
            // 
            this.text_fater.Location = new System.Drawing.Point(558, 102);
            this.text_fater.Name = "text_fater";
            this.text_fater.Size = new System.Drawing.Size(229, 22);
            this.text_fater.TabIndex = 30;
            this.text_fater.TextChanged += new System.EventHandler(this.text_fater_TextChanged);
            // 
            // text_first
            // 
            this.text_first.Location = new System.Drawing.Point(558, 74);
            this.text_first.Name = "text_first";
            this.text_first.Size = new System.Drawing.Size(229, 22);
            this.text_first.TabIndex = 29;
            this.text_first.TextChanged += new System.EventHandler(this.text_first_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(482, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "группа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Имя";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(482, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Фамилия";
            // 
            // text_last
            // 
            this.text_last.Location = new System.Drawing.Point(558, 46);
            this.text_last.Name = "text_last";
            this.text_last.Size = new System.Drawing.Size(229, 22);
            this.text_last.TabIndex = 24;
            this.text_last.TextChanged += new System.EventHandler(this.text_last_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(464, 420);
            this.listBox1.TabIndex = 23;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(302, 29);
            this.button1.TabIndex = 22;
            this.button1.Text = "Выдать справку выбранному";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // refe1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.text_group);
            this.Controls.Add(this.text_fater);
            this.Controls.Add(this.text_first);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_last);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "refe1";
            this.Text = "Справка обучение";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.refe1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox text_group;
        private System.Windows.Forms.TextBox text_fater;
        private System.Windows.Forms.TextBox text_first;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_last;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
    }
}