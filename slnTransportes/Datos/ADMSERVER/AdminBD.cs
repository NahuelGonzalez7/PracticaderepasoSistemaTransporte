using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ADMSERVER
{
    internal static class AdminBD
    {
        internal static SqlConnection ConectarBase()
        {
            string cadena = Datos.Properties.Settings.Default.KeyDBTransporte;
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();

            return conexion;
        }
    }
}
