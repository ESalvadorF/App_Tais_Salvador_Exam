Imports CapaDatos
Imports CapaEntidad

Public Class VideosCN
    Public Sub New()
    End Sub
    Private Shared ReadOnly _instancia As New VideosCN
    Public Shared ReadOnly Property Instancia() As VideosCN
        Get
            Return _instancia
        End Get
    End Property
    Public Function ListarTodos() As DataSet
        Return VideosDA.Instancia.ListarTodos
    End Function
    Public Function FiltrarxCategoria(ByVal codCategoria As String) As DataSet
        Return VideosDA.Instancia.filtrarxCategoria(codCategoria)
    End Function
    Public Function FiltrarXTitulo(ByVal titulo As String) As DataSet
        Return VideosDA.Instancia.filtrarXTitulo(titulo)
    End Function
    Public Function CrearDocumento() As Integer
        Return VideosDA.Instancia.CrearDocumento()
    End Function
    Public Function Insertar(ByVal iddocumento As String, ByVal codVideo As String, cantidad As String, precio As String) As Boolean
        Return VideosDA.Instancia.Agregar(iddocumento, codVideo, cantidad, precio)
    End Function
End Class
