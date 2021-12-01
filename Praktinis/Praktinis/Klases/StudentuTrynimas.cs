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
    class StudentuTrynimas: TrynimaiAsmuo
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
      private  int ID, count=0;
        private string Name, Surname, Group;
        public StudentuTrynimas(string name, string surname, string group)
        {
            Name = name;
            Surname = surname;
            Group = group;
        }

        public void Deletion()
        {
            con.Open();
            SqlCommand command = new SqlCommand("Select Asmens_Kodas from dbo.Studentas where Vardas='"+Name+"' and  Pavarde='"+Surname+"' and Grupe='"+Group+"'",con);
            SqlDataReader Data = command.ExecuteReader();
            while(Data.Read())
            {
                ID = Convert.ToInt32(Data["Asmens_Kodas"].ToString());
                count++;
            }
            Data.Close();
            if (count == 0)
            {
                MessageBox.Show("Tokio studento nėra");
            }
            else
            {
                command = new SqlCommand("Delete  from dbo.Pazymiai where Studentas_Asmens_Kodas='" + ID + "'", con);
                command.ExecuteNonQuery();
                SqlCommand command2 = new SqlCommand("Delete  from dbo.Prisijungimas where Studentas_Asmens_Kodas='" + ID + "'", con);
                command2.ExecuteNonQuery();
                SqlCommand command3 = new SqlCommand("Delete from dbo.Studentas where Asmens_Kodas='" + ID + "'", con);
                command3.ExecuteNonQuery();
            }
            con.Close();
        }

    }
}
