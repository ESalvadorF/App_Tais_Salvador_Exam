<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebCatalagoVideos.aspx.vb" Inherits="App_Tais_Salvador_Exam.WebCatalagoVideos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button2" runat="server" Text="Ir al Carrito" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:App_Tais_Salvador_Exam.My.MySettings.BD_Salvador_TaisConnectionString %>" SelectCommand="SELECT * FROM [Categoria]"></asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="DesCategoria" DataValueField="CodCategoria">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:App_Tais_Salvador_Exam.My.MySettings.BD_Salvador_TaisConnectionString %>" SelectCommand="SELECT [CodCategoria], [DesCategoria] FROM [Categoria]"></asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" Text="Seleccionar Categoria :  "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="DesCategoria" AutoPostBack="true"  DataValueField="CodCategoria">
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" AutoPostBack="true" runat="server"></asp:TextBox>
    <asp:DataList ID="DataList1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both" RepeatColumns="3" Width="784px" HorizontalAlign="Center">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="White" />
        <ItemTemplate>
            <table class="table">
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" Height="65px" ImageUrl='<%# "~/imagen/" + Eval("foto") %>' Width="99px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="codproductoLabel" runat="server" Text='<%#Eval("codVideo") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="descripcionLabel" runat="server" Text='<%#Eval("titulo") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="categoriaLabel" runat="server" Text='<%#Eval("desCategoria") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="precioLabel" runat="server" Text='<%#Eval("precio") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:Button class="btn btn-danger" ID="Button1" runat="server" Text="Añadir Carrito Compras" CommandName="seleccionar" OnClick="Button1_Click" />

                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
    </form>
</body>
</html>
