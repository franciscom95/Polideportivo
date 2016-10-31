Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization

Public Class RegistrarUsuario
    Public modo As String
    Public _id As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles enviar.Click
        Try
            Conectar()
            Dim NomUsuario As String
            Dim userlogin As String
            Dim TipoUsuario As String
            Dim Contrasena As String

            Dim telefono As String

            NomUsuario = txtNombreCompleto.Text
            userlogin = TxtUsuario.Text
            TipoUsuario = ComboBox1.Text
            Contrasena = TxtContrasena.Text

            telefono = txttel.Text



            If (modo = "Modificar") Then


                Dim PrepararInsert As New OleDbCommand("update  DepoUsuario set NomUsuario=@NomUsuario,Pass =@Pass ,TipoUsuario=@TipoUsuario,NombreCompleto=@NombreCompleto,TelefonoUsuario=@TelefonoUsuario where Id=" + _id, con)

                PrepararInsert.Parameters.AddWithValue("@NomUsuario", NomUsuario)
                PrepararInsert.Parameters.AddWithValue("@Pass", Contrasena)
                PrepararInsert.Parameters.AddWithValue("@TipoUsuario", TipoUsuario)
                PrepararInsert.Parameters.AddWithValue("@NombreCompleto", userlogin)
                PrepararInsert.Parameters.AddWithValue("@TelefonoUsuario", telefono)
                PrepararInsert.ExecuteNonQuery()
                MessageBox.Show("Se Actualizo el  registro correctamente")
                Me.Dispose()
            Else

                Dim PrepararInsert As New OleDbCommand("insert into DepoUsuario (NomUsuario,Pass,TipoUsuario,NombreCompleto,TelefonoUsuario) values (@NomUsuario,@Pass,@TipoUsuario,@NombreCompleto,@TelefonoUsuario)", con)
                PrepararInsert.Parameters.AddWithValue("@NomUsuario", NomUsuario)
                PrepararInsert.Parameters.AddWithValue("@Pass", Contrasena)
                PrepararInsert.Parameters.AddWithValue("@TipoUsuario", TipoUsuario)
                PrepararInsert.Parameters.AddWithValue("@NombreCompleto", userlogin)
                PrepararInsert.Parameters.AddWithValue("@TelefonoUsuario", telefono)
                PrepararInsert.ExecuteNonQuery()

                txtNombreCompleto.Clear()
                TxtUsuario.Clear()

                TxtContrasena.ClearUndo()

                txttel.ClearUndo()

                MessageBox.Show("Se registro correctamente")

                Dim result As Integer = MessageBox.Show("Desea capturar otro registro ", "caption", MessageBoxButtons.YesNo
                                                          )
                If result = DialogResult.Yes Then

                ElseIf result = DialogResult.No Then

                    Me.Dispose()
                End If
            End If





        Catch ex As Exception

        End Try
        con.Close()

    End Sub

    Private Sub RegistrarUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class