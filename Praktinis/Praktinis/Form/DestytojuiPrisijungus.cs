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
    public partial class DestytojuiPrisijungus : Form
    {
        string username, password;
        TextBox Grade = new TextBox();
        TextBox StudentName, StudentLastname, StudentGrade, StudentGradeKind;
        int i,numb,gradeId;
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        public DestytojuiPrisijungus(string var, string var2)
        {
            InitializeComponent();
            username = var;
            password = var2;
        }

        private void DestytojuiPrisijungus_Load(object sender, EventArgs e)
        {
            con.Open();
            Label Name=new Label();
            Label LastName= new Label();
            SqlCommand command = new SqlCommand("select Vardas, Pavarde from dbo.Destytojas where Vardas='" + username + "'and Pavarde='" + password + "'", con);
            SqlDataReader DataRead = command.ExecuteReader();
            while(DataRead.Read())
            {
                DisplayInfo(DataRead["Vardas"].ToString(), Name, 100,100, flowLayoutPanel1, 149, 100, 215, 15,0) ;
                DisplayInfo(DataRead["Pavarde"].ToString(), LastName, 100, 100, flowLayoutPanel1, 149, 100, 215, 15,0);
            }
            DataRead.Close();

            command = new SqlCommand("Select Pavadinimas from dbo.Grupe where ID in(select Grupe_ID from dbo.Grupes_Paskaitos where Paskaitos_ID in(Select ID from dbo.Paskaitos where Destytojas_Vardas='"+username+"' and Destytojas_Pavarde='"+password+"'))",con);
            DataRead = command.ExecuteReader();
            while(DataRead.Read())
            {
                DisplayInfo(DataRead["Pavadinimas"].ToString(), LastName, 50,50, GroupChoice, 225, 203, 241, 10, 1);
            }


            con.Close();
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DisplayInfo(string item, Label labelName, int height, int width, System.Windows.Forms.FlowLayoutPanel flow, int R, int G, int B, int S, int c)
        {
            labelName = new Label();
            labelName.Height = height;
            labelName.Width = width;
            labelName.BackColor = Color.FromArgb(R, G, B);
            labelName.ForeColor = Color.FromArgb(0, 0, 0);
            labelName.Text = item ;
            labelName.Font = new Font("Microsoft Sans Serif", S, FontStyle.Regular);
            labelName.TextAlign = ContentAlignment.TopLeft;
            flow.Controls.Add(labelName);
            if(c==1)
            {
                labelName.Click += new EventHandler(GroupClicked);
            }
            if(c==2)
            {
                labelName.Click += new EventHandler(NameClicked);

            }
            if(c==3)
            {
                labelName.Click += new EventHandler(GradeChange);
            }
        }

        private void Atsijungti_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void GradeChange(object click, EventArgs e )
        {
             i = Convert.ToInt32(((Label)click).Text.ToString());
            
            Grade.Width = 20;
            Grade.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            flowLayoutPanel5.Controls.Add(Grade);

        }

        private void NewGrade_Click(object sender, EventArgs e)
        {
            con.Open();
            flowLayoutPanel5.Controls.Clear();
            StudentName = new TextBox();
            StudentLastname = new TextBox();
            StudentGrade = new TextBox();
            StudentGradeKind = new TextBox();
            Label nm = new Label();
            Label gr = new Label();
            nm.Text = "Vardas, Pavarde";
            nm.Width = 100;
            StudentName.Width = 60;
            StudentLastname.Width = 60;
            StudentGrade.Width = 20;
            StudentGradeKind.Width = 60;
            flowLayoutPanel5.Controls.Add(nm);
            flowLayoutPanel5.Controls.Add(StudentName);
            flowLayoutPanel5.Controls.Add(StudentLastname);
            gr.Text = "Pazymys, pazymio tipas";
            gr.Width = 150;
            flowLayoutPanel5.Controls.Add(gr);
            flowLayoutPanel5.Controls.Add(StudentGrade);
            flowLayoutPanel5.Controls.Add(StudentGradeKind);
            Button OK = new Button();
            OK.Text = "Gerai";
            flowLayoutPanel5.Controls.Add(OK);
            OK.Click +=  new EventHandler(OKButton);
            con.Close();
        }

        private void OKButton(object click, EventArgs e)
        {
            if (string.IsNullOrEmpty(StudentName.Text) || String.IsNullOrWhiteSpace(StudentName.Text) || string.IsNullOrEmpty(StudentLastname.Text) || String.IsNullOrWhiteSpace(StudentLastname.Text))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else if (string.IsNullOrEmpty(StudentGrade.Text) || String.IsNullOrWhiteSpace(StudentGrade.Text) || string.IsNullOrEmpty(StudentGradeKind.Text) || String.IsNullOrWhiteSpace(StudentGradeKind.Text))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                NaujasPazymys NewGrades = new NaujasPazymys(StudentName.Text, StudentLastname.Text, StudentGrade.Text, StudentGradeKind.Text, username, password);
                NewGrades.GradeEnter();
                new DestytojuiPrisijungus(username, password).Show();
                this.Hide();
            }
            con.Close();
        }

        private void NameClicked(object click, EventArgs e)
        {
            con.Open();
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            Label Grade = new Label();
            Label type = new Label();
           SqlCommand command = new SqlCommand("select Pazimys, Pazymio_Tipas, Studentas_Asmens_Kodas,Id from dbo.Pazymiai where Studentas_Asmens_Kodas in(select Asmens_Kodas from dbo.Studentas where Vardas='"+((Label)click).Text.ToString()+"' or Pavarde='"+ ((Label)click).Text.ToString() + "')", con);
           SqlDataReader DataRead = command.ExecuteReader();
            while (DataRead.Read())
            {
                DisplayInfo(DataRead["Pazymio_Tipas"].ToString(), type, 100, 100, flowLayoutPanel2, 225, 203, 241, 10, 0);
                DisplayInfo(DataRead["Pazimys"].ToString(), Grade, 100, 100, flowLayoutPanel5, 225, 203, 241, 10, 3);
                numb =Convert.ToInt32( DataRead["Studentas_Asmens_Kodas"].ToString());
                gradeId= Convert.ToInt32(DataRead["Id"].ToString());
            }
            con.Close();
        }

        private void ChangeGrade_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Grade.Text) || String.IsNullOrWhiteSpace(Grade.Text))
            {
                MessageBox.Show("Negali būti tuščia");
            }
            else
            {
                int Newgrade = Convert.ToInt32(Grade.Text);
                RasomiPazymiai change = new RasomiPazymiai();
                change.Grade(i, Newgrade, numb, gradeId);
                new DestytojuiPrisijungus(username, password).Show();
                this.Close();
            }
        }

        private void GroupClicked(object click, EventArgs e)
        {
            con.Open();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel4.Controls.Clear();
            flowLayoutPanel5.Controls.Clear();
            Label NameStudent = new Label();
            Label LNameStudent = new Label();
            SqlCommand command = new SqlCommand("Select Vardas, Pavarde from dbo.Studentas where Grupe='"+((Label)click).Text.ToString()+"'",con);
            SqlDataReader DataRead = command.ExecuteReader();
            while(DataRead.Read())
            {
                
                DisplayInfo(DataRead["Vardas"].ToString(), NameStudent, 20, 90, flowLayoutPanel3, 225, 203, 241, 10, 2);
                DisplayInfo(DataRead["Pavarde"].ToString(), LNameStudent, 20, 90, flowLayoutPanel4, 225, 203, 241, 10, 2);
            }
            DataRead.Close();

            con.Close();
        }
    }
}
