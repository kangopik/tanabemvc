Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class ISalesPlanVerification

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function dsRep() As List(Of v_rep_fullModel)
            Try
                Dim rep_position As String = TryCast(System.Web.HttpContext.Current.Session("rep_position"), [String])
                Dim rep_id As String = TryCast(System.Web.HttpContext.Current.Session("rep_id"), [String])
                Dim departemen As String = TryCast(System.Web.HttpContext.Current.Session("KODEDEPARTEMEN"), [String])
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@department", departemen)
                param.Add("@rep_position", rep_position)
                param.Add("@rep_id", rep_id)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_rep_fullModel)("SP_SELECT_REP_FOR_VERIFICATION", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

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

        Public Function ds_sales(ByVal rep_id_selection As String, ByVal sess_month As Integer, ByVal sess_year As Integer) As List(Of v_sales_plan_2Model)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id_selection)
                param.Add("@month", sess_month)
                param.Add("@year", sess_year)
                connection()
                con.Open()
                Dim tb = con.Query(Of v_sales_plan_2Model)("SP_SELECT_SALES_PLAN_READY", param, commandType:=CommandType.StoredProcedure)
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

        Public Function VerificationSalesPlan(ByVal sales_id As String, ByVal sales_plan_verification_by As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sales_id", sales_id)
                param.Add("@sales_plan_verification_by", sales_plan_verification_by)
                connection()
                con.Open()
                con.Execute("SP_VERIFICATION_SALES_PLAN", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function VerificationOneByOne(ByVal sales_id As String, ByVal sales_plan_verification_by As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sales_id", sales_id)
                param.Add("@sales_plan_verification_by", sales_plan_verification_by)
                connection()
                con.Open()
                con.Execute("SP_VERIFICATION_SALES_PLAN", param, commandType:=CommandType.StoredProcedure)
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
                Dim tb = con.Query(Of v_m_doctorModel)("SELECT * FROM v_m_doctor WHERE ISNULL(dr_sales_session,0) = 0 AND dr_status = 1 AND dr_rep = @rep_id", param, commandType:=CommandType.Text)
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
