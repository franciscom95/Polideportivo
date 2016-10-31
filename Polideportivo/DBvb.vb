Imports System.Data
Imports System.Data.OleDb


Module funcionese
    Public con As New OleDbConnection


    Public Sub Conectar()

        Dim cadena As String
        cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Francisco\\Downloads\\Polideportivo\\Polideportivo\docs\\Proyecto.accdb"

        con.ConnectionString = cadena
        con.Open()
    End Sub
    'LLenado del combo box'

End Module