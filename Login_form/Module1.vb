Imports MySql.Data.MySqlClient

Module Module1
    Public con As New MySqlConnection
    Public cmd As New MySqlCommand
    Public datatable As DataTable
    Public dbread As MySqlDataReader
    Public reader As MySqlDataReader


    Sub openCon()

        con.ConnectionString = "server=localhost;username=root;password=;database=doorlock"
        con.Open()

    End Sub

End Module
