﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class DoctorListEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=DoctorListEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub


    Public Overridable Function SP_SELECT_DOCTOR_LIST(rep_id As String, rep_position As String) As ObjectResult(Of SP_SELECT_DOCTOR_LIST_Result)
        Dim rep_idParameter As ObjectParameter = If(rep_id IsNot Nothing, New ObjectParameter("rep_id", rep_id), New ObjectParameter("rep_id", GetType(String)))

        Dim rep_positionParameter As ObjectParameter = If(rep_position IsNot Nothing, New ObjectParameter("rep_position", rep_position), New ObjectParameter("rep_position", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of SP_SELECT_DOCTOR_LIST_Result)("SP_SELECT_DOCTOR_LIST", rep_idParameter, rep_positionParameter)
    End Function

End Class
