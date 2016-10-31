Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization

Public Class AltaDeAlumno
    Public modo As String
    Public _id As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles enviar.Click
        Try

            Conectar()
            Dim NomAlumno As String
            Dim Matricula As String
            Dim Sexo As String
            Dim Edad As String

            NomAlumno = TxtNombre.Text
            Matricula = txtMatricula.Text
            Sexo = cmbSexo.Text
            Edad = txtEdad.Text


            If (modo = "Modificar") Then
                Dim PrepararInsert As New OleDbCommand("update  RegistroAlumno set Matricula=@Matricula,NombreAlumno =@NombreAlumno ,sexo=@Sexo,edad=@Edad where Id=" + _id, con)
                '  PrepararInsert.Parameters.AddWithValue("@ID", _id)
                PrepararInsert.Parameters.AddWithValue("@Matricula", Matricula)
                PrepararInsert.Parameters.AddWithValue("@NombreAlumno", NomAlumno)
                PrepararInsert.Parameters.AddWithValue("@Sexo", Sexo)
                PrepararInsert.Parameters.AddWithValue("@Edad", Edad)
                PrepararInsert.ExecuteNonQuery()
                MessageBox.Show("Se Actualizo el  registro correctamente")
                Me.Dispose()



            Else

                Dim PrepararInsert As New OleDbCommand("insert into RegistroAlumno(Matricula,NombreAlumno,sexo,edad)   values (@Matricula,@NombreAlumno,@Sexo,@Edad)", con)

                PrepararInsert.Parameters.AddWithValue("@Matricula", Matricula)
                PrepararInsert.Parameters.AddWithValue("@NombreAlumno", NomAlumno)
                PrepararInsert.Parameters.AddWithValue("@Sexo", Sexo)
                PrepararInsert.Parameters.AddWithValue("@Edad", Edad)

                PrepararInsert.ExecuteNonQuery()

                TxtNombre.Clear()
                txtMatricula.Clear()
                cmbSexo.Text = ""
                txtEdad.Clear()

                MessageBox.Show("Se registro correctamente")
                Dim result As Integer = MessageBox.Show("Desea capturar otro registro ", "caption", MessageBoxButtons.YesNo
                                                   )
                If result = DialogResult.Yes Then

                ElseIf result = DialogResult.No Then

                    Me.Dispose()
                End If
                End
            End If



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()
    End Sub
End Class