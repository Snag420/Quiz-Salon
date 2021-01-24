Public Class Pembayaran
    Dim strsql As String
    Dim info As String
    Private _idfk As System.Int32
    Private _Kode_Pembayaran As System.String
    Private _Tanggal_Pembayaran As System.DateTime
    Private _Kode_Pendaftaran As System.Int32
    Private _Biaya_Layanan As System.Int32
    Private _Biaya_Akhir As System.Int32
    Private _Dibayar As System.Int32
    Private _Kembali As System.String
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
    Public Property Tanggal_Pembayaran()
        Get
            Return _Tanggal_Pembayaran
        End Get
        Set(ByVal value)
            _Tanggal_Pembayaran = value
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
    Public Property Biaya_Akhir()
        Get
            Return _Biaya_Akhir
        End Get
        Set(ByVal value)
            _Biaya_Akhir = value
        End Set
    End Property
    Public Property Dibayar()
        Get
            Return _Dibayar
        End Get
        Set(ByVal value)
            _Dibayar = value
        End Set
    End Property
    Public Property Kembali()
        Get
            Return _Kembali
        End Get
        Set(ByVal value)
            _Kembali = value
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
        If (Pembayaran_baru = True) Then
            strsql = "Insert into Pembayaran(Kode_Pembayaran,Tanggal_Pembayaran,Kode_Pendaftaran,Biaya_Layanan,Biaya_Akhir,Dibayar,Kembali,Kode_Stylish) values ('" & _Kode_Pembayaran & "','" & _Tanggal_Pembayaran & "','" & _Kode_Pendaftaran & "','" & _Biaya_Layanan & "','" & _Biaya_Akhir & "','" & _Dibayar & "','" & _Kembali & "','" & _Kode_Stylish & "')"
            info = "INSERT"
        Else
            strsql = "update Pembayaran set Kode_Pembayaran='" & _Kode_Pembayaran & "', Tanggal_Pembayaran='" & _Tanggal_Pembayaran & "', Kode_Pendaftaran='" & _Kode_Pendaftaran & "', Biaya_Layanan='" & _Biaya_Layanan & "', Biaya_Akhir='" & _Biaya_Akhir & "', Dibayar='" & _Dibayar & "', Kembali='" & _Kembali & "', Kode_Stylish='" & _Kode_Stylish & "' where Kode_Pembayaran='" & _Kode_Pembayaran & "'"
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
    Public Sub CariPembayaran(ByVal sKode_Pembayaran As String)
        DBConnect()
        strsql = "SELECT * FROM Pembayaran WHERE Kode_Pembayaran='" & sKode_Pembayaran & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            Pembayaran_baru = False
            DR.Read()
            Kode_Pembayaran = Convert.ToString((DR("Kode_Pembayaran")))
            Tanggal_Pembayaran = Convert.ToString((DR("Tanggal_Pembayaran")))
            Kode_Pendaftaran = Convert.ToString((DR("Kode_Pendaftaran")))
            Biaya_Layanan = Convert.ToString((DR("Biaya_Layanan")))
            Biaya_Akhir = Convert.ToString((DR("Biaya_Akhir")))
            Dibayar = Convert.ToString((DR("Dibayar")))
            Kembali = Convert.ToString((DR("Kembali")))
            Kode_Stylish = Convert.ToString((DR("Kode_Stylish")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            Pembayaran_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sKode_Pembayaran As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM Pembayaran WHERE Kode_Pembayaran='" & sKode_Pembayaran & "'"
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
            strsql = "SELECT * FROM Pembayaran"
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
