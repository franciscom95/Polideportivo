Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Reflection

Public Class BusquedaConsulta

    Public Tipo As String



    Public ID As String

    Public NomBeneficio As String
    Public Descripcion As String

    Public NomUsuario As String
    Public Pass As String
    Public TipoUsuario As String
    Public NombreCompleto As String
    Public Telefono As String


    Public NombreAlumno As String
    Public Matricula As String
    Public sexo As String
    Public edad As String



    Private Sub BusquedaConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Query As String
        Select Case Tipo
            Case "Usuarios"

                Query = "Select * From DepoUsuario"

            Case "Beneficios"
                Query = "SELECT * From admBeneficios"


            Case "Consultas"

                Query = "SElect * FROM AdmConsulta"

            Case "Alumno"
                Query = "Select * FROM RegistroAlumno"

        End Select



        Conectar()

        Try
            Dim lDataAdapter As New OleDbDataAdapter(Query, con)
            ',,,,,,,,,
            Dim lDataTable As New DataTable
            lDataAdapter.Fill(lDataTable)

            Me.DataGridView1.DataSource = lDataTable

            Me.DataGridView1.ReadOnly = True
            Me.DataGridView1.SelectionMode = DataGridView1.SelectionMode.FullRowSelect


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        con.Close()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click



        If (DataGridView1.CurrentRow.Selected = False) Then

            MessageBox.Show("Selecciona un registro")
            Return
        End If




        Dim row As DataGridViewRow

        row = DataGridView1.CurrentRow


        Try
            Conectar()

            Dim Query As String
            Select Case Tipo
                Case "Usuarios"
                    Query = "SELECT * FROM DepoUsuario Where ID=@ID"



                Case "Beneficios"

                    Query = "SELECT * From admBeneficios where ID=@ID"


                Case "Consultas"

                    Query = "SElect * FROM AdmConsulta where Id=@ID"


                Case "Alumno"
                    Query = "Select * FROM RegistroAlumno where Id=@ID"


            End Select

            'Todo llevan ID siempre 
            Dim PrepararInsert As New OleDbCommand(Query, con)
            PrepararInsert.Parameters.AddWithValue("@ID", row.Cells("ID").Value.ToString())
            'Necesito un datareader para cada caso 




            Dim reader As OleDbDataReader = PrepararInsert.ExecuteReader()
            If reader.HasRows Then
                Do While reader.Read()

                    ID = reader(0).ToString()

                    Select Case Tipo
                        Case "Usuarios"
                            NomUsuario = reader(1).ToString()
                            Pass = reader(2).ToString()
                            TipoUsuario = reader(3).ToString()
                            NombreCompleto = reader(4).ToString()
                            Telefono = reader(5).ToString()
                        Case "Beneficios"
                            NomBeneficio = reader(1).ToString()
                            Descripcion = reader(2).ToString()

                        Case "Consultas"

                        Case "Alumno"

                            NombreAlumno = reader(1).ToString()
                            Matricula = reader(2).ToString()
                            sexo = reader(3).ToString()
                            edad = reader(4).ToString()

                    End Select



                Loop
            Else
                MessageBox.Show("No se encontro información")
            End If
            reader.Close()








        Catch ex As Exception
            MessageBox.Show("No Corrio" + ex.ToString())
        End Try
        con.Close()


        Select Case Tipo
            Case "Usuarios"
                Dim frm As New RegistrarUsuario()

                frm.txtNombreCompleto.Text = NombreCompleto
                frm.TxtUsuario.Text = NomUsuario
                frm.txttel.Text = Telefono
                frm.ComboBox1.SelectedItem = TipoUsuario
                frm.modo = "Modificar"
                frm.enviar.Text = "Actualizar"
                frm._id = ID
                frm.Show()

            Case "Beneficios"
                Dim frm As New AdmBeneficios()
                frm.txtNombre.Text = NomBeneficio
                frm.txtDescripción.Text = Descripcion
                frm.modo = "Modificar"
                frm.Enviar.Text = "Actualizar"
                frm._id = ID
                frm.Show()

            Case "Consultas"

            Case "Alumno"

                Dim frm As New AltaDeAlumno()

                frm.TxtNombre.Text = NombreAlumno
                frm.txtMatricula.Text = Matricula
                frm.txtEdad.Text = edad
                frm.cmbSexo.SelectedItem = sexo
                frm.modo = "Modificar"
                frm._id = ID
                frm.enviar.Text = "Actuaizar Registro"
                frm.Show()

        End Select


    End Sub
End Class