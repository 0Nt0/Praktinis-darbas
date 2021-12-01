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
    class KlasesPridejimasPrieDestomoDalyko
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        string Subject, ClassNm, IdClass;
        int maxID = 0, maxIDGr=0;
        public  KlasesPridejimasPrieDestomoDalyko(string name, string ClassName, string Id)
        {
            Subject = name;
            ClassNm = ClassName;
            IdClass = Id;
        }

        public void AssigningToClass()
        {
            con.Open();
            SqlCommand command2 = new SqlCommand("Select * from dbo.Paskaitos", con);
           SqlDataReader Read = command2.ExecuteReader();
            while (Read.Read())
            {
                if (Convert.ToInt32(Read["ID"].ToString()) > maxID)
                {
                    maxID = Convert.ToInt32(Read["ID"].ToString()) + 1;
                }
            }
            Read.Close();

            maxID = maxID + 1;
            SqlCommand command = new SqlCommand("Insert into dbo.Paskaitos (ID, Pavadinimas, Kabinetas, Destytojas_Vardas, Destytojas_Pavarde)values('"+maxID+"','"+Subject+"','"+"-"+"','"+"-"+"','"+"-"+"')", con);
            command.ExecuteNonQuery();

            command2 = new SqlCommand("Select * from dbo.Grupes_Paskaitos", con);
            Read = command2.ExecuteReader();
            while (Read.Read())
            {
                if (Convert.ToInt32(Read["ID"].ToString()) > maxIDGr)
                {
                    maxIDGr = Convert.ToInt32(Read["ID"].ToString()) + 1;
                }
            }
            Read.Close();
            maxIDGr = maxIDGr + 1;

            SqlCommand command3 = new SqlCommand("Insert into dbo.Grupes_Paskaitos(ID, Pavadinimas, Paskaitos_ID,Grupe_ID)values('"+maxIDGr+"','"+Subject+"','"+maxID+"','"+Convert.ToInt32(IdClass)+"')",con);
            command3.ExecuteNonQuery();


            con.Close();
        }

    }
}
