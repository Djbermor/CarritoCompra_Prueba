using ConnectionDB;
using Entidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoCompra
{
    public partial class Carrito : System.Web.UI.Page
    {
        private static int cantidadProdut = 0;
        private static string total = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string idUsuario = HttpUtility.ParseQueryString(new Uri(url).Query).Get("id");
            total = CargarTablaCarrito(idUsuario, gridViewCarrito);
            totalPagar.Text = total;
        }

        [WebMethod]

        public static string GestionarCarrito(Entidad.Carrito carrito)
        {
            try
            {
                if (carrito.Id == "Restar")
                {
                    cantidadProdut = CarritoDB.RetirarCarrito(carrito);
                    return "Carrito " + cantidadProdut;
                }
                else if (carrito.Id == "Sumar")
                {
                    cantidadProdut = cantidadProdut = CarritoDB.RegistrarCarrito(carrito);
                    return "Carrito " + cantidadProdut;
                }
                else if (carrito.Id == "Eliminar")
                {
                    cantidadProdut = cantidadProdut = CarritoDB.EliminarCarrito(carrito);
                    return "Carrito " + cantidadProdut;
                }
                else
                {
                    cantidadProdut = CarritoDB.RegistrarCarrito(carrito);
                    return "Tienda " + cantidadProdut;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CargarTablaCarrito(string carrito, GridView gridView)
        {
            DataTable datasurce = new DataTable();
            datasurce = CarritoDB.ConsultarCarrito(carrito);
            gridView.DataSource = datasurce;
            gridView.DataBind();
            decimal total = datasurce.AsEnumerable().Sum(row => row.Field<decimal>("Total"));
            return total.ToString();
        }

        [WebMethod]
        public static string Comprar(Entidad.Carrito carrito)
        {
            DataTable datasurce = new DataTable();
            cantidadProdut =  CarritoDB.ComprarCarrito(carrito);
            return "Compra " + cantidadProdut;
        }
    }
}