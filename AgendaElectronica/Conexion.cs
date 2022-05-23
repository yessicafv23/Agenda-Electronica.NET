using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
   
namespace AgendaElectronica
{
    class Conexion
    {
        public static SqlConnection conexion()
        {
            string Servidor = "DESKTOP-7O1M971";
            string bd = "agenda";

            string cadenaConexion = "Server="+Servidor+";Database="+bd+";Integrated Security=SSPI";

            try
            {
                SqlConnection conexionBD = new SqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en el accesso a bd comunicarse con el departamente de sistema"+ex);
                return null;
            }
        }
    }
}
