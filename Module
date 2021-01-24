Imports System.Data.OleDb
Imports System.Security.Cryptography

Module MyMod
    Public mycommand As New System.Data.OleDb.OleDbCommand
    Public myadapter As New System.Data.OleDb.OleDbDataAdapter
    Public mydata As New DataTable
    Public DR As System.Data.OleDb.OleDbDataReader
    Public SQL As String
    Public conn As New OleDbConnection
    Public cn As New Connection

    'Tabel User
    '--------------------------------
    Public user_baru As Boolean
    Public oUser As New User
    '--------------------------------

    'Tabel Layanan
    '--------------------------------
    Public Layanan_baru As Boolean
    Public oLayanan As New Layanan
    '--------------------------------

    'Tabel Stylish
    '--------------------------------
    Public Stylish_baru As Boolean
    Public oStylish As New Stylish
    '--------------------------------

    'Tabel Pendaftaran
    '--------------------------------
    Public Pendaftaran_baru As Boolean
    Public oPendaftaran As New Pendaftaran
    '--------------------------------

    'Tabel Pembayaran
    '--------------------------------
    Public Pembayaran_baru As Boolean
    Public oPembayaran As New Pembayaran
    '--------------------------------

    'Tabel DetailPembayaran
    '--------------------------------
    Public DetailPembayaran_baru As Boolean
    Public oDetailPembayaran As New Detailpembayaran
    '--------------------------------

    'Tabel DetailPendaftaran
    '--------------------------------
    Public DetailPendaftaran_baru As Boolean
    Public oDetailPendaftaran As New Detailpendaftaran
    '--------------------------------
    Public login_valid As Boolean

    Public Sub DBConnect()
        cn.DataSource = "C:\Users\Asus A442U\Documents\data\umc.accdb"

        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

End Module
