Imports CapaNegocio
Imports CapaEntidad
Imports CapaDatos
Imports System.Net.Mail
Imports System.Net

Public Class WebListaComprados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            cargarcarrito()
        End If
    End Sub
    Sub cargarcarrito()
        Dim GV As New GridView
        GvwCarrito.DataSource = Session("Canasta")
        GvwCarrito.DataBind()
        Call Button1_Click(Button1, Nothing)
    End Sub
    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Private Sub GvwCarrito_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GvwCarrito.RowCommand
        Dim DS As New DataSet
        DS = CType(Session("Canasta"), DataSet)
        Dim DT As New DataTable
        DT = DS.Tables("Canasta")
        Dim i As Integer
        Dim cod, codb As String
        If e.CommandName = "Borrar" Then
            cod = e.CommandArgument.ToString
            For i = 0 To DT.Rows.Count - 1
                codb = DT.Rows(i).Item(0).ToString
                If codb = cod Then
                    DT.Rows(i).Delete()
                    DT.AcceptChanges()
                    Exit For
                End If
            Next
        End If
        cargarcarrito()
    End Sub
    Protected Sub GvwCarrito_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GvwCarrito.SelectedIndexChanged
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim total, prec, subtotal As Double
        Dim cod, des, cat As String
        Dim cant As Integer
        Dim obj As VideosDS = CType(Session("Canasta"), VideosDS)
        For i = 0 To GvwCarrito.Rows.Count - 1
            cod = (GvwCarrito.Rows(i).Cells(2).Text)
            des = (GvwCarrito.Rows(i).Cells(3).Text)
            cat = (GvwCarrito.Rows(i).Cells(4).Text)
            prec = Double.Parse(GvwCarrito.Rows(i).Cells(5).Text)
            cant = CType(GvwCarrito.Rows(i).Cells(0).FindControl("TextBox1"), TextBox).Text
            prec = Double.Parse(GvwCarrito.Rows(i).Cells(5).Text)
            subtotal = cant * prec
            'Actualiza la canasta
            GvwCarrito.Rows(i).Cells(7).Text = subtotal
            For Each objDR In obj.Videos.Rows
                If objDR("CodVideo") = cod Then
                    objDR("Cantidad") = cant
                    objDR("subtotal") = subtotal
                    Exit For
                End If
            Next
            total = total + subtotal
        Next
        Lblsubtotal.Text = total.ToString("0.00")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Response.Redirect("WebCatalagoVideos.aspx")
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim oVideo As New VideosCN
        Dim numDocumento, i As Integer
        Dim productos As String
        Dim ok As Boolean
        i = 0
        productos = "<table>
          <tr>
            <th>Codigo del Video</th>
            <th>Cantidad</th> 
            <th>Subtotal</th>
          </tr>"
        numDocumento = oVideo.CrearDocumento()
        Dim obj As VideosDS = CType(Session("Canasta"), VideosDS)
        If obj IsNot Nothing Then
            If TextBox2.Text <> "" Then

                Label5.Text = "Nombre: " + TextBox3.Text + " . Usted realizo una compra de varias peliculas por un monto de" + "S/." + Lblsubtotal.Text


                For Each objDR In obj.Videos.Rows
                    ok = oVideo.Insertar(numDocumento, objDR("CodVideo"), objDR("Cantidad"), objDR("subtotal"))
                    productos = productos + "<tr><td>" + objDR("CodVideo").ToString + "</td><td>" + objDR("Cantidad").ToString + "</td><td>" + objDR("subtotal").ToString + "</td></tr>"

                Next


                productos = productos + "</table>"

                Label6.Text = productos
                MsgBox("Compra Registrada")

                Dim correo As New System.Net.Mail.MailMessage
                Dim smtp As New System.Net.Mail.SmtpClient
                Try
                    correo.To.Clear()
                    correo.Body = ""
                    correo.Subject = ""

                    correo.Body = "Nombre: " + TextBox3.Text +
                        " Correo: " + TextBox2.Text +
                        " Usted realizo una compra de varias peliculas por un monto de: " + "S/." + Lblsubtotal.Text + ".<h3>Lista de Videos</h3>" + productos

                    correo.Subject = "Verificacion de Compra"
                    correo.IsBodyHtml = True
                    correo.To.Add(Trim(TextBox2.Text))

                    correo.From = New MailAddress("tais2.visual123@gmail.com")
                    smtp.Credentials = New NetworkCredential("tais2.visual123@gmail.com", "adminVB123")

                    smtp.Host = "smtp.gmail.com"
                    smtp.Port = 587
                    smtp.EnableSsl = True

                    smtp.Send(correo)
                    MsgBox("El mensaje fue enviado correctamente. ", MsgBoxStyle.Information, "Mensaje")

                Catch ex As Exception
                    MsgBox(ex.Message, "Mensaje Visual Basic" & ex.Message)
                End Try

                'Session("Canasta") = Nothing

                'Response.Redirect("WebCatalagoVideos.aspx")
            Else
                MsgBox("Correo no ingresado")
            End If

        Else
                MsgBox("No hay peliculas en el carrito de compras")
        End If
    End Sub
End Class