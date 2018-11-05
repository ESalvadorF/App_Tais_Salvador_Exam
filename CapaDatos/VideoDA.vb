Imports System.Data.SqlClient

Public Class VideosDA
    Public Sub New()
    End Sub
    Private Shared ReadOnly _instancia As New VideosDA
    Public Shared ReadOnly Property Instancia() As VideosDA
        Get
            Return _instancia
        End Get
    End Property

    Public Function ListarTodos() As DataSet
        Dim ds As New DataSet
        Try
            Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
            cnn.Open()
            Dim da As New SqlDataAdapter("pa_videos_listarTodos", cnn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(ds, "Videos")
            cnn.Close()
            cnn.Dispose()
            da.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return ds
    End Function

    Public Function filtrarxCategoria(ByVal codCategoria As String) As DataSet
        Dim ds As New DataSet
        Try
            Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
            cnn.Open()
            Dim da As New SqlDataAdapter("filtrar_videos", cnn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@codVideo", SqlDbType.Int).Value = codCategoria
            da.Fill(ds, "Videos")
            cnn.Close()
            cnn.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return ds
    End Function
End Class