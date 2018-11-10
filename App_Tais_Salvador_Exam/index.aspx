<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Plantilla/Plantilla.Master" CodeBehind="index.aspx.vb" Inherits="App_Tais_Salvador_Exam.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <nav class="navbar navbar-expand-sm navbar-dark bg-dark p-0">
    <div class="container">
      <a href="index.html" class="navbar-brand">Carrito de Compras - Películas</a>
    </div>
  </nav>

  <!-- HEADER -->
  <header id="main-header" class="py-2 bg-primary text-white">
    <div class="container">
      <div class="row">
        <div class="col-md-6">
          <h1>
            <i class="fas fa-user"></i> Comprar</h1>
        </div>
      </div>
    </div>
  </header>

  <!-- ACTIONS -->
  <section id="actions" class="py-4 mb-4 bg-light">
    <div class="container">
      <div class="row">

      </div>
    </div>
  </section>

  <!-- LOGIN -->
  <section id="login">
    <div class="container">
      <div class="row">
        <div class="col-md-6 mx-auto">
          <div class="card">
            <div class="card-header">
              <h4>Iniciar Sesion</h4>
            </div>
            <div class="card-body">
              <div>
                <div class="form-group">
                  <label for="email">Usuario</label>
                  <input type="text" class="form-control">
                </div>
                <div class="form-group">
                  <label for="password">Contraseña</label>
                  <input type="password" class="form-control">
                </div>
                <%--<input type="submit" value="login" class="btn btn-primary btn-block">--%>
                  <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" Text="Ingresar" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

</asp:Content>
