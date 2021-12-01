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
    class NaujasStudentas: Asmuo
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");

        private string Name, Surname, Group, Id;
        private int max = 0;
        public NaujasStudentas(string name, string surname, string group, string ID)
        {
            Name = name;
            Surname = surname;
            Group = group;
            Id = ID;
        }

        public void New()
        {
           
            con.Open();
            SqlCommand command = new SqlCommand("select ID from Dbo.Prisijungimas",con);
            SqlDataReader Data = command.ExecuteReader();
            while(Data.Read())
            {
                if(max< Convert.ToInt32(Data["ID"].ToString()))
                {
                    max = Convert.ToInt32(Data["ID"].ToString())+1;
                }
            }
            Data.Close();
            max = max + 1;
            command = new SqlCommand("Insert into dbo.Studentas (Asmens_Kodas,Vardas,Pavarde,Grupe)values('"+Id+"','"+Name+"','"+Surname+"','"+Group+"')",con);
            command.ExecuteNonQuery();
            SqlCommand command2 = new SqlCommand("Insert into dbo.Prisijungimas (ID,Slapyvardis,Slaptazodis,Studentas_Asmens_Kodas)values('" + max + "','" + Name + "','" + Surname + "','"+Id+"')", con);
            command2.ExecuteNonQuery();

            con.Close();
        }
    }
}
