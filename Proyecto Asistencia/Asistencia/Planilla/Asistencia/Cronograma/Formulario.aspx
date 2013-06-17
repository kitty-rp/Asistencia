<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Asistencia.Presentacion.Cronograma.Formulario"
MasterPageFile="~/Adm.Master" StylesheetTheme="Default"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label6" runat="server" Text="Registrar Cronogramas"></asp:Label>


    <form id="form1" runat="server">
        <center>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <table style="width: 400px; border: 1px">
                <tr>
                    <td align="right" style="width: 26px">
                        <asp:Label ID="lblCodigo" runat="server" Text="Codigo:"></asp:Label>
                    </td>
                    <td align="left" style="width: 26px">
                        <asp:TextBox ID="txtCodigo" runat="server" Width="100px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  align="right">
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td  align="left">
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtDescripcion" ErrorMessage="Requerido"></asp:RequiredFieldValidator>
                    </td>
                </tr>


                 <tr>
                    <td  align="right">
                        
                            <asp:Label ID="lblFIni" runat="server" Text="Fecha Inicio :" Font-Size="9pt"></asp:Label>
                        
                    </td>
                    <td  align="left">
                       
                                 <asp:TextBox ID="txtFechaIni" runat="server" Width="80px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtender1" runat="server"  
                                Format="dd/MM/yyyy"  TargetControlID="txtFechaIni" PopupButtonID="ibFI">
                                 </asp:CalendarExtender>
                                 <asp:ImageButton ID="ibFI" runat="server" CausesValidation="False" 
                            ImageUrl="~/imgs/calendar1.png" />
                         
                    </td>
                </tr>

                 <tr>
                    <td  align="right">
                        
                            <asp:Label ID="lblFFin" runat="server" Text="Fecha Fin :" Font-Size="9pt"></asp:Label>
                        
                    </td>
                    <td  align="left">
                       
                                <asp:TextBox ID="txtFechaFin" runat="server" Width="80px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" 
                                Format="dd/MM/yyyy" PopupButtonID="ibFF" PopupPosition="Right" 
                                TargetControlID="txtFechaFin">
                                  </asp:CalendarExtender>
                                    <asp:ImageButton ID="ibFF" runat="server" CausesValidation="False" 
                                     ImageUrl="~/imgs/calendar1.png" />
                            
                    </td>
                </tr>



                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pHor1" runat="server" Visible="False">
                            <asp:Label ID="lblTurno" runat="server" Text="Turno:" Font-Size="9pt"></asp:Label>
                            <asp:DropDownList ID="ddlTurno" runat="server">
                            </asp:DropDownList>
                            
                            <asp:LinkButton ID="lbAddH" runat="server" ValidationGroup="gHor" 
                                onclick="lbAddH_Click">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/imgs/action_add.png" />
                            </asp:LinkButton>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Panel ID="pHor2" runat="server" Visible="False">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            
                            
                            <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" EnableModelValidation="True" GridLines="Horizontal" 
                                Width="80%" onrowcommand="gvHorario_RowCommand">
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbElimC" runat="server" CommandName="EliminarC" CommandArgument='<%# Eval("Id") %>'>
                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/imgs/action_delete.png" />
                                            
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Turno" DataField="turno" >
                                   
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                   
                                    <asp:BoundField HeaderText="Fecha " DataField="fecha" 
                                        DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle Width="75px"  HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fecha" DataFormatString="{0:dddd}" 
                                        HeaderText="Día" />
                                </Columns>
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            </asp:GridView>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                </tr>
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>


                <tr>
                    <td colspan="2" align="center">
                        <asp:LinkButton ID="lbtnGuardar" runat="server" Font-Overline="False" 
                            onclick="lbtnGuardar_Click" BorderStyle="Outset" Width="100px"> <asp:Image ID="Image1" runat="server" ImageUrl="~/imgs/action_add.png" />Guardar </asp:LinkButton>
                        <asp:LinkButton ID="lbtnVolver" runat="server" Font-Overline="false" 
                            BorderStyle="Outset" Width="100px" CausesValidation="False" 
                            PostBackUrl="Listado.aspx"> <asp:Image ID="Image2" runat="server" ImageUrl="~/imgs/arrow_back.png" />Volver </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </center>
    </form>
</asp:Content>