using ConnectionDB;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace CarritoCompra
{
    public partial class Producto : System.Web.UI.Page
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
        public static string RegistrarProducto(Entidad.Producto producto)
        {
            try
            {
                ProductoDB.RegistrarProducto(producto);
                return "Producto";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}