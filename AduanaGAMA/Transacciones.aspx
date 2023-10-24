<%@ Page Title="" Language="C#" MasterPageFile="~/layout/LayoutPublic.Master" AutoEventWireup="true" CodeBehind="Transacciones.aspx.cs" Inherits="CarritoCompra.Transacciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 col-sm-12 col-md-12">
            <div class="card">
                <div class="card-header">
                    Transacciones
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView runat="server" ClientIDMode="Static" ID="gridViewCompra" BorderWidth="0" GridLines="None" AutoGenerateColumns="false"
                        CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="nfactura" HeaderText="Numero Factura" />
                                <asp:BoundField DataField="fechaCompra" HeaderText="Fecha de Compra" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" onclick="FiltrarDetalle('<%# Eval("nfactura") %>')"">
                                            Detatalle de la compra
                                        </button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

<!-- Modal -->
<div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Compra Detalle</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <asp:GridView runat="server" ClientIDMode="Static" ID="gridViewDetalle" BorderWidth="0" GridLines="None" AutoGenerateColumns="false"
        CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="IdCompra" HeaderText="Factura" Visible="true"/>
                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
            </Columns>
        </asp:GridView>
<%--          <div class="d-flex justify-content-between information"><span>Cantidad: </span><asp:label runat="server" id="cantidad">U/. 0</asp:label></div>
          <div class="d-flex justify-content-between information"><span>Total: </span><asp:label runat="server" id="total">S/. 0</asp:label></div>--%>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>
</asp:Content>
