Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Public Class AdmBeneficios
    Public modo As String
    Public _id As String

    Private Sub Enviar_Click(sender As Object, e As EventArgs) Handles Enviar.Click

        Try

            Conectar()
            Dim NomBeneficio As String
            Dim Desc As String

            NomBeneficio = txtNombre.Text
            Desc = txtDescripción.Text
            If (modo = "Modificar") Then
                Dim PrepararInsert As New OleDbCommand("update  admBeneficios set NomBeneficio=@NomUsuario,Descripcon =@Pass  where Id=" + _id, con)

                PrepararInsert.Parameters.AddWithValue("@Nom", NomBeneficio)
                PrepararInsert.Parameters.AddWithValue("@Des", Desc)
                PrepararInsert.ExecuteNonQuery()
                MessageBox.Show("Se Actualizo el  registro correctamente")
                Me.Dispose()

            Else


                Dim PrepararInsert As New OleDbCommand("insert into admBeneficios (NomBeneficio,Descripcon) values (@Nom,@Des)", con)
                PrepararInsert.Parameters.AddWithValue("@Nom", NomBeneficio)
                PrepararInsert.Parameters.AddWithValue("@Des", Desc)
                PrepararInsert.ExecuteNonQuery()

                txtNombre.Clear()
                txtDescripción.Clear()

                MessageBox.Show("Se registro correctamente")

                Dim result As Integer = MessageBox.Show("Desea capturar otro registro ", "caption", MessageBoxButtons.YesNo
                                                        )
                If result = DialogResult.Yes Then

                ElseIf result = DialogResult.No Then

                    Me.Dispose()
                End If
            End If






        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        con.Close()
    End Sub
End Class