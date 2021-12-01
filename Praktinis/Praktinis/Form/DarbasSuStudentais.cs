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
    public partial class DarbasSuStudentais : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False"); 
        Label Info;
        public DarbasSuStudentais()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            new Administratorius().Show();
            this.Close();
        }

        private void DarbasSuStudentais_Load(object sender, EventArgs e)
        {
            con.Open();
          
            SqlCommand command = new SqlCommand("select * from dbo.Studentas",con);
            SqlDataReader DataRead = command.ExecuteReader();
            while(DataRead.Read())
            {
                Information(100, 100, 225, 203, 241, 9, DataRead["Vardas"].ToString(), Info, DataRead["Pavarde"].ToString(), DataRead["Grupe"].ToString());
            }
            DataRead.Close();
            con.Close();
        }
        private void Information(int height, int width, int R, int G, int B, int S ,string item, Label labelName,string item2, string item3)
        {
            labelName = new Label();
            labelName.Height = height;
            labelName.Width = width;
            labelName.BackColor = Color.FromArgb(R, G, B);
          //  labelName.ForeColor = Color.FromArgb(0, 0, 0);
            labelName.Text = item+" "+item2+" "+item3;
            labelName.Font = new Font("Microsoft Sans Serif", S, FontStyle.Regular);
            labelName.TextAlign = ContentAlignment.TopLeft;
            flowLayoutPanel1.Controls.Add(labelName);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            con.Open();
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string group = textBox3.Text;
            if (string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(surname) || String.IsNullOrWhiteSpace(surname)|| string.IsNullOrEmpty(group) || String.IsNullOrWhiteSpace(group))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                TrynimaiAsmuo DeletionSt = new StudentuTrynimas(name,surname,group);
                DeletionSt.Deletion();
                new DarbasSuStudentais().Show();
                this.Close();
            }


            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox8.Text;
            string surname = textBox9.Text;
            string OldGroup = textBox10.Text;
            string NewGroup = textBox11.Text;
            if (string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(surname) || String.IsNullOrWhiteSpace(surname) || string.IsNullOrEmpty(OldGroup) || String.IsNullOrWhiteSpace(OldGroup)||String.IsNullOrWhiteSpace(NewGroup) || string.IsNullOrEmpty(NewGroup))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                con.Open();
                SqlCommand command = new SqlCommand("Update dbo.Studentas set Grupe='"+NewGroup+"' where Vardas='"+name+"' and Pavarde='"+surname+"'",con);
                command.ExecuteNonQuery();
                new DarbasSuStudentais().Show();
                this.Close();
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;
            string surname = textBox5.Text;
            string group = textBox4.Text;
            string ID = textBox7.Text;
            int count = 0,counta=0;
            if (string.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(surname) || String.IsNullOrWhiteSpace(surname) || string.IsNullOrEmpty(group) || String.IsNullOrWhiteSpace(group) || String.IsNullOrWhiteSpace(ID) || string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else 
            {
                con.Open();
                SqlCommand command = new SqlCommand("Select * from dbo.Grupe",con);
                SqlDataReader Data=command.ExecuteReader();
                while(Data.Read())
                {
                    if(Data["Pavadinimas"].ToString()==group)
                    {
                        count++;
                    }
                }
                Data.Close();
                command = new SqlCommand("Select * from dbo.Studentas", con);
                Data = command.ExecuteReader();
                while (Data.Read())
                {
                    if (Data["Asmens_Kodas"].ToString() == ID)
                    {
                        counta++;
                    }
                }
                Data.Close();
                if (count > 0 && counta == 0)
                {
                    Asmuo NewStud = new NaujasStudentas(name,surname,group,ID);
                    NewStud.New();
                    new DarbasSuStudentais().Show();
                    this.Close();
                }
                else MessageBox.Show("Negalima sukurti");

               
                con.Close();
            }
        }
    }
}
