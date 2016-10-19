Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models
Imports TANABE_MVC.TANABE_MVC.Models

Namespace Repositories
    Public Class r_plan

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
        Dim myConnection As New SqlConnection(ConnectionString)
        Dim exTransaction As SqlTransaction

        Public Function GetVisitPlan(ByVal repId As String, ByVal day As String, ByVal month As String, ByVal year As String) As List(Of VisitPlanModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", repId)
                param.Add("@day", day)
                param.Add("@month", month)
                param.Add("@year", year)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of VisitPlanModel)(myConnection, "SP_SELECT_VISIT_PLAN", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Function GetDataDetail(ByVal drCode As String) As List(Of v_PlannedDetail)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", drCode)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of v_PlannedDetail)(myConnection, "SP_SELECT_DOCTOR_PLANNED_DETAIL", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Function GetDoctorList(ByVal repId As String, ByVal repPos As String) As List(Of m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", repId)
                param.Add("@rep_position", repPos)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of m_doctorModel)(myConnection, "SP_SELECT_DOCTOR_LIST_NEW", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Function GetDoctorRepInfo(ByVal rep_id As String) As Int32
            myConnection.Open()
            Dim cmd As New SqlCommand("SELECT count(*) FROM v_m_doctor WHERE  dr_rep = @rep_id", myConnection)
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            GetDoctorRepInfo = cmd.ExecuteScalar()
            myConnection.Close()
        End Function

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

        Sub SaveReport(ByVal rep_id As String)
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim sSQL As String = String.Empty

            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim curr_month As Int32 = currentDate.Month
                Dim curr_year As Int32 = currentDate.Year

                sSQL = "[SP_INSERT_TRANSACT_EMAIL]"
                myConnection.Open()
                cmd.Connection = myConnection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sSQL
                cmd.Parameters.AddWithValue("@rep_id", rep_id)
                cmd.Parameters.AddWithValue("@month", curr_month)
                cmd.Parameters.AddWithValue("@year", curr_year)
                cmd.Parameters.AddWithValue("@transaction_id", "RVP")
                cmd.Parameters.AddWithValue("@date_sent", CDate(currentDate).ToString("yyyy-MM-dd"))
                'cmd.Transaction = exTransaction
                cmd.ExecuteNonQuery()
                ' exTransaction.Commit()
            Catch ex As Exception
                'exTransaction.Rollback()
            Finally
                myConnection.Close()
            End Try


        End Sub

        Function isHaveRemainingToSendMail(ByVal email_type As String, ByVal rep_id As String) As Boolean
            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim curr_month As Int32 = currentDate.Month
                Dim curr_year As Int32 = currentDate.Year
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", curr_month)
                param.Add("@year", curr_year)
                param.Add("@transaction_id", email_type)
                param.Add("@date_sent", CDate(currentDate).ToString("yyyy-MM-dd"))
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SP_SELECT_TRANSACT_EMAIL", param, commandType:=CommandType.StoredProcedure)
                Return tb(0).is_pass
            Catch ex As Exception
                Return False
            Finally
                myConnection.Close()
            End Try
        End Function

        Function isAnyDayLessThenMinimumDoctor(ByVal rep_position As String, ByVal rep_id As String) As Boolean
            Try
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SELECT visit_date_plan,count(*) as visit_count FROM t_visit WHERE rep_id = '" & rep_id & "' AND DATEPART(MONTH, visit_date_plan) =  DATEPART(MONTH, GETDATE()) " & _
                                         "AND DATEPART(YEAR, visit_date_plan) =  DATEPART(YEAR, GETDATE()) AND visit_plan_verification_status = 0 AND dr_code > 100005 GROUP BY visit_date_plan", commandType:=CommandType.Text)
                'Dim visit_count As Integer = tb(0).visit_count
                Dim recordset As Integer = tb.Count
                Dim i As Integer = 0
                Do While i < recordset
                    Dim visit_count = tb(i).visit_count
                    If IsDBNull(visit_count) Then
                        Return True
                    Else
                        If Trim(rep_position) = "MR" Then
                            If CInt(visit_count) < 11 Then
                                Return True
                            End If
                        ElseIf Trim(rep_position) = "AM" Then
                            If CInt(visit_count) < 5 Then
                                Return True
                            End If
                        ElseIf Trim(rep_position) = "PPM" Then
                            If CInt(visit_count) < 4 Then
                                Return True
                            End If
                        ElseIf Trim(rep_position) = "PS" Then
                            If CInt(visit_count) < 6 Then
                                Return True
                            End If
                        End If
                    End If
                    i = i + 1
                Loop
                Return False
            Catch ex As Exception
                Return True
                Throw ex
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

        Function isAnyDoctorUnverificatedRealInPrevMonth(ByVal prevMonth As Int32, ByVal rep_id As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@dr_used_month_session", prevMonth)
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "select * from v_m_doctor where dr_used_month_session = @dr_used_month_session and dr_status = 1 and dr_rep = @rep_id", param, commandType:=CommandType.Text)
                Return tb.Count > 0
            Catch ex As Exception
                Return True
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Function isAnyDoctorUnplaned(ByVal month_req As String, ByVal rep_id As String) As Boolean
            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim curr_month As Int32 = currentDate.Month
                Dim curr_year As Int32 = currentDate.Year
                Dim curr_monthRequest As Int32 = month_req
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", curr_monthRequest)
                param.Add("@year", curr_year)
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SP_SELECT_IS_ANY_DOCTOR_UNPLANED", param, commandType:=CommandType.StoredProcedure)
                Dim str As String = tb(0).IS_ANY_DOC_UNPLANED
                Return tb(0).IS_ANY_DOC_UNPLANED
            Catch ex As Exception
                Return True
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Sub DeleteVisitPlan(ByVal visit_id As String)

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim sSQL As String = String.Empty

            sSQL = "[SP_DELETE_VISIT_PLAN]"
            Try
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sSQL
                cmd.Parameters.AddWithValue("@visit_id", visit_id)
                cmd.ExecuteNonQuery()
            Catch ex As Exception

            Finally
                conn.Close()
            End Try

        End Sub

        Public Sub ExecVisitPlan(ByVal rep_id As String, ByVal v_visit_date_plan As String, ByVal dr_code As String, ByVal rep_position As String)

            Dim currentDate As DateTime = DateTime.Now
            Dim curr_month As Int32 = currentDate.Month
            Dim curr_year As Int32 = currentDate.Year
            Dim currentDatePlan As DateTime = v_visit_date_plan 'date_planPicker.Value
            Dim curr_monthPlan As Int32 = currentDatePlan.Month
            Dim curr_yearPlan As Int32 = currentDatePlan.Year


            '1. BATAS MAKSIMUM KUNJUNGAN
            If (isMaxLimitedDoctorinCurrDayOnInit(v_visit_date_plan, rep_id, rep_position)) Then
                GlobalClass.temp_message_visit_plan = "You've exceeded the maximum limit doctor visits on that day." '"reach_maximum_doctor"
                Exit Sub
            End If


            If CInt(dr_code) < 100005 Then
                If (isAlreadyPlannedLeave(CDate(v_visit_date_plan).ToString("yyyy-MM-dd"), rep_id)) Then
                    GlobalClass.temp_message_visit_plan = "Leave code can not be paired with a doctor code." '"paired_code"
                    Exit Sub
                End If

            End If

            '3.TIDAK BOLEH ADA  DOKTER YANG SAMA DI HARI YANG SAMA

            If CInt(dr_code) > 100005 Then
                If (isAlreadyPlannedLeaveInCurrDay(CDate(v_visit_date_plan).ToString("yyyy-MM-dd"), rep_id)) Then
                    GlobalClass.temp_message_visit_plan = "Leave code can not be paired with a doctor code." '"paired_code"
                    'exTransaction.Rollback()
                    Exit Sub
                End If
            End If

            '4. 
            If Trim(rep_position) <> "AM" Then
                If curr_year = curr_yearPlan Then
                    If curr_monthPlan = curr_month Then
                        If curr_month = 1 Then
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, 12)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, 11)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                        ElseIf curr_month = 2 Then
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, curr_month - 1)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, curr_month - 12)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                        Else
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, curr_month - 1)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, curr_month - 2)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                        End If

                    ElseIf curr_monthPlan > curr_month Then
                        If curr_monthPlan = 2 Then
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, curr_month)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, 12)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                        Else
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, curr_month)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                            If (isDoctorUnverificatedRealInPrevMonth(dr_code, curr_month - 1)) Then
                                GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                                'exTransaction.Rollback()
                                Exit Sub
                            End If
                        End If

                    End If
                ElseIf curr_year < curr_yearPlan Then
                    If (isDoctorUnverificatedRealInPrevMonth(dr_code, 12)) Then
                        GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                        'exTransaction.Rollback()
                        Exit Sub
                    End If
                    If (isDoctorUnverificatedRealInPrevMonth(dr_code, 11)) Then
                        GlobalClass.temp_message_visit_plan = "Some doctor you have chosen are still tied to the realization visit in the previous month that has not been verified by your Manager." '"prev_month_unverificated_real_by_doc"
                        'exTransaction.Rollback()
                        Exit Sub
                    End If
                End If
            End If
            '=====================
            If (isMaxLimitedDoctorinCurrDayOnRunning(CDate(v_visit_date_plan).ToString("yyyy-MM-dd"), rep_id, rep_position)) Then
                GlobalClass.temp_message_visit_plan = "You've exceeded the maximum limit doctor visits on that day." '"reach_maximum_doctor"
                'exTransaction.Rollback()
                Exit Sub
            End If

            If (isAlreadyPlannedDoctorInCurrDay(CDate(v_visit_date_plan).ToString("yyyy-MM-dd"), dr_code, rep_id)) Then
                GlobalClass.temp_message_visit_plan = "There is already planned doctor with name " & GlobalClass.temp_doctor_planned_day_visit_plan & " on that day." '"already_planned_doctor" 
                'exTransaction.Rollback()
                Exit Sub
            End If

            If (isAlreadyPlannedDoctorInCurrWeek(CDate(v_visit_date_plan).ToString("yyyy-MM-dd"), dr_code, rep_id)) Then
                GlobalClass.temp_message_visit_plan = "There is already planned doctor with name " & GlobalClass.temp_doctor_planned_week_visit_plan & " on that week." '"already_planned_doctor_week"
                'exTransaction.Rollback()
                Exit Sub
            End If
            '=====================


            Dim visit_id As String = GetVisitNumber()
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim sSQL As String = String.Empty

            sSQL = "[SP_INSERT_VISIT_PLAN]"
            Try
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                'exTransaction = conn.BeginTransaction()
                cmd.Connection = conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sSQL
                cmd.Parameters.AddWithValue("@visit_id", visit_id)
                cmd.Parameters.AddWithValue("@rep_id", rep_id)
                cmd.Parameters.AddWithValue("@visit_date_plan", v_visit_date_plan)
                cmd.Parameters.AddWithValue("@dr_code", dr_code)
                cmd.Parameters.AddWithValue("@rep_position", rep_position)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                'exTransaction.Rollback()
                GlobalClass.temp_message_visit_plan = "There is error on save plan." '"error_on_save"
            Finally
                conn.Close()
            End Try
        End Sub

        Function isMaxLimitedDoctorinCurrDayOnInit(ByVal date_plan As Date, ByVal rep_id As String, ByVal rep_position As String) As Boolean

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty

            Try

                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                sSQL = "select count(*) as count_doc from t_visit where convert(date,visit_date_plan) = @visit_date_plan and rep_id = @rep_id"
                cmd.CommandText = sSQL
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@rep_id", rep_id)
                cmd.Parameters.AddWithValue("@visit_date_plan", CDate(date_plan).ToString("yyyy-MM-dd"))
                Dim doc_count As Int32 = cmd.ExecuteScalar()

                Select Case Trim(rep_position)
                    Case "MR"
                        If doc_count > 10 Then
                            Return True
                        Else
                            Return False
                        End If
                    Case "AM"
                        If doc_count > 4 Then
                            Return True
                        Else
                            Return False
                        End If
                    Case "PPM"
                        If doc_count > 3 Then
                            Return True
                        Else
                            Return False
                        End If
                    Case "PS"
                        If doc_count > 5 Then
                            Return True
                        Else
                            Return False
                        End If
                End Select


            Catch ex As Exception
                Return True         '// dibuat true karena kalau error pada sintax sql,  tetap tidak bisa input visit plan
            Finally
                conn.Close()
            End Try
        End Function

        Function isAlreadyPlannedLeave(ByVal date_plan As Date, ByVal rep_id As String) As Boolean

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty

            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            sSQL = "select * from t_visit where convert(date,visit_date_plan) = @visit_date_plan and rep_id = @rep_id and dr_code > 100005" 'ini tanyain knp < 100005 ???
            cmd.CommandText = sSQL
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@visit_date_plan", date_plan)
            cmd.Transaction = exTransaction
            Dim rd As SqlDataReader = cmd.ExecuteReader()

            Try

                rd.Read()
                If rd.HasRows Then
                    GlobalClass.temp_doctor_planned_day_visit_plan = rd("dr_name")
                    'Session("DoctorPlannedDay") = rd("dr_name")
                    rd.Close()
                    Return True         '//true ayaan 
                Else
                    rd.Close()
                    Return False        '//false eweuhan
                End If

            Catch ex As Exception
                rd.Close()
                conn.Close()
                Return True         '// dibuat true karena kalau error pada sintax sql,  tetap tidak bisa input
            End Try

        End Function

        Function isAlreadyPlannedLeaveInCurrDay(ByVal date_plan As Date, ByVal rep_id As String) As Boolean

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty

            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            sSQL = "select * from t_visit where convert(date,visit_date_plan) = @visit_date_plan and rep_id = @rep_id and dr_code < 100005" 'ini tanyain knp < 100005 ???
            cmd.CommandText = sSQL
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@visit_date_plan", date_plan)
            cmd.Transaction = exTransaction
            Dim rd As SqlDataReader = cmd.ExecuteReader()

            Try

                rd.Read()
                If rd.HasRows Then
                    GlobalClass.temp_doctor_planned_day_visit_plan = rd("dr_name")
                    'Session("DoctorPlannedDay") = rd("dr_name")
                    rd.Close()
                    Return True         '//true ayaan 
                Else
                    rd.Close()
                    Return False        '//false eweuhan
                End If

            Catch ex As Exception
                rd.Close()
                conn.Close()
                Return True
            Finally '// dibuat true karena kalau error pada sintax sql,  tetap tidak bisa input
                conn.Close()
            End Try

        End Function

        Function isDoctorUnverificatedRealInPrevMonth(ByVal dr_code As Int32, ByVal prevMonth As Int32) As Boolean

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            sSQL = "select * from v_m_doctor where dr_code = @dr_code and dr_used_month_session = @dr_used_month_session and dr_status = 1"
            cmd.CommandText = sSQL
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@dr_code", dr_code)
            cmd.Parameters.AddWithValue("@dr_used_month_session", prevMonth)
            cmd.Transaction = exTransaction
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            Try

                rd.Read()
                If rd.HasRows Then
                    rd.Close()
                    Return True         '//true ayaan keneh nu can di verifikasi real
                Else
                    rd.Close()
                    Return False        '//false eweuhan
                End If

            Catch ex As Exception
                rd.Close()
                conn.Close()
                Return True         '// dibuat true karena kalau error pada sintax sql,  tetap tidak bisa input visit
            Finally
                conn.Close()
            End Try

        End Function

        Function isAlreadyPlannedDoctorInCurrWeek(ByVal date_plan As Date, ByVal dr_code As String, ByVal rep_id As String) As Boolean

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            sSQL = "[SP_SELECT_IS_ALREADY_PLANNED_DOCTOR_IN_CURR_WEEK]"
            cmd.CommandText = sSQL
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@visit_date_plan", date_plan)
            cmd.Parameters.AddWithValue("@dr_code", dr_code)
            cmd.Transaction = exTransaction
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            Try


                rd.Read()
                If rd.HasRows Then
                    GlobalClass.temp_doctor_planned_week_visit_plan = rd("dr_name")
                    'Session("DoctorPlannedWeek") = rd("dr_name")
                    rd.Close()
                    Return True         '//true ayaan berarti aya doctor sarua di minggu yang sama
                Else
                    rd.Close()
                    Return False        '//false eweuhan
                End If

            Catch ex As Exception
                rd.Close()
                conn.Close()
                Return True         '// dibuat true karena kalau error pada sintax sql,  tetap tidak bisa input
            Finally
                conn.Close()
            End Try
        End Function

        Function isAlreadyPlannedDoctorInCurrDay(ByVal date_plan As Date, ByVal dr_code As String, ByVal rep_id As String) As Boolean
            'Session("DoctorPlanned") = Nothing
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            sSQL = "select * from v_visit_plan where convert(date,visit_date_plan) = @visit_date_plan and rep_id = @rep_id and dr_code = @dr_code"
            cmd.CommandText = sSQL
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@visit_date_plan", date_plan)
            cmd.Parameters.AddWithValue("@dr_code", dr_code)
            cmd.Transaction = exTransaction
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            Try


                rd.Read()
                If rd.HasRows Then
                    GlobalClass.temp_doctor_planned_day_visit_plan = rd("dr_name")
                    'Session("DoctorPlannedDay") = rd("dr_name")
                    rd.Close()
                    Return True         '//true ayaan 
                Else
                    rd.Close()
                    Return False        '//false eweuhan
                End If

            Catch ex As Exception
                conn.Close()
                rd.Close()
                Return True         '// dibuat true karena kalau error pada sintax sql,  tetap tidak bisa input
            Finally
                conn.Close()
            End Try

        End Function

        Function isMaxLimitedDoctorinCurrDayOnRunning(ByVal date_plan As Date, ByVal rep_id As String, ByVal rep_position As String) As Boolean
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty
            conn = New SqlConnection(ConfigClass.Get_Constring)

            Try
                conn.Open()
                sSQL = "select count(*) as count_doc from t_visit where convert(date,visit_date_plan) = @visit_date_plan and rep_id = @rep_id"
                cmd.CommandText = sSQL
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text

                cmd.Parameters.AddWithValue("@rep_id", rep_id)
                cmd.Parameters.AddWithValue("@visit_date_plan", CDate(date_plan).ToString("yyyy-MM-dd"))
                cmd.Transaction = exTransaction
                Dim doc_count As Int32 = cmd.ExecuteScalar()

                Select Case Trim(rep_position)
                    Case "MR"
                        If doc_count > 10 Then 'lebih dari 11
                            Return True
                        Else
                            Return False
                        End If
                    Case "AM"
                        If doc_count > 4 Then 'lebih dari 5
                            Return True
                        Else
                            Return False
                        End If
                    Case "PPM"
                        If doc_count > 3 Then 'lebih dari 4
                            Return True
                        Else
                            Return False
                        End If
                    Case "PS"
                        If doc_count > 5 Then 'lebih dari 6
                            Return True
                        Else
                            Return False
                        End If
                End Select
            Catch ex As Exception
                conn.Close()
                Return True
                '// dibuat true karena kalau error pada sintax sql,  tetap tidak bisa input visit plan
            Finally
                conn.Close()
            End Try
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

        Public Sub UpdatePlan(ByVal coll As FormCollection)
            Dim dr_code As String = coll("dr_code")
            Dim visit_id As String = coll("visit_id")
            Dim visit_date_plan As String = CDate(coll("visit_date_plan")).ToString("yyyy-MM-dd")

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim sSQL As String = String.Empty
            If dr_code = GlobalClass.temp_dr_code_ald_visit_plan Then
                sSQL = "update t_visit set visit_date_plan = @visit_date_plan where visit_id = @visit_id"
                Try
                    conn = New SqlConnection(ConfigClass.Get_Constring)
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sSQL
                    cmd.Parameters.AddWithValue("@visit_id", visit_id)
                    cmd.Parameters.AddWithValue("@visit_date_plan", visit_date_plan)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                Finally
                    conn.Close()
                End Try
            Else
                sSQL = "[SP_UPDATE_VISIT_PLAN]"
                Try
                    conn = New SqlConnection(ConfigClass.Get_Constring)
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = sSQL
                    cmd.Parameters.AddWithValue("@visit_id", visit_id)
                    cmd.Parameters.AddWithValue("@visit_date_plan", visit_date_plan)
                    cmd.Parameters.AddWithValue("@dr_code", dr_code)
                    cmd.Parameters.AddWithValue("@dr_code_old", GlobalClass.temp_dr_code_ald_visit_plan)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                Finally
                    conn.Close()
                End Try
            End If

        End Sub


        Public Function GetDataDoctor(ByVal repId As String, ByVal repPos As String) As List(Of m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", repId)
                param.Add("@rep_position", repPos)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of m_doctorModel)(myConnection, "SP_SELECT_DOCTOR_LIST_NEW_FOR_EDIT", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

    End Class
End Namespace
