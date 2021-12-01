using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktinis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Prisijungimas(1).Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Prisijungimas(2).Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Prisijungimas(3).Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
