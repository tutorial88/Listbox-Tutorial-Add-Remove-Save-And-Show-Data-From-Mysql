Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataToText()
    End Sub

    Sub DataToText()
        If OpenDB() Then
            Dim Query As String = "Select * from country limit 1"
            Dim CMD As New MySqlCommand(Query, Conn)
            Dim DTReader As MySqlDataReader

            Try
                DTReader = CMD.ExecuteReader

                If DTReader.HasRows Then
                    While DTReader.Read
                        TextBox1.Text = DTReader.GetString("cnt_name")
                    End While
                Else
                    MsgBox("Empty")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Conn.Close()
            End Try

        End If
    End Sub


End Class
