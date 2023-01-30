Public Class Form1
    Dim dgv As New DataTable("dgv")
    Dim index As Integer

    Private Sub btnave1_Click(sender As Object, e As EventArgs) Handles btnave1.Click
        Try
            Dim cp As New Double
            Dim quiz As New Double
            Dim major As New Double
            Dim ave As New Double

            cp = txtcpart.Text
            quiz = txtquiz.Text
            major = txtmajor.Text

            ave = (cp * 0.2) + (quiz * 0.3) + (major * 0.5)
            txtgrade.Text = ave

        Catch ex As Exception
            MessageBox.Show("Please enter a number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim msg As String

        msg = MessageBox.Show("Do you want to save?" & vbNewLine & vbNewLine & cbterm.Text & vbNewLine & vbNewLine & "Class Participation: " & txtcpart.Text & vbNewLine & "Quizzes: " & txtquiz.Text & vbNewLine & "Major Exam: " & txtmajor.Text & vbNewLine & "Term Grade: " & txtgrade.Text, "Confirm Informations", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)

        If msg = DialogResult.Yes Then
            If cbterm.Text = "MIDTERM" Then
                txtmidg.Text = txtgrade.Text
            ElseIf cbterm.Text = "FINAL" Then
                txtfinalg.Text = txtgrade.Text
            Else
                MsgBox("Please select term")
            End If
            txtcpart.Clear()
            txtquiz.Clear()
            txtmajor.Clear()
            txtgrade.Clear()
        End If
    End Sub

    Private Sub btnave2_Click(sender As Object, e As EventArgs) Handles btnave2.Click
        Dim finalg As New Double
        Dim midg As New Double
        Dim finalave As New Double

        finalg = txtfinalg.Text
        midg = txtmidg.Text

        finalave = (midg * 0.5) + (finalg * 0.5)
        txtfinalave.Text = finalave

        '96-100 A+,91-95 A,86-90 B+,81-85 B,76-80 C+,71-75 C,66-70 D+,61-65 D,56-60 E+,51-55 E,54 below F
        If txtfinalave.Text >= 96 And txtfinalave.Text <= 100 Then
            txtletter.Text = "A+"
        ElseIf txtfinalave.Text >= 91 And txtfinalave.Text <= 95 Then
            txtletter.Text = "A"
        ElseIf txtfinalave.Text >= 86 And txtfinalave.Text <= 90 Then
            txtletter.Text = "B+"
        ElseIf txtfinalave.Text >= 81 And txtfinalave.Text <= 85 Then
            txtletter.Text = "B"
        ElseIf txtfinalave.Text >= 76 And txtfinalave.Text <= 80 Then
            txtletter.Text = "C+"
        ElseIf txtfinalave.Text >= 71 And txtfinalave.Text <= 75 Then
            txtletter.Text = "C"
        ElseIf txtfinalave.Text >= 66 And txtfinalave.Text <= 70 Then
            txtletter.Text = "D+"
        ElseIf txtfinalave.Text >= 61 And txtfinalave.Text <= 65 Then
            txtletter.Text = "D"
        ElseIf txtfinalave.Text >= 56 And txtfinalave.Text <= 60 Then
            txtletter.Text = "E+"
        ElseIf txtfinalave.Text >= 51 And txtfinalave.Text <= 55 Then
            txtletter.Text = "E"
        ElseIf txtfinalave.Text < 54 Then
            txtletter.Text = "F"
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtsnum.Clear()
        txtlname.Clear()
        txtfname.Clear()
        txtsub.Clear()
        txtcpart.Clear()
        txtquiz.Clear()
        txtmajor.Clear()
        txtgrade.Clear()
        txtmidg.Clear()
        txtfinalg.Clear()
        txtfinalave.Clear()
        txtletter.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ex As String
        ex = MessageBox.Show("Are you sure you want to exit? ", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ex = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.Columns.Add("Student Number", Type.GetType("System.Int32"))
        dgv.Columns.Add("Last Name", Type.GetType("System.String"))
        dgv.Columns.Add("First Name", Type.GetType("System.String"))
        dgv.Columns.Add("Subject", Type.GetType("System.String"))
        dgv.Columns.Add("Final Average", Type.GetType("System.Double"))
        dgv.Columns.Add("Letter Grade", Type.GetType("System.String"))
        dgvData.DataSource = dgv

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        dgv.Rows.Add(txtsnum.Text, txtlname.Text, txtfname.Text, txtsub.Text, txtfinalave.Text, txtletter.Text)
        dgvData.DataSource = dgv
    End Sub

    Private Sub dgvData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellClick
        index = e.RowIndex
        Dim selected As DataGridViewRow
        selected = dgvData.Rows(index)

        txtsnum.Text = selected.Cells(0).Value.ToString
        txtlname.Text = selected.Cells(1).Value.ToString
        txtfname.Text = selected.Cells(2).Value.ToString
        txtsub.Text = selected.Cells(3).Value.ToString
        txtfinalave.Text = selected.Cells(4).Value.ToString
        txtletter.Text = selected.Cells(5).Value.ToString
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim newData As DataGridViewRow

        newData = dgvData.Rows(index)
        newData.Cells(0).Value = txtsnum.Text
        newData.Cells(1).Value = txtlname.Text
        newData.Cells(2).Value = txtfname.Text
        newData.Cells(3).Value = txtsub.Text
        newData.Cells(4).Value = txtfinalave.Text
        newData.Cells(5).Value = txtletter.Text
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        dgvData.Rows.RemoveAt(index)
    End Sub
End Class
