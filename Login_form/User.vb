Imports MySql.Data.MySqlClient
Imports System.IO
Imports Sytem.IO.Ports

Public Class User
    Public username1 As String = Form1.username

    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SerialPort1.PortName = "Com3"
        SerialPort1.Open()

        Timer1.Interval = 1000
        Timer1.Enabled = True

        openCon()
        Dim status As MySqlCommand = New MySqlCommand("SELECT * FROM user_db WHERE user_username = '" & username1 & "' ", con)
        Dim confirmds As New DataSet
        Dim confirmda As New MySqlDataAdapter
        confirmda.SelectCommand = status
        confirmda.Fill(confirmds, "entry")
        Dim myDataTableCurr As New DataTable
        Try
            confirmda.Fill(myDataTableCurr)
            If myDataTableCurr.Rows.Count > 0 Then
                lblUser_id.Text = myDataTableCurr.Rows(0).Item("user_id")
                lblRfidkey.Text = myDataTableCurr.Rows(0).Item("rfid_key")
                lblFullname.Text = myDataTableCurr.Rows(0).Item("user_fullname")
                lblAddress.Text = myDataTableCurr.Rows(0).Item("user_address")
                lblGender.Text = myDataTableCurr.Rows(0).Item("user_gender")
                lblFullname1.Text = myDataTableCurr.Rows(0).Item("user_fullname")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        con.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ReadSerial As String
        Dim Rfidverify As String
        Dim Verify As String

        If SerialPort1.BytesToRead > 0 Then

            ReadSerial = SerialPort1.ReadExisting

            If ReadSerial.Contains("LEDON") Then
                lblStatus.Text = "OPEN"

            ElseIf ReadSerial.Contains("LEDOFF") Then
                lblStatus.Text = "CLOSED"

            ElseIf ReadSerial.Contains("login:") Then

                Rfidverify = ReadSerial.Substring(7)
                openCon()
                cmd.Connection = con
                Verify = "SELECT rfid_key FROM user_db WHERE rfid_key LIKE '%" & Rfidverify & "%' "
                cmd = New MySqlCommand(Verify, con)
                reader = cmd.ExecuteReader()

                If (reader.HasRows) Then
                    While reader.Read
                        SerialPort1.Write("@ledon#")
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


    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        SerialPort1.Write("@ledon#")
        Dim historyon As String

        openCon()
        Try
            cmd.Connection = con
            historyon = "INSERT INTO user_history (`user_id`) VALUES ('" & lblUser_id.Text & "') "
            cmd = New MySqlCommand(historyon, con)
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnViewhistory_Click(sender As Object, e As EventArgs) Handles btnViewhistory.Click
        Dim userhistory As String
        openCon()

        userhistory = "SELECT user_db.user_fullname, user_db.user_id, user_history.datetime_log, user_db.rfid_key FROM user_history
                        JOIN user_db ON user_db.user_id = user_history.user_id WHERE user_db.user_id = '" & lblUser_id.Text & "' "

        Dim myadapter As New MySqlDataAdapter(userhistory, con)
        Dim mydatatable As New DataTable
        myadapter.Fill(mydatatable)
        DataGrid1.DataSource = mydatatable

        con.Close()
    End Sub
End Class