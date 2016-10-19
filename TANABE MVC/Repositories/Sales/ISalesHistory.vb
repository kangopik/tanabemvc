Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class ISalesHistory

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function ds_lookup_plan(ByVal rep_id As String) As List(Of v_sales_planModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_sales_planModel)("SELECT * FROM [v_sales_plan] WHERE rep_id = @rep_id AND (DATEPART(MONTH,sales_date_plan) = DATEPART(MONTH, GETDATE()) AND DATEPART(YEAR,sales_date_plan) = DATEPART(YEAR, GETDATE()))  ORDER BY sales_date_plan ASC", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function dsProductLookup() As List(Of m_productModel)
            Try
                connection()
                con.Open()
                Dim tb = con.Query(Of m_productModel)("SELECT * FROM [m_product] WHERE prd_status = 1")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function dsEditProductSales(ByVal sales_id As String) As List(Of v_sales_productModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sales_id", sales_id)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_sales_productModel)("SELECT * FROM [v_sales_product] WHERE sales_id = @sales_id", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function dsEditProductSalesActual(ByVal sp_id As String) As List(Of t_sales_product_actualModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sp_id", sp_id)
                connection()
                con.Open()
                Dim tb = con.Query(Of t_sales_product_actualModel)("SELECT * FROM [t_sales_product_actual] WHERE sp_id = @sp_id ORDER BY spa_date ASC", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function dsProductSales(ByVal rep_id As String, ByVal sess_month As Integer, ByVal sess_year As Integer) As List(Of v_sales_productModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@sales_date_plan", sess_month)
                param.Add("@sales_year_plan", sess_year)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_sales_productModel)("SELECT * FROM [v_sales_product] WHERE rep_id = @rep_id AND [sales_date_plan] = @sales_date_plan AND [sales_year_plan] = @sales_year_plan AND [sales_real_verification_status] = 1 ORDER BY dr_code ASC", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function dsDoctorList(ByVal rep_id As String) As List(Of v_m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_rep", rep_id)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_m_doctorModel)("SELECT * FROM [v_m_doctor] WHERE dr_rep = @dr_rep AND isnull(dr_sales_session,0) = 0 AND dr_status = 1", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function dsDoctorListByAM(ByVal rep_id As String) As List(Of v_m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_am", rep_id)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_m_doctorModel)("SELECT * FROM [v_m_doctor] WHERE dr_am = @dr_am AND isnull(dr_sales_session,0) = 0 AND dr_status = 1", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function DeleteSalesPlan(ByVal sales_id As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sales_id", sales_id)
                connection()
                con.Open()
                con.Execute("SP_DELETE_SALES_PLAN", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function GenerateSalesPlan(ByVal rep_id As String, ByVal sales_date_plan As Integer, ByVal sales_year_plan As Integer, ByVal rep_position As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@sales_date_plan", sales_date_plan)
                param.Add("@rep_position", rep_position)
                param.Add("@sales_year_plan", sales_year_plan)
                connection()
                con.Open()
                con.Execute("SP_GENERATE_SALES_PLAN", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function UpdateFake() As Boolean
            Try
                connection()
                con.Open()
                con.Execute("SP_UPDATE_FAKE", commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetInfoDetailDoctor(ByVal dr_code As Int64) As List(Of v_m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", dr_code)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_m_doctorModel)("SELECT * FROM [dbo].[m_doctor] WHERE dr_code = @dr_Code", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function InsertSalesPlan(ByVal rep_id As String, ByVal sales_date_plan As Integer, ByVal sales_year_plan As Integer, ByVal rep_position As String, ByVal dr_code As Int64) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@sales_date_plan", sales_date_plan)
                param.Add("@rep_position", rep_position)
                param.Add("@dr_code", dr_code)
                param.Add("@sales_year_plan", sales_year_plan)
                connection()
                con.Open()
                con.Execute("SP_INSERT_SALES_PLAN", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function InsertSalesProduct(ByVal sales_id As String, ByVal prd_code As String, ByVal sp_target_qty As Integer, ByVal sp_note As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sales_id", sales_id)
                param.Add("@prd_code", prd_code)
                param.Add("@sp_target_qty", sp_target_qty)
                param.Add("@sp_note", sp_note)
                connection()
                con.Open()
                con.Execute("SP_INSERT_SALES_PRODUCT", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function InsertSalesProductActual(ByVal sp_id As String, ByVal spa_date As String, ByVal spa_quantity As Integer, ByVal spa_note As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sp_id", sp_id)
                param.Add("@spa_date", spa_date)
                param.Add("@spa_quantity", spa_quantity)
                param.Add("@spa_note", spa_note)
                connection()
                con.Open()
                con.Execute("SP_INSERT_SALES_PRODUCT_ACTUAL", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function DeleteSalesProductActual(ByVal spa_id As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@spa_id", spa_id)
                connection()
                con.Open()
                con.Execute("SP_DELETE_SALES_PRODUCT_ACTUAL", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function UpdateSalesProductActual(ByVal spa_id As String, ByVal sp_id As String, ByVal spa_date As String, ByVal spa_quantity As Integer, ByVal spa_note As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@spa_id", spa_id)
                param.Add("@sp_id", sp_id)
                param.Add("@spa_date", spa_date)
                param.Add("@spa_quantity", spa_quantity)
                param.Add("@spa_note", spa_note)
                connection()
                con.Open()
                con.Execute("SP_UPDATE_SALES_PRODUCT_ACTUAL", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function InsertTranscatEmail(ByVal rep_id As String, ByVal month As Integer) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", month)
                param.Add("@transaction_id", "RVSR")
                connection()
                con.Open()
                con.Execute("SP_INSERT_TRANSACT_EMAIL", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function isHaveRemainingToSendMail(ByVal rep_id As String, ByVal month As Integer) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", month)
                param.Add("@transaction_id", "RVSR")
                connection()
                con.Open()
                Dim tb As TransactEmailModel = con.Query(Of TransactEmailModel)("SP_SELECT_TRANSACT_EMAIL", param, commandType:=CommandType.StoredProcedure)
                If (tb.is_pass = 1) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function isAnyDoctorUnplanedSales(ByVal rep_id As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_m_doctorModel)("SELECT * FROM m_doctor WHERE ISNULL(dr_sales_session,0) = 0 AND dr_status = 1 AND dr_rep = @rep_id", param, commandType:=CommandType.Text)
                If (tb.Count() = 0) Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
                Return True
            Finally
                con.Close()
            End Try
        End Function

        Public Function isAnyPlannedSalesInCurrMonth(ByVal rep_id As String) As Boolean
            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@sales_date_plan", currentDate.Month)
                param.Add("@sales_year_plan", currentDate.Year)
                connection()
                con.Open()
                Dim tb = con.Query(Of t_salesModel)("SELECT * FROM t_sales WHERE sales_date_plan = @sales_date_plan AND sales_year_plan = @sales_year_plan AND rep_id = @rep_id", param, commandType:=CommandType.Text)
                If (tb.Count() = 0) Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
                Return True
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetRepInfo(ByVal rep_id As String) As List(Of v_rep_fullModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_rep_fullModel)("SELECT * FROM v_rep_full WHERE rep_id = @rep_id", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

    End Class
End Namespace
