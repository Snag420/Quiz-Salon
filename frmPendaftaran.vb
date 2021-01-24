Public Class frmPendaftaran
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SimpanPendaftaran()
        GetData()
        frmDetailPendaftaran.ShowDialog()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetData()
    End Sub

    Private Sub txtkodePendaftaran_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKodePendaftaran.KeyDown
        If (e.KeyCode = Keys.Enter And txtKodePendaftaran.Text <> "") Then
            oPendaftaran.CariPendaftaran(txtKodePendaftaran.Text)
            txtKodeCustomer.Text = oPendaftaran.Kode_Pendaftaran
            txtStatusPendaftaran.Text = oPendaftaran.Status_Pendaftaran
        End If
    End Sub
    Private Sub ClearEntry()
        txtKodePendaftaran.Clear()
        txtKodeCustomer.Clear()
        txtStatusPendaftaran.Clear()
    End Sub
    Private Sub TampilData()
        txtKodePendaftaran.Text = oPendaftaran.Kode_Pendaftaran
        txtKodeCustomer.Text = oPendaftaran.Kode_Pendaftaran
        txtStatusPendaftaran.Text = oPendaftaran.Status_Pendaftaran
    End Sub
    Private Sub SimpanPendaftaran()
        Pendaftaran_baru = True
        oPendaftaran.Kode_Pendaftaran = txtKodePendaftaran.Text
        oPendaftaran.Kode_Pendaftaran = txtKodeCustomer.Text
        oPendaftaran.Status_Pendaftaran = txtStatusPendaftaran.Text
    End Sub
    Private Sub GetData()
        oPendaftaran.getAllData(DataGridView1)
    End Sub
End Class
