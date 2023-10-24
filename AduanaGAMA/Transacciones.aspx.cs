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
    public partial class Transacciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            gridViewCompra.DataSource = ConnectionDB.CarritoDB.ConsultarCompras("Compra");
            gridViewCompra.DataBind();
            gridViewDetalle.DataSource = ConnectionDB.CarritoDB.ConsultarCompras("Detalle"); ;
            gridViewDetalle.DataBind();
        }
    }
}