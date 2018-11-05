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
End Class
