Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization

Public Class RegistrarAlumno

    Public Modo As String
    Public TUsuario As String


    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles lblpadecimiento.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Conectar()

            Dim peso As String
            Dim Estatura As String
            Dim EnfermedadCronica As String
            Dim medicamentosControlados As String
            Dim alergias As String
            Dim asisteTerapia As String
            Dim PAdecimientoActual As String
            Dim Evaluacion As String
            Dim Deporte As String



            peso = TxtPeso.Text
            Estatura = TxtEstatura.Text
            EnfermedadCronica = TxtEnfermedad.Text
            medicamentosControlados = TxtMedicamentosControlados.Text
            alergias = TxtAlergias.Text
            asisteTerapia = cmbAsiste.Text
            PAdecimientoActual = TxtPadecimeintoActual.Text
            Evaluacion = TxtEvaluacion.Text
            Deporte = cmbDeporte.Text






            Dim PrepararInsert As New OleDbCommand("insert into AdmAlumno(Peso,Estatura,Deporte,Enfermedad,Alergías,PadecimientoActual,EsTerapia,MedicamentosControlados,Evaluacion)   values (@Peso,@Estatura,@Deporte,@Enfermedad,@Alergías,@PadecimientoActual,@EsTerapia,@MedicamentosControlados,@Evaluacion)", con)
            ',,,,,,,,,

            PrepararInsert.Parameters.AddWithValue("@Peso", peso)
            PrepararInsert.Parameters.AddWithValue("@Estatura", Estatura)
            PrepararInsert.Parameters.AddWithValue("@Deporte", Deporte)
            PrepararInsert.Parameters.AddWithValue("@Enfermedad", EnfermedadCronica)
            PrepararInsert.Parameters.AddWithValue("@Alergías", alergias)
            PrepararInsert.Parameters.AddWithValue("@PadecimientoActual", PAdecimientoActual)
            PrepararInsert.Parameters.AddWithValue("@EsTerapia", asisteTerapia)
            PrepararInsert.Parameters.AddWithValue("@MedicamentosControlados", medicamentosControlados)
            PrepararInsert.Parameters.AddWithValue("@Evaluacion", Evaluacion)

            PrepararInsert.ExecuteNonQuery()

            TxtNombre.Clear()
            txtMatricula.Clear()

            txtEdad.Clear()
            TxtPeso.Clear()
            TxtEstatura.Clear()
            TxtEnfermedad.Clear()
            TxtMedicamentosControlados.Clear()
            TxtAlergias.Clear()

            TxtPadecimeintoActual.Clear()
            TxtEvaluacion.Clear()


            MessageBox.Show("Se registro correctamente")

        Catch ex As Exception

        End Try
        con.Close()
    End Sub

    Private Sub RegistrarAlumno_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Select Case TUsuario
            Case "Psicologo"
                lblpadecimiento.Text = "Motivo de Consulta"
                lblValoacion.Visible = False
                TextBox1.Visible = False
                lblenfermedadc.Visible = False
                TxtEnfermedad.Visible = False
                lblalergia.Visible = False
                TxtAlergias.Visible = False


            Case "Nutriologo"
                lblpadecimiento.Visible = False
                TxtPadecimeintoActual.Visible = False
                lbleval.Visible = False
                TxtEvaluacion.Visible = False
                lblalergia.Visible = False
                TxtAlergias.Visible = False
                lblAsisteTerapia.Visible = False
                cmbAsiste.Visible = False
                LblMedicamentos.Visible = False
                TxtMedicamentosControlados.Visible = False
                lblenfermedadc.Visible = False
                TxtEnfermedad.Visible = False


            Case "Medico"
                lblValoacion.Visible = False
                TextBox1.Visible = False
                cmbAsiste.Visible = False
                LblMedicamentos.Visible = False
                TxtMedicamentosControlados.Visible = False


        End Select



    End Sub

    Private Sub lblalergia_Click(sender As Object, e As EventArgs) Handles lblalergia.Click

    End Sub
End Class