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

    Public Function filtrarXTitulo(ByVal titulo As String) As DataSet
        Dim ds As New DataSet
        Try
            Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
            cnn.Open()
            Dim da As New SqlDataAdapter("filtrar_videos_texto", cnn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@texto", SqlDbType.VarChar, 30).Value = titulo
            da.Fill(ds, "Videos")
            cnn.Close()
            cnn.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return ds
    End Function

    Public Function CrearDocumento() As Integer
        Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
        cnn.Open()
        Dim Sqlcmd As New SqlCommand("registrarDocumento", cnn)
        Sqlcmd.CommandType = CommandType.StoredProcedure
        Sqlcmd.Parameters.Add("@idDocumento", SqlDbType.Int)
        Sqlcmd.Parameters("@idDocumento").Direction = ParameterDirection.Output
        Sqlcmd.ExecuteNonQuery()
        Return Sqlcmd.Parameters("@idDocumento").Value
        cnn.Close()
        cnn.Dispose()
        Sqlcmd.Dispose()
    End Function


    Public Function Agregar(ByVal iddocumento As String, ByVal codVideo As String, cantidad As String, precio As String) As Boolean
        Try
            Dim cnn As New SqlConnection(Conexion.Instancia.cadenaconexion)
            cnn.Open()
            Dim Sqlcmd As New SqlCommand("registrarDetalle", cnn)
            Sqlcmd.CommandType = CommandType.StoredProcedure
            Sqlcmd.Parameters.Add("@iddocumento", SqlDbType.Int).Value = iddocumento
            Sqlcmd.Parameters.Add("@codVideo", SqlDbType.Int).Value = codVideo
            Sqlcmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad
            Sqlcmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio

            Sqlcmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function

End Class