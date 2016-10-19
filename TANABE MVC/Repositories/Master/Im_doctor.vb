Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class Im_doctor

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function GetAllMasterDoctor() As List(Of m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_region", "All")
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_doctorModel)(con, "SP_SELECT_MASTER_DOCTOR", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetAllMasterDoctorByReg(ByVal reg As String) As List(Of m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_region", Trim(reg))
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_doctorModel)(con, "SP_SELECT_MASTER_DOCTOR", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function CekDokter(dr_code As String) As List(Of m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", Convert.ToInt32(dr_code))
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_doctorModel)(con, "SELECT * FROM m_doctor WHERE dr_code = @dr_code AND dr_used_session = 0", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function CekDokterStillPlaned(dr_code As String) As Integer
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", Convert.ToInt32(dr_code))
                connection()
                con.Open()
                Dim tb As Integer = con.Query(Of Integer)("SELECT count(*) as jml_doc FROM m_doctor WHERE dr_code = @dr_code and dr_status = 1 and dr_used_session > 0", param, commandType:=CommandType.Text).Single()
                If (tb = Nothing) Then
                    Return 0
                Else
                    Return tb
                End If
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function CekDokterAlreadyPlaned(dr_sbo As String) As Integer
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_sbo", dr_sbo)
                connection()
                con.Open()
                Dim tb As Integer = con.Query(Of Integer)("SELECT count(*) as jml_doc FROM m_doctor WHERE dr_sbo = @dr_sbo and dr_status = 1 and dr_used_session > 0", param, commandType:=CommandType.Text).Single()
                If (tb = Nothing) Then
                    Return 0
                Else
                    Return tb
                End If
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetDoctorSBO(dr_code As String) As List(Of m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", Convert.ToInt32(dr_code))
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_doctorModel)(con, "SELECT dr_sbo FROM m_doctor WHERE dr_code = @dr_code", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetRegion() As List(Of m_repModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_repModel)(con, "SELECT rep_rm,rep_region, nama_rm FROM [v_rep_full] GROUP BY rep_rm,rep_region, nama_rm")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetSboFull() As List(Of v_branchModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of v_branchModel)(con, "SELECT * FROM v_sbo_full")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetSpec() As List(Of m_specModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_specModel)(con, "SELECT * FROM [m_spec]")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetQuad() As List(Of m_quadrantModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_quadrantModel)(con, "SELECT * FROM [m_quadrant]")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetCategory() As List(Of m_categoryModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_categoryModel)(con, "SELECT * FROM [m_category]")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetDoctorCode(sbo_code As String) As List(Of DoctorCodeModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sbo_code", sbo_code)
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of DoctorCodeModel)(con, "SP_GET_NEW_DOCTOR_CODE", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function MappingSBO(dr_code As String, dr_sbo As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", Convert.ToInt32(Trim(dr_code)))
                param.Add("@dr_sbo", Trim(dr_sbo))
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MAPPING_SBO", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function MappingStatus(dr_code As String, dr_status As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", Convert.ToInt32(Trim(dr_code)))
                param.Add("@dr_status", Convert.ToInt32(Trim(dr_status)))
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MAPPING_STATUS", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function MappingQuadrant(dr_code As String, dr_quadrant As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", Convert.ToInt32(Trim(dr_code)))
                param.Add("@dr_quadrant", Trim(dr_quadrant))
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MAPPING_QUADRANT", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Insert(obj As m_doctorModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", obj.dr_code)
                param.Add("@dr_sbo", obj.dr_sbo)
                param.Add("@dr_name", obj.dr_name)
                param.Add("@dr_spec", obj.dr_spec)
                param.Add("@dr_sub_spec", obj.dr_sub_spec)
                param.Add("@dr_quadrant", obj.dr_quadrant)
                param.Add("@dr_monitoring", obj.dr_monitoring)
                param.Add("@dr_address", obj.dr_address)
                param.Add("@dr_area_mis", obj.dr_area_mis)
                param.Add("@dr_category", obj.dr_category)
                param.Add("@dr_sub_category", obj.dr_sub_category)
                param.Add("@dr_chanel", obj.dr_chanel)
                param.Add("@dr_day_visit", obj.dr_day_visit)
                param.Add("@dr_visiting_hour", obj.dr_visiting_hour)
                param.Add("@dr_number_patient", obj.dr_number_patient)
                param.Add("@dr_kol_not", obj.dr_kol_not)
                param.Add("@dr_gender", obj.dr_gender)
                param.Add("@dr_phone", obj.dr_phone)
                param.Add("@dr_email", obj.dr_email)
                param.Add("@dr_birthday", obj.dr_birthday)
                param.Add("@dr_dk_lk", obj.dr_dk_lk)
                param.Add("@dr_status", obj.dr_status)
                connection()
                con.Open()
                con.Execute("SP_INSERT_MASTER_DOCTOR", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Update(obj As m_doctorModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_code", obj.dr_code)
                param.Add("@dr_sbo", obj.dr_sbo)
                param.Add("@dr_name", obj.dr_name)
                param.Add("@dr_spec", obj.dr_spec)
                param.Add("@dr_sub_spec", obj.dr_spec)
                param.Add("@dr_quadrant", obj.dr_quadrant)
                param.Add("@dr_monitoring", obj.dr_monitoring)
                param.Add("@dr_address", obj.dr_address)
                param.Add("@dr_area_mis", obj.dr_area_mis)
                param.Add("@dr_category", obj.dr_category)
                param.Add("@dr_sub_category", obj.dr_sub_category)
                param.Add("@dr_chanel", obj.dr_chanel)
                param.Add("@dr_day_visit", obj.dr_day_visit)
                param.Add("@dr_visiting_hour", obj.dr_visiting_hour)
                param.Add("@dr_number_patient", obj.dr_number_patient)
                param.Add("@dr_kol_not", obj.dr_kol_not)
                param.Add("@dr_gender", obj.dr_gender)
                param.Add("@dr_phone", obj.dr_phone)
                param.Add("@dr_email", obj.dr_email)
                param.Add("@dr_birthday", obj.dr_birthday)
                param.Add("@dr_dk_lk", obj.dr_dk_lk)
                param.Add("@dr_status", obj.dr_status)
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MASTER_DOCTOR", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Delete(ByVal dr_code As Integer) As Boolean
            Try
                Dim sqlQuery As String = "DELETE FROM m_doctor WHERE dr_code = @dr_code"
                connection()
                con.Open()
                con.Execute(sqlQuery, New With {dr_code})
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
