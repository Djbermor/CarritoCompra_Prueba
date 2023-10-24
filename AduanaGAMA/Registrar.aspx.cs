using ConnectionDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoCompra
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LoadControlDropDown(DropDownList dropDownList, DataTable datos, string value, string text)
        {
            dropDownList.DataSource = datos;
            dropDownList.DataValueField = value;
            dropDownList.DataTextField = text;
            dropDownList.DataBind();
        }

        [WebMethod]
        public static string RegistrarUser(Entidad.Usuario usuario)
        {

            try
            {
                int id = UsuarioDB.RegistrarUsuario("Insertar", usuario);
                if (id==1)
                {
                    return "Login";
                }
                else
                {
                    return "Registro";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}