Imports MySql.Data.MySqlClient
Public Class Form2
    Dim gender As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        openCon()
        con.Close()
        txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub cxHide_CheckedChanged(sender As Object, e As EventArgs) Handles cxHide.CheckedChanged
        If cxHide.Checked = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub rbMale_CheckedChanged(sender As Object, e As EventArgs) Handles rbMale.CheckedChanged
        gender = "Male"
    End Sub

    Private Sub rbFemale_CheckedChanged(sender As Object, e As EventArgs) Handles rbFemale.CheckedChanged
        gender = "Female"
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim register As String
        Dim role As String

        'if no field is left blank, go register
        If (txtRfidkey.Text <> "" And txtUsername.Text <> "" And txtPassword.Text <> "" And txtFullname.Text <> "" And
            txtRole.Text <> "" And (rbFemale.Checked Or rbMale.Checked) And txtAddress.Text <> "") Then

            openCon()
            'check if username has duplicate
            cmd.Connection = con
            register = "SELECT user_username FROM user_db WHERE user_username = '" & txtUsername.Text & "'"
            cmd = New MySqlCommand(register, con)
            reader = cmd.ExecuteReader()

            If (reader.HasRows) Then
                While reader.Read
                    MessageBox.Show("A user is already using this username! Please try again..", "Duplicate")
                    con.Close()
                    Exit Sub
                End While
            End If
            con.Close()

            If txtRole.Text = "1234" Then
                role = "admin"
            ElseIf txtRole.Text = "0000" Then
                role = "user"
            End If

            openCon()

            Try
                cmd.Connection = con
                register = "INSERT INTO user_db (`rfid_key`, `user_username`, `user_password`, `user_fullname`,
                        `login_role`, `user_gender`, `user_address`) VALUES ('" & txtRfidkey.Text & "', '" & txtUsername.Text & "',
                        '" & txtPassword.Text & "', '" & txtFullname.Text & "', '" & role & "',  '" & gender & "',
                        '" & txtAddress.Text & "') "

                cmd = New MySqlCommand(register, con)
                cmd.ExecuteNonQuery()
                MsgBox("Successfully added")
                con.Close()

                txtRfidkey.Clear()
                txtUsername.Clear()
                txtPassword.Clear()
                txtFullname.Clear()
                role = ""
                gender = ""
                txtAddress.Clear()

                Form1.Show()
                Me.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MessageBox.Show("Please try again and do not leave any field blank..", "Notice")
        End If

    End Sub


End Class