Public Class AlterPassword

    Public isAllowed As Boolean = False
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click

        Close()

    End Sub
    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click

        isAllowed = verify()
        If Not verify() Then
            TTip.Show("Wrong password..!", BtnSubmit, 0, 25, 2000)
            TxtPassword.SelectAll()
            TxtPassword.Focus()
            Exit Sub
        End If
        Close()

    End Sub

    Private Sub AlterPassword_Load(sender As Object, e As EventArgs) Handles Me.Load

        isAllowed = False
        TxtPassword.Clear()
        TxtPassword.Select()

    End Sub

    Private Sub AlterPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Me.ActiveControl.Tag <> "1" Then
                e.SuppressKeyPress = True
                Me.ProcessTabKey(True)
            End If
        End If

    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPassword.KeyDown

        If e.KeyCode = Keys.Enter Then
            BtnSubmit.PerformClick()
        End If

    End Sub

    Private Function verify() As Boolean

        Return IIf(TxtPassword.Text.Trim = alterPwd, True, False)

    End Function

End Class