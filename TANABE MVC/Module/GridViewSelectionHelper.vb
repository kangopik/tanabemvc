Imports System.Web
Imports System.Web.SessionState
Imports DevExpress.Web

Namespace TANABE_MVC
    Public Class GridViewSelectionHelper
        Const SelectAllModeSessionKey As String = "4C0A9E6A-5D76-48F9-9086-CD5E9D481928"

        Public Shared Property SelectAllButtonMode() As GridViewSelectAllCheckBoxMode
            Get
                If Session(SelectAllModeSessionKey) Is Nothing Then
                    Session(SelectAllModeSessionKey) = GridViewSelectAllCheckBoxMode.Page
                End If
                Return DirectCast(Session(SelectAllModeSessionKey), GridViewSelectAllCheckBoxMode)
            End Get
            Set(value As GridViewSelectAllCheckBoxMode)
                Session(SelectAllModeSessionKey) = value
            End Set
        End Property

        Private Shared ReadOnly Property Session() As HttpSessionState
            Get
                Return HttpContext.Current.Session
            End Get
        End Property
    End Class
End Namespace