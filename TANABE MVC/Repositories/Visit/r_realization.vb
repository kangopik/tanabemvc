Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models
Imports TANABE_MVC.TANABE_MVC.Models

Namespace Repositories
    Public Class r_realization
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
        Dim myConnection As New SqlConnection(ConnectionString)
        Dim exTransaction As SqlTransaction

        Public Function GetVisitReal(ByVal repId As String, ByVal month As String, ByVal year As String) As List(Of VisitPlanModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", repId)
                param.Add("@month", month)
                param.Add("@year", year)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of VisitPlanModel)(myConnection, "SELECT * FROM [v_visit_plan] WHERE rep_id = @rep_id AND (DATEPART(month,visit_date_plan) = @month AND DATEPART(year,visit_date_plan) = @year) " & _
                                                                           "AND visit_plan_verification_status = 1 AND visit_date_realization_saved is null  ORDER BY visit_date_plan ASC", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Sub SaveRealizationVisit(ByVal visit_id As String, ByVal rep_id As String, ByVal rep_position As String, ByVal visit_real As Integer, ByVal visit_code As String, ByVal info As String, ByVal sp As String, ByVal sp_value As String)
            Dim date_now As Date = CDate(DateTime.Now())
            Try
                myConnection.Open()
                exTransaction = myConnection.BeginTransaction()
                Dim cmd As New SqlCommand("SP_INSERT_VISIT_REALIZATION", myConnection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@visit_id", visit_id)
                cmd.Parameters.AddWithValue("@rep_id", rep_id)
                cmd.Parameters.AddWithValue("@visit_realization", visit_real)
                cmd.Parameters.AddWithValue("@visit_info", info)
                cmd.Parameters.AddWithValue("@visit_sp", sp)
                cmd.Parameters.AddWithValue("@visit_sp_value", sp_value)
                cmd.Parameters.AddWithValue("@visit_date_realization_saved", date_now)
                cmd.Parameters.AddWithValue("@rep_position", rep_position)
                cmd.Transaction = exTransaction
                cmd.ExecuteNonQuery()

                Dim products As String() = visit_code.Split(New Char() {","})
                If visit_code <> "" Then
                    For i As Integer = 0 To products.Length - 1
                        cmd = New SqlCommand("SP_INSERT_VISIT_PRODUCT", myConnection)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@visit_id", visit_id)
                        cmd.Parameters.AddWithValue("@visit_code", products(i))
                        cmd.Parameters.AddWithValue("@vd_date_saved", date_now)
                        cmd.Transaction = exTransaction
                        cmd.ExecuteNonQuery()
                    Next
                Else
                    cmd = New SqlCommand("SP_INSERT_VISIT_PRODUCT", myConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@visit_id", visit_id)
                    cmd.Parameters.AddWithValue("@visit_code", "T0")
                    cmd.Parameters.AddWithValue("@vd_date_saved", date_now)
                    cmd.Transaction = exTransaction
                    cmd.ExecuteNonQuery()
                End If
                exTransaction.Commit()
            Catch ex As Exception
                exTransaction.Rollback()
            Finally
                myConnection.Close()
            End Try
        End Sub

        Public Sub SaveAdditionalVisit(ByVal dr_code As String, ByVal visit_date_plan As String, ByVal rep_id As String, ByVal rep_position As String, ByVal product_code As String, ByVal info As String, ByVal sp As String, ByVal sp_value As Double)
            Dim date_now As Date = CDate(DateTime.Now())
            Dim visit_id As String = Trim(GetVisitNumber())
            Try
                myConnection.Open()
                exTransaction = myConnection.BeginTransaction()
                Dim cmd As New SqlCommand("SP_INSERT_VISIT_REALIZATION_NO_PLAN", myConnection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@visit_id", visit_id)
                cmd.Parameters.AddWithValue("@rep_id", rep_id)
                cmd.Parameters.AddWithValue("@visit_date_plan", CDate(visit_date_plan).ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@dr_code", dr_code)
                cmd.Parameters.AddWithValue("@visit_realization", 1)
                cmd.Parameters.AddWithValue("@visit_info", info)
                cmd.Parameters.AddWithValue("@visit_sp", sp)
                cmd.Parameters.AddWithValue("@visit_sp_value", sp_value)
                cmd.Parameters.AddWithValue("@visit_date_realization_saved", visit_date_plan)
                cmd.Parameters.AddWithValue("@rep_position", rep_position)
                cmd.Transaction = exTransaction
                cmd.ExecuteNonQuery()

                '-------------- masukin visit Code ke tabel t_visit_doctor--------------------
                Dim ProductList As String = product_code
                Dim Products As String() = ProductList.Split(New Char() {";"c})
                If ProductList <> "" Then
                    For Each index In Products
                        Dim ProductVisitCode As String = index
                        If ProductVisitCode = "" Then Exit For
                        cmd = New SqlCommand("SP_INSERT_VISIT_PRODUCT", myConnection)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@visit_id", visit_id)
                        cmd.Parameters.AddWithValue("@visit_code", ProductVisitCode)
                        cmd.Parameters.AddWithValue("@vd_date_saved", date_now)
                        cmd.Transaction = exTransaction
                        cmd.ExecuteNonQuery()
                    Next
                Else
                    cmd = New SqlCommand("SP_INSERT_VISIT_PRODUCT", myConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@visit_id", visit_id)
                    cmd.Parameters.AddWithValue("@visit_code", "T0")
                    cmd.Parameters.AddWithValue("@vd_date_saved", date_now)
                    cmd.Transaction = exTransaction
                    cmd.ExecuteNonQuery()
                End If
                '--------------  masukin Visit Code ke tabel t_visit_doctor--------------------
                exTransaction.Commit()
            Catch ex As Exception
                exTransaction.Rollback()
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Sub

        Public Function SaveCancellationVisit(ByVal rep_id As String, ByVal condiDev As String, ByVal repPos As String, ByVal planText As String, ByVal condition As String, ByVal dateVisit As String) As Boolean
            Dim date_now As Date = CDate(DateTime.Now())
            Try
                myConnection.Open()
                exTransaction = myConnection.BeginTransaction()

                If condiDev = "half" Then
                    Dim sourceText As String = planText
                    Dim cancelVisitList As String() = sourceText.Split(New Char() {","c})
                    For Each Index In cancelVisitList
                        Dim visit_id As String = Index
                        If visit_id = "" Then Exit For
                        Dim cmd As New SqlCommand("[SP_UPDATE_VISIT_PLAN_CANCELLATION]", myConnection)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@rep_id", rep_id)
                        cmd.Parameters.AddWithValue("@rep_position", repPos)
                        cmd.Parameters.AddWithValue("@visit_id", visit_id)
                        cmd.Parameters.AddWithValue("@visit_info", condition)
                        cmd.Parameters.AddWithValue("@visit_date_realization_saved", date_now)
                        cmd.Transaction = exTransaction
                        cmd.ExecuteNonQuery()
                    Next
                Else
                    Dim cmd As New SqlCommand("[SP_UPDATE_VISIT_PLAN_BY_DATE]", myConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@rep_id", rep_id)
                    cmd.Parameters.AddWithValue("@rep_position", repPos)
                    cmd.Parameters.AddWithValue("@visit_info", condition)
                    cmd.Parameters.AddWithValue("@visit_date_realization_saved", date_now)
                    cmd.Parameters.AddWithValue("@visit_date_plan", CDate(dateVisit).ToString("yyyy-MM-dd"))
                    cmd.Transaction = exTransaction
                    cmd.ExecuteNonQuery()
                End If

                exTransaction.Commit()
                Return True
            Catch ex As SqlException
                exTransaction.Rollback()
                Return False
            Finally
                myConnection.Close()
            End Try
        End Function

        Function isAnyPlanOnChoosenDay(ByVal rep_id As String, ByVal choosenDay As String) As Boolean
            myConnection.Open()
            Dim cmd As New SqlCommand("SELECT * FROM t_visit WHERE rep_id = @rep_id AND visit_date_plan = @visit_date_plan AND visit_plan_verification_status = 1", myConnection)
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@visit_date_plan", choosenDay)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            Try
                rd.Read()
                If rd.HasRows Then
                    rd.Close()
                    Return True         '//true berarti plan-na aya
                Else
                    rd.Close()
                    Return False        '//false berarti eweuhan
                End If

            Catch ex As Exception
                rd.Close()
                Return False         '// dibuat false karena kalau error pada sintax sql tetep dianggap plen na eweuhan
            Finally
                myConnection.Close()
            End Try
        End Function

        Function CheckMaxVisit(ByVal rep_id As String, ByVal datePlan As String) As Integer
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@visit_date_plan", datePlan)
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SP_INSERT_ADDITIONAL_VISIT", param, commandType:=CommandType.StoredProcedure)
                Return tb(0).REAL_NO_PLAN
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Function isValidDay(ByVal rep_id As String, ByVal datePlan As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@visit_date_plan", datePlan)
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SELECT * FROM t_visit WHERE CONVERT(date,visit_date_plan) = @visit_date_plan and rep_id = @rep_id AND dr_code < 100005", param, commandType:=CommandType.Text)
                Return tb.Count <= 0
            Catch ex As Exception
                Return False
            Finally
                myConnection.Close()
            End Try

        End Function

        Function isAlreadyPlannedVisitInCurrDay(ByVal rep_id As String, ByVal datePlan As String, ByVal repPos As String) As Boolean
            Try
                myConnection.Open()
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@visit_date_plan", datePlan)
                Dim tb = SqlMapper.Query(myConnection, "SELECT count(*) as count_visit FROM t_visit WHERE CONVERT(date,visit_date_plan) = @visit_date_plan and rep_id = @rep_id", param, commandType:=CommandType.Text)
                Dim visit_count As Integer = tb(0).count_visit
                Select Case repPos
                    Case "MR"
                        If visit_count >= 11 Then            '11
                            Return True
                        End If
                    Case "AM"
                        If visit_count >= 5 Then             '5
                            Return True
                        End If
                    Case "PPM"
                        If visit_count >= 4 Then             '4
                            Return True
                        End If
                    Case "PS"                               '6
                        If visit_count >= 6 Then
                            Return True
                        End If
                End Select

                Return False
            Catch ex As Exception
                Return False
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Function isAlreadyPlannedDoctorInCurrDay(ByVal rep_id As String, ByVal datePlan As Date, ByVal dr_code As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@visit_date_plan", datePlan)
                param.Add("@dr_code", dr_code)
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SELECT *  FROM v_visit_plan WHERE CONVERT(date,visit_date_plan) = @visit_date_plan " & _
                                                        " and rep_id = @rep_id AND dr_code = @dr_code and visit_plan = 1", param, commandType:=CommandType.Text)
                Return tb.Count > 0
            Catch ex As Exception
                Return True
            Finally
                myConnection.Close()
            End Try
        End Function

        Function isMaxLimitedDoctorinCurrDay(ByVal rep_id As String, ByVal datePlan As Date, ByVal repPos As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@visit_date_plan", datePlan)
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SELECT count(*) as count_doc FROM t_visit WHERE CONVERT(date,visit_date_plan) = @visit_date_plan and rep_id = @rep_id", param, commandType:=CommandType.Text)
                Dim doc_count As Integer = tb(0).count_doc
                Select Case repPos
                    Case "MR"
                        If doc_count >= 22 Then      '11
                            Return True
                        End If
                    Case "AM"
                        If doc_count >= 10 Then       '5
                            Return True
                        End If
                    Case "PPM"
                        If doc_count >= 8 Then       '4
                            Return True
                        End If
                    Case "PS"
                        If doc_count >= 12 Then       '6
                            Return True
                        End If
                End Select
                Return False
            Catch ex As Exception
                Return True
            Finally
                myConnection.Close()
            End Try
        End Function

        Function Query(ByVal sql As String) As DataTable
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim sSQL As String = String.Empty
            Try
                sSQL = sql
                myConnection.Open()
                cmd.Connection = myConnection
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sSQL
                Dim sdr As SqlDataReader = cmd.ExecuteReader()
                dt.Load(sdr)
                sdr.Close()
            Catch ex As Exception
            Finally
                myConnection.Close()
            End Try
            Return dt
        End Function

        Public Sub getFullVisitDate(ByVal rep_id As String)
            Dim currentDate As DateTime = DateTime.Now
            Dim dtall As DataTable = Query("SELECT DATEPART(DAY, visit_date_plan) as daylist,count(DATEPART(DAY, visit_date_plan)) as cnt " & _
                                         "FROM t_visit WHERE rep_id = '" & rep_id & "' AND DATEPART(MONTH, visit_date_plan) =  DATEPART(MONTH, GETDATE()) " & _
                                         "AND DATEPART(YEAR, visit_date_plan) =  DATEPART(YEAR, GETDATE()) GROUP BY visit_date_plan;")
            Dim i As Integer = 0
            Dim arr_date(31) As String
            For j As Integer = 0 To 31
                GlobalClass.temp_arr_visit_plan_full_date(j) = Nothing
                GlobalClass.temp_arr_visit_plan_full_cnt(j) = Nothing
            Next

            For Each row As DataRow In dtall.Rows
                GlobalClass.temp_arr_visit_plan_full_date(i) = row("daylist").ToString()
                GlobalClass.temp_arr_visit_plan_full_cnt(i) = row("cnt").ToString()
                i = i + 1
            Next
        End Sub

        Public Function GetVisitNumber() As String
            Try
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SP_GET_NEW_VISIT_NUMBER", commandType:=CommandType.StoredProcedure)
                Return tb(0).NEW_VISIT_ID
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function
    End Class
End Namespace
