using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Praktinis
{
    public partial class Grupes : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        public Grupes()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            new Administratorius().Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string group = textBox1.Text;
            int count = 0;
            if (string.IsNullOrEmpty(group) || String.IsNullOrWhiteSpace(group) )
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("Select * from dbo.Grupe",con);
                SqlDataReader Data = command.ExecuteReader();
                while(Data.Read())
                {
                    if(Data["Pavadinimas"].ToString()==group)
                    {
                        count++;
                    }
                }
                Data.Close();
                if(count==0)
                {
                    MessageBox.Show("Tokios grupes nėra");
                }
                else
                {
                    TrynimaiAsmuo Group = new SalintiGrupe(group);
                   Group.Deletion();
                    MessageBox.Show("Ištrinta!");
                    new Grupes().Show();
                    this.Close();

                }

                con.Close();
            }

        }

        private void Grupes_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("select * from dbo.Grupe", con);
            SqlDataReader DataRead = command.ExecuteReader();
            while (DataRead.Read())
            {
                Label labelName = new Label();
                labelName.Height = 50;
                labelName.Width = 50;
                labelName.BackColor = Color.FromArgb(225, 203, 241);
                labelName.Text = DataRead["Pavadinimas"].ToString();
                labelName.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                labelName.TextAlign = ContentAlignment.TopLeft;
                flowLayoutPanel1.Controls.Add(labelName);
            }
            DataRead.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ID = textBox2.Text;
            string name = textBox3.Text;
            int count = 0;

            if (string.IsNullOrEmpty(ID) || String.IsNullOrWhiteSpace(ID)|| string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("Select * from dbo.Grupe", con);
                SqlDataReader Data = command.ExecuteReader();
                while (Data.Read())
                {
                    if (Data["Pavadinimas"].ToString() == name || Data["ID"].ToString() == ID)
                    {
                        count++;
                    }
                }
                Data.Close();

                if (count > 0)
                {
                    MessageBox.Show("Negalima sukurti naujos grupės. Ji arba jau egzistuoja, arba netinka ID");
                }
                else
                {
                    Asmuo NewGroup = new NaujaGrupe(name,ID);
                    NewGroup.New();
                    MessageBox.Show("Sukurta!");
                    new Grupes().Show();
                    this.Close();
                }

                con.Close();
            }

        }
    }
}
