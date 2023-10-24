<%@ Page Title="" Language="C#" MasterPageFile="~/layout/LayoutPublic.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CarritoCompra.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 col-sm-12 col-md-8 col-lg-4 mx-auto">
            <div class="card">
                <div class="card-header">
                    Menu
                </div>
                <div class="card-body">
                    <button class="btn btn-primary btn-block" onclick="mensajes('Transacciones')" type="button">
                        Transaciones
                    </button>
                </div>
                <div class="card-body">
                    <button class="btn btn-primary btn-block" onclick="mensajes('Producto')" type="button">
                        Gestionar Producto
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
