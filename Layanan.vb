Public Class Layanan
    Dim strsql As String
    Dim info As String
    Private _idfk As System.Int32
    Private _Kode_Layanan As System.String
    Private _Nama_Layanan As System.String
    Private _Harga_Layanan As System.Int32
    Private _Status_Layanan As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property idfk()
        Get
            Return _idfk
        End Get
        Set(ByVal value)
            _idfk = value
        End Set
    End Property
    Public Property Kode_Layanan()
        Get
            Return _Kode_Layanan
        End Get
        Set(ByVal value)
            _Kode_Layanan = value
        End Set
    End Property
    Public Property Nama_Layanan()
        Get
            Return _Nama_Layanan
        End Get
        Set(ByVal value)
            _Nama_Layanan = value
        End Set
    End Property
    Public Property Harga_Layanan()
        Get
            Return _Harga_Layanan
        End Get
        Set(ByVal value)
            _Harga_Layanan = value
        End Set
    End Property
    Public Property Status_Layanan()
        Get
            Return _Status_Layanan
        End Get
        Set(ByVal value)
            _Status_Layanan = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (Layanan_baru = True) Then
            strsql = "Insert into Layanan(idfk,Kode_Layanan,Nama_Layanan,Harga_Layanan,Status_Layanan) values ('" & _idfk & "','" & _Kode_Layanan & "','" & _Nama_Layanan & "','" & _Harga_Layanan & "','" & _Status_Layanan & "')"
            info = "INSERT"
        Else
            strsql = "update Layanan set idfk='" & _idfk & "', Kode_Layanan='" & _Kode_Layanan & "', Nama_Layanan='" & _Nama_Layanan & "', Harga_Layanan='" & _Harga_Layanan & "', Status_Layanan='" & _Status_Layanan & "' where Kode_Layanan='" & _Kode_Layanan & "'"
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
    Public Sub CariLayanan(ByVal sidfk As String)
        DBConnect()
        strsql = "SELECT * FROM Layanan WHERE idfk='" & sidfk & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            Layanan_baru = False
            DR.Read()
            idfk = Convert.ToString((DR("idfk")))
            Kode_Layanan = Convert.ToString((DR("Kode_Layanan")))
            Nama_Layanan = Convert.ToString((DR("Nama_Layanan")))
            Harga_Layanan = Convert.ToString((DR("Harga_Layanan")))
            Status_Layanan = Convert.ToString((DR("Status_Layanan")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            Layanan_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sidfk As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM Layanan WHERE idfk='" & sidfk & "'"
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
            strsql = "SELECT * FROM Layanan"
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
