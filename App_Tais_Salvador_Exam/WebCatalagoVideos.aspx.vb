Imports CapaNegocio
Public Class WebCatalagoVideos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            Dim ds As DataSet
            ds = VideosCN.Instancia.ListarTodos
            DataList1.DataSource = VideosCN.Instancia.ListarTodos
            DataList1.DataBind()
        End If

    End Sub

    Private Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Dim cod, des, cat As String
        Dim pre As Double
        If e.CommandName = "seleccionar" Then
            DataList1.SelectedIndex = e.Item.ItemIndex
            cod = CType(DataList1.SelectedItem.FindControl("codproductoLabel"), Label).Text
            des = CType(DataList1.SelectedItem.FindControl("descripcionLabel"), Label).Text
            cat = CType(DataList1.SelectedItem.FindControl("categoriaLabel"), Label).Text
            pre = CType(DataList1.SelectedItem.FindControl("precioLabel"), Label).Text
            AgregarIdprod(cod, des, cat, pre)
        End If
    End Sub


    Public Function Video() As VideosDS
        Dim obj As VideosDS = CType(Session("Canasta"), VideosDS)
        If obj Is Nothing Then
            obj = New VideosDS()
            Session("Canasta") = obj
        End If
        Return obj
    End Function
    Public Sub AgregarIdprod(ByVal cod As String, ByVal des As String, ByVal cat As String, ByVal pre As Double)
        Dim obj As VideosDS = Me.Video
        Dim fila As VideosDS.VideosRow = obj.Videos.NewVideosRow()
        fila.CodVideo = cod
        fila.Titulo = des
        fila.Categoria = cat
        fila.precio = pre
        fila.Cantidad = 1
        fila.subTotal = pre * 1

        If Me.Video.Tables("Videos").Rows.Find(cod) IsNot Nothing Then
            MsgBox("Video ya registrado")
        Else
            obj.Videos.Rows.Add(fila)
        End If

    End Sub

    Protected Sub DataList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataList1.SelectedIndexChanged
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Response.Redirect("WebListaComprados.aspx")
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        Dim ds As DataSet
        Dim n As String
        n = DropDownList1.SelectedValue
        ds = VideosCN.Instancia.FiltrarxCategoria(n)
        DataList1.DataSource = VideosCN.Instancia.FiltrarxCategoria(n)
        DataList1.DataBind()

    End Sub
End Class