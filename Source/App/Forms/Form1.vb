Imports System.Data.SQLite
Imports MySql.Data.MySqlClient

Public Class Form1

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub

  Private Sub SQLiteTest()
    Dim connectionString As String = "Data Source=D:/Geneology/Data/Ancestry-20230831.rmtree;"
    Dim connection As New SQLiteConnection(connectionString)

    connection.Open()
    Dim query As String = "SELECT Name FROM PlaceTable"
    Dim command As New SQLiteCommand(query, connection)

    Dim reader As SQLiteDataReader = command.ExecuteReader()

    While reader.Read()
      ' Access data using reader
      Debug.Print(reader("Name").ToString())

      ' Process data here
    End While

    reader.Close()
    connection.Close()

  End Sub

  Private Sub MySQLTest()
    Dim connectionString As String = "Server=eleanor0001;Database=geneology;User=root;Password=3l3an0rAI!;"
    Dim connection2 As New MySqlConnection(connectionString)

    connection2.Open()
    Dim query2 As String = "SELECT * FROM rmPlace"
    Dim command2 As New MySqlCommand(query2, connection2)

    Dim reader2 As MySqlDataReader = command2.ExecuteReader()

    While reader2.Read()
      ' Access data using reader
      Debug.Print(reader2("Name").ToString())

      ' Process data here
    End While

    reader2.Close()
    connection2.Close()

  End Sub

End Class