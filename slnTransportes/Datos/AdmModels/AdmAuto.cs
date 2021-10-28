using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos.ADMSERVER;

namespace Datos.AdmModels
{
    public static class AdmAuto
    {

        //MOSTRAR JUGADORES
        // GUARDAR JUGADORES
        // FILTRO DE JUGADORES, TRAE JUGADORES POR PUESTO
        public static List<Auto> Listar()
        {
            string consultaSQL = "SELECT Id , Marca , Modelo , Matricula , Precio FROM dbo.Auto";

            SqlCommand  command = new SqlCommand (consultaSQL, AdminBD.ConectarBase());

            SqlDataReader reader;

            reader = command.ExecuteReader();

            List<Auto> listaAutos = new List<Auto>();

            while (reader.Read())
            {
                listaAutos.Add(new Auto()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Marca = reader["Marca"].ToString(),
                    Modelo = reader["Modelo"].ToString(),
                    Matricula = reader["Matricula"].ToString(),
                    Precio = Convert.ToDecimal(reader["Precio"])
                }
                ); 
            }

            AdminBD.ConectarBase().Close();

            reader.Close();

            return listaAutos;
            //ToDo Devuelve una lista de Autos, Modelo Conectado
        }
        public static DataTable ListarMarca()
        {
            string consultaSQL = "SELECT DISTINCT Marca FROM dbo.Auto";

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminBD.ConectarBase());

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Marca");
            return ds.Tables["Marca"];

        }
        public static DataTable Listar(string marca)
        {
            string consultaSQL = "SELECT Id , Marca , Modelo , Matricula , Precio FROM dbo.Auto WHERE Marca = @Marca";

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdminBD.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = marca;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Marca");
            return ds.Tables["Marca"];

            // ToDo Devuelve una lista de Autos, modelo desconectado
        }
        public static int Insertar(Auto auto)
        {
            string consultaSQL = "INSERT into Auto( Marca, Modelo, Matricula, Precio) VALUES (@Marca,@Modelo,@Matricula,@Precio)";

            SqlCommand command = new SqlCommand(consultaSQL, AdminBD.ConectarBase());

            command.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            command.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            command.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value = auto.Matricula;
            command.Parameters.Add("@Precio", SqlDbType.Decimal, 18).Value = auto.Precio;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminBD.ConectarBase().Close();

            return filasAfectadas;
            // ToDo devuelve filas afectadas
        }
        public static int Modificar(Auto auto)
        {
            string consultaSQL = "UPDATE Auto set Marca = @Marca, Modelo = @Modelo, Matricula = @Matricula, Precio = @Precio WHERE Id = @Id";

            SqlCommand command = new SqlCommand(consultaSQL, AdminBD.ConectarBase());

            command.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            command.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            command.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value = auto.Matricula;
            command.Parameters.Add("@Precio", SqlDbType.Decimal, 18).Value = auto.Precio;
            command.Parameters.Add("@ID", SqlDbType.Int).Value = auto.ID;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminBD.ConectarBase().Close();

            return filasAfectadas;

            // ToDo devuelve filas afectadas
        }
        public static int Eliminar(int id)
        {
            string consultaSQL = "DELETE FROM Auto WHERE Id = @Id";

            SqlCommand command = new SqlCommand(consultaSQL, AdminBD.ConectarBase());

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminBD.ConectarBase().Close();

            return filasAfectadas;
            // ToDo devuelve filas afectadas
        }
    }
}
