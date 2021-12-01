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

   
    class DestytojuTrynimas:TrynimaiAsmuo
    { 
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        private int count = 0;
        private int ID;
        private string Name, Surname;

        public DestytojuTrynimas(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public void Deletion()
        {
            con.Open();
            SqlCommand command = new SqlCommand("select * from dbo.Destytojas where Vardas='"+Name+"' and Pavarde='"+Surname+"'",con);
            SqlDataReader DataRead = command.ExecuteReader();
            while(DataRead.Read())
            {
                count++;
            }
            DataRead.Close();
            if(count==0)
            {
                MessageBox.Show("Tokio destytojo nera");
            }
            else
            {
                command = new SqlCommand("Delete  from dbo.Destytojas where Vardas='"+Name+"' and Pavarde='"+Surname+"'", con);
                command.ExecuteNonQuery();
                SqlCommand command2 = new SqlCommand("update dbo.Paskaitos set Destytojas_Vardas='"+"-"+"', Destytojas_Pavarde='"+"-"+"' where Destytojas_Vardas='"+Name+"' and Destytojas_Pavarde= '"+Surname+"'" , con);
                SqlDataReader Data = command2.ExecuteReader();
                while(Data.Read())
                {
                    ID = Convert.ToInt32( Data["ID"].ToString());
                }
                Data.Close();

               
            }

            con.Close();
        }

    }
}
