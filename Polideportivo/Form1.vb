Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TxtPass_TextChanged(sender As Object, e As EventArgs) Handles TxtPass.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        Conectar()

        con.Close()

        Dim frm As New Menu()

        frm.TipoUsuario = "TipoUsuario"

        frm.Show()


    End Sub
End Class
