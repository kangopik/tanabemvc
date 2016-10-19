Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class Im_rep

        Public con As SqlConnection
        Public con2 As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Sub connection2()
            Dim constr As String = ConfigurationManager.ConnectionStrings("HRDcon").ToString()
            con2 = New SqlConnection(constr)
        End Sub

        Public Function GetAllMasterRep() As List(Of m_repModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_region", "All")
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_repModel)(con, "SP_SELECT_REP", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetAllMasterRepByReg(ByVal reg As String) As List(Of m_repModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_region", Trim(reg))
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_repModel)(con, "SP_SELECT_REP", param, commandType:=CommandType.StoredProcedure)
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

        Public Function GetReg() As List(Of m_regionalModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_regionalModel)(con, "SELECT * FROM [v_m_regional] WHERE reg_status = 1")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetFunctionary() As List(Of m_repModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_repModel)(con, "SELECT rep_id, rep_full_name FROM [v_rep_full] WHERE rep_position NOT IN ('MR','PPM','PS')")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetInfoDetailAM(ByVal rep_id As String) As List(Of m_repModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_repModel)(con, "SELECT * FROM [dbo].[v_rep_full] WHERE [rep_id] = @rep_id", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetAm() As List(Of m_repModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_repModel)(con, "SELECT rep_id, rep_full_name FROM [v_rep_full] WHERE rep_position NOT IN ('RM')")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetEmployee() As List(Of AllKaryawanModel)
            Try
                connection2()
                con2.Open()
                Dim tb = SqlMapper.Query(Of AllKaryawanModel)(con2, "SELECT hrd.dbo.Karyawan.Nomor_Induk, hrd.dbo.Karyawan.Nama, hrd.dbo.HeadQuarter.Kode_Headquarter " &
                                                                    "FROM hrd.dbo.Karyawan INNER JOIN " &
                                                                    "hrd.dbo.Departemen ON hrd.dbo.Karyawan.Kode_Departemen = hrd.dbo.Departemen.Kode_Departemen INNER JOIN " &
                                                                    "hrd.dbo.Cabang ON hrd.dbo.Karyawan.Nama_Cabang = hrd.dbo.Cabang.Nama_Cabang INNER JOIN " &
                                                                    "hrd.dbo.HeadQuarter ON hrd.dbo.Departemen.Kode_Headquarter = hrd.dbo.HeadQuarter.Kode_Headquarter LEFT OUTER JOIN " &
                                                                    "hrd.dbo.Bagian ON hrd.dbo.Karyawan.[Kode Bagian] = hrd.dbo.Bagian.[Kode Bagian] INNER JOIN " &
                                                                    "hrd.dbo.Jabatan ON hrd.dbo.Jabatan.Kode_Jabatan = hrd.dbo.Karyawan.Kode_Jabatan " &
                                                                    "ORDER BY hrd.dbo.Karyawan.Nama")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con2.Close()
            End Try
        End Function

        Public Function GetEmployeeByNIK(nik As String) As List(Of AllKaryawanModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@nik", nik)
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of AllKaryawanModel)(con, "SELECT * FROM [dbo].[All_Karyawan] WHERE [Nomor Induk] = @nik AND [Kode_Headquarter] = 'MSHQ'", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetKodeDept(rep_id As String) As List(Of v_branchModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of v_branchModel)(con, "SELECT Kode_Departemen FROM [dbo].[All_Karyawan] WHERE [Nomor Induk] = @rep_id AND [Kode_Headquarter] = 'MSHQ'", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetDept() As List(Of DepartemenModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of DepartemenModel)(con, "SELECT rep_id, rep_full_name FROM [v_rep_full] WHERE rep_position NOT IN ('RM')")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetSBO() As List(Of v_branchModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of v_branchModel)(con, "select m_sbo.sbo_code, m_sbo.sbo_description, m_bo.bo_code, m_bo.bo_description from m_sbo left join m_bo on m_sbo.bo_code = m_bo.bo_code order by sbo_code asc")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetDivision() As List(Of m_divisionModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_divisionModel)(con, "SELECT * FROM [m_division]")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetAMS() As List(Of v_master_amModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of v_master_amModel)(con, "select distinct(bo_am), Nama  from [v_master_am] order by bo_am ASC")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetRMS() As List(Of v_master_amModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of v_master_amModel)(con, "select distinct(bo_am) as bo_rm, Nama  from [v_master_am] order by bo_am ASC")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetRepDetail(kode As String) As List(Of v_rep_fullModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_region", kode)
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of v_rep_fullModel)(con, "select rep_region,rep_rm,nama_rm FROM v_rep_full WHERE rep_region = @rep_region GROUP BY rep_region,rep_rm,nama_rm", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetSBODetail(sbo_code As String) As List(Of v_branchModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sbo_code", sbo_code)
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of v_branchModel)(con, "SELECT * FROM [dbo].[v_branch] WHERE [sbo_code] = @sbo_code", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function FindBO(sbo_code As String) As List(Of m_boModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sbo_code", sbo_code)
                connection()
                con.Open()
                Dim str = SqlMapper.Query(Of m_boModel)(con, "select bo_code from m_sbo where sbo_code = @sbo_code", param, commandType:=CommandType.Text)
                Return str.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function CekRep1(sbo As String) As List(Of m_repModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_sbo", Trim(sbo))
                connection()
                con.Open()
                Dim str = SqlMapper.Query(Of m_repModel)(con, "SELECT * FROM m_rep WHERE rep_sbo = @rep_sbo and rep_status = 1", param, commandType:=CommandType.Text)
                Return str.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function CekRep2(dr_sbo As String) As List(Of m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_sbo", Trim(dr_sbo))
                connection()
                con.Open()
                Dim str = SqlMapper.Query(Of m_doctorModel)(con, "SELECT * FROM m_doctor WHERE dr_sbo = @dr_sbo and dr_status = 1 and dr_used_session > 0", param, commandType:=CommandType.Text)
                Return str.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function CekRep3(dr_sbo As String) As List(Of m_doctorModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@dr_sbo", Trim(dr_sbo))
                connection()
                con.Open()
                Dim str = SqlMapper.Query(Of m_doctorModel)(con, "SELECT * FROM m_doctor WHERE dr_sbo = @dr_sbo and dr_status = 1 and dr_used_session > 0", param, commandType:=CommandType.Text)
                Return str.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function Mapping(rep_id As String, rep_region As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", Trim(rep_id))
                param.Add("@rep_region", Trim(rep_region))
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MAPPING_REGION", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Insert(obj As m_repModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", obj.rep_id)
                param.Add("@rep_name", obj.rep_name)
                param.Add("@rep_region", obj.rep_region)
                param.Add("@rep_bo", obj.rep_bo)
                param.Add("@rep_sbo", obj.rep_sbo)
                param.Add("@rep_position", obj.rep_position)
                param.Add("@rep_email", obj.rep_email)
                param.Add("@rep_division", obj.rep_division)
                param.Add("@rep_am", obj.rep_am)
                param.Add("@rep_status", obj.rep_status)
                connection()
                con.Open()
                con.Execute("SP_INSERT_REP", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Update(obj As m_repModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", obj.rep_id)
                param.Add("@rep_name", obj.rep_name)
                param.Add("@rep_region", obj.rep_region)
                param.Add("@rep_bo", obj.rep_bo)
                param.Add("@rep_sbo", obj.rep_sbo)
                param.Add("@rep_position", obj.rep_position)
                param.Add("@rep_email", obj.rep_email)
                param.Add("@rep_division", obj.rep_division)
                param.Add("@rep_am", obj.rep_am)
                param.Add("@rep_status", obj.rep_status)
                connection()
                con.Open()
                con.Execute("SP_UPDATE_REP", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Delete(ByVal rep_id As String) As Boolean
            Try
                Dim sqlQuery As String = "UPDATE m_rep SET rep_status = 0 WHERE rep_id =  @rep_id"
                connection()
                con.Open()
                con.Execute(sqlQuery, New With {rep_id})
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
