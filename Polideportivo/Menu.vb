Public Class Menu

    Public TipoUsuario As String



    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim frm As New AltaDeAlumno()
        frm.Show()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim frm As New RegistrarUsuario()
        frm.Show()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim frm As New AdmBeneficios()
        frm.Show()
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim frm As New RegistrarAlumno()

        frm.Modo = "RegistrarConsulta"
        frm.TUsuario = TipoUsuario

        frm.Show()
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim frm As New BusquedaConsulta()

        frm.Tipo = "Alumno"

        frm.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim frm As New BusquedaConsulta()

        frm.Tipo = "Usuarios"

        frm.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim frm As New BusquedaConsulta()

        frm.Tipo = "Beneficios"

        frm.Show()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim frm As New BusquedaConsulta()

        frm.Tipo = "Consultas"

        frm.Show()
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Dim frm As New AltaBeneficioAlumno()


        frm.Show()
    End Sub
End Class