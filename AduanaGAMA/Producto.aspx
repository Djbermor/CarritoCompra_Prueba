<%@ Page Title="" Language="C#" MasterPageFile="~/layout/LayoutPublic.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="CarritoCompra.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 col-sm-12 col-md-8 col-lg-4 mx-auto">
            <div class="card">
                <div class="card-header">
                    Registrar Producto
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="nombre" placeholder="Nombre*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="descripcion" placeholder="Descripcion*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="precio" placeholder="Precio*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="stock" placeholder="Cantidad*" />
                    </div>
                    <button class="btn btn-primary btn-block" onclick="GuardarProducto()" type="button">
                        GUARDAR
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
