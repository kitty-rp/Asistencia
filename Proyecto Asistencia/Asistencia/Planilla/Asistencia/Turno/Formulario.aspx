<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Asistencia.Presentacion.Turno.Formulario"
MasterPageFile="~/Adm.Master" StylesheetTheme="Default"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label8" runat="server" Text="Listado de gestiones y periodos" ></asp:Label>


    <form id="form1" runat="server">
        <center>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            <table style="width: 400px; border: 1px">
                <tr>
                    <td align="right" style="width: 26px">
                        <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
                    </td>
                    <td align="left" style="width: 26px">
                        <asp:TextBox ID="tCod" runat="server" Width="100px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  align="right">
                        <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
                    </td>
                    <td  align="left">
                        <asp:TextBox ID="tDesc" runat="server" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="tDesc" ErrorMessage="Requerido"></asp:RequiredFieldValidator>
                    </td>
                </tr>


                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                <tr>
                    <td align="center" colspan="2">
                    <asp:Panel ID="pHor1" runat="server" Visible="False">
                    <table border="1" width="75%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Día:" Font-Size="9pt"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddDia" runat="server">
                                <asp:ListItem Value="Lunes">Lunes</asp:ListItem>
                                <asp:ListItem Value="Martes">Martes</asp:ListItem>
                                <asp:ListItem Value="Miércoles">Miércoles</asp:ListItem>
                                <asp:ListItem Value="Jueves">Jueves</asp:ListItem>
                                <asp:ListItem Value="Viernes">Viernes</asp:ListItem>
                                <asp:ListItem Value="Sábado">Sábado</asp:ListItem>
                                <asp:ListItem Value="Domingo">Domingo</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" Text="Hora ini:" Font-Size="9pt"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="tHIni" runat="server" Width="20px" ControlToValidate="tHIni" 
                                ValidationGroup="gHor"></asp:TextBox>
                                <asp:Label ID="Label6" runat="server" Text=":"></asp:Label>
                                <asp:TextBox ID="tMIni" runat="server" Width="20px" ControlToValidate="tHIni" 
                                ValidationGroup="gHor"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="?" ControlToValidate="tHIni" 
                                ValidationExpression="\d{1,2}" ValidationGroup="gHor"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="H" ControlToValidate="tHIni" ValidationGroup="gHor"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                ErrorMessage="?" ControlToValidate="tMIni" 
                                ValidationExpression="\d{1,2}" ValidationGroup="gHor"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ErrorMessage="M" ControlToValidate="tMIni" ValidationGroup="gHor"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" Text="Hora fin:" Font-Size="9pt"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="tHFin" runat="server" Width="20px" ValidationGroup="gHor"></asp:TextBox>
                                <asp:Label ID="Label7" runat="server" Text=":"></asp:Label>
                                <asp:TextBox ID="tMFin" runat="server" Width="20px" ValidationGroup="gHor"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="?" ControlToValidate="tHFin" 
                                ValidationExpression="\d{1,2}" ValidationGroup="gHor"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="H" ControlToValidate="tHFin" ValidationGroup="gHor"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ErrorMessage="?" ControlToValidate="tMFin" 
                                ValidationExpression="\d{1,2}" ValidationGroup="gHor"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ErrorMessage="M" ControlToValidate="tMFin" ValidationGroup="gHor"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                            <asp:LinkButton ID="lbAddH" runat="server" ValidationGroup="gHor" 
                                onclick="lbAddH_Click">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/imgs/action_add.png" />Agregar
                            </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                        </asp:Panel>     
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Panel ID="pHor2" runat="server" Visible="False">
                            <asp:GridView ID="gvHorario" runat="server" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" EnableModelValidation="True" GridLines="Horizontal" 
                                Width="80%" onrowcommand="gvHorario_RowCommand">
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbElimH" runat="server" CommandName="EliminarH" CommandArgument='<%# Eval("Id") %>'>
                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/imgs/action_delete.png" />
                                            
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Día" DataField="dia" />
                                    <asp:BoundField HeaderText="Hora ini." DataField="horaEntrada" 
                                        DataFormatString="{0:HH:mm}">
                                    <ItemStyle Width="75px"  HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Hora fin" DataField="horaSalida" 
                                        DataFormatString="{0:HH:mm}">
                                    <ItemStyle Width="75px"  HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>

                <tr>
                    <td colspan="2" align="center">
                        <asp:LinkButton ID="lbGuardar" runat="server" Font-Overline="False" 
                            onclick="lbGuardar_Click" BorderStyle="Outset" Width="100px"> <asp:Image ID="Image1" runat="server" ImageUrl="~/imgs/action_add.png" />Guardar </asp:LinkButton>
                        <asp:LinkButton ID="lbVolver" runat="server" Font-Overline="false" 
                            BorderStyle="Outset" Width="100px" CausesValidation="False" 
                            PostBackUrl="Listado.aspx"> <asp:Image ID="Image2" runat="server" ImageUrl="~/imgs/arrow_back.png" />Volver </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </center>
    </form>
</asp:Content>
