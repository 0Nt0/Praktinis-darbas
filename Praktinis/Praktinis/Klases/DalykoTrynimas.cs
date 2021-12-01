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
    class DalykoTrynimas:TrynimaiAsmuo
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        private int ID,count=0,IDGroup;
        private string Name;
        public DalykoTrynimas(string name, string n, string m)
        {
            Name = name;
        }

      public void  Deletion()
        {
            con.Open();
           
            SqlCommand command = new SqlCommand("Select ID from dbo.Paskaitos where Pavadinimas='"+Name+"'",con);
            SqlDataReader Data = command.ExecuteReader();
            while(Data.Read())
            {
                count++;
            }
            Data.Close();

           while(count>0)
            {
                command = new SqlCommand("Select ID from dbo.Paskaitos where Pavadinimas='" + Name + "'", con);
                Data = command.ExecuteReader();
                while (Data.Read())
                {
                    ID = Convert.ToInt32(Data["ID"].ToString());

                }
                Data.Close();

                SqlCommand command2 = new SqlCommand("Select ID from dbo.Grupes_Paskaitos where Paskaitos_ID='"+ID+"'",con);
                Data = command2.ExecuteReader();
                while(Data.Read())
                {
                    IDGroup = Convert.ToInt32(Data["ID"].ToString());
                }
                Data.Close();

                SqlCommand command3 = new SqlCommand("Delete from dbo.Pazymiai where Grupes_Paskaitos_ID='"+IDGroup+"'",con);
                command3.ExecuteNonQuery();
                command3 = new SqlCommand("Delete from dbo.Grupes_Paskaitos where Paskaitos_ID='"+ID+"'",con);
                command3.ExecuteNonQuery();
                SqlCommand command4 = new SqlCommand("Delete from dbo.Paskaitos where Pavadinimas='"+Name+"'", con);
                command4.ExecuteNonQuery();
               /* command4 = new SqlCommand("Delete from dbo.Galimos_Paskaitos where Pavadinimas='"+name+"'", con);
                command4.ExecuteNonQuery();*/
                count--;

            }
          SqlCommand  command5 = new SqlCommand("Delete from dbo.Galimos_Paskaitos where Pavadinimas='" + Name + "'", con);
          command5.ExecuteNonQuery();


            con.Close();
        }
    }
}
