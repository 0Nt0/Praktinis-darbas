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
    public partial class Pazymiai : Form
    {
        string username, password;
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        public Pazymiai(string var,string var2)
        {
            InitializeComponent();
            username = var;
            password = var2;
        }

        private void Pazymiai_Load(object sender, EventArgs e)
        {
            con.Open();
            Label Name= new Label();
            string group="";
            Label Lastname = new Label();
            SqlCommand command = new SqlCommand("Select Vardas, Pavarde, Grupe from dbo.Studentas where Vardas='"+username+"' and Pavarde='"+password+"'", con);
            SqlDataReader DataRead = command.ExecuteReader();
            while(DataRead.Read())
            {
                 group = DataRead["Grupe"].ToString();
                DisplayInfo(DataRead["Vardas"].ToString(),Name,null,150,90, PersonInfo, 149, 100, 215,12,0);
                DisplayInfo(DataRead["Pavarde"].ToString(), Lastname,DataRead["Grupe"].ToString(),150,150, PersonInfo, 149, 100, 215,12,0);
            }

            DataRead.Close();
            command = new SqlCommand("Select Destytojas_Vardas, Destytojas_Pavarde from dbo.Paskaitos where ID in(select Paskaitos_ID from dbo.Grupes_Paskaitos where Grupe_ID in(Select ID from dbo.Grupe where Pavadinimas= '"+group+"'))", con);
            SqlDataReader Data = command.ExecuteReader();
            while(Data.Read())
            {
                DisplayInfo(Data["Destytojas_Vardas"].ToString(), Name, Data["Destytojas_Pavarde"].ToString(), 90, 100, ProfesorName,225,203, 241,9,0);
            }

            Data.Close();
            command = new SqlCommand("Select Pavadinimas from dbo.Paskaitos where ID in(select Paskaitos_ID from dbo.Grupes_Paskaitos where Grupe_ID in(Select ID from dbo.Grupe where Pavadinimas= '" + group + "'))", con);
            Data = command.ExecuteReader();
            while (Data.Read())
            {
                DisplayInfo(Data["Pavadinimas"].ToString(), Name, null, 90, 100, Class, 225, 203, 241, 9,1);
            }

            Data.Close();
       
            

            con.Close();
        }

        private void DisplayInfo(string item,Label labelName,string item2,int height, int width, System.Windows.Forms.FlowLayoutPanel flow,int R,int G,int B,int S, int nr)
        {
            labelName = new Label();
            labelName.Height = height;
            labelName.Width = width;
            labelName.BackColor = Color.FromArgb(R,G,B);
            labelName.ForeColor = Color.FromArgb(0, 0, 0);
            labelName.Text = item+"  "+item2;
            labelName.Font = new Font("Microsoft Sans Serif", S, FontStyle.Regular);
            labelName.TextAlign = ContentAlignment.TopLeft;
            flow.Controls.Add(labelName); 
            if(nr==1)
            {
                labelName.Click += new EventHandler(ShowGrade);
            }
        }

        public void ShowGrade(object click, EventArgs e)
        {
            KindOfGrade.Controls.Clear();
            PersonGrade.Controls.Clear();
            Label Grade= new Label();
            con.Open();
            SqlCommand command = new SqlCommand("Select Pazimys, Pazymio_Tipas from dbo.Pazymiai where Grupes_Paskaitos_ID in (Select ID from dbo.Grupes_Paskaitos where Pavadinimas='" + ((Label)click).Text.ToString() + "') and Studentas_Asmens_Kodas in( Select Asmens_Kodas from dbo.Studentas where Vardas='"+username+"') ", con);
           SqlDataReader Data = command.ExecuteReader();
            while (Data.Read())
            {
                   DisplayInfo(Data["Pazimys"].ToString(), Grade, null, 90, 50, PersonGrade, 225, 203, 241, 9,0);
                  DisplayInfo("|", Grade, null, 90, 10, PersonGrade, 225, 203, 241, 7,0);
                  DisplayInfo(Data["Pazymio_Tipas"].ToString(), Grade, null, 90,50,KindOfGrade,225, 203, 241, 9,0);
            }
            Data.Close();
            con.Close();
        }

        private void Atsijungti_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
