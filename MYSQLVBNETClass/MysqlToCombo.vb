Imports MySql.Data.MySqlClient
Public Class MysqlToCombo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataToCOmbo()
    End Sub
    Sub DataToCOmbo()
        If OpenDB() Then

            Try
                Dim Query As String = "Select * from Country"
                Dim CMD As New MySqlCommand(Query, Conn)
                Dim DTreader As MySqlDataReader

                DTreader = CMD.ExecuteReader
                ComboBox1.Items.Clear()
                If DTreader.HasRows Then
                    MsgBox("Ada")
                    While DTreader.Read
                        ComboBox1.Items.Add(DTreader.GetString(1))
                    End While
                Else
                    MsgBox("Tidak Ada")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Conn.Close()
            End Try
        End If
    End Sub


End Class