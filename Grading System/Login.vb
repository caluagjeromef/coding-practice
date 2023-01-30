Public Class Login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtbUser.Text = "admin1" And txtbPass.Text = "admin1" Or txtbUser.Text = "admin2" And txtbPass.Text = "admin2" Then
            MessageBox.Show("You are now logged in", "Log in Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form1.Show()
            txtbUser.Clear()
            txtbPass.Clear()
        Else
            MessageBox.Show("Invalid Username and/or Password", "Log in Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtbUser.Clear()
            txtbPass.Clear()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ex As String
        ex = MessageBox.Show("Are you sure you want to exit? ", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ex = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class