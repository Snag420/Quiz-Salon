Public Class Stylish
    Dim strsql As String
    Dim info As String
    Private _idfk As System.Int32
    Private _Kode_Stylish As System.String
    Private _Nama_Stylish As System.String
    Private _Status_Stylish As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property Kode_Stylish()
        Get
            Return _Kode_Stylish
        End Get
        Set(ByVal value)
            _Kode_Stylish = value
        End Set
    End Property
    Public Property Nama_Stylish()
        Get
            Return _Nama_Stylish
        End Get
        Set(ByVal value)
            _Nama_Stylish = value
        End Set
    End Property
    Public Property Status_Stylish()
        Get
            Return _Status_Stylish
        End Get
        Set(ByVal value)
            _Status_Stylish = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (stylish_baru = True) Then
            strsql = "Insert into stylish(Kode_Stylish,Nama_Stylish,Status_Stylish) values ('" & _Kode_Stylish & "','" & _Nama_Stylish & "','" & _Status_Stylish & "')"
            info = "INSERT"
        Else
            strsql = "update stylish set Kode_Stylish='" & _Kode_Stylish & "', Nama_Stylish='" & _Nama_Stylish & "', Status_Stylish='" & _Status_Stylish & "' where Kode_Stylish='" & _Kode_Stylish & "'"
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
    Public Sub Caristylish(ByVal sKode_Stylish As String)
        DBConnect()
        strsql = "SELECT * FROM stylish WHERE Kode_Stylish='" & sKode_Stylish & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            stylish_baru = False
            DR.Read()
            Kode_Stylish = Convert.ToString((DR("Kode_Stylish")))
            Nama_Stylish = Convert.ToString((DR("Nama_Stylish")))
            Status_Stylish = Convert.ToString((DR("Status_Stylish")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            stylish_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sKode_Stylish As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM stylish WHERE Kode_Stylish='" & sKode_Stylish & "'"
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
            strsql = "SELECT * FROM stylish"
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
