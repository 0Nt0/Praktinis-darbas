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
    
    class RasomiPazymiai
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-6vfl2djj;Initial Catalog=Praktinis_Darbas;Integrated Security=True;Pooling=False");

        public void Grade(int Old, int New, int PersonNumbers, int gradeId)
        {
            if (New != Old)
            {
                con.Open();
                SqlCommand command = new SqlCommand("update dbo.Pazymiai set Pazimys='"+New+"' where Id='"+gradeId+"' and Studentas_Asmens_Kodas='"+PersonNumbers+"'", con);
                command.ExecuteNonQuery();

            }
            con.Close();
        }


    }
}
