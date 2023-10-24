<%@ Page Title="" Language="C#" MasterPageFile="~/layout/LayoutCarrito.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoCompra.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 col-sm-12 col-md-12">
            <div class="card">
                <div class="card-header">
                    Productos
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView runat="server" ClientIDMode="Static" ID="gridViewProducto" BorderWidth="0" GridLines="None" AutoGenerateColumns="false"
                        CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                <asp:BoundField DataField="Stock" HeaderText="Cantidad" />
                                <asp:TemplateField HeaderText="Añadir al carrito">
                                    <ItemTemplate>
                                        <a class="fa-2x">
                                            <i class="fa fa-cart-arrow-down" onclick ="GestionarCarrito('<%# Eval("IdProducto") %>',null,'<%# Eval("Stock") %>')"></i>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
<%--                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <i class="fa fa-trash fa-2x" onclick="eliminarEmpleado('<%# Eval("Id") %>')"></i>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
