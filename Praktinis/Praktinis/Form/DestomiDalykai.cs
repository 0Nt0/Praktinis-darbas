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
    public partial class DestomiDalykai : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        public DestomiDalykai()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            new Administratorius().Show();
            this.Close();
        }

        private void DestomiDalykai_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("select * from dbo.Galimos_Paskaitos", con);
            SqlDataReader DataRead = command.ExecuteReader();
            while (DataRead.Read())
            {
                Label labelName = new Label();
                labelName.Height = 50;
                labelName.Width = 70;
                labelName.BackColor = Color.FromArgb(225, 203, 241);
                labelName.Text = DataRead["Pavadinimas"].ToString();
                labelName.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                labelName.TextAlign = ContentAlignment.TopLeft;
                flowLayoutPanel1.Controls.Add(labelName);
            }
            DataRead.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int count = 0;
            if (string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Negali buti tūščia");
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("select * from dbo.Galimos_Paskaitos",con);
                SqlDataReader Data = command.ExecuteReader();
                while(Data.Read())
                {
                    if(Data["Pavadinimas"].ToString()==name)
                    {
                        count++;
                    }
                }
                Data.Close();

                if(count==0)
                {
                    MessageBox.Show("Tokio destomo dalyko nėra");
                }
                else
                {
                 
                    TrynimaiAsmuo groupDel = new DalykoTrynimas(name,null,null);
                    groupDel.Deletion();
                    MessageBox.Show("Ištrinta");
                    new DestomiDalykai().Show();
                    this.Close();
                }

                con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string ID = textBox3.Text;
            int count = 0;
            if (string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)|| string.IsNullOrEmpty(ID) || String.IsNullOrWhiteSpace(ID))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("select* from dbo.Galimos_Paskaitos",con);
                SqlDataReader Data = command.ExecuteReader();
                while(Data.Read())
                {
                    if(ID==Data["ID"].ToString()|| name==Data["Pavadinimas"].ToString())
                    {
                        count++;
                    }
                }
                Data.Close();
                if(count>0)
                {
                    MessageBox.Show("Negalima sukurti!");
                }
                else
                {
                    SqlCommand command2 = new SqlCommand("Insert into dbo.Galimos_Paskaitos (ID,Pavadinimas)values('"+ID+"','"+name+"')",con);
                    command2.ExecuteNonQuery();
                    MessageBox.Show("Sukurta");
                    new DestomiDalykai().Show();
                    this.Close();
                }
               

                con.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Object  = textBox4.Text;
            string ClassName = textBox5.Text;
            string IdGroup=" ";
            int count = 0;
            con.Open();
            if (string.IsNullOrEmpty(Object) || string.IsNullOrWhiteSpace(Object) || string.IsNullOrEmpty(ClassName) || string.IsNullOrWhiteSpace(ClassName))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                SqlCommand command = new SqlCommand("Select ID from dbo.Grupe where Pavadinimas='"+ClassName+"'", con);
                SqlDataReader Data = command.ExecuteReader();
                while(Data.Read())
                {
                    IdGroup = Data["ID"].ToString();
                }
                Data.Close();
                command = new SqlCommand("Select * from dbo.Grupes_Paskaitos",con);
                Data = command.ExecuteReader();
                while(Data.Read())
                {
                    if(Data["Pavadinimas"].ToString()==Object && Data["Grupe_ID"].ToString()==IdGroup)
                    {
                        count++;
                    }
                }
                Data.Close();

                if(count!=0)
                {
                    MessageBox.Show("Negalima pridėti!");
                }
                else
                {
                    KlasesPridejimasPrieDestomoDalyko TeachingObject = new KlasesPridejimasPrieDestomoDalyko(Object,ClassName,IdGroup);
                    TeachingObject.AssigningToClass();
                    MessageBox.Show("Pridėta");
                    new DestomiDalykai().Show();
                    this.Close();
                }

            }
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
