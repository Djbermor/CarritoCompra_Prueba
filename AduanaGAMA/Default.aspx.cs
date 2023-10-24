using ConnectionDB;
using Entidad;
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
    public partial class Default : System.Web.UI.Page
    {
        private static int cantidadProdut = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTablaProducto(gridViewProducto);
        }


        [WebMethod]

        public static string GestionarCarrito(Entidad.Carrito carrito)
        {
            try
            {
                cantidadProdut = CarritoDB.RegistrarCarrito(carrito);
                return "Tienda " + cantidadProdut;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void CargarTablaProducto(GridView gridView)
        {
            gridView.DataSource = ProductoDB.ConsultarProducto();
            gridView.DataBind();
        }
    }
}