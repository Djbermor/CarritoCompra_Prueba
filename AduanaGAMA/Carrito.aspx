<%@ Page Title="" Language="C#" MasterPageFile="~/layout/LayoutCarrito.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoCompra.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row p-2">
    <div class="card col-12 col-md-12">
        <div class="card-body">
            <div class="row">
                <div class="col-md-8">
                    <div class="product-details mr-2">
                        <div class="d-flex justify-content-between">
                            <span class="ml-2">Detalle Compra</span>
                            <a class="btn btn-danger" onclick="Direccionamiento('Tienda')">Volver</a>
                        </div>
                        <hr class="mt-2 mb-2">
                        <div class="justify-content-start mb-2">
                            Tienes <span id="cantidad_articulos" class="ml-1">0</span> artículo(s) en tu carrito
                        </div>
                            <div class="table-responsive">
                                <asp:GridView runat="server" ClientIDMode="Static" ID="gridViewCarrito" BorderWidth="0" GridLines="None" AutoGenerateColumns="false"
                                CssClass="table table-striped">
                                    <Columns>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Precio" HeaderText="precio" />
                                        <asp:TemplateField HeaderText="-">
                                            <ItemTemplate>
                                                <a class="fa-2x">
                                                    <i class="fas fa-minus" onclick ="GestionarCarrito('<%# Eval("IdProducto") %>','Restar')"></i>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"  />
                                        <asp:TemplateField HeaderText="+">
                                            <ItemTemplate>
                                                <a class="fa-2x">
                                                    <i class="fas fa-plus" onclick ="GestionarCarrito('<%# Eval("IdProducto") %>','Sumar','<%# Eval("Stock") %>')"></i>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <a class="fa-2x">
                                                    <i class="fa fa-trash" onclick="GestionarCarrito('<%# Eval("IdProducto") %>','Eliminar')"></i>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                </div>
                <div class="col-md-4">
                    <div class="card bg-light">
                        <div class="card-body">
                            <div class="row">

                                <div class="col-12">
                                    <div class="payment-info">
                                        <hr class="line">
                                        <div class="d-flex justify-content-between information"><span>Total a Pagar</span><asp:label runat="server" id="totalPagar">S/. 0</asp:label></div>
                                        <button class="btn btn-primary btn-block mt-3" id="btnProcesarPago" type="button" onclick ="Comprar()">Procesar Pago</button>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>

</div>
</asp:Content>
