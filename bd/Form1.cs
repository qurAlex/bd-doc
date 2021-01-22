using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bd
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new list().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new refe().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new refe1().Show();
            this.Hide();
        }
    }
}
