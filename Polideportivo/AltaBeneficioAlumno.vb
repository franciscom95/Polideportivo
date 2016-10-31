Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Reflection
Public Class AltaBeneficioAlumno
    Public ID As Integer
    Public NombreAlumno As String
    Public Matricula As String
    Public sexo As String
    Public edad As String
    Public NOMBREDELDELEDADO As String

    Public MyTextBox As New TextBox()

    Private Sub AltaBeneficioAlumno_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Alumnos As New AutoCompleteStringCollection()
        Try
            Conectar()
            Dim Query As String
            Query = "Select * FROM RegistroAlumno "

            Dim PrepararInsert As New OleDbCommand(Query, con)
            Dim reader As OleDbDataReader = PrepararInsert.ExecuteReader()
            If reader.HasRows Then
                Do While reader.Read()

                    ID = reader(0).ToString()
                    NombreAlumno = reader(1).ToString()
                    Matricula = reader(2).ToString()
                    sexo = reader(3).ToString()
                    edad = reader(4).ToString()

                    Alumnos.Add(NombreAlumno.ToString())

                Loop
            Else
                MessageBox.Show("No se encontro información")
            End If
            reader.Close()


            Dim MyCommand As OleDb.OleDbCommand
            Dim MyAdapter As New OleDb.OleDbDataAdapter
            MyCommand = con.CreateCommand
            MyCommand.CommandText = "SELECT * FROM admBeneficios"
            MyAdapter.SelectCommand = MyCommand
            Dim Dt_Cliente As New DataTable
            MyAdapter.Fill(Dt_Cliente)
            ComboBox1.DataSource = Dt_Cliente
            ComboBox1.DisplayMember = "NomBeneficio"
            ComboBox1.ValueMember = "ID"


            'Dim MyTextBox As New TextBox()
            With MyTextBox
                .AutoCompleteCustomSource = Alumnos
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .Location = New Point(100, 62)
                .Width = 250
                .Visible = True

            End With

            ' Add the text box to the form.
            Me.Controls.Add(MyTextBox)

            ' AddHandler MyTextBox.TextChanged, AddressOf Cambio



        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

        con.Close()





    End Sub

    'Private Sub Cambio(sender As Object, e As EventArgs)

    '    NOMBREDELDELEDADO = e.ToString()



    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




        Try
            Conectar()

            Dim ID As Integer

            Dim ObtenerIDMatricula As New OleDbCommand("SELECT ID FROM RegistroAlumno where NombreAlumno = @Nombre", con)
            ObtenerIDMatricula.Parameters.AddWithValue("@Nombre", MyTextBox.Text)
            'Buscar la matricula primero 
            ID = Convert.ToInt32(ObtenerIDMatricula.ExecuteScalar())






            'Buscar si existe ya el beneficio con esa matricula 
            Dim Beneficio As New Integer

            Dim ObtenerExistencias As New OleDbCommand("SELECT count(IdAlumno) FROM BeneficioAlumno where IdAlumno = @idalumno and IdBeneficio =@beneficio", con)
            ObtenerExistencias.Parameters.AddWithValue("@idalumno", ID)
            ObtenerExistencias.Parameters.AddWithValue("@beneficio", ComboBox1.SelectedValue)

            'Buscar la matricula primero 
            Beneficio = Convert.ToInt32(ObtenerExistencias.ExecuteScalar())

            If (Beneficio >= 1) Then
                MessageBox.Show("Ya hay un registro con este beneficio para este alumno")
            Else


                Dim PrepararInsert As New OleDbCommand("insert into BeneficioAlumno (IdAlumno,IdBeneficio) values (@idalumno,@idbeneficio)", con)
                'PrepararInsert.Parameters.AddWithValue("@matricula", NomBeneficio)
                PrepararInsert.Parameters.AddWithValue("@idalumno", ID)
                PrepararInsert.Parameters.AddWithValue("@idbeneficio", ComboBox1.SelectedValue)

                PrepararInsert.ExecuteNonQuery()



                MessageBox.Show("Se registro correctamente")
            End If





        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()





    End Sub
End Class