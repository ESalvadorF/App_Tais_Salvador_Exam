﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebListaComprados.aspx.vb" Inherits="App_Tais_Salvador_Exam.WebListaComprados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
            <link href="../assets/css/all.css" rel="stylesheet" />
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-right: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label4" runat="server" Text="Nombre :"></asp:Label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Ingresar Correo Electronico :"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

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

 <asp:GridView ID="GvwCarrito" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="444px" CssClass="auto-style1">
 <RowStyle ForeColor="#000066" />
 <Columns>
 <asp:TemplateField HeaderText="Quitar">
 <ItemTemplate>
 <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("CodVideo") %>' CommandName='Borrar' ImageUrl="imagen/eliminar.PNG" HeaderText="Quitar" onclick="ImageButton1_Click"/>
 </ItemTemplate>
 </asp:TemplateField>
     <asp:TemplateField HeaderText="Imagen">
         <ItemTemplate>
             <asp:Image ID="Image1" runat="server" Height="130px" ImageUrl='<%# "~/imagen/" + Eval("Foto") %>' Width="165px" />
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
     <asp:Button ID="Button3" runat="server" Text="Comprar" />
 </td>
 </tr>
 </table>

        <asp:Label ID="Label5" runat="server"></asp:Label>


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Codigo del Video" />
                <asp:BoundField HeaderText="Cantidad" />
                <asp:BoundField HeaderText="Subtotal" />
            </Columns>
        </asp:GridView>

        <script src="../assets/js/jquery-3.3.1.min.js"></script>
    <script src="../assets/js/popper.min.js"></script>
    <script src="../assets/js/bootstrap.min.js"></script>
        <asp:Label ID="Label6" runat="server"></asp:Label>


    </form>

        </body>
</html>
