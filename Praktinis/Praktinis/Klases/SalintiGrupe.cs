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
    class SalintiGrupe: TrynimaiAsmuo 
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
       private string GroupName;
      private  int IDGroup,IDClass;
        private string Name;
        public SalintiGrupe(string name)
        {
            Name = name;
        }

        public void Deletion()
        {
            GroupName = Name;
            con.Open();
            SqlCommand command = new SqlCommand("Select ID from dbo.Grupe where Pavadinimas='"+GroupName+"'",con);
            SqlDataReader Data = command.ExecuteReader();
            while(Data.Read())
            {
                IDGroup =Convert.ToInt32(Data["ID"].ToString());
            }
            Data.Close();

            command = new SqlCommand("Delete  from dbo.Grupe where Pavadinimas='"+GroupName+"' and ID='"+IDGroup+"'", con);
            command.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("Select ID from dbo.Grupes_Paskaitos where Grupe_ID='"+IDGroup+"'", con);
            Data = command2.ExecuteReader();
            while (Data.Read())
            {
                IDClass = Convert.ToInt32(Data["ID"].ToString());
            }
            Data.Close();

            command2 = new SqlCommand("Delete  from dbo.Grupes_Paskaitos where Grupe_ID='"+IDGroup+"'", con);
            command2.ExecuteNonQuery();

            SqlCommand command3 = new SqlCommand("Delete from dbo.Pazymiai where Grupes_Paskaitos_ID='"+IDClass+"'",con);
            command3.ExecuteNonQuery();

            SqlCommand command4 = new SqlCommand("Delete from dbo.Studentas where Grupe='"+GroupName+"'",con);
            command4.ExecuteNonQuery();

            con.Close();
        }
    }
}
