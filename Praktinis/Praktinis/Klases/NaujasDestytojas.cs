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
    class NaujasDestytojas : Asmuo
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");
        private string Name;
        private string Surname;
        private string Id;

        public NaujasDestytojas(string name, string surname, string ID)
        {
            Name = name;
            Surname = surname;
            Id = ID;
        }
                 
        public void New()
        {
            con.Open();
           SqlCommand command = new SqlCommand("Insert into dbo.Destytojas (Asmens_Kodas,Vardas,Pavarde)values('" + Id + "','" + Name + "','" + Surname + "')", con);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
