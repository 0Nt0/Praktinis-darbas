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
    public partial class DarbasSuDestytojais : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        public DarbasSuDestytojais()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            new Administratorius().Show();
            this.Close();
        }

        private void DarbasSuDestytojais_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("select * from dbo.Destytojas", con);
            SqlDataReader DataRead = command.ExecuteReader();
            while(DataRead.Read())
            {
               Label labelName = new Label();
                labelName.Height = 100;
                labelName.Width = 100;
                labelName.BackColor = Color.FromArgb(225, 203, 241);
              //  labelName.ForeColor = Color.FromArgb(0, 0, 0);
                labelName.Text = DataRead["Vardas"].ToString() + " " + DataRead["Pavarde"].ToString();
                labelName.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                labelName.TextAlign = ContentAlignment.TopLeft;
                flowLayoutPanel1.Controls.Add(labelName);
            }
            DataRead.Close();
            con.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            con.Open();
            string name = textBox1.Text;
            string surname = textBox2.Text;
            if (string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(surname) || String.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                TrynimaiAsmuo DeletionProf = new DestytojuTrynimas(name,surname);
                DeletionProf.Deletion();
                new DarbasSuDestytojais().Show();
                this.Close();
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            int count = 0;
            string name = textBox3.Text;
            string surname = textBox4.Text;
            string IDPerson = textBox5.Text;
            if (string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(surname) || String.IsNullOrWhiteSpace(surname)|| string.IsNullOrEmpty(IDPerson) || String.IsNullOrWhiteSpace(IDPerson))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                SqlCommand command = new SqlCommand("Select * from dbo.Destytojas",con);
                SqlDataReader Data = command.ExecuteReader();
                while(Data.Read())
                {
                    if(Data["Vardas"].ToString()==name && Data["Pavarde"].ToString()==surname && IDPerson==Data["Asmens_Kodas"].ToString()|| IDPerson== Data["Asmens_Kodas"].ToString())
                    {
                        MessageBox.Show("Destytojas jau egzistuoja");
                        count++;
                    }
                }
                if(count==0)
                {
                    Asmuo Destytojas = new NaujasDestytojas(name,surname,IDPerson);
                    Destytojas.New();
                    new DarbasSuDestytojais().Show();
                    this.Close();
                }
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;
            string surname = textBox7.Text;
            string Class = textBox8.Text;
            string room = textBox9.Text;
            int count = 0, countnm=0,countsk=0;
            if (string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(surname) || String.IsNullOrWhiteSpace(surname)|| string.IsNullOrEmpty(Class) || String.IsNullOrWhiteSpace(Class) || string.IsNullOrEmpty(room) || String.IsNullOrWhiteSpace(room))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                con.Open();
                int maxID=0;
                SqlCommand command = new SqlCommand("select * from dbo.Galimos_Paskaitos",con);
                SqlDataReader Read = command.ExecuteReader();
                while(Read.Read())
                {
                    if(Read["Pavadinimas"].ToString()==Class)
                    {
                        count++;
                    }
                }
                Read.Close();

               SqlCommand command3 = new SqlCommand("select * from dbo.Destytojas", con);
                 Read = command3.ExecuteReader();
                while (Read.Read())
                {
                    if (Read["Vardas"].ToString() == name && Read["Pavarde"].ToString()==surname)
                    {
                        countnm++;
                    }
                }
                Read.Close();
                if (count==0)
                {
                    MessageBox.Show("Toks dalykas nėra dėstomas");
                }
                else if(countnm==0)
                {
                    MessageBox.Show("Tokio destytojo nėra");
                }
                else
                {
                    SqlCommand command2 = new SqlCommand("Select * from dbo.Paskaitos",con);
                    Read = command2.ExecuteReader();
                    while(Read.Read())
                    {
                        if(Convert.ToInt32(Read["ID"].ToString())> maxID)
                        {
                            maxID = Convert.ToInt32(Read["ID"].ToString()) + 1;
                        }
                    }
                    Read.Close();

                     command2 = new SqlCommand("Select * from dbo.Paskaitos", con);
                    Read = command2.ExecuteReader();
                    while (Read.Read())
                    {
                        if(Read["Pavadinimas"].ToString()!=null && Read["ID"].ToString()!=null && Read["Destytojas_Vardas"].ToString()=="-" && Read["Destytojas_Pavarde"].ToString()=="-" && Read["Pavadinimas"].ToString()==Class)
                        {
                            countsk++;
                        }
                        
                    }
                    Read.Close();

                    if(countsk!=0)
                    {
                        SqlCommand command4 = new SqlCommand("Update dbo.Paskaitos set Destytojas_Vardas='" + name + "', Destytojas_Pavarde='" + surname + "', Kabinetas='" + room + "' where Destytojas_Vardas='" + "-" + "'", con);
                        command4.ExecuteNonQuery();
                        MessageBox.Show("Atlikta!");
                        new DarbasSuDestytojais().Show();
                        this.Close(); 
                    }
                    else
                    {
                        maxID = maxID + 1;
                        SqlCommand command5 = new SqlCommand("Insert into dbo.Paskaitos (ID, Pavadinimas, Kabinetas, Destytojas_Vardas, Destytojas_Pavarde)values('" + maxID + "','" + Class + "','" + room + "','" + name + "','" + surname + "')", con);
                        command5.ExecuteNonQuery();
                        MessageBox.Show("Atlikta!");
                        new DarbasSuDestytojais().Show();
                        this.Close();
                    }
                }


                con.Close();
            }

        }
    }
}
