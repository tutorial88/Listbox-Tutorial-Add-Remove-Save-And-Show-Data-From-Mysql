Imports MySql.Data.MySqlClient
Public Class MysqlListbox
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex >= 0 Then
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Add(TextBox1.Text)
        TextBox1.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListSave()
    End Sub

    Sub ListSave()
        Dim i As Integer
        Dim Query As String
        Dim CMD As New MySqlCommand

        Try
            If OpenDB() Then
                Query = "delete from listbox"
                CMD = New MySqlCommand(Query, Conn)
                CMD.ExecuteNonQuery()

                For i = 0 To ListBox1.Items.Count - 1
                    Query = "insert into listbox (country) values ('" & ListBox1.Items(i) & "')"
                    CMD = New MySqlCommand(Query, Conn)
                    CMD.ExecuteNonQuery()
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conn.Close()
        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ShowList()
    End Sub

    Sub ShowList()
        Try
            If OpenDB() Then
                Dim Query As String = "Select * from Listbox"
                Dim CMD As New MySqlCommand(Query, Conn)
                Dim DTReader As MySqlDataReader

                DTReader = CMD.ExecuteReader
                ListBox1.Items.Clear()

                While DTReader.Read
                    ListBox1.Items.Add(DTReader.GetString("country"))
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

End Class