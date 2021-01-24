  Public Class Detailpendaftaran
    Dim strsql As String
    Dim info As String
    Private _idfk As System.Int32
    Private _Kode_Pendaftaran As System.String
    Private _Status_Pendaftaran As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property Kode_Pendaftaran()
        Get
            Return _Kode_Pendaftaran
        End Get
        Set(ByVal value)
            _Kode_Pendaftaran = value
        End Set
    End Property
    Public Property Status_Pendaftaran()
        Get
            Return _Status_Pendaftaran
        End Get
        Set(ByVal value)
            _Status_Pendaftaran = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (DetailPendaftaran_baru = True) Then
            strsql = "Insert into DetailPendaftaran(Kode_Pendaftaran,Status_Pendaftaran) values ('" & _Kode_Pendaftaran & "','" & _Status_Pendaftaran & "')"
            info = "INSERT"
        Else
            strsql = "update DetailPendaftaran set Kode_Pendaftaran='" & _Kode_Pendaftaran & "', Status_Pendaftaran='" & _Status_Pendaftaran & "' where Kode_Pendaftaran='" & _Kode_Pendaftaran & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub CariDetailPendaftaran(ByVal sKode_Pendaftaran As String)
        DBConnect()
        strsql = "SELECT * FROM DetailPendaftaran WHERE Kode_Pendaftaran='" & sKode_Pendaftaran & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            DetailPendaftaran_baru = False
            DR.Read()
            Kode_Pendaftaran = Convert.ToString((DR("Kode_Pendaftaran")))
            Status_Pendaftaran = Convert.ToString((DR("Status_Pendaftaran")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            DetailPendaftaran_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sKode_Pendaftaran As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM DetailPendaftaran WHERE Kode_Pendaftaran='" & sKode_Pendaftaran & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM DetailPendaftaran"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class
