using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidad;
using System.Runtime.CompilerServices;

namespace ConnectionDB
{
    public class UsuarioDB
    {
        public static DataTable ValidarCredenciales(Entidad.Usuario usuario)
        {
            DataTable resultado = new DataTable();
            //using lo usamos para que la variable connection solo exista dentro de el (de using)
            using (SqlConnection connection = new Connection().GetConnection())
            {
                //connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", "Login") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@usuario", usuario.Login) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@contrasenna", usuario.Contrasenna) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input }
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

                connection.Close();
                return resultado;
            }
        }

        public static int RegistrarUsuario(string activar, Entidad.Usuario usuario)
        {
            int id = 0;
            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", activar) {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@nombre", usuario.Nombre) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@direccion", usuario.Direccion) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@telefono", usuario.Telefono) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@usuario", usuario.Login) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@contrasenna", usuario.Contrasenna) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@rol", usuario.Rol) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                           id  = 1;
                        }
                        else
                        {
                            id = 0;
                        }
                        reader.Close();
                        sqlCommand.Dispose();
                        connection.Close();
                    }
                }
            }
            return id;
        }
    }
}
