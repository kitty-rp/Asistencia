<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="Asistencia.Presentacion.Cronograma.Listado"
MasterPageFile="~/Adm.Master" StylesheetTheme="Default"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Listado de cronogramas"></asp:Label>

    <form id="form1" runat="server">
    <asp:HyperLink ID="hlNuevo" runat="server" 
        NavigateUrl="Formulario.aspx" Font-Overline="False">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/imgs/action_add.png" />Nuevo
      </asp:HyperLink>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" EnableModelValidation="True" GridLines="Horizontal" 
        onrowcommand="gvListado_RowCommand">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="hlMod" runat="server" 
                        NavigateUrl='<%# Eval("Id", "Formulario.aspx?id={0}") %>'>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/imgs/reply.png" />
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>'>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imgs/action_delete.png" />
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="Código">
            <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="descripcion" HeaderText="Descripción">
            <ItemStyle Width="200px" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="fechaIni" DataFormatString="{0:dd/MM/yyyy}" 
                HeaderText="FechaInicio">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="fechaFin" DataFormatString="{0:dd/MM/yyyy}" 
                HeaderText="Fecha Fin">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="Label1" runat="server" Text="No hay datos"></asp:Label>
        </EmptyDataTemplate>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:GridView>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</asp:Content>
