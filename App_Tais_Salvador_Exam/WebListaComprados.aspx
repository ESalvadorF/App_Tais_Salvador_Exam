<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebListaComprados.aspx.vb" Inherits="App_Tais_Salvador_Exam.WebListaComprados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="style1">
 <tr>
 <td bgcolor="#006699">
 <asp:Label ID="Label2" runat="server" Font-Bold="True"
ForeColor="White"
 Text="Mi Carrito de Compras - Videos"></asp:Label>
 </td>
 </tr>
 <tr>
 <td class="style2">

 <asp:GridView ID="GvwCarrito" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="444px">
 <RowStyle ForeColor="#000066" />
 <Columns>
 <asp:TemplateField HeaderText="Quitar">
 <ItemTemplate>
 <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("CodVideo") %>' CommandName='Borrar' ImageUrl="imagen/eliminar.PNG" HeaderText="Quitar" onclick="ImageButton1_Click"/>
 </ItemTemplate>
 </asp:TemplateField>
 <asp:BoundField DataField="CodVideo" HeaderText="Codigo" />
 <asp:BoundField DataField="Titulo" HeaderText="Video" />
     <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
 <asp:BoundField DataField="precio" HeaderText="Precio" />
 <asp:TemplateField HeaderText="Cantidad" >
 <ItemTemplate>
 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Cantidad") %>' ontextchanged="TextBox1_TextChanged" Width="80px"></asp:TextBox>
 </ItemTemplate>
 </asp:TemplateField>
 <asp:BoundField DataField="subtotal" HeaderText="Subtotal" />
 </Columns>
 <FooterStyle BackColor="White" ForeColor="#000066" />
 <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
 <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
 <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
 </asp:GridView>

 </td>
 </tr>
 <tr>
 <td align="right" class="style2">
 <asp:Label ID="Label1" runat="server" Text="Subtotal S/." FontBold="True"></asp:Label>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Label ID="Lblsubtotal" runat="server" Text="Label"></asp:Label>
 </td>
 </tr>
 <tr>
 <td align="center" class="style2">
 <asp:Button ID="Button1" runat="server" Text="Actualizar Datos" style="height: 26px" />
 <asp:Button ID="Button2" runat="server" Text="Continuar Comprando" />
 </td>
 </tr>
 </table>
    </form>
</body>
</html>
