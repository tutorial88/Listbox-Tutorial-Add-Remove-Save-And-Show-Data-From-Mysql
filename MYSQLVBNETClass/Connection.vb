Imports MySql.Data.MySqlClient
Module Connection
    Public Conn As New MySqlConnection
    Dim Result As Boolean
    Dim StrConn As String
    Public Function OpenDB() As Boolean
        Try
            If Conn.State = ConnectionState.Closed Then
                StrConn = "server=localhost;user=root;password=;port=3306;database=tutorial88_vbnet;sslmode=none"
                Conn.ConnectionString = StrConn
                Conn.Open()
                Result = True
            End If
        Catch ex As Exception
            Result = False
        End Try

        Return Result
    End Function
End Module
