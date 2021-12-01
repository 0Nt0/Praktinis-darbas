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
   
    public partial class Prisijungimas : Form
    {
       SqlConnection con=new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        public Prisijungimas(int var )
        {
            InitializeComponent();
            if (var == 1)
            {
                label1.Text = "Studento prisijungimas";
            }
            else if (var == 2) label1.Text = "Dėstytojo prisijungimas";
            else label1.Text = "Administratorius";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prisijungi_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text;
            string Password = textBox2.Text;
            int count = 0;
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrWhiteSpace(UserName)||string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                if (label1.Text == "Studento prisijungimas")
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select * from dbo.Studentas", con);
                    SqlDataReader DataRead = command.ExecuteReader();
                    while (DataRead.Read())
                    {
                        if (UserName == DataRead["Vardas"].ToString() && Password == DataRead["Pavarde"].ToString())
                        {
                            count++;
                            new Pazymiai(UserName,Password).Show();
                            this.Hide();
                        }

                    }
                    if (count == 0)
                    {
                        MessageBox.Show("Tokio studento nėra");
                    }

                    DataRead.Close();
                    con.Close();
                }
                else if(label1.Text== "Dėstytojo prisijungimas")
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select * from dbo.Destytojas", con);
                    SqlDataReader DataRead = command.ExecuteReader();
                    while (DataRead.Read())
                    {
                        if (UserName == DataRead["Vardas"].ToString() && Password == DataRead["Pavarde"].ToString())
                        {
                            count++;
                            new DestytojuiPrisijungus(UserName,Password).Show();
                            this.Hide();
                        }

                    }
                    if (count == 0)
                    {
                        MessageBox.Show("Tokio dėstytojo nėra");
                    }

                    DataRead.Close();
                    con.Close();
                }
                else
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("select * from dbo.Administratoriai",con);
                    SqlDataReader DataRead = command.ExecuteReader();
                    while(DataRead.Read())
                    {
                        if (UserName == DataRead["Slapyvardis"].ToString() && Password == DataRead["Slaptazodis"].ToString())
                        {
                            count++;
                            new Administratorius().Show();
                            this.Hide();
                        }
                    }
                    if(count==0)
                    {
                        MessageBox.Show("Toks administratorius neegzistuoja");
                    }
                    DataRead.Close();
                    con.Close();
                }

            }
            
        }

        private void Atgal_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
                
        }

        private void Prisijungimas_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
