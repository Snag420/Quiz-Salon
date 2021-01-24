Public Class frmLayanan
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SimpanLayanan()
        GetData()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetData()
    End Sub

    Private Sub txtkode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKode.KeyDown
        If (e.KeyCode = Keys.Enter And txtKode.Text <> "") Then
            oLayanan.CariLayanan(txtKode.Text)
            txtNama.Text = oLayanan.Nama_Layanan
            txtHarga.Text = oLayanan.Harga_Layanan
        End If
    End Sub
    Private Sub ClearEntry()
        txtKode.Clear()
        txtNama.Clear()
        txtHarga.Clear()
    End Sub
    Private Sub TampilData()
        txtKode.Text = oLayanan.Kode_Layanan
        txtNama.Text = oLayanan.Nama_Layanan
        txtHarga.Text = oLayanan.Harga_Layanan
    End Sub
    Private Sub SimpanLayanan()
        Layanan_baru = True
        oLayanan.Kode_Layanan = txtKode.Text
        oLayanan.Nama_Layanan = txtNama.Text
        oLayanan.Harga_Layanan = txtHarga.Text
    End Sub
    Private Sub GetData()
        oLayanan.getAllData(DataGridView1)
    End Sub
End Class
