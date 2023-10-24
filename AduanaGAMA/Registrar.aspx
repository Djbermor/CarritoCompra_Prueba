<%@ Page Title="" Language="C#" MasterPageFile="~/layout/LayoutInicio.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="CarritoCompra.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 col-sm-12 col-md-8 col-lg-4 mx-auto">
            <div class="card">
                <div class="card-header">
                    Registrarse
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="nombre" placeholder="Nombre*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="direccion" placeholder="Direccion*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="telefono" placeholder="Telefono*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="usuario" placeholder="Usuario*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="contrasenna" placeholder="Contraseña*" />
                    </div>
                    <button class="btn btn-primary btn-block" onclick="GuardarDatos()" type="button">
                        Registrar
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
