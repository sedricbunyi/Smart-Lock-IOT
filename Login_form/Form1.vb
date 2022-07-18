Imports MySql.Data.MySqlClient

Public Class Form1
    Dim atemp As Integer = 0
    Public username As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        openCon()
        MsgBox("Connected")
        con.Close()
        txtPassword.UseSystemPasswordChar = True
        Me.txtUsername.Select() 'selects username tb 
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim query As String
        Dim count As Integer
        Dim arole As String = "admin"
        openCon()

        Try
            cmd.Connection = con
            query = "SELECT * FROM user_db WHERE user_username = '" & txtUsername.Text & "' AND user_password = '" & txtPassword.Text & "' "
            cmd = New MySqlCommand(query, con)
            reader = cmd.ExecuteReader

            count = 0
            While reader.Read
                count = count + 1
            End While

            con.Close()

            If count = 1 Then

                openCon()
                username = txtUsername.Text
                cmd.Connection = con
                query = "SELECT * FROM user_db WHERE user_username = '" & txtUsername.Text & "' AND login_role = '" & arole & "' "
                cmd = New MySqlCommand(query, con)
                reader = cmd.ExecuteReader

                count = 0
                While reader.Read
                    count = count + 1
                End While

                con.Close()
                If count = 1 Then
                    Admin.Show()
                    Me.Close()
                Else
                    User.Show()
                    Me.Close()
                End If

            ElseIf count > 1 Then
                MsgBox("Username and Password Duplicate")
            Else
                atemp += 1
                'force close for 5 wrong attempts
                If (atemp = 5) Then
                    MessageBox.Show("You have reached the maximum login attempts. Please try again later..", "Notice")
                    Me.Close()
                End If

                If txtPassword.Text = "" And txtUsername.Text = "" Then
                    MsgBox(String.Format("Please enter a username and a password. Attempt ({0})", atemp),, Title:="Login")
                    txtUsername.Select()
                ElseIf txtUsername.Text <> "" And txtPassword.Text = "" Then
                    MsgBox(String.Format("Please enter a password. Attempt ({0})", atemp),, Title:="Login")
                    txtUsername.Select()
                ElseIf txtUsername.Text = "" And txtPassword.Text <> "" Then
                    MsgBox(String.Format("Please enter a username. Attempt ({0})", atemp),, Title:="Login")
                    txtUsername.Select()
                Else
                    MsgBox(String.Format("Incorrect username or password. Try Again. Attempt ({0})", atemp),, Title:="Login")
                    txtUsername.Select()
                End If

                'txtUsername.Clear()
                'txtPassword.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Form2.Show()
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        'pressing "enter" matik click login button
        If Asc(e.KeyChar) = 13 Then
            btnLogin.PerformClick()
            e.Handled = True
        End If
    End Sub
End Class
