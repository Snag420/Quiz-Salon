Public Class Detailpembayaran
    Dim strsql As String
    Dim info As String
    Private _idfk As System.Int32
    Private _Kode_Pembayaran As System.String
    Private _Kode_Pendaftaran As System.String
    Private _Biaya_Layanan As System.Int32
    Private _Kode_Stylish As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property Kode_Pembayaran()
        Get
            Return _Kode_Pembayaran
        End Get
        Set(ByVal value)
            _Kode_Pembayaran = value
        End Set
    End Property
    Public Property Kode_Pendaftaran()
        Get
            Return _Kode_Pendaftaran
        End Get
        Set(ByVal value)
            _Kode_Pendaftaran = value
        End Set
    End Property
    Public Property Biaya_Layanan()
        Get
            Return _Biaya_Layanan
        End Get
        Set(ByVal value)
            _Biaya_Layanan = value
        End Set
    End Property
    Public Property Kode_Stylish()
        Get
            Return _Kode_Stylish
        End Get
        Set(ByVal value)
            _Kode_Stylish = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (DetailPembayaran_baru = True) Then
            strsql = "Insert into DetailPembayaran(Kode_Pembayaran,Kode_Pendaftaran,Biaya_Layanan,Kode_Stylish) values ('" & _Kode_Pembayaran & "','" & _Kode_Pendaftaran & "','" & _Biaya_Layanan & "','" & _Kode_Stylish & "')"
            info = "INSERT"
        Else
            strsql = "update DetailPembayaran set Kode_Pembayaran='" & _Kode_Pembayaran & "', Kode_Pendaftaran='" & _Kode_Pendaftaran & "', Biaya_Layanan='" & _Biaya_Layanan & "', Kode_Stylish='" & _Kode_Stylish & "' where Kode_Pembayaran='" & _Kode_Pembayaran & "'"
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
    Public Sub CariDetailPembayaran(ByVal sKode_Pembayaran As String)
        DBConnect()
        strsql = "SELECT * FROM DetailPembayaran WHERE Kode_Pembayaran='" & sKode_Pembayaran & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            DetailPembayaran_baru = False
            DR.Read()
            Kode_Pembayaran = Convert.ToString((DR("Kode_Pembayaran")))
            Kode_Pendaftaran = Convert.ToString((DR("Kode_Pendaftaran")))
            Biaya_Layanan = Convert.ToString((DR("Biaya_Layanan")))
            Kode_Stylish = Convert.ToString((DR("Kode_Stylish")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            DetailPembayaran_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sKode_Pembayaran As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM DetailPembayaran WHERE Kode_Pembayaran='" & sKode_Pembayaran & "'"
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
            strsql = "SELECT * FROM DetailPembayaran"
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
