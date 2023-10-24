using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidad;

namespace ConnectionDB
{
    public class ProductoDB
    {
        public static void RegistrarProducto(Entidad.Producto producto)
        {
            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", "InsertProducto") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@nombre", producto.Nombre) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@descripcion", producto.Descripcion) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@precio", producto.Precio) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@stock", producto.Stock) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();
                    sqlCommand.ExecuteReader();
                    sqlCommand.Dispose();
                    connection.Close();  
                }
            }
        }

        //Metodo generico para el cargue de los datos Rol, Departameto y Sexo y el empleado.
        public static DataTable ConsultarProducto()
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", "ConsultarProducto") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input }
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            resultado.Load(reader);
                        }

                        reader.Close();
                        sqlCommand.Dispose();
                        connection.Close();
                    }
                }
            }

            return resultado;
        }
    }
}
