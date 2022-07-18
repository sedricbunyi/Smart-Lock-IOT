Imports MySql.Data.MySqlClient
Imports System.IO
Imports Sytem.IO.Ports

Public Class Admin
    Dim userdatabase As String
    Dim userhistory As String
    Dim user_id As Integer
    Dim gen As String

    Private Sub btnShowall_Click(sender As Object, e As EventArgs) Handles btnShowall.Click
        openCon()

        userdatabase = "SELECT * FROM user_db"

        Dim myadapter As New MySqlDataAdapter(userdatabase, con)
        Dim mydatatable As New DataTable
        myadapter.Fill(mydatatable)
        DataGrid1.DataSource = mydatatable

        con.Close()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        openCon()
        Dim search As MySqlCommand = New MySqlCommand("SELECT * FROM user_db WHERE user_fullname LIKE '%" & txtSearch.Text & "%' ", con)
        Dim confirmds As New DataSet
        Dim confirmda As New MySqlDataAdapter
        confirmda.SelectCommand = search
        confirmda.Fill(confirmds, "entry")
        DataGrid1.DataSource = confirmds.Tables(0)
        con.Close()

        Dim myDataTableCurr As New DataTable
        Try
            confirmda.Fill(myDataTableCurr)
            If myDataTableCurr.Rows.Count > 0 Then
                user_id = myDataTableCurr.Rows(0).Item("user_id")
                txtRfidkey.Text = myDataTableCurr.Rows(0).Item("rfid_key")
                txtUsername.Text = myDataTableCurr.Rows(0).Item("user_username")
                txtFullname.Text = myDataTableCurr.Rows(0).Item("user_fullname")
                txtPassword.Text = myDataTableCurr.Rows(0).Item("user_password")
                txtRole.Text = myDataTableCurr.Rows(0).Item("login_role")
                txtAddress.Text = myDataTableCurr.Rows(0).Item("user_address")

                gen = myDataTableCurr.Rows(0).Item("user_gender")

                If gen = "Male" Then
                    rbMale.Checked = True
                Else
                    rbFemale.Checked = True
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If (txtFullname.Text = "") Then
            MessageBox.Show("No item to update!", "Notice")
        Else
            Dim tr As MySqlTransaction
            openCon()
            tr = con.BeginTransaction
            cmd.Transaction = tr
            cmd.Connection = con

            cmd.CommandText = "UPDATE user_db set user_fullname = '" & txtFullname.Text & "' WHERE user_id = '" & user_id & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE user_db set user_username = '" & txtUsername.Text & "' WHERE user_id = '" & user_id & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE user_db set user_password = '" & txtPassword.Text & "' WHERE user_id = '" & user_id & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE user_db set rfid_key = '" & txtRfidkey.Text & "' WHERE user_id = '" & user_id & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE user_db set login_role = '" & txtRole.Text & "' WHERE user_id = '" & user_id & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE user_db set user_gender = '" & gen & "' WHERE user_id = '" & user_id & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE user_db set user_address = '" & txtAddress.Text & "' WHERE user_id = '" & user_id & "' "
            cmd.ExecuteNonQuery()

            MsgBox("Update Successed")
            tr.Commit()
            con.Close()
        End If
    End Sub

    Private Sub btnViewhistory_Click(sender As Object, e As EventArgs) Handles btnViewhistory.Click
        openCon()

        userhistory = "SELECT rfid_key, user_fullname, datetime_log FROM user_db
                       JOIN user_history ON user_history.user_id = user_db.user_id  
                       WHERE user_db.rfid_key = '%" & txtViewhistory.Text & "%' "

        Dim myhadapter As New MySqlDataAdapter(userhistory, con)
        Dim myhistorytable As New DataTable
        myhadapter.Fill(myhistorytable)
        DataGrid2.DataSource = myhistorytable

        con.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If (txtFullname.Text = "") Then
            MessageBox.Show("No item to delete!", "Notice")
        Else
            Dim result As DialogResult = MsgBox("Are you sure you want to delete data?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = Windows.Forms.DialogResult.Yes Then
                openCon()

                Dim cmd As MySqlCommand = New MySqlCommand("DELETE FROM user_db WHERE user_id = '" & user_id & "' ", con)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If (i > 0) Then
                    MsgBox("Deleted Successfuly")
                Else
                    MsgBox("User is not Deleted")
                End If

                con.Close()

            End If
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        'validate logout
        Dim out As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo)

        If out = DialogResult.Yes Then
            Me.Hide()
            MessageBox.Show("Logout success!", "Notice")
            Form1.Show()

            'Closing All Forms Except Login Form
            My.Application.OpenForms.Cast(Of Form)().Except({Form1}).ToList().
            ForEach(Sub(form) form.Close())
        End If
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        'pressing "enter" matik click search button
        If Asc(e.KeyChar) = 13 Then
            btnSearch.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SerialPort2.PortName = "Com3"
        SerialPort2.Open()

        Timer1.Interval = 1000
        Timer1.Enabled = True

        openCon()

        userhistory = "SELECT * FROM user_history ORDER BY datetime_log DESC"

        Dim myhadapter As New MySqlDataAdapter(userhistory, con)
        Dim myhistorytable As New DataTable
        myhadapter.Fill(myhistorytable)
        DataGrid2.DataSource = myhistorytable

        con.Close()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        SerialPort2.Write("@register#")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ReadSerial As String
        Dim Rfidverify As String
        Dim Verify As String
        If SerialPort2.BytesToRead > 0 Then

            ReadSerial = SerialPort2.ReadExisting

            If ReadSerial.Contains("Register") Then
                lblRfidserial.Text = ReadSerial.Substring(10)
            ElseIf ReadSerial.Contains("login:") Then

                Rfidverify = ReadSerial.Substring(7)
                openCon()
                cmd.Connection = con
                Verify = "SELECT rfid_key FROM user_db WHERE rfid_key LIKE '%" & Rfidverify & "%' "
                cmd = New MySqlCommand(Verify, con)
                reader = cmd.ExecuteReader()

                If (reader.HasRows) Then
                    While reader.Read
                        SerialPort2.Write("@ledon#")
                        Try
                            con.Close()
                            openCon()
                            cmd.Connection = con
                            cmd = New MySqlCommand("INSERT INTO user_history (`rfid_key1`) VALUES ('" & Rfidverify & "') ", con)
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        con.Close()
                        Exit Sub
                    End While
                End If
                con.Close()

            End If
            Rfidverify = ""

        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim verify_register As String
        Dim save_rfid As String

        If (txtFullname2.Text <> "") Then

            'Check if RFID is already registered
            openCon()
            cmd.Connection = con
            verify_register = "SELECT rfid_key FROM user_db WHERE rfid_key = '" & lblRfidserial.Text & "'"
            cmd = New MySqlCommand(verify_register, con)
            reader = cmd.ExecuteReader()

            If (reader.HasRows) Then
                While reader.Read
                    MessageBox.Show("RFID key is already registered, Please try again..", "Duplicate")
                    con.Close()
                    Exit Sub
                End While
            End If
            con.Close()

            Try
                openCon()
                cmd.Connection = con
                save_rfid = "INSERT INTO user_db (`rfid_key`, `user_fullname`) VALUES ('" & lblRfidserial.Text & "','" & txtFullname2.Text & "') "
                cmd = New MySqlCommand(save_rfid, con)
                cmd.ExecuteNonQuery()
                MsgBox("Successfully added")
                con.Close()
                txtFullname2.Clear()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MsgBox("Please try again and do not leave any field blank..")
        End If
    End Sub

End Class