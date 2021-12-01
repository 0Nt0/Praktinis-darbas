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
    class NaujaGrupe : Asmuo
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        private string Name,ID;
        public NaujaGrupe(string name, string id)
        {
            Name = name;
            ID = id;
        }
        public void New()
        {
            con.Open();
            SqlCommand command = new SqlCommand("Insert into dbo.Grupe (ID,Pavadinimas)values('"+Convert.ToInt32(ID)+"','"+ Name + "')",con);
            command.ExecuteNonQuery();

            con.Close();
        }
    }
}
