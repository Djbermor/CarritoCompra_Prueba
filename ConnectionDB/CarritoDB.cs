using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidad;
using System.Net.Security;

namespace ConnectionDB
{
    public class CarritoDB
    {
        public static int RegistrarCarrito(Carrito carrito)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", "AgregarCarrito") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@idusuario", int.Parse(carrito.IdUsuario)) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@idproducto", int.Parse(carrito.IdProducto)) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        reader.Close();
                        sqlCommand.Dispose();
                        connection.Close();
                    }
                }
            }
            resultado.Clear();
            resultado  = ConsultarCarrito(carrito.IdUsuario);
            int cantidad = resultado.AsEnumerable().Sum(row => row.Field<int>("Cantidad"));
            return cantidad;
        }

        //Metodo generico para el cargue de los datos Rol, Departameto y Sexo y el empleado.
        public static DataTable ConsultarCarrito(string idUsuario)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", "ConsultarCarrito") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@idusuario",int.Parse(idUsuario)) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
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
                        
                    }
                }
                connection.Close();
            }
            return resultado;
        }

        public static int  RetirarCarrito(Carrito carrito)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", "RetirarCarrito") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@idusuario", int.Parse(carrito.IdUsuario)) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@idproducto", int.Parse(carrito.IdProducto)) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        reader.Close();
                        sqlCommand.Dispose();
                        connection.Close();
                        resultado.Clear();
                    }
                }
            }
            resultado.Clear();
            resultado = ConsultarCarrito(carrito.IdUsuario);
            int cantidad = resultado.AsEnumerable().Sum(row => row.Field<int>("Cantidad"));
            return cantidad;
        }

        public static int EliminarCarrito(Carrito carrito)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", "EliminarCarrito") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@idusuario", int.Parse(carrito.IdUsuario)) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@idproducto", int.Parse(carrito.IdProducto)) {  SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        reader.Close();
                        sqlCommand.Dispose();
                        connection.Close();
                        resultado.Clear();
                    }
                }
            }
            resultado.Clear();
            resultado = ConsultarCarrito(carrito.IdUsuario);
            int cantidad = resultado.AsEnumerable().Sum(row => row.Field<int>("Cantidad"));
            return cantidad;
        }

        public static int ComprarCarrito(Carrito carrito)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Activar", "RegistrarCompra") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input },
                        new SqlParameter("@idusuario", int.Parse(carrito.IdUsuario)) {  SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                    };

                    sqlCommand.Parameters.AddRange(parametros.ToArray());

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        reader.Close();
                        sqlCommand.Dispose();
                        connection.Close();
                        resultado.Clear();
                    }
                }
            }
            resultado.Clear();
            resultado = ConsultarCarrito(carrito.IdUsuario);
            int cantidad = resultado.AsEnumerable().Sum(row => row.Field<int>("Cantidad"));
            return cantidad;
        }

        public static DataTable ConsultarCompras(string opcion)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection connection = new Connection().GetConnection())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Gestionar", connection) { CommandType = CommandType.StoredProcedure })
                {
                    if (opcion == "Compra")
                    {
                        List<SqlParameter> parametros = new List<SqlParameter>()
                        {
                            new SqlParameter("@Activar", "ConsultarCompra") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input }
                        };
                        sqlCommand.Parameters.AddRange(parametros.ToArray());
                    }
                    else
                    {
                        List<SqlParameter> parametros = new List<SqlParameter>()
                        {
                            new SqlParameter("@Activar", "ConsultarDetalle") {  SqlDbType = SqlDbType.VarChar, Size = 20, Direction = ParameterDirection.Input }
                        };
                        sqlCommand.Parameters.AddRange(parametros.ToArray());
                    }
                    

                    connection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            resultado.Load(reader);
                        }

                        reader.Close();
                        sqlCommand.Dispose();

                    }
                }
                connection.Close();
            }
            return resultado;
        }
    }
}
