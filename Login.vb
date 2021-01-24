Public Class Form1
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        login_valid = oUser.Login(txtUsername.Text, txtPassword.Text)
        If (login_valid = True) Then
            MessageBox.Show("selamat datang di salon kami")
            Dashboard.Show()
            Me.Hide()
        Else
            MessageBox.Show("Login Not Valid")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub
    Private Sub ValidateUserLogin()
        oUser.Login(txtUsername.Text, txtPassword.Text)
        If (Login_Valid = True) Then

        End If
    End Sub
End Class
