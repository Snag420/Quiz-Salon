Public Class frmPembayaran
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SimpanPembayaran()
        GetData()
        frmDetailPembayaran.ShowDialog()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetData()
    End Sub

    Private Sub txtkodePembayaran_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKodePembayaran.KeyDown
        If (e.KeyCode = Keys.Enter And txtKodePembayaran.Text <> "") Then
            oPembayaran.CariPembayaran(txtKodePembayaran.Text)
            txtKodePendaftaran.Text = oPendaftaran.Kode_Pendaftaran
            txtBiayaLayanan.Text = oPembayaran.Biaya_Layanan
            txtBiayaAkhir.Text = oPembayaran.Biaya_Akhir
            txtDibayar.Text = oPembayaran.Dibayar
            txtKembali.Text = oPembayaran.Kembali
            txtKodeStylish.Text = oPembayaran.Kode_Stylish
        End If
    End Sub
    Private Sub ClearEntry()
        txtKodePembayaran.Clear()
        txtKodePendaftaran.Clear()
        txtBiayaLayanan.Clear()
        txtBiayaAkhir.Clear()
        txtDibayar.Clear()
        txtKembali.Clear()
        txtKodeStylish.Clear()
    End Sub
    Private Sub TampilData()
        txtKodePembayaran.Text = oPembayaran.Kode_Pembayaran
        txtKodePendaftaran.Text = oPembayaran.Kode_Pembayaran
        txtBiayaLayanan.Text = oPembayaran.Biaya_Layanan
        txtBiayaAkhir.Text = oPembayaran.Biaya_Akhir
        txtDibayar.Text = oPembayaran.Dibayar
        txtKembali.Text = oPembayaran.Kembali
        txtKodeStylish.Text = oPembayaran.Kode_Stylish
    End Sub
    Private Sub SimpanPembayaran()
        Pembayaran_baru = True
        oPembayaran.Kode_Pembayaran = txtKodePembayaran.Text
        oPembayaran.Kode_Pendaftaran = txtKodePendaftaran.Text
        oPembayaran.Biaya_Layanan = txtBiayaLayanan.Text
        oPembayaran.Biaya_Akhir = txtBiayaAkhir.Text
        oPembayaran.Dibayar = txtDibayar.Text
        oPembayaran.Kembali = txtKembali.Text
        oPembayaran.Kode_Stylish = txtKodeStylish.Text
    End Sub
    Private Sub GetData()
        oPembayaran.getAllData(DataGridView1)
    End Sub
End Class
