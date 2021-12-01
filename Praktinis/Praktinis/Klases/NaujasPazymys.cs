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
    class NaujasPazymys
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        int PersonId;
        string GroupName,GroupClassName;
        string GroupId,GroupClassId;
        int Gr,max=0,s=0;
        string GrKind;

        public NaujasPazymys(string name, string LastName, string grade,  string  GradeKind,string username, string password)
        {
            con.Open();
            int count = 0;
            SqlCommand command = new SqlCommand("select Asmens_Kodas, Grupe from dbo.Studentas where Vardas='"+name+"' and Pavarde='"+LastName+"'",con);
            SqlDataReader Data = command.ExecuteReader();
            while(Data.Read())
            {
            PersonId = Convert.ToInt32(Data["Asmens_Kodas"].ToString());
            GroupName = Data["Grupe"].ToString();
                count++;
            }
            Data.Close();
            if (count != 0)
            {
                Gr = Convert.ToInt32(grade);
                GrKind = GradeKind;
                command = new SqlCommand("select ID from dbo.Grupe where Pavadinimas= '" + GroupName + "'", con);
                Data = command.ExecuteReader();
                while (Data.Read())
                {
                    GroupId = Data["ID"].ToString();
                }
                Data.Close();

                command = new SqlCommand("select ID, Pavadinimas from dbo.Grupes_Paskaitos where Paskaitos_ID in(select ID from dbo.Paskaitos where Destytojas_Vardas='" + username + "' and Destytojas_Pavarde='" + password + "') and Grupe_ID='" + GroupId + "'", con);
                Data = command.ExecuteReader();
                while (Data.Read())
                {
                    GroupClassName = Data["Pavadinimas"].ToString();
                    GroupClassId = Data["ID"].ToString();
                }
                Data.Close();

                command = new SqlCommand("select Id from dbo.Pazymiai", con);
                Data = command.ExecuteReader();
                while (Data.Read())
                {
                    if (Convert.ToInt32(Data["Id"].ToString()) > max)
                    {
                        max = Convert.ToInt32(Data["Id"].ToString()) + 1;
                    }
                }

            }
            else
            { MessageBox.Show("Tokio studento nera"); 
               s++; }

            con.Close();
        }

        public void GradeEnter()
        {
            if (s == 0)
            {
                con.Open();
                max = max + 1;
                SqlCommand command = new SqlCommand("insert into dbo.Pazymiai (Id, Pazimys, Studentas_Asmens_Kodas, Grupes_Paskaitos_ID, Pazymio_Tipas)values('" + max + "','" + Gr + "','" + PersonId + "','" + Convert.ToInt32(GroupClassId) + "','" + GrKind + "')", con);
                command.ExecuteNonQuery();
            }

            con.Close();
        }




    }



}
