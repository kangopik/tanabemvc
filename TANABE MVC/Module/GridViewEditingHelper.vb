Imports System.Collections.Generic
Imports System.Web
Imports System.Web.SessionState
Imports DevExpress.Web
Imports DevExpress.Web.Mvc

Public Class GridViewEditingHelper
    Const EditingModeSessionKey As String = "AA054892-1B4C-4158-96F7-894E1545C05C",
          BatchEditModeSessionKey As String = "E509E30E-99E3-4CB3-A07B-A08B04784A46",
          BatchStartEditActionSessionKey As String = "F2014F18-18A5-42F2-B713-B1538D1D1720"

    Public Shared Property EditMode() As GridViewEditingMode
        Get
            If Session(EditingModeSessionKey) Is Nothing Then
                Session(EditingModeSessionKey) = GridViewEditingMode.EditFormAndDisplayRow
            End If
            Return DirectCast(Session(EditingModeSessionKey), GridViewEditingMode)
        End Get
        Set(value As GridViewEditingMode)
            HttpContext.Current.Session(EditingModeSessionKey) = value
        End Set
    End Property

    Shared m_availableEditModesList As List(Of GridViewEditingMode)
    Public Shared ReadOnly Property AvailableEditModesList() As List(Of GridViewEditingMode)
        Get
            If m_availableEditModesList Is Nothing Then
                m_availableEditModesList = New List(Of GridViewEditingMode)() From { _
                    GridViewEditingMode.Inline, _
                    GridViewEditingMode.EditForm, _
                    GridViewEditingMode.EditFormAndDisplayRow, _
                    GridViewEditingMode.PopupEditForm _
                }
            End If
            Return m_availableEditModesList
        End Get
    End Property

    Public Shared Property BatchEditMode() As GridViewBatchEditMode
        Get
            If Session(BatchEditModeSessionKey) Is Nothing Then
                Session(BatchEditModeSessionKey) = GridViewBatchEditMode.Cell
            End If
            Return DirectCast(Session(BatchEditModeSessionKey), GridViewBatchEditMode)
        End Get
        Set(value As GridViewBatchEditMode)
            Session(BatchEditModeSessionKey) = value
        End Set
    End Property
    Public Shared Property BatchStartEditAction() As GridViewBatchStartEditAction
        Get
            If Session(BatchStartEditActionSessionKey) Is Nothing Then
                Session(BatchStartEditActionSessionKey) = GridViewBatchStartEditAction.Click
            End If
            Return DirectCast(Session(BatchStartEditActionSessionKey), GridViewBatchStartEditAction)
        End Get
        Set(value As GridViewBatchStartEditAction)
            Session(BatchStartEditActionSessionKey) = value
        End Set
    End Property
    Protected Shared ReadOnly Property Session() As HttpSessionState
        Get
            Return HttpContext.Current.Session
        End Get
    End Property
End Class
