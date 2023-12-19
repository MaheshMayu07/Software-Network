Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status

Public Class forgotd


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim cmd As New SqlCommand("select * from reg where email='" & TextBox1.Text & "'", Conn)
        Dim ex As SqlDataReader = cmd.ExecuteReader()
        If ex.HasRows Then
            Panel2.Show()
        Else
            MsgBox("INVALID LOGIN")
        End If
    End Sub

    Private Sub forgotd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Hide()
    End Sub
    Public pkvar, ps As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        pkvar = "select password from reg where email='" & TextBox1.Text & "'"
        Dim cmd As New SqlCommand("select * from reg where sec='" & ComboBox1.SelectedItem & "'and ans='" & TextBox2.Text & "'", Conn)
        Dim ex As SqlDataReader = cmd.ExecuteReader()
        If ex.HasRows Then
            'Me.Hide()
            ex.Read()
            ps = ex(5).ToString
            MsgBox("Your Password is" & ps)

        Else
            MsgBox("INVALID QUESTION OR ANSWER")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        devlog.Show()
    End Sub
End Class