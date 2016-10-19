Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class ISalesPlan

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

        Public Function ds_sales(ByVal rep_id As String, ByVal sess_month As Integer, ByVal sess_year As Integer) As List(Of v_sales_plan_2Model)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@sales_date_plan", sess_month)
                param.Add("@sales_year_plan", sess_year)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_sales_plan_2Model)("SELECT * FROM [v_sales_plan_2] WHERE rep_id = @rep_id AND [sales_date_plan] = @sales_date_plan AND [sales_year_plan] = @sales_year_plan AND sales_plan_verification_status = 0 ORDER BY dr_code ASC", param, commandType:=CommandType.Text)
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

        Public Function GenerateSalesPlan(ByVal rep_id As String, ByVal sales_date_plan As Integer, ByVal sales_year_plan As Integer) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@sales_date_plan", sales_date_plan)
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

        Public Function InsertSalesProductMapping(ByVal dr_code As Int64, ByVal sales_month As Integer, ByVal sales_year As Integer, ByVal prd_code As String, ByVal sp_target_qty As Integer, ByVal sp_note As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", dr_code)
                param.Add("@sales_month", sales_month)
                param.Add("@sales_year", sales_year)
                param.Add("@prd_code", prd_code)
                param.Add("@sp_target_qty", sp_target_qty)
                param.Add("@sp_note", sp_note)
                connection()
                con.Open()
                con.Execute("SP_INSERT_SALES_PRODUCT_MAPPING", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function CopySalesPlan(ByVal rep_id As String, ByVal from_month As Integer, ByVal from_year As Integer) As Boolean
            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim curr_month As Int32 = currentDate.Month + 1
                Dim curr_year As Int32 = currentDate.Year
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@from_month", from_month)
                param.Add("@from_year", from_year)
                param.Add("@curr_month", curr_month)
                param.Add("@curr_year", curr_year)
                connection()
                con.Open()
                con.Execute("SP_COPY_SALES_PLAN", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function FindSales(ByVal dr_code As Integer, ByVal sales_month As Integer, ByVal sales_year As Integer, ByVal rep_id As String) As String
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", dr_code)
                param.Add("@sales_month", sales_month)
                param.Add("@sales_year", sales_year)
                param.Add("@rep_id", rep_id)
                connection()
                con.Open()
                Dim tb As String = con.Query(Of String)("SELECT sales_id FROM t_sales WHERE dr_code = @dr_code AND sales_date_plan = @sales_month AND sales_year_plan = @sales_year AND rep_id = @rep_id", param, commandType:=CommandType.Text).Single()
                Return tb
            Catch ex As Exception
                Throw ex
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

        Public Function UpdateSalesProduct(ByVal sp_id As String, ByVal sp_target_qty As Integer, ByVal sp_note As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sp_id", sp_id)
                param.Add("@sp_target_qty", sp_target_qty)
                param.Add("@sp_note", sp_note)
                connection()
                con.Open()
                con.Execute("SP_UPDATE_SALES_PRODUCT", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function DeleteSalesProduct(ByVal sp_id As String, ByVal sales_id As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sp_id", sp_id)
                param.Add("@sales_id", sales_id)
                connection()
                con.Open()
                con.Execute("SP_DELETE_PRODUCT_SALES", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function InsertTranscatEmail(ByVal rep_id As String, ByVal month As Integer, ByVal year As Integer) As Boolean
            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", month)
                param.Add("@year", year)
                param.Add("@transaction_id", "RVSR")
                param.Add("@date_sent", CDate(currentDate).ToString("yyyy-MM-dd"))
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

        Public Function isHaveRemainingToSendMail(ByVal rep_id As String, ByVal month As Integer, ByVal year As Integer) As Boolean
            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", month)
                param.Add("@year", year)
                param.Add("@transaction_id", "RVSP")
                param.Add("@date_sent", CDate(currentDate).ToString("yyyy-MM-dd"))
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(con, "SP_SELECT_TRANSACT_EMAIL", param, commandType:=CommandType.StoredProcedure)
                If (tb(0).is_pass = 1) Then
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

        Public Function isAnyDoctorUnplanedSales(ByVal rep_id As String, ByVal month As Integer, ByVal year As Integer) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", month)
                param.Add("@year", year)
                connection()
                con.Open()
                Dim tb = con.Query(Of t_salesModel)("SELECT * FROM t_sales WHERE sales_plan = 0 and ISNULL(sales_plan_verification_status,0) = 0 AND sales_date_plan = @month and sales_year_plan = @year AND rep_id = @rep_id", param, commandType:=CommandType.Text)
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

        Public Function isAnyPlannedSalesInSelectedMonth(ByVal rep_id As String, ByVal mth As Integer, ByVal yer As Integer) As Boolean
            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@sales_date_plan", mth)
                param.Add("@sales_year_plan", yer)
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

        Public Function SaveReport(ByVal rep_id As String) As Boolean
            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim curr_month As Int32 = currentDate.Month
                Dim curr_year As Int32 = currentDate.Year
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", curr_month)
                param.Add("@year", curr_year)
                param.Add("@transaction_id", "RVSP")
                param.Add("@date_sent", CDate(currentDate).ToString("yyyy-MM-dd"))
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

    End Class
End Namespace
