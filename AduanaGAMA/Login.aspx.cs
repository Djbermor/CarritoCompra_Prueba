using ConnectionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoCompra
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static string IniciarSesion(Entidad.Usuario usuario)
        {
            //NameValueCollection Query = HttpContext.Current.Request.QueryString;

            try
            {
                DataTable user = UsuarioDB.ValidarCredenciales(usuario);

                if (user.Rows.Count > 0)
                {
                    var fila = user.Rows[0];
                    //usuario.Id = fila["IdUsuario"].ToString();
                    //usuario.Nombre = fila["Nombres"].ToString();
                    //usuario.Rol = fila["Rol"].ToString();
                    if ((bool)fila["Rol"])
                    {
                        return "Admin";
                    }
                    else
                    {
                        return "Tienda " + fila["IdUsuario"].ToString() + " "  + fila["Cantidad"].ToString();
                    }
                }
                else { 
                    return "LoginError";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}